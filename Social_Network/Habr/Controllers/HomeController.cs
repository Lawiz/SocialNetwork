using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BLL.Domain.Models;
using Habr.Data;
using Microsoft.AspNetCore.Mvc;
using Habr.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Habr.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(ApplicationDbContext context)
        {
            this.context = context;
        }
        private ApplicationDbContext context;
        static readonly Random rnd = new Random();
        public static DateTime GetRandomDate(DateTime from, DateTime to)
        {
            var range = to - from;

            var randTimeSpan = new TimeSpan((long)(rnd.NextDouble() * range.Ticks));

            return from + randTimeSpan;
        }
        public IActionResult Index()
        {
            //var rnd = new Random();
            //var testList = new List<ViewsStatistics>();
            //for (int i = 0; i < 10000; i++)
            //{
            //    testList.Add(new ViewsStatistics()
            //    {
            //        DateTime = GetRandomDate(new DateTime(2019,1,1,1,1,1), DateTime.Now)
            //        ,ArticleId = rnd.Next(1,1000)
            //    });
            //}
            //context.ViewsStatistics.AddRange(testList);
            //context.SaveChanges();
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public dynamic GetStatistics()
        {
            
            return JsonConvert.SerializeObject(new List<dynamic>()
            {
                GetEntryStatistics(),GetViewStatistics()
            },Formatting.Indented);

        }

        private dynamic GetEntryStatistics()
        {
            var response = new List<int>();
            context.Database.SetCommandTimeout(100);
            response.Add(context.EntryStatistics.AsNoTracking().Where(s => s.EntryDate.Hour > 0 && s.EntryDate.Hour < 3).Count());
            context.Database.SetCommandTimeout(100);
            response.Add(context.EntryStatistics.AsNoTracking().Where(s => s.EntryDate.Hour > 3 && s.EntryDate.Hour < 6).Count());
            context.Database.SetCommandTimeout(100);
            response.Add(context.EntryStatistics.AsNoTracking().Where(s => s.EntryDate.Hour > 6 && s.EntryDate.Hour < 9).Count());
            context.Database.SetCommandTimeout(100);
            response.Add(context.EntryStatistics.AsNoTracking().Where(s => s.EntryDate.Hour > 9 && s.EntryDate.Hour < 12).Count());
            context.Database.SetCommandTimeout(100);
            response.Add(context.EntryStatistics.AsNoTracking().Where(s => s.EntryDate.Hour > 12 && s.EntryDate.Hour < 15).Count());
            context.Database.SetCommandTimeout(100);
            response.Add(context.EntryStatistics.AsNoTracking().Where(s => s.EntryDate.Hour > 15 && s.EntryDate.Hour < 18).Count());
            context.Database.SetCommandTimeout(100);
            response.Add(context.EntryStatistics.AsNoTracking().Where(s => s.EntryDate.Hour > 18 && s.EntryDate.Hour < 21).Count());
            context.Database.SetCommandTimeout(100);
            response.Add(context.EntryStatistics.AsNoTracking().Where(s => s.EntryDate.Hour > 21 && s.EntryDate.Hour < 0).Count());
            return JsonConvert.SerializeObject(response);
        }
        private dynamic GetViewStatistics()
        {
            var response = new List<int>();
            context.Database.SetCommandTimeout(100);
            response.Add(context.ViewsStatistics.AsNoTracking().Where(s => s.DateTime.Hour > 0 && s.DateTime.Hour < 3).Count());
            context.Database.SetCommandTimeout(100);
            response.Add(context.ViewsStatistics.AsNoTracking().Where(s => s.DateTime.Hour > 3 && s.DateTime.Hour < 6).Count());
            context.Database.SetCommandTimeout(100);
            response.Add(context.ViewsStatistics.AsNoTracking().Where(s => s.DateTime.Hour > 6 && s.DateTime.Hour < 9).Count());
            context.Database.SetCommandTimeout(100);
            response.Add(context.ViewsStatistics.AsNoTracking().Where(s => s.DateTime.Hour > 9 && s.DateTime.Hour < 12).Count());
            context.Database.SetCommandTimeout(100);
            response.Add(context.ViewsStatistics.AsNoTracking().Where(s => s.DateTime.Hour > 12 && s.DateTime.Hour < 15).Count());
            context.Database.SetCommandTimeout(100);
            response.Add(context.ViewsStatistics.AsNoTracking().Where(s => s.DateTime.Hour > 15 && s.DateTime.Hour < 18).Count());
            context.Database.SetCommandTimeout(100);
            response.Add(context.ViewsStatistics.AsNoTracking().Where(s => s.DateTime.Hour > 18 && s.DateTime.Hour < 21).Count());
            context.Database.SetCommandTimeout(100);
            response.Add(context.ViewsStatistics.AsNoTracking().Where(s => s.DateTime.Hour > 21 && s.DateTime.Hour < 0).Count());
            return JsonConvert.SerializeObject(response);
        }
    }
}
