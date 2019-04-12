using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using MyHabr.Models.BLL.Domain.Models;
using Newtonsoft.Json;

namespace MyHabr.Data
{
    public interface IRestService
    {
        Task<List<Article>> RefreshDataAsync(int id=0);

        Task SaveArticleAsync(Article item, bool isNewItem);

        Task DeleteArticleAsync(string id);
    }
    public class RestClinet : IRestService
    {
        HttpClient client;
        public List<Article> Items { get; private set; }

        public async Task<List<Article>> RefreshDataAsync(int id=0)
        {
            Items = new List<Article>();
            using (client = new HttpClient())
            {
                var uri = new Uri(string.Format(Constants.RestUrl, "api/Articles"));

                try
                {
                    var response = await client.GetAsync("https://habr.azurewebsites.net/api/Articles");
                    if (response.IsSuccessStatusCode)
                    {
                        var content  = await response.Content.ReadAsStringAsync();
                        Items = JsonConvert.DeserializeObject<List<Article>>(content);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(@"ERROR {0}", ex.Message);
                }
            }

            return Items;
        }

        public async Task SaveArticleAsync(Article item, bool isNewItem = false)
        {
            var uri = new Uri(string.Format(Constants.RestUrl, string.Empty));

            try
            {
                var json = JsonConvert.SerializeObject(item);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = null;
                if (isNewItem)
                {
                    response = await client.PostAsync(uri, content);
                }
                else
                {
                    response = await client.PutAsync(uri, content);
                }

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"Article successfully saved.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }
        }

        public async Task DeleteArticleAsync(string id)
        {
            // RestUrl = http://developer.xamarin.com:8081/api/Articles/{0}
            var uri = new Uri(string.Format(Constants.RestUrl, id));

            try
            {
                var response = await client.DeleteAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    Debug.WriteLine(@"Article successfully deleted.");
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"ERROR {0}", ex.Message);
            }
        }
    }
}
