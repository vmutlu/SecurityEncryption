using System;
using System.Collections.Generic;
using System.Linq;

namespace SecurityEncryption
{
    /// <summary>
    /// This class performs the encryption and decryption process according to the specified characters in return for the letter determined according to the displacement algorithm.
    /// </summary>
    public static class DisplacementCipher
    {
        #region Fields

        private static Dictionary<char, char> _dictionaryWord;

        #endregion

        #region Encryption Methods

        /// <summary>
        /// this method encrypts the incoming string text
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string Encryption(string text)
        {
            if (string.IsNullOrEmpty(text) || text == null)
                throw new NullReferenceException("Text to encrypt cannot be null or null");

            FillWord();
            var output = string.Empty;

            foreach (var character in text)
            {
                output += _dictionaryWord.GetValueOrDefault(character);
            }

            text = output.Replace('\0', '?');
            return text;
        }

        #endregion

        #region Descryption Methods

        /// <summary>
        /// this method serves to decrypt the encrypted text
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string Descryption(string text)
        {
            if(string.IsNullOrEmpty(text) || text == null)
                throw new NullReferenceException("Text to be decrypted cannot be empty or null");

            FillWord();
            var output = string.Empty;

            foreach (var character in text)
            {
                output += _dictionaryWord.FirstOrDefault(d => d.Value.Equals(character)).Key;
            }

            text = output.Replace('\0', '?');
            return text;
        }

        #endregion

        #region Letter equivalents

        /// <summary>
        /// Which letter will come in return for which letter is determined
        /// </summary>
        private static void FillWord()
        {
            _dictionaryWord = new Dictionary<char, char>();
            _dictionaryWord.Add('a', 'z');
            _dictionaryWord.Add('b', 'y');
            _dictionaryWord.Add('c', 'v');
            _dictionaryWord.Add('ç', 'ü');
            _dictionaryWord.Add('d', 'u');
            _dictionaryWord.Add('e', 't');
            _dictionaryWord.Add('f', 'ş');
            _dictionaryWord.Add('g', 's');
            _dictionaryWord.Add('ğ', 'r');
            _dictionaryWord.Add('h', 'p');
            _dictionaryWord.Add('ı', 'ö');
            _dictionaryWord.Add('i', 'o');
            _dictionaryWord.Add('j', 'n');
            _dictionaryWord.Add('k', 'm');
            _dictionaryWord.Add('l', 'l');
            _dictionaryWord.Add('m', 'k');
            _dictionaryWord.Add('n', 'j');
            _dictionaryWord.Add('o', 'i');
            _dictionaryWord.Add('ö', 'ı');
            _dictionaryWord.Add('p', 'h');
            _dictionaryWord.Add('r', 'ğ');
            _dictionaryWord.Add('s', 'g');
            _dictionaryWord.Add('ş', 'f');
            _dictionaryWord.Add('t', 'e');
            _dictionaryWord.Add('u', 'd');
            _dictionaryWord.Add('ü', 'ç');
            _dictionaryWord.Add('v', 'c');
            _dictionaryWord.Add('y', 'b');
            _dictionaryWord.Add('z', 'a');
            _dictionaryWord.Add('A', 'Z');
            _dictionaryWord.Add('B', 'Y');
            _dictionaryWord.Add('C', 'V');
            _dictionaryWord.Add('Ç', 'Ü');
            _dictionaryWord.Add('D', 'U');
            _dictionaryWord.Add('E', 'T');
            _dictionaryWord.Add('F', 'Ş');
            _dictionaryWord.Add('G', 'S');
            _dictionaryWord.Add('Ğ', 'R');
            _dictionaryWord.Add('H', 'P');
            _dictionaryWord.Add('I', 'Ö');
            _dictionaryWord.Add('İ', 'O');
            _dictionaryWord.Add('J', 'N');
            _dictionaryWord.Add('K', 'M');
            _dictionaryWord.Add('L', 'L');
            _dictionaryWord.Add('M', 'K');
            _dictionaryWord.Add('N', 'J');
            _dictionaryWord.Add('O', 'İ');
            _dictionaryWord.Add('Ö', 'I');
            _dictionaryWord.Add('P', 'H');
            _dictionaryWord.Add('R', 'Ğ');
            _dictionaryWord.Add('S', 'G');
            _dictionaryWord.Add('Ş', 'F');
            _dictionaryWord.Add('T', 'E');
            _dictionaryWord.Add('U', 'D');
            _dictionaryWord.Add('Ü', 'Ç');
            _dictionaryWord.Add('V', 'C');
            _dictionaryWord.Add('Y', 'B');
            _dictionaryWord.Add('Z', 'A');
        }

        #endregion
    }
}
