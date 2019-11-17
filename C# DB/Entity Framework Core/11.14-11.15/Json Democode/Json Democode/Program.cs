using System;

namespace Json_Democode
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System.Collections.Generic;

    class Program
    {
        //Javascript Object Notation - XML is old, outdated and inefficient
        //Paste Json as classes
        //strings, numbers and bool are valid for jsons
        static void Main(string[] args)
        {
            Person person = new Person() { Name = "Tashi", Age = 20 };
            string jsonObject = JsonConvert.SerializeObject(person);
            Console.WriteLine(jsonObject);
            Console.WriteLine(JsonConvert.DeserializeObject(jsonObject));
            Person newboi = JsonConvert.DeserializeObject<Person>(jsonObject);
            Console.WriteLine(newboi);

            List<Person> people = new List<Person>();
            for (int i = 1; i <= 3; i++)
                people.Add(new Person() { Name = $"Boom{i}", Age = 20 + i } );
            string peopleObject = JsonConvert.SerializeObject(people, Formatting.Indented);
            Console.WriteLine(peopleObject);
            people = JsonConvert.DeserializeObject<List<Person>>(peopleObject);

            var personTemplate = new
            {
                Name = String.Empty,
                Age = (int?)0
            };
            var anons = JsonConvert.DeserializeAnonymousType(jsonObject, personTemplate);
            JsonConvert.DeserializeObject(jsonObject, new JsonSerializerSettings() 
            {
                
            });
            var jObject = JObject.Parse(peopleObject);
            foreach(JToken token in jObject["User"])
            {

            }
            
            Console.ReadKey();

        }

        class Person
        {
            [JsonProperty("User")]
            public string Name { get; set; }
            public int Age { get; set; }
            [JsonIgnore]
            public string ID { get; set; }
        }

    }
}
