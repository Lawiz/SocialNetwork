using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using MyHabr.Models;
using MyHabr.Models.BLL.Domain.Models;
using MyHabr.ViewModels;

namespace MyHabr.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDetailPage : ContentPage
    {
        ItemDetailViewModel viewModel;

        public ItemDetailPage(ItemDetailViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = this.viewModel = viewModel;
        }

        public ItemDetailPage()
        {
            InitializeComponent();

            var item = new Article()
            {
                ArticleText = "Item 1",
                Headline = "This is an item description."
            };

            viewModel = new ItemDetailViewModel(item);
            BindingContext = viewModel;
        }
    }
}