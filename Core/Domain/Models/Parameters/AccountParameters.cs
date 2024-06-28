using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Parameters
{
    public class AccountParameters : GetItemsQuery
    {
        public string OrderBy { get; init; }
        public DateTime MinDateCreated { get; init; }
        public DateTime MaxDateCreated { get; init; }
    }
}
