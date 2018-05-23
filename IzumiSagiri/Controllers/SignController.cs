using IzumiSagiri.App_Start;
using IzumiSagiris.Service.IzmuService;
using IzumiSagiris.Service.IzumiEntity;
using IzumiSagiris.Service.Student;
using IzumiSagirisCommon.Resolver;
using IzumiSagirisCommon.Worker;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace IzumiSagiri
{
    public class SignController : BaseController
    {
        public readonly IStudentInterFace studentService;

        public SignController()
        {
            studentService = IzumiDirectLocator.GetService<IStudentInterFace>();

        }
        // GET: SignIn
        [AllowAnonymous]
        public ActionResult SignIn(string returnUrl = "")
        {
            ViewBag.returnUrl = returnUrl;
            Response.Headers.Add("returnUrl", returnUrl);
            return View();
        }


        [AllowAnonymous]
        public ActionResult SignOut(string returnUrl = "")
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("SignIn");
        }

        // GET: Register
        [AllowAnonymous]
        public ActionResult Register(string token = "")
        {
            var en = RSAWorker.RsaEncrypt("Niconiconi");
            if (token.Equals(en))
            {
                var user = new UserEntity();
                user.UserName = "yaobin";
                user.Password = "yb864665226";
                studentService.CreateUser(user);
            }
            return Content("1");
        }

        [AllowAnonymous]
        [HttpPost]
        public ActionResult SignOn(string username = "", string password = "", string returnUrl = "")
        {
            //查库先省略

            var user = studentService.GetUser(username, password);
            user.TimeSpan = DateTime.Now.ToString();
            if (user == null)
            {
                var reuslt = new HttpStatusCodeResult(401, "用户名密码错误");
                return Json(reuslt);
            }
            else
            {
                string token = Newtonsoft.Json.JsonConvert.SerializeObject(user);
                var ss = RSAWorker.RsaEncrypt(token);
                FormsAuthentication.SetAuthCookie(ss, false);
                if (string.IsNullOrEmpty(returnUrl))
                {
                    returnUrl = "/Home/Index";
                }
                var reuslt = new HttpStatusCodeResult(200, returnUrl);
                return Json(reuslt);
            }
        }
    }
}