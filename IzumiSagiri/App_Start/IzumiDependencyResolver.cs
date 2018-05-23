using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IzumiSagirisCommon.Resolver;

namespace IzumiSagiri.App_Start
{
    public class IzumiDependencyResolver : IDependencyResolver
    {
        public object GetService(Type serviceType)
        {
            if (serviceType == null)
            {
                throw new ArgumentNullException("serviceType is null");
            }
            if(!serviceType.IsClass || serviceType.IsAbstract)
            {
                return null;
            }
            return IzumiServiceLocator.Get(serviceType);


        }

        public TInterface GetService<TInterface>()
        {
            var type = typeof(TInterface);
            return IzumiDirectLocator.GetService<TInterface>();

        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (serviceType == null)
            {
                throw new ArgumentNullException("serviceType");
            }
            return (serviceType.IsClass && !serviceType.IsAbstract) ? new List<object>() : null;
        }
    }

    
}