using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class GetItemsQuery
    {
        public int PageNumber { get; init; }
        public int PageSize { get; init; }
    }
}
