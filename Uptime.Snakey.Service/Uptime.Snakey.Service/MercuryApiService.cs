using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using Uptime.Snakey.BusinessDomain;
using Uptime.Snakey.Service.Interfaces;

namespace Uptime.Snakey.Service
{
    public class MercuryApiService : IMercuryApiService
    {
        public ClutterFreeArticle GetCleanArticleFrom(string url)
        {
			var httpPostRequest = (HttpWebRequest)WebRequest.Create("https://uptime-mercury-api.azurewebsites.net/webparser");
			httpPostRequest.ContentType = "application/json";

			httpPostRequest.Method = "POST";

			var jsonObjectToSend = JsonConvert.SerializeObject(new { url = url });
			using (var streamWriter = new StreamWriter(httpPostRequest.GetRequestStream()))
			{
				var json = jsonObjectToSend;
				streamWriter.Write(json);
				streamWriter.Flush();
				streamWriter.Close();
			}

			HttpWebResponse httpResponse = (HttpWebResponse)httpPostRequest.GetResponse();


			var stringResult = "";
			using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
			{
				stringResult = streamReader.ReadToEnd();
			}

			ClutterFreeArticle deserialize = JsonConvert.DeserializeObject<ClutterFreeArticle>(stringResult, new JsonSerializerSettings
			{
				MissingMemberHandling = MissingMemberHandling.Ignore,
				NullValueHandling = NullValueHandling.Ignore,
				DateFormatString = "dd/MM/yyyy"
			});


			return deserialize;
		}
    }
}
