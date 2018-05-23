using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace IzumiSagiri.App_Start
{
    public class IzumiIdentity : IIdentity
    {

        private string _userName;  

        public string UserName
        {
            get { return _userName; }
        }
            
        public IzumiIdentity(string UserName)
        {
            _userName = UserName;
        }

        public IzumiIdentity(int UserID)
        {
         
        }

        public string AuthenticationType
        {
            get { return "Form"; }
        }

        public bool IsAuthenticated
        {
            get
            {
                return !(string.IsNullOrEmpty(this._userName));
            }
        }

        public string Name
        {
            get { return _userName; }
        }

    }
}