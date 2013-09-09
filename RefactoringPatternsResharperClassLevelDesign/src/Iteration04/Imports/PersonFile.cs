using Iteration04.Model;

namespace Iteration04.Imports
{
    public class PersonFile : DelimitedFile<Person>
    {
        public PersonFile()
        {
            Path = "InputFiles\\People.txt";
            TimeStampFormat = "M/d/yyyy";
            Delimiter = '|';
            HasHeaderLine = true;

            Column(x => x.Name);
            Column(x => x.Birthday);
            Column(x => x.Email);
            Column(x => x.Hobbies);
        }
    }
}