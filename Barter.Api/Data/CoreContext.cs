using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Barter.Models;

namespace Barter.Api.Data
{
    public class CoreContext : DbContext
    {
        public CoreContext (DbContextOptions<CoreContext> options)
            : base(options)
        {
        }

        public DbSet<Barter.Models.User> User { get; set; }
    }
}
