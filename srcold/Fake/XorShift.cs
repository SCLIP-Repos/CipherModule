using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CipherModule.Fake
{
    public class XorShift
    {/*
        public uint Create
        {
            get
            {
                GeneratorN generator = new GeneratorN();

                return generator.Create();
            }
        }

        private class GeneratorN
        {
            private UInt32 _a, _b, _c, _d, _x;
            
            internal uint Create()
            {
                _a = 123456789;

                _b = 362436069;

                _c = 521288629;
                
                //_d = 88675123;//SEED

                _d = Convert.ToUInt32( DateTime.Now.Ticks.ToString().Remove(0, 9));

                _x = _a ^ (_a << 11);

                _a = _b;

                _b = _c;

                _c = _d;

                return _d = (_d ^ (_d >> 19)) ^ (_x ^ (_x >> 8));
            }

        }*/

    }
}
