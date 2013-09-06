using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Iteration01.Model;

namespace Iteration01.Importers
{
    public class PersonImporter
    {
        public Person[] Read(string path)
        {
            List<Person> people = new List<Person>();

            var lines = File.ReadAllLines(path);

            foreach (var line in lines.Skip(1))
            {
                var fields = line.Split('|');

                Person person = new Person();

                person.Name = fields[0];
                person.Birthday = DateTime.ParseExact(fields[1], "M/d/yyyy", CultureInfo.InvariantCulture);
                person.Email = fields[2];
                person.Hobbies = fields[3];

                people.Add(person);
            }

            return people.ToArray();
        }
    }
}
