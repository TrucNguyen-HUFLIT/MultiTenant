using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiTenant.Application.Exceptions
{
    public  class UserNameExistedException:Exception
    {
        public UserNameExistedException(string username,string name)
         : base($"UserName Or Name Already Exists!")
        {

        }
    }
}
