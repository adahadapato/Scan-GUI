using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace scan
{
    static class Encryption
    {

        static string cipherText;
        

        public static string EncryptFileName(string plainText)
        {
            
                string passPhrase = "Pas5pr@se";
                string saltValue = "s@ltValue";
                string hashAlgorithm = "SHA1";
                int passwordIterations = 1;
                string initVector = "@1B2c3D4e5F6g7H8";
                int keySize = 256;

                byte[] initVectorBytes = Encoding.ASCII.GetBytes(initVector);
                byte[] saltValueBytes = Encoding.ASCII.GetBytes(saltValue);
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
                PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, saltValueBytes, hashAlgorithm, passwordIterations);
                byte[] keyBytes = password.GetBytes(keySize / 16);
                RijndaelManaged symmetricaKey = new RijndaelManaged();
                symmetricaKey.Mode = CipherMode.CBC;
                ICryptoTransform encryptor = symmetricaKey.CreateEncryptor(keyBytes, initVectorBytes);
                MemoryStream memoryStream = new MemoryStream();
                CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                cryptoStream.FlushFinalBlock();
                byte[] cipherTextBytes = memoryStream.ToArray();
                memoryStream.Close();
                cryptoStream.Close();
                cipherText = Convert.ToBase64String(cipherTextBytes);
            
            
            return cipherText;
        }
    }
}
