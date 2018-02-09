using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CipherModule.PublicKeyEncryptor
{
    class RSA:Interfaces.Out
    {

        private string print, err;

        private RSACryptoServiceProvider _rsa;

        

        public RSA() => _rsa = new RSACryptoServiceProvider();


        public void SET()
        {

        }


        public void Encrypt()
        {

        }

        public void Decrypt()
        {

        }

        public void Close() => _rsa.Dispose();

        public string Print()
        {
            return print;
        }

        public void SetPrint(string value)
        {
            SetPrint(print);
        }


        public string Err()
        {
            return err;
        }

        public void SetErr(string value)
        {
            SetErr(err);
        }


        public class Key
        {

            public void CreateKeyPair()
            {

            }
            
        }
    }
}
