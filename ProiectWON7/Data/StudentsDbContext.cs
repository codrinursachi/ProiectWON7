using Microsoft.EntityFrameworkCore;
using ProiectWON7.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProiectWON7.Data
{
    internal class StudentsDbContext : DbContext
    {
        public StudentsDbContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Addresses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\codri\source\repos\ProiectWON7\ProiectWON7\Data\Students.mdf;Integrated Security=True");
        }
    }
}
