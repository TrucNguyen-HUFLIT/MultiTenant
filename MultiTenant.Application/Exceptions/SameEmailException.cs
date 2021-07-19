using System;

namespace MultiTenant.Application.Exceptions
{
    public class SameEmailException:SystemException
    {
        public SameEmailException(string email)
            : base($" Email \'{email}\' is already ")
        {

        }
    }
}
