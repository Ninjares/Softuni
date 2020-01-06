namespace DeprecatedClass
{
    using System.Reflection;

    public class PrivateObject
    {
        private object Object;
        public PrivateObject(object obj)
        {
            Object = obj;
        }

        public object Invoke(string methodName, params object[] parameters)
        {
            MethodInfo eatMethod = Object.GetType().GetMethod(methodName ,BindingFlags.Instance|BindingFlags.Public|BindingFlags.NonPublic);
            return eatMethod.Invoke(Object, parameters);
        }
    }
}
