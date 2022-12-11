using Domain.Configurations.Common;
using Domain.Entities;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel.DataAnnotations.Schema;
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

            builder.HasIndex(x => new { x.Header, x.Category }).IsUnique();
        }
    }
}
