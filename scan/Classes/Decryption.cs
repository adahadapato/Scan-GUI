using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace scan
{
    static class Decryption
    {
        static string plaintext;
        public static string iDecrypt(string cipherText, System.Text.Encoding encoding)
        {
            
            try
            {
                /*int decValue = int.Parse(hexValue, System.Globalization.NumberStyles.HexNumber);
                string per_no = Convert.ToString(decValue);
                string[] text = new string[per_no.Length];
                for (int i = 0; i < per_no.Length; i += 2)
                {
                    text[i] = per_no.Substring(i, 2);
                }
                byte[] intText = new byte[4];
                int j = 0;
                for (int i = 0; i < text.Length; i++)
                {

                    if (text[i] != null)
                    {

                        intText[j] = Convert.ToByte(text[i]);
                        j++;

                    }

                }
                plaintext = ASCIIEncoding.ASCII.GetString(intText).ToUpper() ;
                 * */
                int numberChars = cipherText.Length;
                byte[] bytes = new byte[numberChars / 2];
                for (int i = 0; i < numberChars; i+=2)
                {
                    bytes[i / 2] = Convert.ToByte(cipherText.Substring(i, 2), 16);
                }
                
                plaintext = encoding.GetString(bytes);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message.ToString(), "NECO SCAN");
                plaintext = "0000";
            }
            return plaintext;
        
        }

        public static string DecryptFileName(string cipherText)//, string passPhrase, string saltValue,
                                      //string hashAlgorithm, int passwordIterartions,
                                      //string initVector, int keySize)
        {
            string plainText;
            string passPhrase = "Pas5pr@se";
            string saltValue = "s@ltValue";
            string hashAlgorithm = "SHA1";
            int passwordIterations = 1;
            string initVector = "@1B2c3D4e5F6g7H8";
            int keySize = 256;
            
            
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);
            byte[] keyBytes = password.GetBytes(keySize / 16);
            RijndaelManaged symmetricKey = new RijndaelManaged();
            symmetricKey.Mode = CipherMode.CBC;
            ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes);
            MemoryStream memoryStream = new MemoryStream(cipherTextBytes);
            CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            byte[] plainTextBytes = new byte[cipherTextBytes.Length];
            int decryptedbytByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            plainText = Encoding.UTF8.GetString(plainTextBytes, 0, decryptedbytByteCount);
            return plainText;
        }
    }
}
