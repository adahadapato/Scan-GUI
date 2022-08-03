using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;
using scan.Models;
using System.Threading.Tasks;

namespace scan
{
    static class CountNumberOfFormsScanned
    {
        static string ioLine; // Going to hold one line at a time
        static string[] files,keep;
        
        //static long tcount;
        static int NumberOfFormsScanned = 0;


        public static long OperatorFileContentCountAll(out List<OStatModel> model)
        {
            long NumberOfFormsScanned = 0;
            model = new List<OStatModel>();
            //var useName = "PHILLIP .O.GODDAY";
            var useName = getRegistryValues.GetRegistryValue("UID").ToString().Trim();
            if (useName == "UID")
                return 0;

            var scanDir = getRegistryValues.GetRegistryValue("scanDir");
            var destinationDir = string.Format($"c:\\Main_{GetSystemName.SystemName()}\\");
            if (Directory.Exists(destinationDir))
                CreateZipFIle.RemoveDirectories(destinationDir);

            var Tempfiles = Directory.GetFiles(scanDir)
                   .Where(x => new FileInfo(x).Length>0).ToArray();

            ProcessDir(Tempfiles, destinationDir);

            var files = Directory.GetFiles(destinationDir);

            var temp = GetFilesByOperator(files, useName);

            foreach (var m in temp)
            {
                var info = new FileInfo(m);
                var fdate = info.LastWriteTime.Date.ToShortDateString();
                var fname = info.Name;
                var lineCount = File.ReadLines(m).Count();

                model.Add(new OStatModel
                {
                    date = fdate,
                    file = fname,
                    total = lineCount,
                });
            }

            foreach (var p in temp)
            {
                NumberOfFormsScanned += File.ReadLines(p)
                   .Select(line => Regex.Matches(line, useName).Count)
                   .Sum();

            }

            return NumberOfFormsScanned;
        }


        public static long OperatorFileContentCountForToday(out List<OStatModel> model)
        {
            long formsScanned = 0;
            model = new List<OStatModel>();
            //var useName = "PHILLIP .O.GODDAY";// getRegistryValues.GetRegistryValue("UID").ToString().Trim();
            var useName = getRegistryValues.GetRegistryValue("UID").ToString().Trim();
            if (useName == "UID")
                return 0;

            var scanDir = getRegistryValues.GetRegistryValue("scanDir");
            var destinationDir = string.Format($"c:\\Main_{GetSystemName.SystemName()}\\");
            if(Directory.Exists(destinationDir))
                CreateZipFIle.RemoveDirectories(destinationDir);

            //var today = DateTime.Today.AddDays(-1).Date.ToShortDateString();
            var today= DateTime.Today.Date.ToShortDateString();

            var Tempfiles = Directory.GetFiles(scanDir)
                    .Where(x => new FileInfo(x).LastWriteTime.Date.ToShortDateString() == today).ToArray();

            ProcessDir(Tempfiles, destinationDir);

            var files = Directory.GetFiles(destinationDir);

            var temp = GetFilesByOperator(files, useName);

            foreach(var m in temp)
            {
                var info = new FileInfo(m);
                var fdate = info.LastWriteTime.Date.ToShortDateString();
                var fname = info.Name;
                var lineCount = File.ReadLines(m).Count();

                model.Add(new OStatModel
                {
                    date = fdate,
                    file = fname,
                    total = lineCount,
                });
            }


            foreach (var p in temp)
            {
                formsScanned += File.ReadLines(p)
                   .Select(line => Regex.Matches(line, useName).Count)
                   .Sum();

            }
            return formsScanned;
        }


