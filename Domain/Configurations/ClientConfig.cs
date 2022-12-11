using Domain.Configurations.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configurations
{
    internal class ClientConfig : BaseEntityConfig<Client>
    {
        protected override void Config(EntityTypeBuilder<Client> builder)
        {
        }
    }
}