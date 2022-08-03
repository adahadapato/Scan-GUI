using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace scan
{
    public class CreateFiles
    {
        private string Job;
        private string Exam;

        public CreateFiles(string Job, string Exam)
        {
            this.Job = Job;
            this.Exam = Exam;
        }

        public void CreateWorkingFiles()
        {
            switch (Exam.Substring (0,4))
            {
                case "SSCE":
                    string temp = getRegistryValues.GetRegistryValue("scandir") + "temp_" + GetSystemName.SystemName();
                    temp += ".dbf";
                    string log = getRegistryValues.GetRegistryValue("scandir") + "log_" + GetSystemName.SystemName();
                    log += ".val";
                    string[] workingfiles = { "subjref.dbf", "state.dbf", "fin.dbf" };
                    foreach (string f in workingfiles)
                    {
                        string newfile = getRegistryValues.GetRegistryValue("scandir") + f;
                        if (!File.Exists(newfile))
                        {
                            File.Copy(UtilityClass.InstallationPath()+@"necoscan\Programes\ssce_data\" + f, newfile, true);
                        }
                    }
                    if (!File.Exists(temp))
                    {
                        File.Copy(UtilityClass.InstallationPath()+@"necoscan\Programes\ssce_data\temp.dbf", temp, true);
                    }
                    break;
            }
           
           

        }
    }
}
