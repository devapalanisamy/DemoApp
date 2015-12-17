using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace DemoApp.Core
{
		public class RestService : IRestService
		{
			HttpClient client;

			public List<Qualification> Items { get; private set; }

			public RestService ()
			{
				client = new HttpClient ();
				//client.MaxResponseContentBufferSize = 256000;
			}

			public async Task<List<Qualification>> RefreshDataAsync ()
			{
				Items = new List<Qualification> ();

			const string RestUrl = "https://api.gojimo.net/api/v4/qualifications";
				var uri = new Uri (string.Format (RestUrl, string.Empty));

				try {
					var response = await client.GetAsync (uri);
					if (response.IsSuccessStatusCode) {
						var content = await response.Content.ReadAsStringAsync ();
					Items = JsonConvert.DeserializeObject <List<Qualification>> (content);
					}
				} catch (Exception ex) {
					Debug.WriteLine (@"ERROR {0}", ex.Message);
				}

				return Items;
			}
				
				
		}
}

