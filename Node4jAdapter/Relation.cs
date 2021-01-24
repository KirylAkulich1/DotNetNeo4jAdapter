using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Node4jAdapter
{
    public class Relation<F,T> : IModel
    {
        private readonly string _name;
        private readonly string _attrs = null;
        private  Node<F> _from;
        private  Node<T> _to;

        public Relation(F from = default , string relationName= "", object relationAttrs=null, T to=default)
        {
            _from = new Node<F>(from);
            _to = new Node<T>(to);
            _name = relationName;
            if (relationAttrs != null)
            {
               _attrs = JsonConvert.SerializeObject(relationAttrs);
            } 
        }

        public override string ToString()
        {
            return $"({_from.GetNodeId()})-[:{_name} {_attrs}]->({_to.GetNodeId()})";
        }
    }
}