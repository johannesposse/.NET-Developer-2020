using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitryFramework_Uppgift1
{
    public class SchoolContext : DbContext
    {
        public DbSet<Course> Courses { get; set; }
        public DbSet<Student> students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder dBContextbuilder)
        {
            dBContextbuilder.UseSqlServer(@"Server=.\SQLExpress;Database=School;Trusted_Connection=True;").UseLazyLoadingProxies();
        }
    }
}
