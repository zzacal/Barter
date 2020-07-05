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

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<User>()
                .HasMany(t => t.Things)
                .WithOne(u => u.User)
                .HasForeignKey(t => t.UserId)
                .HasPrincipalKey(u => u.Id);
        }

        public DbSet<Barter.Models.User> User { get; set; }

        public DbSet<Barter.Models.Friendship> Friendship { get; set; }

        public DbSet<Barter.Models.Thing> Thing { get; set; }
    }
}
