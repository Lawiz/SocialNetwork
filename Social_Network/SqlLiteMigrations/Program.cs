using System;
using BLL.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace SqlLiteMigrations
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
public class ApplicationContext : DbContext
{
    private string _databasePath;

    public DbSet<Article> Articles { get; set; }

    public ApplicationContext(string databasePath)
    {
        _databasePath = databasePath;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }
}
