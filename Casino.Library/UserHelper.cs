using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Casino.Library.Models;
using Newtonsoft.Json;

namespace DotnetBlog.Library
{
    public class UserHelper
    {
        public UserHelper()
        {
			
        }

		public static async Task<List<User>> GetUsers()
		{
			var client = new HttpClient();

			var result = await client.GetAsync("http://localhost:5000/api/article");

			if(result.IsSuccessStatusCode)
			{
				return JsonConvert.DeserializeObject<List<User>>(await result.Content.ReadAsStringAsync());
			}
			else
			{
				return null;
			}
		}
    }
}
