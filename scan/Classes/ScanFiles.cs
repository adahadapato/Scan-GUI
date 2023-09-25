/***********************************************************************************************************************************************
 * this class looks up the scanfiles in the scan directory
 * 
 * 
 * 
 **********************************************************************************************************************************************/ 
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using SCRghelp.Infrastructure;

namespace scan
{
    static class ScanFiles
    {
        
        public static List<string> GetFileData(string FileName)
        {
            var lines = File.ReadAllLines(FileName).ToList();
            if (lines.Count == 0)
                return null;
            var scanData = new List<string>();
            foreach (var l in lines)
                scanData.Add(l);

            return scanData;
        }

        public static string GetLastScanFileName(string ParentDir, string FileName)
        {
            try
            {
                //var s1 = Directory.GetFiles(path , "*.*", SearchOption.AllDirectories).Where(d => !d.StartsWith("<EXCLUDE_DIR_PATH>")).ToArray();
                string scanfile = FileName;//string.Format($"{SubjCode.Trim()}{GetSystemName.SystemName()}{stateCode}");
                //scanfile += "*";
                //ScanDir += @"\";
                //var ParentDir = Path.GetDirectoryName(FileName);
                var ScanFilesList = Directory.GetFiles(ParentDir, scanfile, SearchOption.AllDirectories)
                    .Where(d => !d.Contains("Images")).OrderByDescending(d => UtilityClass.Right(d, 3)).ToList();


               
                if (ScanFilesList.Count > 0) //There are scanfiles in the directory
                {
                    //var newsFiles = CleanScanFiles.CleanFiles(ScanFilesList).ToList().OrderByDescending(x=> x);
                    //long last = newsFiles.Length;
                    //string lastfile = newsFiles[last - 1];
                    return ScanFilesList.FirstOrDefault();//  lastfile;
                }
                else
                {
                    return "000";
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Find scan files");
            }
            return "NILL";

        }
        public static int GetLastScanFileSize(string file)
        {
            try
            {
                
                return (File.ReadAllLines(file).Length > 0) ? 1 : 0;
               
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Get file size");
            }
            return 0; ;
        }
        static RegistryHelperClass rHelper = new RegistryHelperClass();
        public static string GetScanFileOwnerName(string file)
        {
            try
            {
                var line1 = File.ReadLines(file).FirstOrDefault(); // gets the first line from file.
                var input = (rHelper.Job=="Obj")? line1.Substring(122, line1.Length - 122).Trim() : line1.Substring(73, line1.Length - 73);
                string str = new string(input.Where(c => c != '-' && (c < '0' || c > '9')).ToArray()).Trim();
                var s = str.TrimStart('.');
                return s.Trim();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Get file size");
            }
            return "";
        }

        public static string GetScanFileOwnerId(string file)
        {
            try
            {
                var line1 = File.ReadLines(file).FirstOrDefault(); // gets the first line from file.
                var idx = line1.LastIndexOf(':');
                var input = line1.Substring(idx+1, 4).Trim();
                //string str = new string(input.Where(c => c != '-' && (c < '0' || c > '9')).ToArray()).Trim();
                var s = input;
                return s.Trim();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Get file size");
            }
            return "";
        }

        //DateTime creation = File.GetCreationTime(@"C:\test.txt");
        public static string GetScanFileCreationDate(string file)
        {
            try
            {
                var date = File.GetCreationTime(file);
                return date.ToString();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Get file date");
            }
            return "";
        }

        public static string GetScanFileSubject(string file)
        {
            try
            {
                string input = "";
                var line1 = File.ReadLines(file).FirstOrDefault(); // gets the first line from file.
                if (rHelper.Job == "Obj")
                {
                    input = line1.Substring(122, line1.Length - 122).Trim();
                }
                if(rHelper.Job == "Essay")
                {
                    if (rHelper.ExamType == "SSCE")
                    {
                      input =  line1.Substring(6,4).Trim();
                    }
                    else
                    {
                      input =  line1.Substring(62, line1.Length - 62).Trim();
                    }
                }
                  
                string str = input.Substring(0, 4);
                var s = str.TrimStart('.');
                return s.Trim();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Get file subject");
            }
            return "";
        }

        public static int GetScanFileSize(string file)
        {
            try
            {
                return File.ReadAllLines(file).Length ;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Get file size");
            }
            return 0; 
        }

        public static bool CheckBatchCounterValidity(int Number)
        {
            Number++;
            if (Number > 999)
            {
                return false;
            }
            return true;
        }

        public static string GetBatchCounter(int Number)
        {
            var NewNumber = Number + 1;
            if (NewNumber < 10)
            {
               return $"00{NewNumber}";
            }
            if (NewNumber >= 10 && NewNumber <= 99)
            {
               return $"0{NewNumber}";
            }
            if (NewNumber >= 100 && NewNumber < 999)
            {
               return NewNumber.ToString();
            }
            if (NewNumber > 999)
            {
               return "0";
            }
            return "0";
        }

        public static string DecrementBatchCounter(int Number)
        {
            var NewNumber = Number - 1;
            if (NewNumber == 0)
            {
                return "0";
            }
            if (NewNumber < 10)
            {
                return $"00{NewNumber}";
            }
            if (NewNumber >= 10 && NewNumber <= 99)
            {
                return $"0{NewNumber}";
            }
            if (NewNumber >= 100 && NewNumber < 999)
            {
                return NewNumber.ToString();
            }
            if (NewNumber > 999)
            {
                return "0";
            }
            return "0";
        }

        public static void DeleteLastEmptyScanFile(string mPath, string mFile)
        {
            try
            {
                File.Delete(mFile);

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Delete Empty scan file");
            }
        }


        public static string RenameScanFile(string Oldname, string Newname)
        {
            string done;
            try
            {
                if (!File.Exists(Newname))
                {
                    File.Copy(Oldname, Newname);
                    File.Delete(Oldname);
                    done = "File renamed successfully !";
                }
                else
                {
                    done = "Error - file with name "+ Newname +" already exist !" ;
                }
            }
            catch (Exception ex)
            {
                done = "Error "+ex.Message +   " Cannot rename the file";
            }
            return done;
        }
    }
}
