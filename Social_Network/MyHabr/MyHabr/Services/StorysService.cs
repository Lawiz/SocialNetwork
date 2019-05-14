using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using MyHabr.Data;
using MyHabr.Models.BLL.Domain.Models;
using Newtonsoft.Json;

namespace MyHabr.Services
{
    public interface IStoryService<T> where T : class
    {
        Task<IEnumerable<Article>> GetAll();
        Task<T> Get(int id);
        Task<string> Update(int id);
        Task<string> Delete(int id);
    }

    public class StorysService<T> : IStoryService<T> where T: class
    {
        //"https://habr.azurewebsites.net";
        private readonly string BaseUri = "https://habr.azurewebsites.net";

        private async Task<TResult> InvokeGetApi<TResult>(string requestUri)
        {
            using (var daemonProxyClient = new HttpClient())
            {
                daemonProxyClient.BaseAddress = new Uri(BaseUri);

                try
                {
                    var res = await daemonProxyClient.GetAsync(requestUri).ConfigureAwait(false);

                    if (res.IsSuccessStatusCode)
                        using (var responseStream = await res.Content.ReadAsStreamAsync().ConfigureAwait(false))
                        using (var reader = new StreamReader(responseStream))
                        using (var jsonReader = new JsonTextReader(reader))
                        {
                            jsonReader.SupportMultipleContent = true;
                            var serializer = new JsonSerializer();
                            var resObject = serializer.Deserialize<TResult>(jsonReader);
                            return resObject;
                        }

                    throw new Exception(res.ReasonPhrase);
                }
                catch (Exception ex)
                {

                }

                return default(TResult);
            }
        }


        public async Task<IEnumerable<Article>> GetAll()
        {
            DateTime maxDate;
            var db = new Database(Constants.ConnectionString);
            try
            {
                maxDate = db.database.Table<Article>().ToListAsync().Result.Max(s => s.CreaDateTime);
                //.QueryAsync<DateTime>($"select CreaDateTime from [Article]").Result
                //.FirstOrDefault();

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            var TESTsTRING = $"api/Articles?dateTimeFrom={maxDate}";
            var result = InvokeGetApi<IEnumerable<Article>>($"api/Articles?dateTimeFrom={maxDate}").Result;
            return result;
        }

        public Task<T> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> Update(int id)
        {
            throw new NotImplementedException();
        }

        public Task<string> Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}
