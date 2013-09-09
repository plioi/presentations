using System;
using System.Linq;
using Iteration04.DependencyResolution;
using Iteration04.Imports;
using Iteration04.Model;
using NUnit.Framework;
using Should;

namespace Iteration04.Tests
{
    [TestFixture]
    public class PersonImporterTests
    {
        [Test]
        public void ShouldReadPeopleFile()
        {
            var importer = DependencyRegistrar.Resolve<DelimitedFileImporter>();
            var people = importer.Import<Person>().ToArray();

            people.Length.ShouldEqual(2);

            people[0].Name.ShouldEqual("John Doe");
            people[0].Birthday.ShouldEqual(new DateTime(1990, 1, 2));
            people[0].Email.ShouldEqual("john@example.com");
            people[0].Hobbies.ShouldEqual("Tennis");

            people[1].Name.ShouldEqual("Jane Doe");
            people[1].Birthday.ShouldEqual(new DateTime(1991, 2, 3));
            people[1].Email.ShouldEqual("jane@example.com");
            people[1].Hobbies.ShouldEqual("Soccer Cycling");
        }
    }
}