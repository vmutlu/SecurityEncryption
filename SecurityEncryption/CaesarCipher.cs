using System;

namespace SecurityEncryption
{
    /// <summary>
    /// This class contains methods for encrypting text using the caesar encryption algorithm and decrypting the encrypted text.
    /// </summary>
    public static class CaesarCipher
    {
        /*
         * By Veysel MUTLU -> github.com/vmutlu
         * veysel_mutlu42@hotmail.com
         * 
         * Sample Usage
         * var encrypt = CeaserCipher.Encryption("Şifrelecek Metin");
         * var dencrypt = CeaserCipher.Descryption(encrypt);
         */

        #region Fields

        private const int _encryptionKey = 3;
        private static string _textEncryptionOutput = string.Empty;
        private static string _textDescryptionOutput = string.Empty;

        #endregion

        #region Caesar Encryption Methods

        /// <summary>
        /// This method encrypts the received text by shifting 3 letters in the alphabet and returns the encrypted text.
        /// </summary>
        /// <param name="encrypting"></param>
        /// <returns></returns>
        public static string Encryption(string encrypting)
        {
            if (string.IsNullOrEmpty(encrypting) || encrypting == null)
                throw new NullReferenceException("Text to encrypt cannot be null or null");

            foreach (var allCharacter in encrypting)
                _textEncryptionOutput += (char)((allCharacter + _encryptionKey) % 127);

            encrypting = _textEncryptionOutput;
            return encrypting;
        }

        #endregion

        #region Ceasar Descryption Methods

        /// <summary>
        /// This method returns the encrypted text by shifting -3 letters in the alphabet, converting it to its original text.
        /// </summary>
        /// <param name="decryption"></param>
        /// <returns></returns>
        public static string Descryption(string decryption)
        {
            if (string.IsNullOrEmpty(decryption) || decryption == null)
                throw new NullReferenceException("Text to be decrypted cannot be empty or null");

            foreach (var allCharacter in decryption)
                _textDescryptionOutput += (char)((allCharacter - _encryptionKey) % 127);

            decryption = _textDescryptionOutput;
            return decryption;
        }

        #endregion
    }
}
