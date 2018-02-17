using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CipherModule
{
    public class RSA:Interfaces.Out
    {

        private string print, err;

        private RSACryptoServiceProvider _rsa;

        

        public RSA() => _rsa = new RSACryptoServiceProvider();
        

        public void Encrypt(string Source,string Key)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                try
                {
                    rsa.FromXmlString(Key);

                    print = Convert.ToBase64String(rsa.Encrypt(Encoding.UTF8.GetBytes(Source), false));
                }
                catch(Exception ex)
                {
                    err = ex.ToString();
                }
            }
        }

        public void Decrypt(string Source,string Key)
        {
            var Tmp = Convert.FromBase64String(Source);

            Key key = new RSA.Key();

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                try
                {
                    rsa.FromXmlString(Key);
                    
                    byte[] SourceBytes = rsa.Decrypt(Tmp, false);

                    print = Encoding.UTF8.GetString(SourceBytes);
                }
                catch (Exception ex)
                {
                    err = ex.ToString();
                }

            }
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

            public void CreateKeyPair(out string PublicKey,out string PrivateKey,string ContainerName)
            {
                CspParameters cspParameters = new CspParameters();

                cspParameters.KeyContainerName = ContainerName;

                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cspParameters))
                {
                    PublicKey = rsa.ToXmlString(false);

                    PrivateKey = rsa.ToXmlString(true);
                }
            }

            public void CreateKeyPair(out string PublicKey,out string PrivateKey,out string ContainerName)
            {

                ContainerName = Guid.NewGuid().ToString("N").Substring(0, 20);


                CreateKeyPair(out PublicKey, out PrivateKey, ContainerName);
            }



            internal bool TypeOfElementToDecryptChecker(string Element)
            {
                if (Element.Remove("<RSAKeyValue>".Length) == "<RSAKeyValue>")
                    return true;

                return false;
            }

        }
    }
}
