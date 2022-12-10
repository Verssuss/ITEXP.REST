using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations.Common
{
    public abstract class BaseAuditableEntityConfig<TDomain> : IEntityTypeConfiguration<TDomain> where TDomain : AuditableEntity<Guid>
    {
        public void Configure(EntityTypeBuilder<TDomain> builder)
        {
            Config(builder);
        }

        protected abstract void Config(EntityTypeBuilder<TDomain> builder);
    }
}
