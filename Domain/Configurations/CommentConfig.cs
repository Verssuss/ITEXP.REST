using Domain.Configurations.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    public class CommentConfig : BaseEntityConfig<Comment>
    {
        protected override void Config(EntityTypeBuilder<Comment> builder)
        {
            builder.HasOne(x => x.Todo)
                   .WithMany(x => x.Comments)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}