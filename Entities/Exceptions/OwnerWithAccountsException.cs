using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Exceptions
{
    public class OwnerWithAccountsException : Exception
    {
        public OwnerWithAccountsException()
        {
        }

        public OwnerWithAccountsException(string message)
            : base(message)
        {
        }

        public OwnerWithAccountsException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
