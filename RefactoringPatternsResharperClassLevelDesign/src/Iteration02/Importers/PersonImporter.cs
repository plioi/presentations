using System;
using System.Globalization;
using Iteration02.Model;

namespace Iteration02.Importers
{
    public class PersonImporter : DelimitedFile<Person>
    {
        public PersonImporter() : base(delimiter: '|', hasHeaderLine: true)
        {
        }

        protected override Person CreateItem(string[] fields)
        {
            return new Person
            {
                Name = fields[0],
                Birthday = DateTime.ParseExact(fields[1], "M/d/yyyy", CultureInfo.InvariantCulture),
                Email = fields[2],
                Hobbies = fields[3]
            };
        }
    }
}
