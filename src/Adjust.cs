using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CipherModule
{
    internal class Adjust
    {
        public static void Txt(string str, int Size,char AppendChar)
        {
            if (str.Length < Size)
                for (int i = 0; i < Size - str.Length; i++)
                    str += AppendChar;
            else
                str = str.Remove(Size);
        }

    }
}
