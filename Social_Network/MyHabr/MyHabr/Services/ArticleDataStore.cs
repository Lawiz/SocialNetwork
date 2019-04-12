using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using MyHabr.Models.BLL.Domain.Models;
using Xamarin.Forms;


namespace MyHabr.Services
{
    public class ArticleDataStore : IDataStore<Article>
    {
        IStoryService<Article> _storyService = DependencyService.Get<IStoryService<Article>>();

        public Task<bool> AddItemAsync(Article item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateItemAsync(Article item)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<Article> GetItemAsync(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Article>> GetItemsAsync(bool forceRefresh = false)
        {
            return await _storyService.GetAll();
        }
    }
}
