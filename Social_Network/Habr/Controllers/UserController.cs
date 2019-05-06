using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Domain.Models;
using Habr.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Habr.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext context;
        public UserController(ApplicationDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await context.Users.ToListAsync());
        }
    }
}