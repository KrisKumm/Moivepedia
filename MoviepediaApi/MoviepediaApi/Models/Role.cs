using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MoviepediaApi.Models
{
	public class Role
	{
		public Actor actor { get; set; }
		public Movie movie { get; set; }
		public Series series { get; set; }
		public String role { get; set; }
	}
}