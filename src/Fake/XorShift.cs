using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CipherModule
{
    public class XorShift
    {
        private UInt32 _a, _b, _c,_d,_x;


        public XorShift()
        {
            _a = SimpleRandom.CreateN(9);

            _b = SimpleRandom.CreateN(9);

            _c = SimpleRandom.CreateN(9);

            _d = 123456789;
        }


        public void Create()
        {
            _x = _a ^ (_a << 11);

            _a = _b;

            _c = _d;

            Console.WriteLine(_d = (_d ^ (_d >> 19)) ^ (_x ^ (_x >> 8)));
        }
    }
}