        private static object _lockObject = new object();
        public static IEnumerable<string> GetFilesByOperator(string[] files, string searchterm)
        {
            var result = new List<string>();
            try
            {
                //var dirs = Directory.EnumerateDirectories(path);
                

                //Parallel.ForEach(Dirs, dir =>
                //{
                //var files = Directory.EnumerateFiles(dir);
                Parallel.ForEach(files, file =>
                {
                    var allFileLines = File.ReadAllLines(file);
                    foreach (var line in allFileLines)
                    {
                        if (line.IndexOf(searchterm, StringComparison.CurrentCultureIgnoreCase) >= 0)
                        {
                            lock (_lockObject)
                            {
                                result.Add(file);
                            }
                            break;
                        }
                    }
                });
                //});

                return result;
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return result;
        }

        private static void ProcessDir(IEnumerable<string> sourceFiles, string destinationDir)
        {
            if (!Directory.Exists(destinationDir))
                Directory.CreateDirectory(destinationDir);

            if (sourceFiles.Count()==0)
                return;

            
            foreach (var f in sourceFiles)
            {
                try
                {
                    var file = string.Format($"{destinationDir}\\{Path.GetFileName(f)}");
                    if (!CryptograhyClass.Decrypt(f, file))
                    {
                        File.Delete(file);
                    }   
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }


        private static string[] getTodayFiles(string spath, string[] files)
        {
            keep = new string[files.Length];
            int kk = 0;
            DateTime dt = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            for (int i = 0; i < files.Length; i++)
            {
                string[] tfile = Directory.GetFiles(spath, files[i], SearchOption.AllDirectories);
                //System.Windows.Forms.MessageBox.Show(tfile[0]+" "+File.GetCreationTime(tfile[0]).ToShortDateString() + "\n" +
                //"Today's date "+DateTime.Now.ToShortDateString());
                if (Convert.ToDateTime(File.GetCreationTime(tfile[0]).ToShortDateString()) == dt)
                {

                    keep[kk] = files[i];
                    kk++;
                }

            }
            Array.Resize(ref keep, kk);
            Array.Resize(ref files, keep.Length);
            for (int j = 0; j < files.Length; j++)
            {
                files[j] = keep[j];
            }
            return files ;
        }

        public static string[] getFile(string spath, string sfile, bool today, bool withUserName)
        {
            try
            {
                //count = 0;
                sfile += "*";
                files = CleanScanFiles.CleanFiles(Directory.GetFiles(spath, sfile, SearchOption.AllDirectories));
                if (today && !withUserName )
                {
                    getTodayFiles(spath,files); 
                }

                if (withUserName   && today)
                {
                    keep = getTodayFiles(spath,files);
                    int kk = 0;
                    string UserName = getRegistryValues.GetRegistryValue("UID").ToString();
                    for (int i = 0; i < keep.Length ; i++)
                    {
                        string[] f = Directory.GetFiles(spath,keep[i], SearchOption.AllDirectories );
                        using (StreamReader ioFile = new StreamReader(f[0]))
                        {

                            while ((ioLine = ioFile.ReadLine()) != null)
                            {
                                if (ioLine.Contains(UserName))
                                {
                                    keep[kk] = keep[i];
                                    kk++;
                                    break;
                                }


                            }

                        }
                    }
                    Array.Resize(ref keep, kk);
                    Array.Resize(ref files, keep.Length);
                    for (int j = 0; j < files.Length; j++)
                    {
                        files[j] = keep[j];
                    }

                }

                if (withUserName && !today )
                {
                    keep = new string[files.Length ];
                    int kk = 0;
                    string UserName = getRegistryValues.GetRegistryValue("UID").ToString();
                    for (int i = 0; i < files.Length; i++)
                    {
                        string[] f = Directory.GetFiles(spath, files[i], SearchOption.AllDirectories);
                        using (StreamReader ioFile = new StreamReader(f[0]))
                        {

                            while ((ioLine = ioFile.ReadLine()) != null)
                            {
                                if (ioLine.Contains(UserName))
                                {
                                    keep[kk] = files[i];
                                    kk++;
                                    break;
                                }


                            }

                        }
                    }
                    Array.Resize(ref keep, kk);
                    Array.Resize(ref files, keep.Length);
                    for (int j = 0; j < files.Length; j++)
                    {
                        files[j] = keep[j];
                    }

                }

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            return files;

        }
        
        static int CountLines(string sFile)
        {
            int NumberOfForms=0;
            using (StreamReader sr = new StreamReader(sFile))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    NumberOfForms++;
                }
            }
            return NumberOfForms;
        }

        public static string[] GetFilesScanned(string mPath,string mFile)
        {
           string[] ScanFiles = Directory.GetFiles(mPath, mFile,SearchOption.AllDirectories);
           return ScanFiles; 
        }

        public static int GetFiles(string UserName, string Path)
        {

            using (StreamReader sr = new StreamReader(Path))
            {
                string Contents = sr.ReadToEnd();
                if (Regex.IsMatch(Contents, UserName))
                {

                }
            }
            return NumberOfFormsScanned;
        }

    }
}
