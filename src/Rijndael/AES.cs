using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace CipherModule.Rijndael
{
    partial class AES
    {

        private AesCryptoServiceProvider _aesCrypto;

        private Ciphers _ciphers;



        public AES() => _aesCrypto = new AesCryptoServiceProvider();


        public  struct SET
        {
            public static string Key { internal get; set; }

            public static string Iv { internal get; set; }

            public static uint KeySize { internal get; set; }
        }


        public string Encrypt(string Str,Enum CipherMode)
        {

            switch(CipherMode)
            {
                case CipherChannel.ecb:
                    _aesCrypto.Mode = System.Security.Cryptography.CipherMode.ECB;
                    return null;

                case CipherChannel.cbc:
                    _aesCrypto.Mode = System.Security.Cryptography.CipherMode.CBC;
                    return null;

                default:
                    return null;
            }
        }

        public string Decrypt(string Str, Enum CipherMode)
        {
            

            switch (CipherMode)
            {
                case CipherChannel.ecb:
                    _aesCrypto.Mode = System.Security.Cryptography.CipherMode.ECB;
                    return null;

                case CipherChannel.cbc:
                    _aesCrypto.Mode = System.Security.Cryptography.CipherMode.CBC;
                    return null;

                default:
                    return null;
            }
        }
        

        private class Ciphers:AES
        {
            private Ciphers()
            {

            }

            public string ECB_Encrypt(string Str)
            {
                return "";
            }

            public string ECB_Decrypt(string Str)
            {
                return null;
            }

            public string CBC_Encrypt(string Str)
            {
                return null;
            }


            public string CBC_Decrypt(string Str)
            {
                return null;
            }


            private void Close() => _aesCrypto.Dispose();
        }
    }
}
