using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public interface IModelWithId
    {
        Guid Id { get; init; }
    }
}
