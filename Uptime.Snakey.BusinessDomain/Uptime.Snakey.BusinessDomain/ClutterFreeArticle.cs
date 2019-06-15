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
		[JsonProperty(PropertyName = "content")]
		public string Description { get; set; }
		[JsonProperty(PropertyName = "url")]
		public string Link { get; set; }
		public string Category { get; set; }
		public string Author { get; set; }
		[JsonProperty(PropertyName = "lead_image_url")]
		public string ImageUrl { get; set; }
		[JsonProperty(PropertyName = "date_published")]
		public string PublishedDate { get; set; }
	}
}
