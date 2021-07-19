using System;

namespace MultiTenant.Application.Exceptions
{
    public class SameDbExceptions : SystemException
    {
        public SameDbExceptions(string name)
            : base($" Database \'{name}\' is already ")
        {

        }
    }
}
