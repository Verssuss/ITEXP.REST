using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IAuditableEntity<TId> : IAuditableEntity, IEntity<TId>
    {
    }

    public interface IAuditableEntity : IEntity
    {
        DateTime CreatedOn { get; set; }
    }
}
