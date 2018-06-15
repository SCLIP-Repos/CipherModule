using System.Text;
using System.Security.Cryptography;

namespace CipherModule.Hash
{
    public  class SHA
    {
        public static string SHA256(string Str)
        {

            using(SHA256CryptoServiceProvider sha = new SHA256CryptoServiceProvider())
            {

                var tmp = sha.ComputeHash(Encoding.UTF8.GetBytes(Str));

                StringBuilder sb = new StringBuilder();

                for (int i = 0; i < tmp.Length; i++)
                {
                    sb.AppendFormat("{0:x2}", tmp[i]);
                }

                return sb.ToString();
            }
        }


        public static string SHA384(string Str)
        {

            using (SHA384CryptoServiceProvider sha = new SHA384CryptoServiceProvider())
            {

                var tmp = sha.ComputeHash(Encoding.UTF8.GetBytes(Str));

                var sb = new StringBuilder();

                for (int i = 0; i < tmp.Length; i++)
                {
                    sb.AppendFormat("{0:x2}", tmp[i]);
                }

                return sb.ToString();
            }        
        }


        public  class SecureSHA:SHA
        {
#pragma warning disable RECS0146 
            public  static  string SHA256(string Str, char Salt, int Count)
#pragma warning restore RECS0146 
            {
                string tmp = SHA.SHA256(Str + Salt);

                for (int i = 0; i < Count; i++)
                {
                    tmp = SHA.SHA256(tmp + Salt);
                }

                return tmp;
            }


#pragma warning disable RECS0146 
            public static string SHA384(string Str, char Salt, int Count)
#pragma warning restore RECS0146 
            {
                string tmp = SHA.SHA384(Str + Salt);

                for (int i = 0; i < Count; i++)
                {
                    tmp = SHA.SHA384(tmp + Salt);
                }

                return tmp;
            }
        }
    }
}
