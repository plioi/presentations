using System.IO;
using System.Runtime.CompilerServices;
using DefaultArguments.Assert;

namespace DefaultArguments
{
    public class Example4__CallerInfoAttributesTests
    {
        static class Psychic
        {
            public static string WhatFileIsThis([CallerFilePath] string callerFilePath = null)
            {
                return Path.GetFileName(callerFilePath);
            }

            public static int WhatLineIsThis([CallerLineNumber] int callerLineNumber = 0)
            {
                return callerLineNumber;
            }

            public static string WhatMethodIsThis([CallerMemberName] string callerMethodName = "This cake, like this default value, is a lie.")
            {
                return callerMethodName;
            }
        }

        public void Should_know_what_file_called_it()
        {
            Psychic.WhatFileIsThis().ShouldEqual("Example4__CallerInfoAttributesTests.cs");
        }

        public void Should_know_what_method_called_it()
        {
            Psychic.WhatMethodIsThis().ShouldEqual("Should_know_what_method_called_it");
        }

        public void Should_know_what_line_number_called_it()
        {
            Psychic.WhatLineIsThis().ShouldEqual(39);
            Psychic.WhatLineIsThis().ShouldEqual(40);
            Psychic.WhatLineIsThis().ShouldEqual(41);
            Psychic.WhatLineIsThis().ShouldEqual(42);
        }
    }
}
