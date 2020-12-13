using System.Linq;

namespace SecurityEncryption
{
    /// <summary>
    /// This class encrypts received text using the Zigzag encryption method and decrypts the encrypted text. The words are placed in the matrix by creating columns up to the word length and rows as many as the value received from the user.
    /// </summary>
    public class ZigzagCipher
    {
        /*
        * By Veysel MUTLU -> github.com/vmutlu
        * veysel_mutlu42@hotmail.com
        * 
        * Sample Usage
        * ZigzagCipher zigzag = new ZigzagCipher("Merhaba",5); // 5 burada matrisin satır sayısı kelime uzunlugu kadar da sutun oluşturulacak
        * var encrypt = zigzag.Encryption(); // şifreli metin
        * var dencrypt = zigzag.Descryption(); // şifresi çözülmüş orijinal metin
        */

        #region Fields

        private static int _rowValue;
        private static int _columnValue;

        private static string _zigzagText;
        private static char[,] _zigzagMatrix;

        #endregion

        #region Constructive Method

        /// <summary>
        /// When creating an object from the class, the text and key to be encrypted are retrieved
        /// </summary>
        /// <param name="text"></param>
        /// <param name="keyValue"></param>
        public ZigzagCipher(string text, int keyValue)
        {
            _zigzagText = text;
            _rowValue = keyValue;
            _columnValue = _zigzagText.Count();
            _zigzagMatrix = new char[_rowValue, _columnValue];

            ZigzagMatrixFill();
        }

        #endregion

        #region Encryption Methods

        /// <summary>
        /// This method encrypts the received text by shifting 3 letters in the alphabet and returns the encrypted text.
        /// </summary>
        /// <returns></returns>
        public string Encryption()
        {          
            string output = string.Empty;

            for (int i = 0; i < _rowValue; i++)
            {
                for (int j = 0; j < _columnValue; j++)
                {
                    char zigzagValue = _zigzagMatrix[i, j];

                    if (zigzagValue == '\0')
                    {
                        continue;
                    }

                    output += zigzagValue;
                }
            }

            return output;
        }

        #endregion

        #region Descryption Methods

        /// <summary>
        /// This method returns the encrypted text by shifting -3 letters in the alphabet, converting it to its original text.
        /// </summary>
        /// <returns></returns>
        public string Descryption()
        {
            string output = string.Empty;
            int index = 0;

            while (index < _zigzagText.Length - 1)
            {
                for (int i = 0, j = index; i < _rowValue - 1; i++, j++)
                {
                    output += _zigzagMatrix[i, j];

                    if (index == _zigzagText.Length - 1)
                    {
                        break;
                    }

                    index++;
                }

                for (int i = _rowValue - 1, j = index; i > 0; i--, j++)
                {
                    output += _zigzagMatrix[i, j];

                    if (index == _zigzagText.Length - 1)
                    {
                        break;
                    }

                    index++;
                }
            }

            return output;
        }

        #endregion

        #region Letter equivalents

        /// <summary>
        /// the character is placed one by one in the matrix in a diagonal fashion
        /// </summary>
        private static void ZigzagMatrixFill()
        {
            int index = 0;

            while (index < _zigzagText.Length - 1)
            {
                for (int i = 0, j = index; i < _rowValue - 1; i++, j++)
                {
                    _zigzagMatrix[i, j] = _zigzagText[index];

                    if (index == _zigzagText.Length - 1)
                    {
                        break;
                    }

                    index++;
                }

                for (int i = _rowValue - 1, j = index; i > 0; i--, j++)
                {
                    _zigzagMatrix[i, j] = _zigzagText[index];

                    if (index == _zigzagText.Length - 1)
                    {
                        break;
                    }

                    index++;
                }
            }
        }

        #endregion
    }
}
