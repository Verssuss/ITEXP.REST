using Domain.Contracts;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
