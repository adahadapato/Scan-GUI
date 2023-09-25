using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using SCRghelp.Infrastructure;

namespace scan
{
    static class ICreateBatchNumber
    {
        static string LastBatchCounter, BatchCounter;
        static int tempbatch;
        static string SOSInpBatchFileName;
        static RegistryHelperClass _Helper = new RegistryHelperClass();
        //Batch number Creation
        public static string CreateBatchNumber(string ParentDir, string ScanDir,  string SubjCode, string stateCode, string Job)
        {
            //RegistryHelperClass _Helper = new RegistryHelperClass();
            //System.Windows.Forms.MessageBox.Show(SubjCode, "ICreate Batch");
            try
            {
                if (_Helper.ExamType.ToUpper().Contains("NCEE") || _Helper.ExamType.ToUpper().Contains("NEEFUSSC") || _Helper.ExamType.ToUpper().Contains("GIFT"))
                {
                    stateCode = "";
                }
              
                string scanpath = ScanDir;
                string sysno = GetSystemName.SystemName();
                if (sysno != "Invalid")
                {
                    string scanfile = (_Helper.Job=="Essay" )? $"{_Helper.SubjCode.Trim()}{sysno}" : $"{SubjCode.Trim()}{sysno}{stateCode}";
                    
                    tempbatch = Convert.ToInt32(scanfile);
                    scanfile += "*";
                    SOSInpBatchFileName = (_Helper.Job == "Essay" )? $"{_Helper.SubjCode.Trim()}{sysno}" : $"{SubjCode.Trim()}{sysno}";
                    BatchCounter = ScanFiles.GetLastScanFileName(ParentDir, scanfile);// ScanDir, SubjCode + paper, stateCode);
                    if (BatchCounter != "000" && BatchCounter != "NILL")
                    {
                        var LastScanFileName = BatchCounter;
                        LastBatchCounter = UtilityClass.Right(BatchCounter, 3);
                        if (ScanFiles.GetLastScanFileSize(LastScanFileName) == 1)
                        {
                            var BatchCounterValidity = ScanFiles.CheckBatchCounterValidity(Convert.ToInt32(LastBatchCounter));
                            if (!BatchCounterValidity)
                            {

                                System.Windows.Forms.MessageBox.Show("Batch Counter has exceeded allowed figure for this subject (999)\n" +
                                    "please use another system to continue scanning the state and subject");
                                return "000000.000";
                            }

                            var NewBatchCounter = ScanFiles.GetBatchCounter(Convert.ToInt32(LastBatchCounter));
                            if (Convert.ToInt32(NewBatchCounter) == 0)
                            {
                                System.Windows.Forms.MessageBox.Show("Batch Counter has exceeded allowed figure for this subject (999)\n" +
                                   "please use another system to continue scanning the state and subject");
                                return "000000.000";
                            }
                            var NewScanFileName = $"{Path.GetFileNameWithoutExtension(LastScanFileName)}.{NewBatchCounter}";
                            _Helper.BatchNumber = NewScanFileName;
                            //System.Windows.Forms.MessageBox.Show(_Helper.BatchNumber);
                            _Helper.SOSInpBatchFileName = $"{SOSInpBatchFileName}{NewBatchCounter}";
                            SOSInpBatchFileName += ScanFiles.DecrementBatchCounter(Convert.ToInt32(NewBatchCounter));
                            //System.Windows.Forms.MessageBox.Show(SOSInpBatchFileName, "SOSinp Subject code");
                            return SOSInpBatchFileName;


                        }
                        else
                        {
                            ScanFiles.DeleteLastEmptyScanFile(ParentDir, LastScanFileName);
                            var NewScanFileName = Path.GetFileName(LastScanFileName);
                            _Helper.BatchNumber = NewScanFileName;
                            
                            _Helper.SOSInpBatchFileName = $"{SOSInpBatchFileName}{UtilityClass.Right(LastScanFileName,3)}";
                            SOSInpBatchFileName += ScanFiles.DecrementBatchCounter(Convert.ToInt32(UtilityClass.Right(LastScanFileName, 3)));
                            return SOSInpBatchFileName;
                        }
                    }
                    if (BatchCounter == "000")
                    {
                        LastBatchCounter = BatchCounter;
                        var BatchCounterValidity = ScanFiles.CheckBatchCounterValidity(Convert.ToInt32(LastBatchCounter));
                        if (!BatchCounterValidity)
                        {
                            System.Windows.Forms.MessageBox.Show("Batch Counter has exceeded allowed figure for this subject (999)\n" +
                                "please use another system to continue scanning the state and subject");
                            return "000000.000";
                        }
                        var NewBatchCounter = ScanFiles.GetBatchCounter(Convert.ToInt32(LastBatchCounter));
                        if (Convert.ToInt32(NewBatchCounter) == 0)
                        {
                            System.Windows.Forms.MessageBox.Show("Batch Counter has exceeded allowed figure for this subject (999)\n" +
                               "please use another system to continue scanning the state and subject");
                            return "000000.000";
                        }
                        var NewScanFileName = $"{tempbatch}.{NewBatchCounter}";
                        _Helper.BatchNumber = NewScanFileName;
                        _Helper.SOSInpBatchFileName = $"{SOSInpBatchFileName}{NewBatchCounter}";
                        SOSInpBatchFileName += BatchCounter;
                        //System.Windows.Forms.MessageBox.Show(SOSInpBatchFileName, "SOSinp Subject code for 000 batch");
                        return SOSInpBatchFileName;

                    }
                    if (LastBatchCounter == "NILL")
                    {
                        return "000000.000";
                    }
                    //NewBatchNumber = OldBatchNumber;
                }
                else
                {
                    return "000000.000";
                }


            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Create Batchnumber");

            }

            return "000000.000";
        }

    } 
}
        
    

