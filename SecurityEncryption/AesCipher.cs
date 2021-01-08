using System;
using System.Security.Cryptography;
using System.Text;

namespace SecurityEncryption
{
    public static class AesCipher
    {
        /*
         * By Veysel MUTLU -> github.com/vmutlu
         * veysel_mutlu42@hotmail.com
         * 
         * Sample Usage
         * var encrypt = AesCipher.AESEncrypt("Şifrelecek Metin");
         * var dencrypt = AesCipher.AESDecrypt(encrypt);
         */

        #region Fields

        private const string AES_IV = @"!&+QWSDF!123126+"; 
        private static string _aesKey = @"QQsaw!257()%%ert";

        #endregion

        #region AES Encryption Methods

        /// <summary>
        /// The method returned by encrypting the text received as parameter with the AES encryption algorithm
        /// </summary>
        /// <param name="encryptText"></param>
        /// <returns></returns>
        public static string AESEncrypt(string encryptText)
        {
            AesCryptoServiceProvider aesSaglayici = new AesCryptoServiceProvider();
            aesSaglayici.BlockSize = 128;
            aesSaglayici.KeySize = 128;

            aesSaglayici.IV = Encoding.UTF8.GetBytes(AES_IV);
            aesSaglayici.Key = Encoding.UTF8.GetBytes(_aesKey);
            aesSaglayici.Mode = CipherMode.CBC;
            aesSaglayici.Padding = PaddingMode.PKCS7;

            byte[] resource = Encoding.Unicode.GetBytes(encryptText);
            using (ICryptoTransform encrypt = aesSaglayici.CreateEncryptor())
            {
                byte[] target = encrypt.TransformFinalBlock(resource, 0, resource.Length);
                return Convert.ToBase64String(target);
            }
        }

        #endregion

        #region AES Descryption Methods

        /// <summary>
        /// Returning method by taking the text encrypted with AES as parameter and decrypting it
        /// </summary>
        /// <param name="encryptedText"></param>
        /// <returns></returns>
        public static string AESDecrypt(string encryptedText)
        {
            AesCryptoServiceProvider aesProvider = new AesCryptoServiceProvider();
            aesProvider.BlockSize = 128;
            aesProvider.KeySize = 128;

            aesProvider.IV = Encoding.UTF8.GetBytes(AES_IV);
            aesProvider.Key = Encoding.UTF8.GetBytes(_aesKey);
            aesProvider.Mode = CipherMode.CBC;
            aesProvider.Padding = PaddingMode.PKCS7;

            byte[] resource = System.Convert.FromBase64String(encryptedText);
            using (ICryptoTransform decrypt = aesProvider.CreateDecryptor())
            {
                byte[] target = decrypt.TransformFinalBlock(resource, 0, resource.Length);
                return Encoding.Unicode.GetString(target);
            }
        }

        #endregion

    }
}
