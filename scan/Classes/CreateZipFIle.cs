using System;
using System.IO;
using Ionic.Zip;
using System.Windows.Forms;
using System.Collections.Generic;

namespace scan
{
    public class CreateZipFIle
    {
        static string faultyFilesDir = "";
        static List<string> faultyFiles = new List<string>();
        public static void RemoveDirectories(string sDirectoryPath)
        {
            try
            {
                //This condition is used to delete all files from the Directory
                foreach (string file in System.IO.Directory.GetFiles(sDirectoryPath))
                {
                    System.IO.File.Delete(file);
                }
                //This condition is used to check all child Directories and delete files
                foreach (string subfolder in System.IO.Directory.GetDirectories(sDirectoryPath))
                {
                    RemoveDirectories(subfolder);
                }

                System.IO.Directory.Delete(sDirectoryPath);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           
        }


        private static void DecriptFiles(string fPath, string OPath)
        {
            if (!Directory.Exists(fPath))
                return;

            var files = Directory.GetFiles(fPath);
            if (files.Length == 0)
                return;

            
            foreach (var f in files)
            {
                try
                {
                    var fileE = string.Format($"{Path.GetFileNameWithoutExtension(f)}E");
                    var fileX = Path.GetFileNameWithoutExtension(f);
                    var file =(fileX.Length==7) ? f.Replace(fileX.Substring(0, 7), fileE) : f.Replace(fileX.Substring(0, 5), fileE);
                    var OFile = string.Format($"{OPath}\\{Path.GetFileName(f)}");
                    if (!CryptograhyClass.Decrypt(f, file, CryptograhyClass.EncryptionPWD))
                    {
                        faultyFiles.Add(OFile);
                    }
                }
                catch(Exception)
                {
                    //MessageBox.Show(string.Format($"{ex.Message}\n Corrupt file encountered {f}"), "Export Files", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    continue;
                }
            }

            if (faultyFiles.Count > 0)
            {
                KeepFaultyFiles(faultyFiles, OPath);
                //RemoveFaultyFile(faultyFiles, fPath);
            }
               
        }


        private static void RemoveFaultyFile(List<string> files, string path)
        {
            foreach(var f in files)
            {
                var OFile = string.Format($"{path}\\{Path.GetFileName(f)}");
                var fileX = Path.GetFileNameWithoutExtension(OFile);
                var fileE = string.Format($"{Path.GetFileNameWithoutExtension(OFile)}E");
                var tfile = (fileX.Length == 7) ? OFile.Replace(fileX.Substring(0, 7), fileE) : OFile.Replace(fileX.Substring(0, 5), fileE);

                if (File.Exists(OFile))
                {
                    File.Delete(OFile);
                }
                if (File.Exists(tfile))
                    File.Delete(tfile); 
            }
  
        }


        private static void KeepFaultyFiles(List<string> files, string path)
        {
            if (files.Count == 0)
                return;
            var filePath = (path.Contains("Main_")) ? string.Format($"{faultyFilesDir}Main") : string.Format($"{faultyFilesDir}Disc");

            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);

            

            foreach(var f in files)
            {
                if(File.Exists(f))
                {
                    var file = string.Format($"{filePath}\\{Path.GetFileName(f)}");
                    File.Move(f, file);
                }
                
            }
            
        }


       

        private static void ProcessDir(string sourceDir, string destinationDir)
        {
            if (!Directory.Exists(destinationDir))
                Directory.CreateDirectory(destinationDir);

            if (!Directory.Exists(sourceDir))
                return;

            var files = Directory.GetFiles(sourceDir);

            if (files.Length == 0)
                return;

            foreach(var f in files)
            {
                try
                {
                    if (f.Length > 0)
                    {
                        var file = string.Format($"{destinationDir}\\{Path.GetFileName(f)}");
                        File.Copy(f, file);
                    }
                    else
                    {
                        faultyFiles.Add(f);
                    }
                }
                catch(Exception)
                {
                    faultyFiles.Add(f);
                    continue;
                }
            }

        }


        public static bool CompressFiles(string drive, out string mainDirIn, out string discDirIn)
        {
            try
            {
                string startPath =  getRegistryValues.GetRegistryValue("sosDir");//source folder
                faultyFilesDir = string.Format($"{startPath}\\faulty\\");
                var system = GetSystemName.SystemName();
                
                var mainDirToCopy = string.Format($"{getRegistryValues.GetRegistryValue("scanDir")}");
                var tempmainDirToCopy = string.Format($"C:\\Main_{system}");
                mainDirIn = tempmainDirToCopy;

                if (Directory.Exists(tempmainDirToCopy))
                    RemoveDirectories(tempmainDirToCopy);

                ProcessDir(mainDirToCopy, tempmainDirToCopy);
                DecriptFiles(tempmainDirToCopy, mainDirToCopy);

                RemoveFaultyFile(faultyFiles, tempmainDirToCopy);

                var discardDirToCopy = string.Format($"{startPath}\\Disc_{system}\\");
                var tempdiscardDirToCopy= string.Format($"C:\\Disc_{system}\\");
                discDirIn = tempdiscardDirToCopy;
                if (Directory.Exists(tempdiscardDirToCopy))
                    RemoveDirectories(tempdiscardDirToCopy);

                ProcessDir(discardDirToCopy, tempdiscardDirToCopy);
                DecriptFiles(tempdiscardDirToCopy, discardDirToCopy);

                RemoveFaultyFile(faultyFiles, tempdiscardDirToCopy);

                string zipPath = string.Format($"{startPath}\\SYS_{system}.zip");// Destination folder and file
                string Destination = string.IsNullOrEmpty(drive) ? string.Format($"{startPath}\\SYS_{system}.zip") : string.Format($"{drive}SYS_{system}.zip");
                
                
                if (File.Exists(zipPath))
                {
                    string prompt = string.Format($"The file {zipPath} already exist, do you want to ovewrite it" );
                    if (MessageBox.Show(prompt, "Export", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        File.Delete(zipPath);
                    }
                    else
                    {
                        return false;
                    }
                }



                using (ZipFile zip = new ZipFile())
                {
                    zip.UseUnicodeAsNecessary = true;
                    zip.AddDirectory(tempmainDirToCopy, tempmainDirToCopy);

                    if(Directory.Exists(tempdiscardDirToCopy))
                        zip.AddDirectory(tempdiscardDirToCopy, tempdiscardDirToCopy);

                    zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression;
                    zip.Comment = "This zip was created at " + DateTime.Now.ToString("G");
                    zip.Save(zipPath);
                    File.Move(zipPath, Destination);
                }

                if(faultyFiles.Count>0)
                      MessageBox.Show("Some Data files were not zipped & exported successfully", "Export data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("All Data zipped & exported successfully", "Export data", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return true;

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Zip files");
                mainDirIn = null;
                discDirIn = null;
                return false;
            }


        }

    }
}
