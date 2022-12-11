using Domain.Contracts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations.Common
{
    public abstract class BaseEntityConfig<TDomain> : IEntityTypeConfiguration<TDomain> where TDomain : BaseEntity<int>
    {
        public void Configure(EntityTypeBuilder<TDomain> builder)
        {
            builder.HasKey(x => x.Id);

            Config(builder);
        }

        protected abstract void Config(EntityTypeBuilder<TDomain> builder);
    }
}