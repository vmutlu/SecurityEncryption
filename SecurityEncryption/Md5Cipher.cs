using System.Security.Cryptography;
using System.Text;

namespace SecurityEncryption
{
    public static class Md5Cipher
    {
        /*
         * By Veysel MUTLU -> github.com/vmutlu
         * veysel_mutlu42@hotmail.com
         * 
         * Sample Usage
         * var encrypt = Md5Cipher.Encryption("Şifrelecek Metin");
         */

        /// <summary>
        /// The method returned by encrypting the text received as parameter with the MD5 encryption algorithm
        /// </summary>
        /// <param name="encrypting">Şifrelenecek Metin...</param>
        /// <returns></returns>
        public static string Encryption(string encrypting)
        {
            MD5CryptoServiceProvider mD5CryptoServiceProvider = new MD5CryptoServiceProvider();
            byte[] encryptionArray = Encoding.UTF8.GetBytes(encrypting);
            encryptionArray = mD5CryptoServiceProvider.ComputeHash(encryptionArray);
            StringBuilder stringBuilder = new StringBuilder();

            foreach (byte encry in encryptionArray)
                stringBuilder.Append(encry.ToString("x2").ToLower());

            return stringBuilder.ToString();
        }
    }
}
