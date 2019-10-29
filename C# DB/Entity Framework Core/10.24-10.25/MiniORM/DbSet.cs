namespace MiniORM
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class DbSet<TEntity> : ICollection<TEntity> where TEntity: class, new()
    {
        public DbSet(IEnumerable<TEntity> entities)
        {
            this.Entities = entities.ToList();
            ChangeTracker = new ChangeTracker<TEntity>(entities);
        }
        public void Add(TEntity item)
        {
            if (item == null) throw new ArgumentNullException();
            Entities.Add(item);
            ChangeTracker.Add(item);
        }
        public void Clear()
        {
            while (Entities.Any())
            {
                var entity = this.Entities.First();
                this.Remove(entity);
            }
        }

        public bool Remove(TEntity item)
        {
            if (item == null) throw new ArgumentNullException(nameof(item), "Item cannot be null");
            bool removedSuccesfully = this.Entities.Remove(item);
            if (removedSuccesfully)
            {
                ChangeTracker.Remove(item);
            }
            return removedSuccesfully;
        }

        public bool Contains(TEntity item) => Entities.Contains(item);
        public void CopyTo(TEntity[] array, int arrayIndex) => Entities.CopyTo(array, arrayIndex);
        
        public int Count => Entities.Count;
        public bool IsReadOnly => Entities.IsReadOnly;
        internal ChangeTracker<TEntity> ChangeTracker { get; set; }
        internal IList<TEntity> Entities { get; set; }

        public IEnumerator<TEntity> GetEnumerator() => Entities.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();
    }
}