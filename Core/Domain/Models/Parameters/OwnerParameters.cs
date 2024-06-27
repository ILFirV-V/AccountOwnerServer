using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Parameters
{
    public class OwnerParameters : GetItemsQuery
    {
        public DateTime MinDateOfBirth { get; init; }
        public DateTime MaxDateOfBirth { get; init; }
        public string Name { get; init; }
        public string OrderBy { get; init; }
    }
}
