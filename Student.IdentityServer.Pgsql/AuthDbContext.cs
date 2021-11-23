using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Student.IdentityServer.DI.Model;

namespace Student.IdentityServer.Pgsql
{
    public class AuthDbContext : IdentityDbContext<StudentUser>
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<StudentUser>().ToTable("StudentUser");
        }

    }
}
