using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class DeleteOwnerWithAccountsException : Exception
    {
        public DeleteOwnerWithAccountsException()
        {
        }

        public DeleteOwnerWithAccountsException(string message)
            : base(message)
        {
        }

        public DeleteOwnerWithAccountsException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
