using Domain.Models.Parameters.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Parameters
{
    public class AccountQueryParameters : QueryStringParametersBase
    {
        public new string OrderBy { get; set; } = "DateCreated";
    }
}
