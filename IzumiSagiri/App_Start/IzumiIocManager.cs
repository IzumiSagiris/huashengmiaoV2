using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IzumiSagirisCommon.Resolver;
using IzumiSagiris.Service.IzmuService;
using IzumiSagiris.Service.Student;

namespace IzumiSagiri.App_Start
{
    public static class IzumiIocManager
    {
        /// <summary>
        /// RegisterIzumiLocator
        /// </summary>
        public static void RegisterIzumiLocator(IzumiContainer container)
        {
            container.RegisterType<IzumiInterFace, IzumiService>();
            container.RegisterType<IStudentInterFace, StudentService>();
            
            IzumiDirectLocator.SetContainaer(container);
            IzumiServiceLocator.SetContainaer(container);
        }
    }
}