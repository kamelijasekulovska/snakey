﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using Uptime.Snakey.BusinessDomain;
using Uptime.Snakey.Service.Interfaces;

namespace Uptime.Snakey.Service
{
    public class RssFeedService : IRssFeedService
    {
        public IList<Feed> GetRssFeed()
        {
			XmlDocument rssXmlDoc = new XmlDocument();

			// Load the RSS file from the RSS URL
			rssXmlDoc.Load("https://flipboard.com/@raimoseero/feed-nii8kd0sz.rss");
			XmlNamespaceManager namespaceManager = new XmlNamespaceManager(rssXmlDoc.NameTable);
			namespaceManager.AddNamespace("media", "http://search.yahoo.com/mrss/");


			// Parse the Items in the RSS file
			XmlNodeList rssNodes = rssXmlDoc.GetElementsByTagName("item");

			List<Feed> feedList = new List<Feed>();

			foreach (XmlNode rssNode in rssNodes)
			{
				Feed item = new Feed();

				XmlNode rssSubNode = rssNode.SelectSingleNode("title");
				string title = rssSubNode != null ? rssSubNode.InnerText : "";

				rssSubNode = rssNode.SelectSingleNode("link");
				string link = rssSubNode != null ? rssSubNode.InnerText : "";

				rssSubNode = rssNode.SelectSingleNode("author");
				string author = rssSubNode != null ? rssSubNode.InnerText : "";

				rssSubNode = rssNode.SelectSingleNode("description");
				string description = rssSubNode != null ? rssSubNode.InnerText : "";

				rssSubNode = rssNode.SelectSingleNode("pubDate");
				string pubDate = rssSubNode != null ? rssSubNode.InnerText : "";

				var media = rssNode.SelectSingleNode("media:content", namespaceManager);
				string url = media != null ? media.OuterXml : "";

				item.Title = title;
				item.Link = link;
				item.Author = author;
				item.Description = description;
				item.PublishedDate = pubDate;
				item.ImageUrl = url;

				feedList.Add(item);

			}

			return feedList;
		}
    }
}
