using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace BibliotecaDeClasses.Criptografia
{
    public class Criptography
    {
        public Criptography()
        {
        }

        private RC2CryptoServiceProvider CriaKey(RC2CryptoServiceProvider key)
        {
            key.IV = new byte[] { 137, 220, 146, 142, 243, 0, 169, 32 };
            key.Key = new byte[] { 242, 186, 54, 173, 133, 182, 147, 252, 77, 181, 139, 132, 80, 110, 159, 21 };

            return key;
        }

        private byte[] CamuflaKey(RC2CryptoServiceProvider keyRC2)
        {
            var key = string.Empty;
            string salt = string.Empty;
            if (keyRC2.LegalKeySizes.Length > 0)
            {
                int keySize = key.Length * 8;
                int minSize = keyRC2.LegalKeySizes[0].MinSize;
                int maxSize = keyRC2.LegalKeySizes[0].MaxSize;
                int skipSize = keyRC2.LegalKeySizes[0].SkipSize;
                if (keySize > maxSize)
                {
                    key = key.Substring(0, maxSize / 8);
                }
                else if (keySize < maxSize)
                {
                    int validSize = (keySize <= minSize) ? minSize : (keySize - keySize % skipSize) + skipSize;
                    if (keySize < validSize)
                    {
                        key = key.PadRight(validSize / 8);
                    }
                }
            }
            PasswordDeriveBytes PasswaordDey = new PasswordDeriveBytes(key, ASCIIEncoding.ASCII.GetBytes(salt));
            return PasswaordDey.GetBytes(key.Length);
        }

        public string Encrypt(string key)
        {
            var KeyCript = new RC2CryptoServiceProvider();
            CriaKey(KeyCript);
            var alterKey = CamuflaKey(KeyCript);
            KeyCript.Key = alterKey;

            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = Encoding.UTF8.GetBytes(key);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, KeyCript.CreateEncryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();

                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }


        public string Decrypt(string key)
        {
            var KeyCript = new RC2CryptoServiceProvider();
            CriaKey(KeyCript);
            var alterKey = CamuflaKey(KeyCript);
            KeyCript.Key = alterKey;

            try
            {
                DESCryptoServiceProvider des = new DESCryptoServiceProvider();
                byte[] inputByteArray = Convert.FromBase64String(key);
                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, KeyCript.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(inputByteArray, 0, inputByteArray.Length);
                cs.FlushFinalBlock();
                Encoding enc = Encoding.UTF8;
                return enc.GetString(ms.ToArray());
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

        public T Cast<T>(Type typeObject)
        {
            return (T)Activator.CreateInstance(typeObject);
        }

        public string GeraHashMD5(string key)
        {
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] input = Encoding.ASCII.GetBytes(key);
            byte[] hashCode = md5.ComputeHash(input);

            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < hashCode.Length; i++)
            {
                builder.Append(hashCode[i].ToString("x3"));
            }

            var hash = builder.ToString().Substring(0, 16);
            return hash;
        }
    }
}
