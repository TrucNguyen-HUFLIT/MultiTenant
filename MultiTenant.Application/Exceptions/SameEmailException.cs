using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenant.Application.Exceptions
{
    public class SameEmailException:SystemException
    {
        public SameEmailException(string email)
            : base($" Email is already ")
        {

        }
    }
}
