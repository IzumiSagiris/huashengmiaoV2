using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzumiSagirisCommon.Resolver
{
    public class IzumiContainer
    {
        private Dictionary<Type, Type> _serviceDic = new Dictionary<Type, Type>();

        public Dictionary<Type, Type> ServiceDic
        {
            get
            {
                return _serviceDic;
            }
        }

        /// <summary>
        /// RegisterType
        /// </summary>
        /// <typeparam name="TInterface">Your Interface</typeparam>
        /// <typeparam name="TService">Your Service</typeparam>
        public void RegisterType<TInterface, TService>()
        {
            if (typeof(TInterface).IsAssignableFrom(typeof(TService)) && !IsRegisted(typeof(TInterface)))
            {
                _serviceDic.Add(typeof(TInterface), typeof(TService));
            }
            else
            {
                throw new Exception("none of Interface in your register list or this type already registed");
            }
        }

        public bool IsRegisted(Type type)
        {
            return _serviceDic.ContainsKey(type);
        }
    }
}
