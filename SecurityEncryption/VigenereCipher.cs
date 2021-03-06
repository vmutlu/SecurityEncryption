﻿using System;
using System.Text;

namespace SecurityEncryption
{
    /// <summary>
    /// This class performs text encryption and decryption using the vigenere algorithm.
    /// </summary>
    public static class VigenereCipher
    {
        /*
        * By Veysel MUTLU -> github.com/vmutlu
        * veysel_mutlu42@hotmail.com
        * 
        * Sample Usage
        *   StringBuilder stringBuilder = new StringBuilder("Text to Encrypt");
            const string key = "keyword";
            VigenereCipherr.Encryption(ref stringBuilder, key); // encrypts text
            Console.WriteLine(stringBuilder);
            VigenereCipherr.Descryption(ref stringBuilder, key); // decrypts encrypted text
            Console.WriteLine(stringBuilder);
        */

        #region Caesar Encryption Methods

        /// <summary>
        /// This method encrypts using the vigenere algorithm
        /// </summary>
        /// <param name="s"></param>
        /// <param name="key"></param>
        public static void Encryption(ref StringBuilder stringBuilder, string key)
        {
            for (int i = 0; i < stringBuilder.Length; i++) stringBuilder[i] = Char.ToUpper(stringBuilder[i]);
            key = key.ToUpper();
            int j = 0;
            for (int i = 0; i < stringBuilder.Length; i++)
            {
                if (Char.IsLetter(stringBuilder[i]))
                {
                    stringBuilder[i] = (char)(stringBuilder[i] + key[j] - 'A');
                    if (stringBuilder[i] > 'Z') stringBuilder[i] = (char)(stringBuilder[i] - 'Z' + 'A' - 1);
                }
                j = j + 1 == key.Length ? 0 : j + 1;
            }
        }

        #endregion

        #region Ceasar Descryption Methods

        /// <summary>
        /// This method decrypts the text encrypted with the vigenere algorithm.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="key"></param>
        public static void Descryption(ref StringBuilder stringBuilder, string key)
        {
            for (int i = 0; i < stringBuilder.Length; i++) stringBuilder[i] = Char.ToUpper(stringBuilder[i]);
            key = key.ToUpper();
            int j = 0;
            for (int i = 0; i < stringBuilder.Length; i++)
            {
                if (Char.IsLetter(stringBuilder[i]))
                {
                    stringBuilder[i] = stringBuilder[i] >= key[j] ?
                              (char)(stringBuilder[i] - key[j] + 'A') :
                              (char)('A' + ('Z' - key[j] + stringBuilder[i] - 'A') + 1);
                }
                j = j + 1 == key.Length ? 0 : j + 1;
            }
        }

        #endregion
    }
}
