using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using MyHabr.Data;
using Xamarin.Forms;

using MyHabr.Models;
using MyHabr.Models.BLL.Domain.Models;
using MyHabr.Views;

namespace MyHabr.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        public ObservableCollection<Article> Items { get; set; }
        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel()
        {
            Title = "Browse";
            Items = new ObservableCollection<Article>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<NewItemPage, Article>(this, "AddItem", async (obj, item) =>
            {
                var newItem = item as Article;
                Items.Add(newItem);
                await DataStore.AddItemAsync(newItem);
            });
        }
        Database db = new Database(Constants.ConnectionString);
        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();
                //var items = DataStore.GetItemsAsync(true).Result;
                var items = db.GetItemsAsync().Result;
                foreach (var item in items)
                {
                    Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}