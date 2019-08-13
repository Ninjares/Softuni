using MXGP.Repositories.Contracts;
using System.Collections.Generic;

namespace MXGP.Repositories
{
    public abstract class Repository<T> : IRepository<T>
    {
        protected readonly List<T> models = new List<T>();
        public void Add(T model)
        {
            models.Add(model);
        }

        public IReadOnlyCollection<T> GetAll()
        {
            return models.AsReadOnly();
        }

        public abstract T GetByName(string name);

        public bool Remove(T model)
        {
            return models.Remove(model);
        }
    }
}
