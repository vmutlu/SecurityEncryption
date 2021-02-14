using System;
using System.IO;
using System.Security.Cryptography;

namespace SecurityEncryption
{
    /// <summary>
    /// This class contains methods for encrypting text using the des encryption algorithm and decrypting the encrypted text.
    /// </summary>
    public static class DesCipher
    {
        /*
         * By Veysel MUTLU -> github.com/vmutlu
         * veysel_mutlu42@hotmail.com
         * 
         * Sample Usage
         * var encrypt = DesCipher.Encryption("Şifrelecek Metin");
         * var
         * dencrypt = DesCipher.Descryption(encrypt);
         */

        #region Fields

        private static readonly byte[] _aryKey = Byte8("87654321");
        private static readonly byte[] _aryIV = Byte8("87654321");

        #endregion

        public static byte[] Byte8(string value)
        {
            char[] arrayChar = value.ToCharArray();
            byte[] arrayByte = new byte[arrayChar.Length];

            for (int i = 0; i < arrayByte.Length; i++)
                arrayByte[i] = Convert.ToByte(arrayChar[i]);

            return arrayByte;
        }

        #region Des Encryption Methods

        /// <summary>
        /// This method Des is the method that encrypts the text it receives using the encryption algorithm.
        /// </summary>
        /// <param name="encrypting"></param>
        /// <returns></returns>
        public static string Encryption(string encrypting)
        {
            string response = string.Empty;

            if (encrypting == "" || encrypting == null)
                throw new ArgumentNullException("There is no data to be encrypted.");

            else
            {
                DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateEncryptor(_aryKey, _aryIV), CryptoStreamMode.Write);
                StreamWriter streamWriter = new StreamWriter(cryptoStream);
                streamWriter.Write(encrypting);
                streamWriter.Flush();
                cryptoStream.FlushFinalBlock();
                streamWriter.Flush();
                response = Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
                streamWriter.Dispose();
                cryptoStream.Dispose();
                memoryStream.Dispose();
            }
            return response;
        }

        #endregion

        #region Des Descryption Methods

        /// <summary>
        /// This method Des is a method that decrypts the encrypted text received using the encryption algorithm.
        /// </summary>
        /// <param name="decryption"></param>
        /// <returns></returns>
        public static string Descryption(string decryption)
        {
            string response = string.Empty;

            if (decryption == "" || decryption == null)
                throw new ArgumentNullException("There is no data to be encrypted.");

            else
            {
                DESCryptoServiceProvider dESCryptoServiceProvider = new DESCryptoServiceProvider();
                MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(decryption));
                CryptoStream cryptoStream = new CryptoStream(memoryStream, dESCryptoServiceProvider.CreateDecryptor(_aryKey, _aryIV), CryptoStreamMode.Read);
                StreamReader streamReader = new StreamReader(cryptoStream);
                response = streamReader.ReadToEnd();
                streamReader.Dispose();
                cryptoStream.Dispose();
                memoryStream.Dispose();
            }
            return response;
        }

        #endregion

    }
}
