using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SecurityEncryption
{
    public static class RsaCipher
    {
        /*
         * By Veysel MUTLU -> github.com/vmutlu
         * veysel_mutlu42@hotmail.com
         * 
         * Sample Usage
         * var rsaKey = RsaCipher.GetKey();
         * var encrypt = RsaCipher.Encrypt("Şifrelecek Metin", rsaKey["PublicKey"]);
         * var dencrypt = RsaCipher.Decrypt(encrypt,rsaKey["PrivateKey"]);
         */

        #region RSA Encryption Methods

        /// <summary>
        /// This method RSA is the method that encrypts the text it receives using the encryption algorithm.
        /// </summary>
        /// <param name="encrypting">Şifrelecek metin</param>
        /// <param name="publicKey">public anahtar</param>
        /// <returns></returns>
        public static string Encrypt(string encrypting, string publicKey)
        {
            RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider();
            rSACryptoServiceProvider.FromXmlString(publicKey);

            byte[] byteText = Encoding.UTF8.GetBytes(encrypting);
            byte[] byteEntry = rSACryptoServiceProvider.Encrypt(byteText, false);

            return Convert.ToBase64String(byteEntry);
        }

        #endregion

        #region RSA Descryption Methods

        /// <summary>
        /// This method Des is a method that decrypts the encrypted text received using the encryption algorithm.
        /// </summary>
        /// <param name="decryption">Şifreli metin</param>
        /// <param name="privateKey">Private anahtar </param>
        /// <returns></returns>
        public static string Decrypt(string decryption, string privateKey)
        {
            RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider();
            rSACryptoServiceProvider.FromXmlString(privateKey);

            byte[] byteEntry = Convert.FromBase64String(decryption);
            byte[] byteText = rSACryptoServiceProvider.Decrypt(byteEntry, false);

            return Encoding.UTF8.GetString(byteText);
        }

        #endregion

        /// <summary>
        /// This method is used to create public and private keys.
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> GetKey()
        {
            Dictionary<string, string> keyValuePair = new Dictionary<string, string>();
            RSACryptoServiceProvider rSACryptoServiceProvider = new RSACryptoServiceProvider();

            keyValuePair.Add("PublicKey", rSACryptoServiceProvider.ToXmlString(false));
            keyValuePair.Add("PrivateKey", rSACryptoServiceProvider.ToXmlString(true));

            return keyValuePair;
        }
    }
}
