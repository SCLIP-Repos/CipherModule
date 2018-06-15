using System;
using System.Text;
using System.Security.Cryptography;


namespace CipherModule.Rijndael
{
    public partial class AES
    {

        private AesCryptoServiceProvider aesCryptoService;

        private ICryptoTransform cryptoTransform;



        public enum Mode{ECB,CBC}


        public AES() => aesCryptoService = new AesCryptoServiceProvider();


        public void SET(string Key,int KeySize)
        {
            if (KeySize == 128 || KeySize == 192 || KeySize == 256)
            {
                aesCryptoService.KeySize = KeySize;   
            }
            else if (KeySize == 16 || KeySize == 24 || KeySize == 32)
            {
                aesCryptoService.KeySize = KeySize * 8;
            }
            else
            {
                Console.WriteLine("Key size err");
                return;
            }

            aesCryptoService.Key = Encoding.UTF8.GetBytes(AdjustSize(Key, aesCryptoService.KeySize / 8, '*'));

            aesCryptoService.Padding = PaddingMode.PKCS7;

        }

        public void SET(string Key,string Iv,int KeySize)
        {
            SET(Key, KeySize);


            aesCryptoService.IV = Encoding.UTF8.GetBytes( AdjustSize(Iv, 16, '*') ); 

        }
        



        public string Encrypt(string Str, Enum @enum)
        {
            switch (@enum)
            {
                case Mode.ECB:
                    aesCryptoService.Mode = CipherMode.ECB;
                    break;

                case Mode.CBC:
                    aesCryptoService.Mode = CipherMode.CBC;
                    break;
                default:
                    break;
            }



            cryptoTransform = aesCryptoService.CreateEncryptor();


            byte[] StrBytes = Encoding.UTF8.GetBytes(Str);

            try
            {
                byte[] TfromFBBytes = cryptoTransform.TransformFinalBlock(StrBytes, 0, StrBytes.Length);    

                return Convert.ToBase64String(TfromFBBytes);
            }
            catch
            {
                return null;    
            }

        }



        public string Decrypt(string Str, Enum @enum)
        {
            switch (@enum)
            {
                case Mode.ECB:
                    aesCryptoService.Mode = CipherMode.ECB;
                    break;

                case Mode.CBC:
                    aesCryptoService.Mode = CipherMode.CBC;
                    break;
                default:
                    break;
            }





            cryptoTransform = aesCryptoService.CreateDecryptor();


            byte[] StrBytes = Convert.FromBase64String(Str);



            try
            {
                byte[] TfromFBBytes = cryptoTransform.TransformFinalBlock(StrBytes, 0, StrBytes.Length);


                return Encoding.UTF8.GetString(TfromFBBytes);
            }
            catch
            {
                return null;    
            }

        }


        public void Close() => aesCryptoService.Dispose();


        private string AdjustSize(string SourceStr,int Size,char AppendChar)
        {
            int SourceSize = SourceStr.Length;

            if (SourceSize < Size)
            {
                for (int i = 0; i < Size - SourceSize;i++)
                    SourceStr += AppendChar;

                return SourceStr;

            }
            else if (SourceSize > Size)
            {
                return SourceStr.Remove(Size);
            }
            else
                return SourceStr;
        }

    }
}
