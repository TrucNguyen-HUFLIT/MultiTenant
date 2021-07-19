using System;

namespace MultiTenant.Application.Exceptions
{
    public  class UserNameExistedException:Exception
    {
        public UserNameExistedException(string username)
         : base($"User name \'{username}\' already exists!")
        {

        }
    }
}
