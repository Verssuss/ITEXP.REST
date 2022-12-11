using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Domain.Contracts
{
    public interface IEntity<TId> : IEntity
    {
        [JsonIgnore]
        public TId Id { get; set; }
    }
    public interface IEntity { }
}
