using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using MyHabr.Data;
using MyHabr.Models.BLL.Domain.Models;
using MyHabr.Modules;
using MyHabr.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using MyHabr.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace MyHabr
{
    public partial class App : Application
    {
        private static IStoryService<Article> _restService;

        public static void Initialize()
        {
        }
        public App()
        {
            InitializeComponent();

            ServicesModule.Load();
            MainPage = new MainPage();
        }

        private Database db;
        protected async override void OnStart()
        {
            db = new Database(Constants.ConnectionString);
        //    _restService = DependencyService.Get<IStoryService<Article>>();

        //    var articles = await _restService.GetAll();
            
        //    var i = db.database.InsertAllAsync(articles).Result;
            

            var result = db.GetItemsAsync().Result;
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
