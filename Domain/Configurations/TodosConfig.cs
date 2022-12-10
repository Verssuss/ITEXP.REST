using Domain.Configurations.Common;
using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Diagnostics;
using System.Reflection.Emit;

namespace Domain.Configurations
{
    public class TodosConfig : BaseAuditableEntityConfig<Todo>
    {
        protected override void Config(EntityTypeBuilder<Todo> builder)
        {
            builder
            .Property(p => p.Color)
                 .HasConversion(new EnumToStringConverter<Color>());

            builder.HasData(new Todo
            {
                Id = 1,
                Header = "Create a ticket",
                Category = Category.Analytics,
                Status = Status.Running,
                Color = Color.Red,
                CreatedOn = DateTime.UtcNow,
            },
            new Todo
            {
                Id = 2,
                Header = "Request information",
                Category = Category.Bookkeeping,
                Color = Color.Green,
                Status = Status.Running,
                CreatedOn = DateTime.UtcNow,
            });

            builder.HasKey(x => new { x.Header, x.Category });
        }
    }
}
