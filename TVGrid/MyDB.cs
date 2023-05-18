using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TVGrid
{
    public class MyDB : DbContext
    {
        public DbSet<PostToGroup> Posts { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Company> Companys { get; set; }

        public DbSet<Country> Countrys { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=MyNewBD;Trusted_Connection=True");
        }

        public MyDB()
        {
            Database.EnsureCreated();
        }
    }

    public class PostToGroup
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string DateAndTime { get; set; }

    }

    public class User
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }

        public int company_id { get; set; }

        public IEnumerable<Company> Company { get; set; }



    }

    public class Company
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
    public class Country
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}

