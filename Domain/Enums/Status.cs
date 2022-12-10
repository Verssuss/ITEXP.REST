using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum Status : byte
    {
        Running = 0,
        Waiting = 1,
        Canceled = 2,
        Success = 3,
    }
}
