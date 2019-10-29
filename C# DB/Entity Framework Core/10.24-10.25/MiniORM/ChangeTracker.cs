﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace MiniORM
{
	internal class ChangeTracker<T> where T: class, new() //where is a constraint of what T can be
    {
        private readonly List<T> allEntities;
        private readonly List<T> added;
        private readonly List<T> removed;

        public ChangeTracker(IEnumerable<T> entities)
        {
            this.added = new List<T>();
            this.removed = new List<T>();
            this.allEntities = CloneEntities(entities);
        }

        public IReadOnlyCollection<T> AllEntities => this.allEntities.AsReadOnly();
        public IReadOnlyCollection<T> Added => this.added.AsReadOnly();
        public IReadOnlyCollection<T> Removed => this.removed.AsReadOnly();

        public void Add(T item) => this.added.Add(item);
        public void Remove(T item) => this.removed.Add(item);
        private static List<T> CloneEntities(IEnumerable<T> entities)
        {
            var clonedEntities = new List<T>();

            PropertyInfo[] propertiesToClone = typeof(T).GetProperties()
                                                        .Where(pi => DbContext.AllowedSqlTypes.Contains(pi.GetType()))
                                                        .ToArray();
            foreach(T entity in entities)
            {
                T clonedEntity = Activator.CreateInstance<T>();
                foreach(PropertyInfo property in propertiesToClone)
                {
                    object value = property.GetValue(entity);
                    property.SetValue(clonedEntity, value);
                }
                clonedEntities.Add(clonedEntity);
            }

            return clonedEntities;
        }

        public IEnumerable<T> GetModifiedEntities(DbSet<T> dbSet)
        {
            var modifiedEntities = new List<T>();
            PropertyInfo[] primaryKeys = typeof(T).GetProperties()
                                       .Where(pi => pi.HasAttribute<KeyAttribute>())
                                       .ToArray();
            foreach(var proxyEntity in this.AllEntities)
            {
                object[] primaryKeyValues = GetPrimaryKeyValues(primaryKeys, proxyEntity).ToArray();
                var entity = dbSet.Entities.Single(e => GetPrimaryKeyValues(primaryKeys, e).SequenceEqual(primaryKeyValues));
                var isModifie = isModified(proxyEntity, entity);
                if (isModifie)
                {
                    modifiedEntities.Add(entity);
                }
            }
            return modifiedEntities;
        }

        private static bool isModified(T entity, T proxyEntity)
        {
            var monitoredProperties = typeof(T).GetProperties()
                                               .Where(pi => DbContext.AllowedSqlTypes.Contains(pi.PropertyType));
            var modifiedProperties = monitoredProperties
                                               .Where(pi => !Equals(pi.GetValue(entity), pi.GetValue(proxyEntity)))
                                               .ToArray();
            return modifiedProperties.Any();
        }

        private static IEnumerable<object> GetPrimaryKeyValues(IEnumerable<PropertyInfo> primaryKeys, T entity)
        {
            return primaryKeys.Select(pk => pk.GetValue(entity));
        }
    }
}