using System.Reflection;
using Newtonsoft.Json;

namespace Node4jAdapter
{
    public class Node<T> : INode,IModel
    {
        private readonly string _name;
        private readonly string _jsonObject;
        
        public Node(T obj)
        {
            _name = $"id{obj.GetHashCode()}";
            //PropertyInfo[] propertyInfos = obj.GetType().GetProperties();
            _jsonObject = JsonConvert.SerializeObject(obj);
        }

        public override string ToString()
        {
            return $"{_name}:{typeof(T).FullName} {_jsonObject}";
        }

        public string GetNodeId()
        {
            return _name;
        }
    }
}