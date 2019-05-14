using System;

using MyHabr.Models;
using MyHabr.Models.BLL.Domain.Models;
using Xamarin.Forms;

namespace MyHabr.ViewModels
{
    public class ItemDetailViewModel : BaseViewModel
    {
        public Article Item { get; set; }
        public ItemDetailViewModel(Article item = null)
        {
            Title = item?.Headline;
            Item = item;
            
        }
    }
}
