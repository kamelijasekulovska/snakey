using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Uptime.Snakey.BusinessDomain
{
    public class ClutterFreeArticle
    {
		//TODO
		public string Title { get; set; }
		public string Description { get; set; }
		public string Link { get; set; }
		public string Category { get; set; }
		public string Author { get; set; }
		[JsonProperty(PropertyName = "date_published")]
		public string PublishedDate { get; set; }
	}
}
