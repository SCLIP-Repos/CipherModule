using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CipherModule
{
    public class AES:Interfaces.Out
    {

        private string print, err;



        private AesCryptoServiceProvider _aesCryptoServiceProvider;




        public AES() => _aesCryptoServiceProvider = new AesCryptoServiceProvider();



        public void SET(string key,int KeySize,string Mode)
        {
            
            //SET KEY

            if (KeySize == 128 || KeySize == 192 || KeySize == 256)
            {
                _aesCryptoServiceProvider.KeySize = KeySize;
            }
            else if (KeySize == 16 || KeySize == 24 || KeySize == 32)
            {
                _aesCryptoServiceProvider.KeySize = KeySize * 8;
            }
            else
            {
                err = "The KeySize specification is incorrect.";
                return;
            }

            _aesCryptoServiceProvider.Key = Encoding.UTF8.GetBytes(key);

            _aesCryptoServiceProvider.Padding = PaddingMode.PKCS7;



            //SET MODE

            switch (Mode)
            {
                case "ECB":
                    _aesCryptoServiceProvider.Mode = CipherMode.ECB;
                    break;
                case "CBC":
                    _aesCryptoServiceProvider.Mode = CipherMode.CBC;
                    break;
                default:
                    err = "The mode specification is incorrect.";
                    return;
            }


        }
        
        public void SET(string Key,string Iv,int KeySize,string Mode)
        {
            SET(Key, KeySize, Mode);


            //SET IV
            _aesCryptoServiceProvider.IV = Encoding.UTF8.GetBytes(Iv);

        }

        public void Encyrpt(string Source)
        {
            ICryptoTransform cryptoTransform = _aesCryptoServiceProvider.CreateEncryptor();


            byte[] TmpBytes = Encoding.UTF8.GetBytes(Source);

            try
            {
                byte[] TfromFBBytes = cryptoTransform.TransformFinalBlock(TmpBytes, 0, TmpBytes.Length);

                print = Convert.ToBase64String(TfromFBBytes);
            }
            catch(Exception ex)
            {
                err = ex.ToString();
            }
        }

        public void Decrypt(string Source)
        {
            ICryptoTransform cryptoTransform = _aesCryptoServiceProvider.CreateDecryptor();

            byte[] TmpBytes = Convert.FromBase64String(Source);

            try
            {
                byte[] TfromFBBytes = cryptoTransform.TransformFinalBlock(TmpBytes, 0, TmpBytes.Length);

                print = Encoding.UTF8.GetString(TfromFBBytes);
            }
            catch (Exception ex)
            {
                err = ex.ToString();
            }
        }

   

        public void Close() => _aesCryptoServiceProvider.Dispose();



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

    }

    public class RijndaelCryptor:Interfaces.Out
    {
        private string print, err;

        private Rijndael _rijndael;

        public RijndaelCryptor()
        {
            _rijndael = Rijndael.Create();

            _rijndael.BlockSize = 256;
        }

        public void SET(string Key,char PaddingChar,string Mode)
        {

            //SET KEY

            _rijndael.Key = Encoding.UTF8.GetBytes(AdjustSize(Key, PaddingChar, 32));

            _rijndael.KeySize = 256;



            //SET MODE

            switch (Mode)
            {
                case "ECB":
                    _rijndael.Mode = CipherMode.ECB;
                    break;
                case "CBC":
                    _rijndael.Mode = CipherMode.CBC;
                    break;
                default:
                    err = "The mode specification is incorrect.";
                    return;
            }

        }

        public void SET(string Key,string Iv, char PaddingChar,string Mode)
        {
            SET(Key, PaddingChar, Mode);

            //SET IV
            _rijndael.IV = Encoding.UTF8.GetBytes(AdjustSize(Iv,PaddingChar,32));
        }



        public void Encrypt(string Source)
        {

            ICryptoTransform cryptoTransform = _rijndael.CreateEncryptor();


            byte[] TmpBytes = Encoding.UTF8.GetBytes(Source);
            
            try
            {
                byte[] TfromFBBytes = cryptoTransform.TransformFinalBlock(TmpBytes, 0, TmpBytes.Length);
            
                print = Convert.ToBase64String(TfromFBBytes);
            }
            catch (Exception ex)
            {
                err = ex.ToString();
            }

        }

        public void Decrypt(string Source)
        {
            ICryptoTransform cryptoTransform = _rijndael.CreateDecryptor();
            
            
            byte[] TmpBytes = Convert.FromBase64String(Source); 

            try
            {
                byte[] TfromFBBytes = cryptoTransform.TransformFinalBlock(TmpBytes, 0, TmpBytes.Length);

                print = Encoding.UTF8.GetString(TfromFBBytes);
            }
            catch (Exception ex)
            {
                err = ex.ToString();
            }
        }


        public void Close() => _rijndael.Dispose();


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



        private string AdjustSize(string Origin,char AppendChar,int Size)
        {
            string RemakeStr = String.Empty;


            if (Origin.Length < Size)
            {
                RemakeStr += Origin;

                for (int i = 0; i < Size - Origin.Length; i++)
                    RemakeStr += AppendChar;

            }
            else
            {
                for (int i = 0; i < Origin.Length; i++)
                {
                    RemakeStr += Origin[i];

                    if (i == Size - 1)
                        break;
                }
            }

            return RemakeStr;
        }
    }
}
