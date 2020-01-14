using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviepediaApi.Models
{
	public class Series
	{
		//public String id { get; set; }
		public String title { get; set; }
		public String released { get; set; }
		public String genre { get; set; }
		public String tagline { get; set; }
        public String picture { get; set; }
        public int rate { get; set; }

        public List<Role> cast { get; set; }
	}
}