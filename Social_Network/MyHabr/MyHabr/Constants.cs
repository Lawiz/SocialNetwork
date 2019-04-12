using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MyHabr
{
    public static class Constants
    {
        // URL of REST service
        public static string RestUrl = "https://habr.azurewebsites.net/{0}";
        // Credentials that are hard coded into the REST service
        public static string Username = "Petr";
        public static string Password = "Pa$$w0rd";
        public static string ConnectionString = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "appDataBase");
    }
}
