using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace scan
{
    static class ICreateBatchNumber
    {
        static string NewBatchNumber, OldBatchNumber;
        static int tempbatch;//, addin;
        //Batch number Creation
        public static string CreateBatchNumber(string ScanDir, string SubjCode, string stateCode,string examType,string job)
        {

            try
            {
                if (examType.ToUpper().Contains("NCEE") || examType.ToUpper().Contains("NEEFUSSC") )
                {
                    stateCode = "";

                }
                string scanpath = ScanDir;
                string sys = Environment.MachineName.Trim();
                string sysno = sys.Substring(3, 2);
                string scanfile = SubjCode.Trim() + sysno + stateCode;
                tempbatch = Convert.ToInt32(scanfile);
                scanfile += "*";
                string fpath = scanpath + @"\";
                string[] sfiles = Directory.GetFiles(fpath, scanfile);//Read scanfiles into array
                if (sfiles.Length > 0) //There are scanfile in the directory
                {
                    int i = 0;
                    foreach (string s in sfiles)
                    {
                        string store = s;

                        do
                        {
                            int pos = UtilityClass.Instr(store, @"\");
                            if (pos > 0)
                            {
                                store = store.Substring((pos + 1), (store.Length - (pos + 1)));
                            }
                        } while (store.Contains(@"\"));
                        if (i < sfiles.Length)
                        {
                            sfiles[i] = store;
                        }
                        i++;
                    }

                    Array.Sort(sfiles);
                    long last = sfiles.Length;
                    string lastfile = sfiles[last - 1];
                    FileInfo fInfo = new FileInfo(fpath + lastfile);
                    int CheckPoint = UtilityClass.Instr(lastfile, ".");
                    if (fInfo.Length > 0)
                    {
                        if (UtilityClass.getBatchCounter(Convert.ToInt32(UtilityClass.Right(lastfile, 3))) == "Invalid Counter")
                        {
                            OldBatchNumber = "000000.000";
                            System.Windows.Forms.MessageBox.Show("Batch Counter has exceeded 999\n"+
                                "please use another system to continue scanning the state and subject");
                        }
                        else
                        {
                            if (SubjCode.Length > 1)
                            {
                                string lastbatch = lastfile.Trim().Substring(0, (CheckPoint - 2)) + lastfile.Trim().Substring((CheckPoint + 1), 3);
                                OldBatchNumber = lastbatch.Trim();
                            }
                            else
                            {
                                string lastbatch = lastfile.Trim().Substring(0, CheckPoint);
                                OldBatchNumber = lastbatch.Trim();
                            }
                        }
                    }
                    else
                    {
                        if (SubjCode.Length > 1)
                        {
                            string lastbatch = lastfile.Trim().Substring(0, (CheckPoint - 2));
                            lastbatch += UtilityClass .Right (lastfile.Trim(),3);
                            tempbatch = Convert.ToInt32(UtilityClass.Right(lastbatch.Trim(),3));
                            tempbatch--;
                            OldBatchNumber = lastbatch.Trim().Substring(0, (CheckPoint - 2)) + UtilityClass.getBatchCounter(tempbatch)+ tempbatch.ToString();
                        }
                        else
                        {
                            string lastbatch = UtilityClass.Left(lastfile.Trim(),6);//.Substring(0, 6);
                            tempbatch = Convert.ToInt32(lastbatch.Trim().Substring(3 , 3));
                            tempbatch--;
                            OldBatchNumber = lastbatch.Trim().Substring(0, 3) + UtilityClass.getBatchCounter(tempbatch) +tempbatch.ToString();
                        }
                        File.Delete(fpath + lastfile);
                    }
                }
                else
                {
                    
                    int len = tempbatch.ToString().Length;
                    len = len - 2;
                    OldBatchNumber = Convert.ToInt32(UtilityClass.Left(tempbatch.ToString(), len)) + "000";
                    if (examType.ToUpper().Contains("NCEE") || examType.ToUpper().Contains("NEEFUSSC"))
                    {

                        OldBatchNumber = Convert.ToInt32(tempbatch.ToString()) + "000";
                    }

                }

                NewBatchNumber = OldBatchNumber;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Create Batchnumber");
                NewBatchNumber = "000000.000";
            }
            return NewBatchNumber;
        }
    }
}
