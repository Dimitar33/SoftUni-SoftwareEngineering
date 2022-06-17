using System.Reflection;

namespace Task_1._Reflection_investigation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var type = typeof(int);

            var ass = Assembly.GetAssembly(type);

            foreach (var assTypes in ass.GetTypes())
            {
                Console.WriteLine($"Assembly Type: {assTypes.Name}");
                Console.WriteLine();

                foreach (var field in assTypes.GetFields())
                {
                    Console.WriteLine($"Field Name: {field.Name}, Field Type: {field.FieldType}");
                }

                Console.WriteLine();

                foreach (var prop in assTypes.GetProperties())
                {
                    Console.WriteLine($"Property Name: {prop.Name}, Property Type: {prop.PropertyType}");
                }

                Console.WriteLine();

                foreach (var ctor in assTypes.GetConstructors())
                {
                    Console.WriteLine($"Constructor Type: {ctor.DeclaringType}");

                    foreach (var p in ctor.GetParameters())
                    {
                        Console.WriteLine($"Constructor Parameter Type: {p.ParameterType}");
                    }
                }

                Console.WriteLine();

                foreach (var metod in assTypes.GetMethods())
                {
                    Console.WriteLine($"Method name: {metod.Name}, Method return type: {metod.ReturnType}");

                    foreach (var p in metod.GetParameters())
                    {
                        Console.WriteLine($"Method parameter type: {p.ParameterType}");
                    }
                }

                Console.WriteLine();

                foreach (var member in assTypes.GetMembers())
                {
                    if (!(member.MemberType is MemberTypes.Method) &&
                        !(member.MemberType is MemberTypes.Property) &&
                        !(member.MemberType is MemberTypes.Field) &&
                        !(member.MemberType is MemberTypes.Constructor))
                    {

                        Console.WriteLine($"Member Name: {member.Name}, Member Decraring Type: {member.DeclaringType}, Member Type: {member.MemberType}");
                    }
                }

                Console.WriteLine("--------------------");
            }
        }
    }
}