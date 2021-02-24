using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    class Spy
    {
        public string StealFieldInfo(string className, params string[] fields)
        {
            Type classType = Type.GetType(className);
           
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public);

            StringBuilder sb = new StringBuilder();

            object classInstance = Activator.CreateInstance(classType, new object[] { });

            sb.AppendLine($"Class under investigation: {className}");

            foreach (var item in classFields.Where(x => fields.Contains(x.Name)))
            {
                sb.AppendLine($"{item.Name} = {item.GetValue(classInstance)}");
            }

            return sb.ToString().Trim();
        }

        public string AnalyzeAcessModifiers(string className)
        {
            Type classType = Type.GetType(className);
            FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance 
                | BindingFlags.Static | BindingFlags.Public);

            MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Instance 
                | BindingFlags.Public);

            MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.Instance 
                | BindingFlags.NonPublic);

            StringBuilder sb = new StringBuilder();

            foreach (var item in classFields)
            {
                sb.AppendLine($"{item.Name} must be private!");
            }
            foreach (var item in classNonPublicMethods.Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{item.Name} have to be public!");
            }
            foreach (var item in classPublicMethods.Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{item.Name} have to be private!");
            }

            return sb.ToString().Trim();
        }

        public string RevealPrivateMethods(string className)
        {
            Type classType = Type.GetType(className);
            MethodInfo[] classMethods = classType.GetMethods(BindingFlags.Instance 
                | BindingFlags.NonPublic);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"All private methods of Class: {className}");
            sb.AppendLine($"Base Class: {classType.BaseType.Name}");

            foreach (var item in classMethods)
            {
                sb.AppendLine(item.Name);
            }

            return sb.ToString().Trim();
        }
    }
}
