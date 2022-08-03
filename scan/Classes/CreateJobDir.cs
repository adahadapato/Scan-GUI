using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.AccessControl;

namespace scan
{
    static class CreateJobDir
    {
        static string ScanDir;
        public static  string  CreateDir(string DirNameToCreate, string ScanTypeDir, string Subject)
        {
            try
            {
                if (Subject.Contains("1"))
                {
                    Subject = @"\Paper1";
                }
                else if (Subject.Contains("2"))
                {
                    Subject = @"\Paper2";
                }
                else
                {
                    Subject = "";
                }
                string DirToCreate = DirNameToCreate + @"\" + ScanTypeDir+Subject ; 
                
                if (!Directory.Exists(DirToCreate))
                {
                    Directory.CreateDirectory(DirToCreate);
                }
                if (Directory.Exists(DirToCreate))
                {
                    ScanDir = DirToCreate;
                }
                else
                {
                    ScanDir = "";
                }
                
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Create Dir");
                ScanDir = "";
            }
            return ScanDir;
        }

        public static void CreateDir(string DirNameToCreate)
        {
            try
            {
                if (!Directory.Exists(DirNameToCreate))
                {
                    Directory.CreateDirectory(DirNameToCreate);
                }
              
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Create Dir");
            }
        }

        public  static string BiuldJobDir(string cexam, string year, string Job, string OthersPath)
        {
            switch (cexam)
            {
                case "SSCE External"://SSCE NOV/DEC Variables
                    if (Job == "Essay")
                    {
                        ScanDir = @"c:\novems" + year.Substring(2, 2);
                        
                    }
                    if (Job == "Obj")
                    {
                        ScanDir = @"c:\novans" + year.Substring(2, 2);
                        
                    }
                    break;
                case "SSCE Internal":
                    if (Job == "Essay")
                    {
                        ScanDir = @"c:\ems" + year;
                    }
                    if (Job == "Obj")
                    {
                        ScanDir = @"c:\sscean" + year.Substring(2, 2);
                        
                    }
                    break;
                case "BECE BECE":
                    if (Job == "Essay")
                    {
                        ScanDir = @"c:\beceems" + year.Substring(2, 2);
                        
                    }
                    if (Job == "Obj")
                    {
                        ScanDir = @"c:\beceans" + year.Substring(2, 2);
                    }
                    break;
                case "NCEE NCEE":
                    if (Job == "Obj")
                    {
                        ScanDir = @"c:\nce" + year;

                    }
                    break;
                case "NEEFUSSC NEEFUSSC":
                    
                    ScanDir = @"c:\neef" + year.Substring(2, 2);
                    
                    break;
                case "Others":
                    ScanDir = OthersPath;
                    
                    break;
            }
            
            string retVal = ScanDir;
            return retVal;
        }
        
        public static bool FindSOSKitw()
        {
            return File.Exists(UtilityClass.InstallationPath() + @"drs\skw\Sosinpw.exe");  
        }
    }
    
}
