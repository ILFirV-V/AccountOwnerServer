using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models.Parameters.Base
{
    public abstract class QueryStringParametersBase
    {
        const int maxPageSize = 50;
        private int pageSize = 10;

        [Required]
        [Range(1, int.MaxValue)]
        public uint PageNumber { get; set; } = 1;

        [Range(1, maxPageSize)]
        public int PageSize
        {
            get
            {
                return pageSize;
            }
            set
            {
                pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
    }
}
