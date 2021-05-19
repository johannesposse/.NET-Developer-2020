using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Model
{
    public class DbCon : DbContext
    {
        public DbCon(DbContextOptions<DbCon> options) : base (options)
        {

        }

        public DbSet<Book> Book { get; set; }
    }
}
