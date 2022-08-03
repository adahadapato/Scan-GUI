using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace scan
{
    static class GetUser
    {
        static string UName;
        static string ioLine;
        //static string dir;
        public static string search(string tUID)
        {
            //dir = (OsVersionHelper.Is64BitOperatingSystem()) ? @"c:\program files\" : @"c:\program files(x86)\";
            try
            {
               
                UName = "";
                using (StreamReader ioFile = new StreamReader( UtilityClass.InstallationPath()+   @"necoscan\scan\scan.neco"))
                {

                    while ((ioLine = ioFile.ReadLine()) != null)
                    {
                        if (ioLine.Contains(Encryption.EncryptFileName(tUID).Trim()))
                        {
                            UName = "Found";
                            break;
                        }
                        else
                        {
                            UName = "";
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                UName = "";
                MessageBox.Show(ex.Message, "Get User");
            }

            return UName;
        }
        public static string fetch(string tUID)
        {
            try
            {
                
                UName = "";
                using (StreamReader ioFile = new StreamReader(UtilityClass.InstallationPath()+  @"necoscan\scan\scan.neco"))
                {

                    while ((ioLine = ioFile.ReadLine()) != null)
                    {
                        string hold = Decryption.DecryptFileName(ioLine.Substring(25, 24));
                        string hh = ioLine.Substring(25, 24);
                        if (Decryption.DecryptFileName(ioLine.Substring(25, 24)).ToUpper().Contains(tUID.Trim()))
                        {
                            string result = ioLine.Substring(50, ioLine.Length-50).Trim();
                            string Name = Decryption.DecryptFileName(result);
                            UName = Name.Substring(0,4);
                            break;
                        }
                        else
                        {
                            UName = "";
                        }
                        
                    }

                }
               
            }
            catch (Exception ex)
            {
                UName = "";
                MessageBox.Show(ex.Message,"Get User");
            }

            return UName;
        }
        public static string fetchOperatorName(string tUID)
        {
            try
            {

                UName = "";
                using (StreamReader ioFile = new StreamReader( UtilityClass.InstallationPath()+ @"necoscan\scan\scan.neco"))
                {

                    while ((ioLine = ioFile.ReadLine()) != null)
                    {

                        if (Decryption.DecryptFileName(ioLine.Substring(25, 24)).ToUpper().Contains(tUID.Trim()))
                        {
                            string result = ioLine.Substring(50, ioLine.Length - 50).Trim();
                            string Name = Decryption.DecryptFileName(result);
                            UName = Name.Substring(4, Name.Length - 4);
                            break;
                        }
                        else
                        {
                            UName = "";
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                UName = "";
                MessageBox.Show(ex.Message, "Get User");
            }

            return UName;
        }
        public static string getScanid(string tUID)
        {
            try
            {

                UName = "";
                using (StreamReader ioFile = new StreamReader(UtilityClass.InstallationPath()+@"necoscan\scan\scan.neco"))
                {
                    
                    while ((ioLine = ioFile.ReadLine()) != null)
                    {
                        if (ioLine.Contains(Encryption.EncryptFileName(tUID)))
                        {
                            string result = Decryption.DecryptFileName(ioLine.Substring(25, 24)).Trim();
                            string final = "";
                            string[] hold = new string[8];
                            for (int i = 0; i < 8; i++)
                            {
                                hold[i] = result.Substring(i, 1);
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
                            UName = final;
                            break;
                        }
                        else
                        {
                                UName = "";
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                UName = "";
                MessageBox.Show(ex.Message, "Get User");
            }

            return UName;
        }

        public static string getOperatorName(string tUID)
        {
            try
            {

                UName = "";
                using (StreamReader ioFile = new StreamReader(UtilityClass.InstallationPath()+@"necoscan\scan\scan.neco"))
                {
                    
                    while ((ioLine = ioFile.ReadLine()) != null)
                    {
                        if (ioLine.Contains(Encryption.EncryptFileName(tUID)))
                        {
                            string result = ioLine.Substring(50, ioLine.Length - 50).Trim();
                            string Name = Decryption.DecryptFileName(result);
                            UName = Name.Substring(4, Name.Length - 4);
                            break;
                        }
                        else
                        {
                            UName = "";
                        }

                    }

                }

            }
            catch (Exception ex)
            {
                UName = "";
                MessageBox.Show(ex.Message, "Get User");
            }

            return UName;
        }
    }
}
