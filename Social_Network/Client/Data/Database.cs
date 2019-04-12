using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using MyHabr.Models.BLL.Domain.Models;
using System.Threading.Tasks;

namespace Client.Data
{
    public class Database
    {
        readonly SQLiteAsyncConnection database;

        public Database(string dbPath)
        {
            database = new SQLiteAsyncConnection(Constants.ConnectionString);
        }

        public Task<List<Article>> GetItemsAsync()
        {
            return database.Table<Article>().ToListAsync();
        }

        public Task<List<Article>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Article>("SELECT * FROM [Article] WHERE [Done] = 0");
        }

        public Task<Article> GetItemAsync(int id)
        {
            return database.Table<Article>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Article item)
        {
            if (item.Id != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(Article item)
        {
            return database.DeleteAsync(item);
        }
    }
}

