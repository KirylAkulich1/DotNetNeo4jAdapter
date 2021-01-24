using System.Reflection;
using Newtonsoft.Json;

namespace Node4jAdapter
{
    public class Node<T>
    {
        private readonly string _name;
        private readonly string _jsonObject;
        
        public Node(T obj)
        {
            _name = $"id{obj.GetHashCode()}";
            //PropertyInfo[] propertyInfos = obj.GetType().GetProperties();
            _jsonObject = JsonConvert.SerializeObject(obj);
            
        }
        
        
    }
}