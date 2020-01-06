namespace CTF.Framework.Asserts
{
    using System.Reflection;
    using System;
    using CTF.Framework.Exceptions;

    // ReSharper disable once InconsistentNaming
    public abstract class CTFAssert
    {
        public static void AreEqual(object a, object b)
        {
            if (a.GetType() == b.GetType())
            {
                if (Object.Equals(a, b)) { }
                else
                    throw new TestException();
            }
            else throw new TestException();
        }

        public static void AreNotEqual(object a, object b)
        {
            if (a.GetType() == b.GetType())
            {
                if (Object.Equals(a, b)) 
                    throw new TestException();
            }
        }

        public static void Throws<T>(Func<bool> condition) where T: Exception
        {
            condition.Invoke();
        }
    }
}


//if (a.GetType() == b.GetType())
//            {
//                bool allPropertiesAndFieldsEqual = true;
//var propertyInfo = a.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
//                foreach (PropertyInfo property in propertyInfo)
//                {
//                    if (a.GetType().GetProperty(property.Name).GetValue(a) != b.GetType().GetProperty(property.Name).GetValue(b))
//                    {
//                        allPropertiesAndFieldsEqual = false;
//                        break;
//                    }
//                }
//                var fieldInfo = a.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
//                if(allPropertiesAndFieldsEqual)
//                foreach (FieldInfo field in fieldInfo)
//                {
//                    if (a.GetType().GetField(field.Name).GetValue(a) != b.GetType().GetField(field.Name).GetValue(b))
//                    {
//                        allPropertiesAndFieldsEqual = false;
//                        break;
//                    }
//                }
//                if (allPropertiesAndFieldsEqual) throw new TestException();
//            }