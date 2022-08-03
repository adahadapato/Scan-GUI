using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace scan
{
    static class CreateUser
    {
        public static void newUser(string muid, string mname)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(UtilityClass.InstallationPath()+@"necoscan\scan\scan.neco", true))
                {
                    string number = Encryption.EncryptFileName(muid + mname.Trim());
                    string scanid = number.Substring(0, 8);
                    string final = "";
                    string[] hold = new string[8];
                    for (int i = 0; i < 8; i++)
                    {
                        hold[i] = scanid.Substring(i, 1);
                    }
                    for (int j = 0; j < 8; j++)
                    {
                        if (hold[j] == "/")
                        {
                            hold[j] = "7";
                        }
                        if (hold[j] == "+")
                        {
                            hold[j] = "Q";
                        }
                        final += hold[j].ToUpper();
                    }
                    sw.WriteLine(Encryption.EncryptFileName(muid) + " " + Encryption.EncryptFileName(final) + " " + number.Trim());
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "New User");
            }
        }
      
    }
}
