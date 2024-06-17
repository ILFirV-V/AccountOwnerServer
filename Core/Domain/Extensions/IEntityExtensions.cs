using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Extensions
{
    public static class IEntityExtensions
    {
        public static bool IsObjectNull(this IEntity? entity)
        {
            return entity == null;
        }

        public static bool IsEmptyObject(this IEntity? entity)
        {
            if(entity.IsObjectNull())
            {
                return false;
            }
            return entity.Id.Equals(Guid.Empty);
        }
    }
}
