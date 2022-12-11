using Domain.Contracts;
using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Contexts
{
    public class ITEXPContext : DbContext
    {
        public ITEXPContext(DbContextOptions options) : base(options)
        {
     
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<IAuditableEntity>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedOn = DateTime.UtcNow;
                        break;
                }
            }

            return await base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(IEntity)));
            var guid = Guid.NewGuid();

            modelBuilder.Entity<Todo>().HasData(new Todo
            {
                Id = guid,
                Header = "Create a ticket",
                Category = Category.Analytics,
                Status = Status.Running,
                Color = Color.Red,
                CreatedOn = DateTime.UtcNow,
            },
            new Todo
            {
                Id = Guid.NewGuid(),
                Header = "Request information",
                Category = Category.Bookkeeping,
                Color = Color.Green,
                Status = Status.Running,
                CreatedOn = DateTime.UtcNow,
            });

            modelBuilder.Entity<Comment>().HasData(new Comment() { Id = 1, TodoId = guid, Text = "2-3шт." });
            base.OnModelCreating(modelBuilder);
        }
    }
}
