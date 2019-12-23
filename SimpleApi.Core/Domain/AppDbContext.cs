using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Text;


namespace SimpleApi.Core.Domain
{
   public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<User> UsersItems { get; set; }
        public DbSet<Order> OrderItems { get; set; }
        public DbSet<OrderDetails> OrderDetailItems { get; set; }
        public DbSet<Product> ProductItems { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            foreach (IMutableEntityType entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.Relational().TableName = entityType.DisplayName();
            }
        }

    }
}
