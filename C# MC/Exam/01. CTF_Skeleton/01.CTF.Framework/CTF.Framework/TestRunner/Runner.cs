namespace CTF.Framework.TestRunner
{
    using CTF.Framework.Exceptions;
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Runner
    {
        private readonly StringBuilder stringBuilder;

        public Runner()
        {
            this.stringBuilder = new StringBuilder();
        }

        public string Run(string assemblyPath)
        {

            var types = Assembly.LoadFrom(assemblyPath).GetTypes()
             .Where(x => x.CustomAttributes.Any(a => a.AttributeType.Name == "CTFTestClassAttribute")).ToArray();
                ;
            foreach(var type in types)
            {
                var invocation = Activator.CreateInstance(type);
                foreach(var method in type.GetMethods().Where(x => x.CustomAttributes.Any(a => a.AttributeType.Name == "CTFTestMethodAttribute")))
                {
                    try
                    {
                        method.Invoke(invocation, null);
                        stringBuilder.AppendLine($"Class: {type.Name} Method: {method.Name} - passed!");
                    }
                    catch(ApplicationException)
                    {
                        stringBuilder.AppendLine($"Class: {type.Name} Method: {method.Name} - failed!");
                    }
                    catch(Exception)
                    {
                        stringBuilder.AppendLine($"Unexpected error occurred in {method.Name}!");
                    }
                    
                }
            }
            return stringBuilder.ToString();
        }
    }
}
