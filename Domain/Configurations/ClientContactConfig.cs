using Domain.Configurations.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

internal class ClientContactConfig : BaseEntityConfig<ClientContact>
{
    protected override void Config(EntityTypeBuilder<ClientContact> builder)
    {
        builder
            .HasOne(x => x.Client)
            .WithMany(x => x.Contacts);
    }
}