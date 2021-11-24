using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Student.IdentityServer.Pgsql
{
    public class IdentityServerDbContext : DbContext
    {
        public IdentityServerDbContext(DbContextOptions<IdentityServerDbContext> options) : base(options)
        {

        }
    }
}
