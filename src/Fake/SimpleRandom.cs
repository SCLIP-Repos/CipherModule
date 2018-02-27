using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CipherModule
{
    public class SimpleRandom
    {
        public static string Create(int Size)
        {
            Guid guid = Guid.NewGuid();

            try
            {
                return guid.ToString("N").Substring(0, Size);
            }
            catch
            {
                return null;
            }

        }

        public static string Create()
        {
            return Create(10);
        }


        public static UInt32 CreateN(UInt32 Size)
        {

            
            string n = String.Empty;

            Random random = new Random();

            for ( int i = 0; i < Size; i++)
            {
                n += random.Next(9);
            }


            return Convert.ToUInt32(n);
        }

   

    }
}
