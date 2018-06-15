using System;
using System.Text;
using System.Security;
using System.Security.Cryptography;

namespace CipherModule.RSA
{
    public class RSA
    {
        private RSACryptoServiceProvider rsaCrypto;



        public RSA() => rsaCrypto = new RSACryptoServiceProvider();




        public string Encrypt(string Str,string Key)
        {
            try
            {
                rsaCrypto.FromXmlString(Key);

                return Convert.ToBase64String(rsaCrypto.Encrypt(Encoding.UTF8.GetBytes(Str),false));
            }
            catch
            {
                return null;
            }
            finally
            {
                Close();
            }
        }



        public string Decrypt(string Str,string Key)
        {
            try
            {
                rsaCrypto.FromXmlString(Key);

                return Encoding.UTF8.GetString(rsaCrypto.Decrypt(Convert.FromBase64String(Str),false));
            }
            catch
            {
                return null;
            }
            finally
            {
                Close();
            }
        }




        public void Close() => rsaCrypto.Dispose();


        public class Key
        {
            public void CreateKeyPair(out string PublicKey, out string PrivateKey, string ContainerName)
            {
                CspParameters cspParameters = new CspParameters();

                cspParameters.KeyContainerName = ContainerName;

                using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(cspParameters))
                {
                    PublicKey = rsa.ToXmlString(false);

                    PrivateKey = rsa.ToXmlString(true);
                }
            }

            public void CreateKeyPair(out string PublicKey, out string PrivateKey, out string ContainerName)
            {

                ContainerName = Guid.NewGuid().ToString("N").Substring(0, 20);


                CreateKeyPair(out PublicKey, out PrivateKey, ContainerName);
            }


            /*
            internal bool TypeOfElementToDecryptChecker(string Element)
            {
                if (Element.Remove("<RSAKeyValue>".Length) == "<RSAKeyValue>")
                    return true;

                return false;
            }
            */

        }
    }
}
