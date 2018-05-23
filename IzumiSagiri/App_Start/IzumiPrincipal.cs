using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace IzumiSagiri.App_Start
{
    public class IzumiPrincipal : IPrincipal  
    {

        private IIdentity _identity;

        public IIdentity Identity
        {
            get { return _identity; }
        }

        public bool IsInRole(string role)
        {
            return false;
        }

        public IzumiPrincipal(string UserName)
        {
            _identity = new IzumiIdentity(UserName);                 
        }

        public IzumiPrincipal(int UserID)
        {
            _identity = new IzumiIdentity(UserID);
        }      
    }
}