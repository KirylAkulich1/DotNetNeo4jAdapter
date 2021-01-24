using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Neo4j.Driver;

namespace Node4jAdapter
{
    public static class Neo4jDb
    {
        private static StringBuilder _query=new StringBuilder();

        private static IDriver _driver =
            GraphDatabase.Driver("bolt://localhost:7687", AuthTokens.Basic("neo4j", "test"));

        public static Boolean Create(IModel obj)
        {
            _query.Append($"({ obj.ToString() }),\n");
            return true;
        }

        public static Boolean Create(IEnumerable<IModel> objs)
        {
            foreach (var obj in objs)
            {
                Create(obj);
            }

            return true;
        }

        public static void Execute()
        {
            using (var session=_driver.Session())
            {
                var greeting = session.WriteTransaction(tx =>
                {
                    var result = tx.Run(_query.ToString());
                    return result.Single()[0].As<string>();
                });
                Console.WriteLine(greeting);
            }
            _query.Clear();
        }
    }
}