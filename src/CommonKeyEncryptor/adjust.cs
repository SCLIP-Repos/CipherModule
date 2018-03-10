using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CipherModule
{
    internal class adjust
    {
        internal static string ReMake(string s,char AppendChar,int Size)
        {
            int tmp = s.Length;
            
            if(tmp == Size)
            {
                return s;
            }
            else if(tmp < Size)
            {
                for (int i = 0; i < Size - tmp; i++)
                    s += AppendChar;

                return s;
            }
            else//(tmp > Size)
            {
                return s.Remove(Size);
            }
        }

    }
}
