using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace ConsoleApp6
{
    public class NotesDBContext : DbContext
    {
        public DbSet<Note> Notes { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Picture> Pictures { get; set; }
        public DbSet<Tag> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost;Database=NotesDatabase;Trusted_Connection=True;")
                .UseLazyLoadingProxies();
        }
    }
}