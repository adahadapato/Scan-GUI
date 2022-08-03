using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace scan
{
    class Encrypt
    {


        string per_no;
        string plaintext;
        public string iEncrypt(string plainText)
        {
            per_no = "";
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            
            for (int i = 0; i < plainTextBytes.Length; i++)
            {
               per_no = per_no + Convert.ToInt32(plainTextBytes[i]);   
            }
            int decvalue = Convert.ToInt32(per_no);
            string hexvalue = decvalue.ToString("X");
            string cipherText = hexvalue;
            return cipherText;
        }


         public string iDecrypt(string cipherText)
         {
             string hexValue = cipherText;
             try
             {
                 int decValue = int.Parse(hexValue, System.Globalization.NumberStyles.HexNumber);
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
                 plaintext = ASCIIEncoding.ASCII.GetString(intText);
             }
             catch (Exception ex)
             {
                 System.Windows.Forms.MessageBox.Show(ex.Message.ToString(), "NECO SCAN");
                 plaintext = "0000";
             }
             return plaintext;
             
         }
    }
}
