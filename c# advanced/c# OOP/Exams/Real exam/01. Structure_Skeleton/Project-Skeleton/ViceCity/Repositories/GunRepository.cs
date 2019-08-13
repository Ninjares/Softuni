using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViceCity.Models.Guns.Contracts;
using ViceCity.Repositories.Contracts;

namespace ViceCity.Repositories
{
    public class GunRepository:IRepository<IGun>
    {
        private readonly List<IGun> guns = new List<IGun>();

        public IReadOnlyCollection<IGun> Models => guns.AsReadOnly();

        public void Add(IGun model)
        {
            if(!guns.Contains(model))
            guns.Add(model);
        }

        public IGun Find(string name)
        {
            return guns.FirstOrDefault(x => x.Name == name);
        }

        public bool Remove(IGun model)
        {
            if (guns.Contains(model))
                return guns.Remove(model);
            else return false;
        }
    }
}
