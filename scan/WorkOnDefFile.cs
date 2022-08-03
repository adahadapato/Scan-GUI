using System;
using System.Collections.Generic;
using Microsoft.Win32 ;
using System.Text;
using System.IO;
using System.Security.AccessControl;

namespace scan
{
    class WorkOnDefFile
    {
        
        string ioLine; // Going to hold one line at a time
        string ioLines;// Going to hold whole file
        public void CreateDir(string DirNameToCreate, string ParentDir)
        {
            if (!Directory.Exists(DirNameToCreate))
            {
                Directory.CreateDirectory(DirNameToCreate);
            }

            FileInfo fi = new FileInfo(DirNameToCreate);
            File.SetAttributes(DirNameToCreate, FileAttributes.ReadOnly);
            //DirectoryInfo di = new DirectoryInfo(DirNameToCreate);
            //fi.Attributes = FileAttributes.ReadOnly;
            //di.Attributes = FileAttributes.ReadOnly;
            
            //di.Refresh();

            //System.Windows.Forms.MessageBox.Show(fi.Attributes.ToString ());
            //UtilityClass.AddDirectorySecurity(ParentDir, "adahada", FileSystemRights.FullControl, AccessControlType.Deny);   
           /* string DomainName = Environment.UserDomainName.ToString();
            DomainName += @"\";
            string AccountName = Environment.UserName.ToString();
            DomainName += AccountName;
            UtilityClass.AddDirectorySecurity(ParentDir, DomainName, FileSystemRights.AppendData, AccessControlType.Deny);  
            * */
        }

       

        //Instr Function
       


        //Modify Def File Content here
        public void ModifyDefFle(string filepath, string filename, string ScanDirectory,string Companion,string ExamYear, string ExamType,
                                 string Subject, string State,string userName,string BatchNumber)
        {
            string sfile, sosfile ;
            sfile = filepath + @"\" + filename  + ".def";
            sosfile = filepath + @"\" + filename + ".sos";

                string mstate;
                if ( ExamType.Contains("SSCE") || ExamType.Contains ("BECE"))
                {
                    mstate = State.ToUpper ();
                }
                else
                {
                    mstate = string.Empty;
                }
            try
            {
                if (!File.Exists(sosfile))
                {
                    File.Copy(@"c:\program files\necoscan\SosFiles\" + filename + ".sos", sosfile, true);

                }
                if (!File.Exists(sfile))
                {
                    File.Copy(@"c:\program files\necoscan\DefFiles\" + filename + ".def", sfile, true);
                }

                using (StreamReader ioFile = new StreamReader(sfile))
                {

                    while ((ioLine = ioFile.ReadLine()) != null)
                    {
                        if (ioLine.Contains("LastBatchNumber"))
                        {
                            ioLine = "LastBatchNumber=" + BatchNumber;
                        }
                        if (ioLine.Contains("ExportDir"))
                        {
                            ioLine = "ExportDir=" + ScanDirectory;
                        }
                        if (ioLine.Contains("ExportFilter="))
                        {
                            ioLine = "ExportFilter=ExpNeco";
                        }
                        if (ioLine.Contains("Companion="))
                        {
                            ioLine = "Companion=" + Companion.Trim();

                        }

                        if ( sfile.ToUpper().Contains("EMS"))
                        {
                            if (ioLine.Contains("JobTitle"))
                            {
                                ioLine = "JobTitle=" + " " + ExamType.Trim() + " " + ExamYear.Trim() + " EMS (" +
                                        Environment.MachineName.ToUpper().Trim() + ")" + ", " + Subject.Trim().ToUpper() + 
                                        " - " + userName;
                            }
                        }
                        else
                        {

                            if (ioLine.Contains("JobTitle"))
                            {
                                ioLine = "JobTitle=" + " " + ExamType.Trim() + " " + ExamYear.Trim() + " (" +
                                        Environment.MachineName.ToUpper().Trim() + ")" + " - " + Subject.Trim().ToUpper() + ", " + mstate +
                                        " - " + userName;
                            }
                        }
                        ioLines += ioLine + "\n";
                    }

                }
                File.Delete(sfile);
                using (StreamWriter ioFile = new StreamWriter(sfile))
                {
                    ioFile.WriteLine(ioLines);
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message + "Sosdef file cannot be oppened", "NECO SCAN");
            }
        }
    }
}
