using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IzumiSagiris.Service.IzmuService
{
    public class IzumiService : IzumiInterFace
    {
        public IzumiService()
        {
            three = 10;
        }
        public IzumiService(double _three)
        {
            three = _three;
        }
        public IzumiService(double _three,double _four)
        {
            three = _three;
            four = _four;
        }
        private double three;

        private double four;

        public double Shimada(double one, double two)
        {
            return one * two * three;
        }

        public double Genji(double one , double two)
        {
            return one * two;
        }
    }
}
