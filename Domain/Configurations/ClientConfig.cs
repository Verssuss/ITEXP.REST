using Domain.Configurations.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Configurations
{
    internal class ClientConfig : BaseEntityConfig<Client>
    {
        protected override void Config(EntityTypeBuilder<Client> builder)
        {
        }
    }
}
