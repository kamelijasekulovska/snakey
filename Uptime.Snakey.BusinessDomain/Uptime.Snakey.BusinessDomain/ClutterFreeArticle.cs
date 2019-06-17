using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Uptime.Snakey.BusinessDomain
{
    public class ClutterFreeArticle
    {
		public string Title { get; set; }
		[JsonProperty(PropertyName = "Content")]
		public string Description { get; set; }
		[JsonProperty(PropertyName = "Url")]
		public string Link { get; set; }
		public string Category { get; set; }
		public string Author { get; set; }
		[JsonProperty(PropertyName = "Lead_image_url")]
		public string ImageUrl { get; set; }
		[JsonProperty(PropertyName = "Date_published")]
		public string PublishedDate { get; set; }
	}
}
