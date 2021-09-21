using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AuthDemo.Database
{
    public class AuthDbCon : IdentityDbContext
    {
        public AuthDbCon(DbContextOptions<AuthDbCon> options) :base(options)
        {

        }
    }
}
