using ConsoleApp1.Model.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Model.Context
{
    partial class WordDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=TutorialDB;Trusted_Connection=True;");
        }

        public WordDbContext() {  
        }

        public WordDbContext(DbContextOptions<WordDbContext> options)
        : base(options){        }

        public DbSet<Words> Words { get; set; }
        public DbSet<User> Users { get; set; }
    }

}
