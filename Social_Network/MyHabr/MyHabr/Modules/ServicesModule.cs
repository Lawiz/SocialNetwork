using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using MyHabr.Data;
using MyHabr.Models.BLL.Domain.Models;
using MyHabr.Services;
using Xamarin.Forms;

namespace MyHabr.Modules
{
    public static class ServicesModule 
    {
        public static void Load()
        {
            DependencyService.Register<IStoryService<Article>,StorysService<Article>>();
            DependencyService.Register<IDataStore<Article>, ArticleDataStore>();
            DependencyService.Register<IRestService,RestClinet>();
        }
    }
}
