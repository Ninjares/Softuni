using System.Reflection;
using ValidationAttributes.Attributes;
using System.Linq;
namespace ValidationAttributes
{
    public static class Validator
    {
        public static bool IsValid(object obj)
        {
            PropertyInfo[] propertyInfos = obj.GetType().GetProperties();
            foreach(var property in propertyInfos)
            {
                MyValidationAttribute[] attributes = property
                    .GetCustomAttributes()
                    .Where(a => a is MyValidationAttribute)
                    .Cast<MyValidationAttribute>()
                    .ToArray();

                foreach(MyValidationAttribute validationAttribute in attributes)
                {
                    if (!validationAttribute.IsValid(property.GetValue(obj))) return false;
                }
            }
            return true;
        }
    }
}
