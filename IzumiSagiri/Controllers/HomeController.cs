using IzumiSagiri.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IzumiSagiris.Service.IzmuService;
using IzumiSagirisCommon.Resolver;

namespace IzumiSagiri
{
    /// <summary>
    /// Home
    /// </summary>
    [IzumiAuthorization]
    public class HomeController :  BaseController
    {
        public readonly IzumiInterFace _service;
        public readonly IzumiInterFace _serviceTwo;

        public HomeController()
        {
            _service = IzumiDirectLocator.GetService<IzumiInterFace>();
            _serviceTwo = IzumiDirectLocator.GetService<IzumiInterFace>(new object []{ 2.0 ,3.0 });

        }
        // GET: Home
        public ActionResult Index(long ID = 10, long License = 20)
        {
            var result = _service.Shimada(5, 6);
            return View();
        }

        public ActionResult License(long ID = 0, long License = 20)
        {
            var result = _serviceTwo.Shimada(5, 6);
            return View();
        }

        public ActionResult test()
        {
            var result = _service.Shimada(5, 6);
            return View();
        }

    }
}