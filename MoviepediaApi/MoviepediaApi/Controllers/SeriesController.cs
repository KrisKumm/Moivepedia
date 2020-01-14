﻿using System;
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
    public class SeriesController : ApiController
    {
		public List<Series> GetSeriesLike(string seriesTitle)
		{
			var client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "edukacija");
			client.Connect();

			string title = ".*" + seriesTitle + ".*";

			Dictionary<string, object> queryDict = new Dictionary<string, object>();
			queryDict.Add("seriesTitle", title);


			var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) match (n:Series) where exists(n.title) and n.title =~ {seriesTitle} return n",
															queryDict, CypherResultMode.Set);

			List<Series> series = ((IRawGraphClient)client).ExecuteGetCypherResults<Series>(query).ToList();

			return series.ToList();
		}

		public Series GetSeries(string sTitle)
		{
			var client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "edukacija");
			client.Connect();

			string title = sTitle;

			Dictionary<string, object> queryDict = new Dictionary<string, object>();
			queryDict.Add("seriesTitle", title);


			var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) match (n:Series) where exists(n.title) and n.title =~ {seriesTitle} return n",
															queryDict, CypherResultMode.Set);

			List<Series> series = ((IRawGraphClient)client).ExecuteGetCypherResults<Series>(query).ToList();

			return series.ToList().First();
		}

		public List<Series> GetSeriesFromDirector(string directorName)
		{
			var client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "edukacija");
			client.Connect();

			string name = ".*" + directorName + ".*";

			Dictionary<string, object> queryDict = new Dictionary<string, object>();
			queryDict.Add("directorName", name);


			var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) match (n)-[r:DIRECTED]->(m:Series) where exists(n.name) and n.name =~ {directorName} return m",
															queryDict, CypherResultMode.Set);

			List<Series> series = ((IRawGraphClient)client).ExecuteGetCypherResults<Series>(query).ToList();

			return series.ToList();
		}

		public List<Series> GetSeriesFromProducent(string producentName)
		{
			var client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "edukacija");
			client.Connect();

			string name = ".*" + producentName + ".*";

			Dictionary<string, object> queryDict = new Dictionary<string, object>();
			queryDict.Add("producentName", name);


			var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) match (n)-[r:PRODUCED]->(m:Series) where exists(n.name) and n.name =~ {producentName} return m",
															queryDict, CypherResultMode.Set);

			List<Series> series = ((IRawGraphClient)client).ExecuteGetCypherResults<Series>(query).ToList();

			return series.ToList();
		}

		public List<Series> GetSeriesFromWriter(string writerName)
		{
			var client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "edukacija");
			client.Connect();

			string name = ".*" + writerName + ".*";

			Dictionary<string, object> queryDict = new Dictionary<string, object>();
			queryDict.Add("writerName", name);


			var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) match (n)-[r:WROTE]->(m:Series) where exists(n.name) and n.name =~ {writerName} return m",
															queryDict, CypherResultMode.Set);

			List<Series> series = ((IRawGraphClient)client).ExecuteGetCypherResults<Series>(query).ToList();

			return series.ToList();
		}

		public List<Series> GetSeriesFromActor(string actorName)
		{
			var client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "edukacija");
			client.Connect();

			string name = ".*" + actorName + ".*";

			Dictionary<string, object> queryDict = new Dictionary<string, object>();
			queryDict.Add("actorName", name);


			var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) match (n)-[r:ACTED_IN]->(m:Series) where exists(n.name) and n.name =~ {actorName} return m",
															queryDict, CypherResultMode.Set);

			List<Series> series = ((IRawGraphClient)client).ExecuteGetCypherResults<Series>(query).ToList();

			return series.ToList();
		}

        [HttpPost]
		public void addSeries([FromBody] Series s)
		{
			var client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "edukacija");
			client.Connect();

			Dictionary<string, object> queryDict = new Dictionary<string, object>();
			queryDict.Add("title", s.title);
			queryDict.Add("released", s.released);
			queryDict.Add("genre", s.genre);
            queryDict.Add("tagline", s.tagline);
            queryDict.Add("picture", s.picture);

            var query = new Neo4jClient.Cypher.CypherQuery("MERGE (n:Series {title:'" + s.title
															+ "', released:'" + s.released + "', genre:'" + s.genre
															+ "', tagline:'" + s.tagline
															+ "', picture:'" + s.picture + "'}) return n",
															queryDict, CypherResultMode.Set);

            ((IRawGraphClient)client).ExecuteCypher(query);

		}

        [HttpPut]
        public void updateSeries([FromBody] Series s)
        {
            var client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "edukacija");
            client.Connect();

            Dictionary<string, object> queryDict = new Dictionary<string, object>();
            queryDict.Add("title", s.title);
            queryDict.Add("released", s.released);
            queryDict.Add("genre", s.genre);
            queryDict.Add("tagline", s.tagline);
            queryDict.Add("picture", s.picture);
            queryDict.Add("rate", s.rate);

            var query = new Neo4jClient.Cypher.CypherQuery("MERGE (n:Series {title:'" + s.title
                                                            + "'}) ON MATCH SET n.rate=~{rate} return n",
                                                            queryDict, CypherResultMode.Set);

            ((IRawGraphClient)client).ExecuteCypher(query);

        }

        public string deleteSeries(string title)
		{
			var client = new GraphClient(new Uri("http://localhost:7474/db/data"), "neo4j", "edukacija");
			client.Connect();

			string seriesTitle = title;

			Dictionary<string, object> queryDict = new Dictionary<string, object>();
			queryDict.Add("seriesTitle", seriesTitle);

			var query = new Neo4jClient.Cypher.CypherQuery("start n=node(*) where (n:Series) and exists(n.title) and n.title =~ {seriesTitle} delete n",
															queryDict, CypherResultMode.Projection);

			((IRawGraphClient)client).ExecuteCypher(query);

			return "Series deleted.";

		}
	}
}
