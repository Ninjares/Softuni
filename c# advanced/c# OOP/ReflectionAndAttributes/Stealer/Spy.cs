using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Linq;

namespace Stealer
{
    class Spy
    {
        public string StealFieldInfo(string klass, params string[] fields)
        {
            Type klas = Type.GetType("Stealer." + klass);
            FieldInfo[] classfields = klas.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Class under investigation: {klass}");

            Object activator = Activator.CreateInstance(klas, new object[] { });
            foreach (var field in classfields.Where(x => fields.Contains(x.Name)))
            {
                sb.AppendLine($"{field.Name} = {field.GetValue(activator)}");
            }
            return sb.ToString().Trim();
        }

        public string GetAccessModifiers(string klass)
        {
            StringBuilder sb = new StringBuilder();

            Type classtype = Type.GetType(klass);
            FieldInfo[] classFields = classtype.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);
            MethodInfo[] classPublicMethods = classtype.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            MethodInfo[] classNonPublicMethods = classtype.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach(FieldInfo field in classFields)
            {
                sb.AppendLine($"{field.Name} must be private  ({field.Attributes})");
            }
            foreach (MethodInfo method in classNonPublicMethods.Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} must be public  ({method.Attributes})");
            }
            foreach (MethodInfo method in classPublicMethods.Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} must be private  ({method.Attributes})");
            }
            return sb.ToString().Trim();
        }

        public string RevealPrivateMethods(string klass)
        {
            StringBuilder sb = new StringBuilder();

            Type classtype = Type.GetType(klass);
            MethodInfo[] classmethods = classtype.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

            sb.AppendLine($"Private methods of class: {klass}");
            sb.AppendLine($"Base class: {classtype.BaseType.Name}");
            foreach(MethodInfo method in classmethods)
            {
                sb.AppendLine(method.Name);
            }
            return sb.ToString().Trim();
        }

        public string GettersAndSetters(string klass)
        {
            StringBuilder sb = new StringBuilder();

            Type classtype = Type.GetType(klass);
            MethodInfo[] classmethods = classtype.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic|BindingFlags.Public);

            foreach(MethodInfo method in classmethods.Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} --- {method.ReturnType}");
            }
            foreach (MethodInfo method in classmethods.Where(x => x.Name.StartsWith("set")))
            {
                sb.AppendLine($"{method.Name} --- {method.GetParameters().First().ParameterType}");
            }

            return sb.ToString().Trim();
        }
    }
}
