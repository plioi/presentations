using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace DefaultArguments.Assert
{
    public static class Should
    {
        public static void ShouldEqual(this object actual, object expected, [CallerFilePath] string path = "", [CallerLineNumber] int line = 0)
        {
            if (actual is int && expected is int)
                if ((int)actual == (int)expected)
                    return;

            if (actual is string && expected is string)
                if ((string)actual == (string)expected)
                    return;

            if (actual != expected)
            {
                var assertionLine = File.ReadAllLines(path)[line - 1];

                int shouldIndex = assertionLine.IndexOf(".ShouldEqual(");

                var expression = assertionLine.Substring(0, shouldIndex).Trim();

                if (expected is string)
                    expected = "\"" + (string)expected + "\"";

                if (actual is string)
                    actual = "\"" + (string)actual + "\"";

                var message = new StringBuilder();
                message.AppendLine();
                message.AppendLine();
                message.AppendFormat("    {0} should be {1} but was {2}.", expression, expected, actual);
                message.AppendLine();

                throw new Exception(message.ToString());
            }
        }
    }
}
