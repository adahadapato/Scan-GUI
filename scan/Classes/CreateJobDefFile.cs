using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using SCRghelp.Infrastructure;
using System.Threading.Tasks;

namespace scan
{
    static class CreateJobDefFile
    {
        
        static string ioLine; // Going to hold one line at a time
        static string ioLines;// Going to hold whole file
        static bool succeed=false;
        static RegistryHelperClass Rh = new RegistryHelperClass();
        //Modify Def File Content here
        //static public bool ModifyDefFle(string filepath, string filename, string ScanDirectory,string Companion,string ExamYear, string ExamType,
        //                        string Subject, string State,string userName,string BatchNumber, string subjCode)
        static public async Task<bool> ModifyDefFle(string filepath, string filename, string ScanDirectory, string Companion, 
                                string Subject, string State,string userName,string BatchNumber, string subjCode)
        {
            string sfile, sosfile ;
            sfile = filepath + @"\" + filename  + ".def";
            sosfile = filepath + @"\" + filename + ".sos";
            /*if (subjCode == "909")
            {
                subjCode = "1014";
            }*/
            try
            {
                var IsCreateSOSFile = await CreateSosAndDefFIles.CreateSosFile(sosfile);
                var IsCreateDefFile = await CreateSosAndDefFIles.CreateDefFile(sfile);
                //if (IsCreateSOSFile && CreateSosAndDefFIles.CreateDefFile(filename, sfile))
                if(IsCreateSOSFile && IsCreateDefFile)
                {
                    //System.Windows.Forms.MessageBox.Show(Companion);
                    string mstate;
                    if ( Rh.ExamType.Contains("SSCE") || Rh.ExamType.Contains("BECE"))
                    {
                        mstate = State.ToUpper();
                    }
                    else
                    {
                        mstate = string.Empty;
                    }
                    using (StreamReader ioFile = new StreamReader(sfile))
                    {

                        while ((ioLine = ioFile.ReadLine()) != null)
                        {
                            if (ioLine.Contains("LastBatchNumber"))
                            {
                                ioLine = "LastBatchNumber=" + BatchNumber;
                            }
                            if (ioLine.Contains("AllowDiscard"))
                            {
                                ioLine = "AllowDiscard=" + "1";
                            }
                            if (ioLine.Contains("ExportDir"))
                            {
                                ioLine = "ExportDir=" + ScanDirectory;
                            }
                            if (ioLine.Contains("ExportFilter="))
                            {
                                ioLine= "ExportFilter=ExpNeco";
                            }
                            if (ioLine.Contains("Companion="))
                            {
                                ioLine= "Companion="+Companion.Trim() ;

                            }

                            if (ioLine.Contains("CompanionAll="))
                            {
                                ioLine= "CompanionAll=1";
                            }

                            if (ioLine.Contains("EnableImaging="))
                            {
                                 ioLine= "EnableImaging=0";

                            }
                            if (ioLine.Contains("CheckImageCapture="))
                            {
                                ioLine = "CheckImageCapture=" + "0";

                            }
                            if (ioLine.Contains("ImageDirectory="))
                            {
                                ioLine = "";

                            }
                            /* if(!GetSystemName.getOSInfo().Contains("XP"))
                             {
                                 if (ioLine.Contains("EnableImaging="))
                                 {
                                    // ioLine = "EnableImaging=" + "1";

                                 }

                                 if (ioLine.Contains("CheckImageCapture="))
                                 {
                                     ioLine = "CheckImageCapture=" + "0";

                                 }

                                /* if (ioLine.Contains("ImageDirectory="))
                                 {
                                     ioLine = string.Format($"ImageDirectory={getRegistryValues.GetRegistryValue("sosDir")}\\Images");

                                 }

                             }*/


                            //BPUFHLJ4
                            /*if (ioLine.Contains("Clip0="))
                            {
                                ioLine = "Clip0="+"\"\"";
                            }*/

                            //ImageDirectory
                            if (sfile.ToUpper().Contains("EMS"))
                            {
                                if (ioLine.Contains("JobTitle"))
                                {
                                    ioLine = string.Format($"JobTitle= {Rh.Examination} {Rh.ExamYear.Trim()} EMS|{Environment.MachineName.ToUpper().Trim()}|{Subject.Trim().ToUpper()}|{userName}");
                                }
                            }
                            else
                            {
                                string type = "";
                                if (ScanDirectory.Contains("Type"))
                                {
                                    string kk = "-"+UtilityClass.Left(UtilityClass.Right(getRegistryValues.GetRegistryValue("scandir"),4),1);
                                    type = kk;
                                }
                                if (ioLine.Contains("JobTitle"))
                                {
                                    /*ioLine = $"JobTitle= " + " " + Rh.Examination.Trim() + " " + Rh.ExamYear.Trim() + " (" +
                                            Environment.MachineName.ToUpper().Trim() + ")" + " - " + Subject.Trim().ToUpper() +"["+ subjCode+type+"]"+
                                            ", " + mstate +
                                            " - " + userName ;*/
                                    ioLine = $"JobTitle= {Rh.Examination} {Rh.ExamYear}|{Environment.MachineName.ToUpper()}|{Subject.Trim().ToUpper()} {subjCode}{type}|{mstate}|{userName}";
                                }
                            }
                            ioLines += ioLine + "\n";
                        }

                    }
                    //System.Windows.Forms.MessageBox.Show(ioLines);
                    //File.Delete(sfile);
                    using (StreamWriter ioFile = new StreamWriter(sfile, false))
                    {
                        ioFile.WriteLine(ioLines);
                    }
                    succeed = true;
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message + "Sosdef file cannot be opened", "Scanning");
                succeed = false;
            }
            return succeed;
        }
    }
}
