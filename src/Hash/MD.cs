using System;
using System.Security.Cryptography;
using System.Text;

namespace CipherModule.Hash
{
    public class MD
    {


        public static string MD5(string Str)
        {
            using(MD5CryptoServiceProvider md = new MD5CryptoServiceProvider())
            {
                var tmp = md.ComputeHash(Encoding.UTF8.GetBytes(Str));

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < tmp.Length; i++)
                {
                    sb.AppendFormat("{0:x2}", tmp[i]);
                }

                return sb.ToString();
            }

        }
    }
}
