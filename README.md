
https://www.nuget.org/packages/SecurityEncryption/ -> You can download the package from this link and secure encryption and decryption.

Example Usage

 Caesar Cipher
 * var encrypt = CeaserCipher.Encryption("Text to Encrypt"); -> encrypts text
 * var solve = CeaserCipher.Descryption(encrypt);            -> decrypts encrypted text
 
 Displacement Cipher
 * var encrypt = Displacement.Encryption("Text to Encrypt"); -> encrypts text
 * var solve = Displacement.Descryption(encrypt);            -> decrypts encrypted text
 
 Zigzag Cipher
 * ZigzagCipher zigzag = new ZigzagCipher("Text to Encrypt",key) -> The value of key will determine the number of rows in the matrix.
 * var encrypt = zigzag.Encryption();                       -> encrypts text
 * var solve =   zigzag.Descryption();                      -> decrypts encrypted text
 
 Vigenere Cipher
 * StringBuilder stringBuilder = new StringBuilder("Text to Encrypt");
 * const string key = "keyword";
 * VigenereCipherr.Encryption(ref stringBuilder, key); // encrypts text
 * Console.WriteLine(stringBuilder);
 * VigenereCipherr.Descryption(ref stringBuilder, key); // decrypts encrypted text
 * Console.WriteLine(stringBuilder);
 
 Aes Cipher
 * var encrypt = AesCipher.AESEncrypt("Text to Encrypt");  -> encrypts text
 * var dencrypt = AesCipher.AESDecrypt(encrypt);           -> decrypts encrypted text

