using System.IO;
using System.Runtime.CompilerServices;

namespace FixieDemo
{
    public static class TextWriterExtensions
    {
        public static void WhereAmI(this TextWriter console, [CallerMemberName] string member = null)
        {
            console.WriteLine(member);
        }
    }
}