using System;
using System.Collections.Generic;
using System.Text;

namespace MyHabr.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Войти
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
