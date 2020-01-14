using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Neo4jClient;
using Neo4jClient.Cypher;
using MoviepediaApi.Models;

namespace MoviepediaApi.Controllers
{
    public class RoleController : ApiController
    {
		public List<Role> GetRoles(string movieTitle)
		{
			var client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "edukacija");
			client.Connect();

			string movie = movieTitle;

			Dictionary<string, object> queryDict = new Dictionary<string, object>();
			queryDict.Add("movieTitle", movie);


			var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) match (n:Person)-[r:ACTED_IN]->(m:Movie) where exists(m.title) and m.title =~ {movieTitle} return n, m, r",
															queryDict, CypherResultMode.Set);

			List<Role> roles = ((IRawGraphClient)client).ExecuteGetCypherResults<Role>(query).ToList();

			return roles.ToList();

		}
    }
}
