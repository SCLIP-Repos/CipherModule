using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace CipherModule
{
    public class SHA
    {
        public static string MD5(string Origin)
        {
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            {
                var Tmp = md5.ComputeHash(Encoding.UTF8.GetBytes(Origin));

                StringBuilder stringBuilder = new StringBuilder();



                for (int i = 0; i < Tmp.Length; i++)
                {
                    stringBuilder.AppendFormat("{0:x2}", Tmp[i]);
                }

                return stringBuilder.ToString();
            }

        }

        public static string SHA_1(string Origin)
        {
            using (SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider())
            {
                var Tmp = sha1.ComputeHash(Encoding.UTF8.GetBytes(Origin));

                StringBuilder stringBuilder = new StringBuilder();



                for (int i = 0; i < Tmp.Length; i++)
                {
                    stringBuilder.AppendFormat("{0:x2}", Tmp[i]);
                }

                return stringBuilder.ToString();
            }
        }


        public static string SHA_256(string Origin)
        {
            using (SHA256CryptoServiceProvider sha256 = new SHA256CryptoServiceProvider())
            {
                var Tmp = sha256.ComputeHash(Encoding.UTF8.GetBytes(Origin));

                StringBuilder stringBuilder = new StringBuilder();



                for (int i = 0; i < Tmp.Length; i++)
                {
                    stringBuilder.AppendFormat("{0:x2}", Tmp[i]);
                }

                return stringBuilder.ToString();
            }
        }

        public static string SHA_384(string Origin)
        {
            using (SHA384CryptoServiceProvider sha384 = new SHA384CryptoServiceProvider())
            {
                var Tmp = sha384.ComputeHash(Encoding.UTF8.GetBytes(Origin));


                StringBuilder stringBuilder = new StringBuilder();



                for (int i = 0; i < Tmp.Length; i++)
                {
                    stringBuilder.AppendFormat("{0:x2}", Tmp[i]);
                }

                return stringBuilder.ToString();
            }

        }
    }
}
