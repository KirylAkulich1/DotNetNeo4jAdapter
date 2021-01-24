using System;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace Node4jAdapter
{
    static public class ObjectConverter
    {
        static public string GetObjectRef(this string obj)
        {
            return null;
        }

        public static string ConvertObject(object obj)
        {
            int hashCode = obj.GetHashCode();
            string objectRef = $"object{hashCode}";
            PropertyInfo[] propertyInfos = obj.GetType().GetProperties();
            StringBuilder serializedObject = new StringBuilder(objectRef);
            foreach (var property in propertyInfos)
            {
                if (property.GetType() == typeof(string) || property.GetType().GetProperties().Length == 0)
                    serializedObject.Append($"{property.Name}:{property.GetValue(obj)},");
                else
                {
                    string internalObject = ConvertObject(property.GetValue(obj));

                }

                return "";
            }

            return null;
        }
    }
}