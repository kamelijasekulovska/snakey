using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Uptime.Snakey.BusinessDomain;
using Uptime.Snakey.Service;
using Uptime.Snakey.Service.Interfaces;
using Uptime.Snakey.UI.Models;

namespace Uptime.Snakey.UI.Controllers
{
	public class GetCleanArticleRequest
	{
		public string url { get; set; }
	}

	public class SnakeyController : Controller
	{
		private IRssFeedService rssFeedService;
		private IMercuryApiService mercuryApiService;

		public SnakeyController(IRssFeedService _rssFeedService, IMercuryApiService _mercuryApiService)
		{
			rssFeedService = _rssFeedService;
			mercuryApiService = _mercuryApiService;
		}

		public IActionResult GetRssFeed()
		{
			return Content(JsonConvert.SerializeObject(rssFeedService.GetRssFeed(), Formatting.Indented,
		   new JsonSerializerSettings
		   {
			   ReferenceLoopHandling = ReferenceLoopHandling.Ignore
		   }), "application/json");
		}

		[HttpPost]
		public IActionResult GetCleanArticleFrom([FromBody] GetCleanArticleRequest url)
		{
			return Content(JsonConvert.SerializeObject(mercuryApiService.GetCleanArticleFrom(url.url), Formatting.Indented,
			   new JsonSerializerSettings
			   {
				   ReferenceLoopHandling = ReferenceLoopHandling.Ignore
			   }), "application/json");
		}

		public IActionResult Index()
		{
			//GET RssFeed from Uptime.Snakey.Service
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
