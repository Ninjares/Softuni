using System;
using System.Collections.Generic;
using System.Text;

namespace DefiningClasses
{
    class Family
    {
        public List<Person> people = new List<Person>();

        public void AddMember(Person add)
        {
            people.Add(add);
        }

        public Person GetOldestMember()
        {
            int oldestposition = 0;
            int oldestage = people[0].Age;
            for(int i=0; i<people.Count; i++) if(oldestage<people[i].Age) { oldestage = people[i].Age; oldestposition = i; }
            return people[oldestposition];
        }
    }
}
