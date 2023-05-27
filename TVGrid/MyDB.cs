using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TVGrid

{
    public class MyDB : DbContext
    {
        public DbSet<Role> Role { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<Schedule> Schedule { get; set; }

        public DbSet<Program> Program { get; set; }
        public DbSet<ProgramTypeDictionary> ProgramTypeDictionary { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=MyNewBD;Trusted_Connection=True");
        }

        public MyDB()
        {
            
        }

        public MyDB CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<MyDB>();
            optionsBuilder.UseSqlServer("YourConnectionStringHere");

            return new MyDB(optionsBuilder.Options);
        }
        public MyDB(DbContextOptions<MyDB> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }

    public class Role
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual IEnumerable<User> Users { get; set; }

    }

    public class User
    {
        public int Id { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public int RoleId { get; set; }


        public int Password { get; private set; }
        public string UserName { get; private set; }

        public virtual Role Role { get; set; }

    }

    public class Schedule
    {
        public int Id { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public int ProgramID { get; set; }
        public virtual Program Program { get; set; }

        public Schedule()
        {

        }

        public Schedule(DateTime TimeStart, DateTime TimeEnd, int ProgramID)
        {
            this.TimeStart=TimeStart;
            this.TimeEnd=TimeEnd;
            this.ProgramID=ProgramID;
        }

    }

    public class Program
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public TimeSpan Duration { get; set; }
        public int ProgramTypeDictionaryID { get; set; }

        public ProgramTypeDictionary ProgramTypeDictionary { get; set; }
        public IEnumerable<Schedule> Schedule { get; set; }
    }

    public class ProgramTypeDictionary
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public virtual IEnumerable<Program> Programs { get; set; }
    }

}

