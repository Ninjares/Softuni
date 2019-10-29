namespace MiniORM
{
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;
    using System.Linq;
    using System.Reflection;
    public abstract class DbContext
    {
        private readonly DatabaseConnection connection;
        private readonly Dictionary<Type, PropertyInfo> dbSetProperties;

        internal static readonly Type[] AllowedSqlTypes =
        {
            typeof(string),
            typeof(int),
            typeof(uint),
            typeof(long),
            typeof(ulong),
            typeof(decimal),
            typeof(bool),
            typeof(DateTime)
        };

        protected DbContext(string connectionString)
        {
            connection = new DatabaseConnection(connectionString);
            dbSetProperties = DiscoverDbSets();
            using(new ConnectionManager(connection))
            {
                this.InitializeDbSets();
            }
            this.MapAllRelations();
        }

        public void SaveChanges()
        {
            var dbSets = this.dbSetProperties.Select(pi => pi.Value.GetValue(this)).ToArray();
            foreach(IEnumerable<object> dbSet in dbSets)
            {
                var invalidEntities = dbSet.Where(entity => !IsValidObject(entity)).ToArray();
                if (invalidEntities.Any()) throw new InvalidOperationException($"{invalidEntities.Length} Invalid entities found in {dbSet.GetType().Name}");
            }

            using (new ConnectionManager(connection))
            {
                using (var transaction = this.connection.StartTransaction())
                {
                    foreach(IEnumerable dbSet in dbSets)
                    {
                        var dbSetType = dbSet.GetType().GetGenericArguments().First();
                        var persistMethod = typeof(DbContext)
                                            .GetMethod("Persist", BindingFlags.Instance | BindingFlags.NonPublic)
                                            .MakeGenericMethod(dbSetType);
                        try
                        {
                            persistMethod.Invoke(this, new object[] { dbSet });
                        }
                        catch(TargetInvocationException e)
                        {
                            throw e.InnerException;
                        }
                        catch(InvalidOperationException)
                        {
                            transaction.Rollback();
                            throw;
                        }
                        catch (SqlException)
                        {
                            transaction.Rollback();
                            throw; 
                        }
                    }
                    transaction.Commit();
                }
            }
        }

        private void Persist<TEntity>(DbSet<TEntity> dbSet) where TEntity : class, new()
        {
            var tableName = GetTableName(typeof(TEntity));
            var columns = connection.FetchColumnNames(tableName).ToArray();

            if (dbSet.ChangeTracker.Added.Any())
            {
                connection.InsertEntities(dbSet.ChangeTracker.Added, tableName, columns);
            }
            var modifiedEntries = dbSet.ChangeTracker.GetModifiedEntities(dbSet).ToArray();
            if (modifiedEntries.Any())
            {
                connection.UpdateEntities(modifiedEntries, tableName, columns);
            }
        }

        
    }
}