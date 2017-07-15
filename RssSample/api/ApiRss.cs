using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace RssSample.api
{
    public class ApiRss
    {
        private static string URL = "https://news.yahoo.co.jp/pickup/rss.xml";
        public ApiRss()
        {
        }

        public static async Task<dynamic> GetDataFromServiceOfXml() {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(URL);
            if (response == null) {
                return null;
            }
            int statusCode = (int)response.StatusCode;
            if (statusCode >= 400) {
                return null;
            }
            string result = response.Content.ReadAsStringAsync().Result;
            dynamic data = result;
            return data;
        }

        public static async Task<dynamic> Get() {
            dynamic result = GetDataFromServiceOfXml();
            return result;
        }
    }
}
