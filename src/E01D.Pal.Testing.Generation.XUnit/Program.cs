using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Root.Code.Attributes.E01D;
using Root.Testing.Code.Containers.E01D.Runtimic.Execution.Emitting.Conversion;

namespace Root
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = typeof(ILConversionTestContainer).Assembly;

            var types = assembly.GetTypes();

            foreach (var type in types)
            {
                List<MethodInfo> methods;

                if ((methods = GetTestMethods(type)) != null && methods.Count > 0)
                {
                    WriteXUnitTest(type, methods);
                }




            }
        }

        private static void WriteXUnitTest(Type type, List<MethodInfo> methods)
        {
            StringBuilder methodText = new StringBuilder();

            foreach (var method in methods)
            {
                WriteMethod(methodText, type, method);
            }

            var className = type.FullName.Replace(".", "_") + "_XUnit";

            var classText = template.Replace("XUNIT_CLASSNAME", className);

            classText = classText.Replace("XUNITCODE", methodText.ToString());

            string fileName = @"C:\Dev\e01d\EvolvingGit\src\E01D.Pal.Testing.XUnit\" + className + ".cs";

            System.IO.File.WriteAllText(fileName, classText);
        }

        private static void WriteMethod(StringBuilder methodText, Type type, MethodInfo method)
        {
            methodText.AppendLine("        [Fact]");
            methodText.AppendLine("        [Generated]");
            methodText.AppendLine($"        public void {method.Name}()");
            methodText.AppendLine("        {");
            methodText.AppendLine($"            {type.FullName} tests = new {type.FullName}();");
            methodText.AppendLine("            ");
            methodText.AppendLine($"            tests.{method.Name}();");
            methodText.AppendLine("        }");
            methodText.AppendLine();
        }

        private static List<MethodInfo> GetTestMethods(Type type)
        {
            List<MethodInfo> result = new List<MethodInfo>();

            var methods = type.GetMethods();

            foreach (var method in methods)
            {
                var attributes = method.GetCustomAttributes(typeof(TestAttribute), false);

                if (attributes != null && attributes.Length > 0)
                {
                    result.Add(method);
                }
            }

            return result;


        }

        private static string template = @"
using Root.Code.Attributes.E01D;
using Xunit;

namespace Root
{
    [Generated]
    public class XUNIT_CLASSNAME
    {
XUNITCODE
    }
}
";
    }
}
