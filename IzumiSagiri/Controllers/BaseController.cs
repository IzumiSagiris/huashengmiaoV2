using IzumiSagiris.Service.IzumiEntity;
using IzumiSagirisCommon.Worker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;

namespace IzumiSagiri
{
    public class BaseController : Controller
    {
        public BaseController()
        {

        }

        public UserEntity userEntity;

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string DecryptToken = RSAWorker.RsaDecrypt(filterContext.HttpContext.User.Identity.Name);
            userEntity = Newtonsoft.Json.JsonConvert.DeserializeObject<UserEntity>(DecryptToken);
        }
    }
}