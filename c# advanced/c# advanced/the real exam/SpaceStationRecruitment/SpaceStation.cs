using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace SpaceStationRecruitment
{
    class SpaceStation
    {
        private  List<Astronaut> data;
        public string Name { get; set; }
        public int Capacity { get; set; }

        public SpaceStation(string name, int capacity, params Astronaut[] data)
        {
            Name = name;
            Capacity = capacity;
            this.data = new List<Astronaut>(data);
        }

        public void Add(Astronaut astronaut)
        {
            if(data.Count<Capacity)
            data.Add(astronaut);
        }
        public bool Remove(string name)
        {
            if (data.Any(x => x.Name == name))
            {
                Astronaut toremove = data.FirstOrDefault(x => x.Name == name);
                data.Remove(toremove);
                return true;
            }
            else return false;
        }
        public Astronaut GetOldestAstronaut()
        {
            return data.OrderByDescending(x => x.Age).FirstOrDefault();
        }
        public Astronaut GetAstronaut(string name)
        {
            return data.FirstOrDefault(x => x.Name == name);
        }

        public int Count { get => data.Count; }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Astronauts working at Space Station {Name}:");
            foreach (Astronaut ast in data) sb.AppendLine(ast.ToString());
            return sb.ToString().Trim();
        }
    }
}
