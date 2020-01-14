using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MoviepediaApi.Models;
using Neo4jClient;
using Neo4jClient.Cypher;
using MoviepediaApi;


namespace MoviepediaApi.Controllers
{
	public class ActorController : ApiController
	{
		public List<Actor> GetActorsLike(String name)
		{
			var client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "edukacija");
			client.Connect();

			string actorName = ".*" + name + ".*";

			Dictionary<string, object> queryDict = new Dictionary<string, object>();
			queryDict.Add("actorName", actorName);

			var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) where (n:Person) and exists(n.name) and n.name =~ {actorName} return n",
															queryDict, CypherResultMode.Set);

			List<Actor> actors = ((IRawGraphClient)client).ExecuteGetCypherResults<Actor>(query).ToList();

			return actors.ToList();
		}

		public Actor GetActor(String actorName)
		{
			var client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "edukacija");
			client.Connect();

			string aName = actorName;

			Dictionary<string, object> queryDict = new Dictionary<string, object>();
			queryDict.Add("actorName", aName);

			var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) where (n:Person) and exists(n.name) and n.name =~ {actorName} return n",
															queryDict, CypherResultMode.Set);

			List<Actor> actors = ((IRawGraphClient)client).ExecuteGetCypherResults<Actor>(query).ToList();

			return actors.ToList().First();
		}

		public List<Actor> GetActorsFromMovie(string movieTitle)
		{
			var client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "edukacija");
			client.Connect();

			string movieName = ".*" + movieTitle + ".*";

			Dictionary<string, object> queryDict = new Dictionary<string, object>();
			queryDict.Add("movieName", movieName);

			var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) match (n:Movie)<-[r:ACTED_IN]-(a) where exists(n.title) and n.title =~ {movieName} return a",
															queryDict, CypherResultMode.Set);

			List<Actor> actors = ((IRawGraphClient)client).ExecuteGetCypherResults<Actor>(query).ToList();

			return actors.ToList();
		}

		public List<Actor> GetActorsFromSeries(string seriesTitle)
		{
			var client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "edukacija");
			client.Connect();

			string seriesName = ".*" + seriesTitle + ".*";

			Dictionary<string, object> queryDict = new Dictionary<string, object>();
			queryDict.Add("seriesName", seriesName);

			var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) match (n:Series)<-[r:ACTED_IN]-(a) where exists(n.title) and n.title =~ {seriesName} return a",
															queryDict, CypherResultMode.Set);

			List<Actor> actors = ((IRawGraphClient)client).ExecuteGetCypherResults<Actor>(query).ToList();

			return actors.ToList();
		}

		public List<Actor> GetActorsFromMovieOrSeries(string movieOrSeriesTitle)
		{
			var client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "edukacija");
			client.Connect();

			string movieOrSeriesName = ".*" + movieOrSeriesTitle + ".*";

			Dictionary<string, object> queryDict = new Dictionary<string, object>();
			queryDict.Add("movieOrSeriesName", movieOrSeriesName);

			var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) match (n)<-[r:ACTED_IN]-(a) where exists(n.title) and n.title =~ {movieOrSeriesName} return a",
															queryDict, CypherResultMode.Set);

			List<Actor> actors = ((IRawGraphClient)client).ExecuteGetCypherResults<Actor>(query).ToList();

			return actors.ToList();
		}

		public List<Actor> GetActorsFromDirectorMovie(string directorNameMovie)
		{
			var client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "edukacija");
			client.Connect();

			string directorName = ".*" + directorNameMovie + ".*";

			Dictionary<string, object> queryDict = new Dictionary<string, object>();
			queryDict.Add("directorName", directorName);

			var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) match (n)-[r:DIRECTED]->(m:Movie)<-[r1:ACTED_IN]-(a) where exists(n.name) and n.name =~ {directorName} return a",
															queryDict, CypherResultMode.Set);

			List<Actor> actors = ((IRawGraphClient)client).ExecuteGetCypherResults<Actor>(query).ToList();

			return actors.ToList();
		}

		public List<Actor> GetActorsFromDirectorSeries(string directorNameSeries)
		{
			var client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "edukacija");
			client.Connect();

			string directorName = ".*" + directorNameSeries + ".*";

			Dictionary<string, object> queryDict = new Dictionary<string, object>();
			queryDict.Add("directorName", directorName);

			var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) match (n)-[r:DIRECTED]->(m:Series)<-[r1:ACTED_IN]-(a) where exists(n.name) and n.name =~ {directorName} return a",
															queryDict, CypherResultMode.Set);

			List<Actor> actors = ((IRawGraphClient)client).ExecuteGetCypherResults<Actor>(query).ToList();

			return actors.ToList();
		}

		public List<Actor> GetActorsFromDirectorMovieOrSeries(string directorNameMovieOrSeries)
		{
			var client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "edukacija");
			client.Connect();

			string directorName = ".*" + directorNameMovieOrSeries + ".*";

			Dictionary<string, object> queryDict = new Dictionary<string, object>();
			queryDict.Add("directorName", directorName);

			var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) match (n)-[r:DIRECTED]->(m)<-[r1:ACTED_IN]-(a) where exists(n.name) and n.name =~ {directorName} return a",
															queryDict, CypherResultMode.Set);

			List<Actor> actors = ((IRawGraphClient)client).ExecuteGetCypherResults<Actor>(query).ToList();

			return actors.ToList();
		}

		public List<Actor> GetActorsFromProducentMovie(string producentNameMovie)
		{
			var client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "edukacija");
			client.Connect();

			string producentName = ".*" + producentNameMovie + ".*";

			Dictionary<string, object> queryDict = new Dictionary<string, object>();
			queryDict.Add("producentName", producentName);

			var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) match (n)-[r:PRODUCED]->(m:Movie)<-[r1:ACTED_IN]-(a) where exists(n.name) and n.name =~ {producentName} return a",
															queryDict, CypherResultMode.Set);

			List<Actor> actors = ((IRawGraphClient)client).ExecuteGetCypherResults<Actor>(query).ToList();

			return actors.ToList();
		}

		public List<Actor> GetActorsFromProducentSeries(string producentNameSeries)
		{
			var client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "edukacija");
			client.Connect();

			string producentName = ".*" + producentNameSeries + ".*";

			Dictionary<string, object> queryDict = new Dictionary<string, object>();
			queryDict.Add("producentName", producentName);

			var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) match (n)-[r:PRODUCED]->(m:Series)<-[r1:ACTED_IN]-(a) where exists(n.name) and n.name =~ {producentName} return a",
															queryDict, CypherResultMode.Set);

			List<Actor> actors = ((IRawGraphClient)client).ExecuteGetCypherResults<Actor>(query).ToList();

			return actors.ToList();
		}

		public List<Actor> GetActorsFromProducentMovieOrSeries(string producentNameMovieOrSeries)
		{
			var client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "edukacija");
			client.Connect();

			string producentName = ".*" + producentNameMovieOrSeries + ".*";

			Dictionary<string, object> queryDict = new Dictionary<string, object>();
			queryDict.Add("producentName", producentName);

			var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) match (n)-[r:PRODUCED]->(m)<-[r1:ACTED_IN]-(a) where exists(n.name) and n.name =~ {producentName} return a",
															queryDict, CypherResultMode.Set);

			List<Actor> actors = ((IRawGraphClient)client).ExecuteGetCypherResults<Actor>(query).ToList();

			return actors.ToList();
		}

		public List<Actor> GetActorsFromWriterMovie(string writerNameMovie)
		{
			var client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "edukacija");
			client.Connect();

			string writerName = ".*" + writerNameMovie + ".*";

			Dictionary<string, object> queryDict = new Dictionary<string, object>();
			queryDict.Add("writerName", writerName);

			var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) match (n)-[r:WROTE]->(m:Movie)<-[r1:ACTED_IN]-(a) where exists(n.name) and n.name =~ {writerName} return a",
															queryDict, CypherResultMode.Set);

			List<Actor> actors = ((IRawGraphClient)client).ExecuteGetCypherResults<Actor>(query).ToList();

			return actors.ToList();
		}

		public List<Actor> GetActorsFromWriterSeries(string writerNameSeries)
		{
			var client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "edukacija");
			client.Connect();

			string writerName = ".*" + writerNameSeries + ".*";

			Dictionary<string, object> queryDict = new Dictionary<string, object>();
			queryDict.Add("writerName", writerName);

			var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) match (n)-[r:WROTE]->(m:Series)<-[r1:ACTED_IN]-(a) where exists(n.name) and n.name =~ {writerName} return a",
															queryDict, CypherResultMode.Set);

			List<Actor> actors = ((IRawGraphClient)client).ExecuteGetCypherResults<Actor>(query).ToList();

			return actors.ToList();
		}

		public List<Actor> GetActorsFromWriterMovieOrSeries(string writerNameMovieOrSeries)
		{
			var client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "edukacija");
			client.Connect();

			string writerName = ".*" + writerNameMovieOrSeries + ".*";

			Dictionary<string, object> queryDict = new Dictionary<string, object>();
			queryDict.Add("writerName", writerName);

			var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) match (n)-[r:WROTE]->(m)<-[r1:ACTED_IN]-(a) where exists(n.name) and n.name =~ {writerName} return a",
															queryDict, CypherResultMode.Set);

			List<Actor> actors = ((IRawGraphClient)client).ExecuteGetCypherResults<Actor>(query).ToList();

			return actors.ToList();
		}

        [HttpPost]
		public List<Actor> addActor([FromBody] Actor a)
		{
			var client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "edukacija");
			client.Connect();

			Dictionary<string, object> queryDict = new Dictionary<string, object>();
			queryDict.Add("name", a.name);
			queryDict.Add("born", a.born);
			queryDict.Add("birthplace", a.birthplace);
            queryDict.Add("biography", a.biography);
            queryDict.Add("picture", a.picture);

            var query = new Neo4jClient.Cypher.CypherQuery("MERGE (n:Person {name:'" + a.name
															+ "', born:'" + a.born + "', birthplace:'" + a.birthplace
															+ "', biography:'" + a.biography
															+ "', picture:'" + a.picture + "'}) return n",
															queryDict, CypherResultMode.Set);

			List<Actor> actors = ((IRawGraphClient)client).ExecuteGetCypherResults<Actor>(query).ToList();

			return actors.ToList();

		}

		public string deleteActor(string name)
		{
			var client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "edukacija");
			client.Connect();

			string actorName = name;

			Dictionary<string, object> queryDict = new Dictionary<string, object>();
			queryDict.Add("actorName", actorName);

			var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) where (n:Person) and exists(n.name) and n.name =~ {actorName} delete n",
															queryDict, CypherResultMode.Projection);

            ((IRawGraphClient)client).ExecuteCypher(query);

			return "Actor deleted.";

		}

        public void createActedIn(string actorIme, string movieTitle, string role)
        {
            var client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "edukacija");
            client.Connect();

            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("actorName", actorIme);
            queryDict.Add("movieTitle", movieTitle);
            queryDict.Add("role", role);

            var query = new Neo4jClient.Cypher.CypherQuery("match (m:Movie) where exists(m.title) and m.title=~{movieTitle} match (p:Person) where exists(p.name) and p.name=~{actorName} create (p)-[:ACTED_IN {roles:{role}}]->(m)",
                                                            queryDict, CypherResultMode.Projection);

            ((IRawGraphClient)client).ExecuteCypher(query);
        }
	}
}
