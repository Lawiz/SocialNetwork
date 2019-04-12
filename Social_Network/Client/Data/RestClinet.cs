using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BLL.Domain.Models;
using Newtonsoft.Json;

namespace Client.Data
{
    public interface IRestService
    {
        Task<List<Article>> RefreshDataAsync();

        Task SaveArticleAsync(Article item, bool isNewItem);

        Task DeleteArticleAsync(string id);
    }
    public class RestClinet : IRestService
    {
        HttpClient client;
        public List<Article> Items { get; private set; }
        public RestClinet()
        {
            client = new HttpClient();
        }
        public async Task<List<Article>> RefreshDataAsync()
        {
            Items = new List<Article>();
            
                var uri = new Uri(string.Format(Constants.RestUrl, Constants.apiArticles));

                try
                {
                    var response = await client.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();
                        Items = JsonConvert.DeserializeObject<List<Article>>(content);
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(@"ERROR {0}", ex.Message);
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
