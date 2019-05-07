using System;
using System.Collections.Generic;
using System.Text;
using BLL.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Habr.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {   
        public DbSet<Article> Articles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<BLL.Domain.Models.ViewsStatistics> ViewsStatistics { get; set; }

        public DbSet<BLL.Domain.Models.EntryStatistics> EntryStatistics { get; set; }
    }
}
