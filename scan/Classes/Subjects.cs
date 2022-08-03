using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Text;

namespace scan
{
    static class Subjects
    {
        static string ioLine; // Going to hold one line at a time
        static ArrayList ioLines = new ArrayList();
        public static string[] getSubjects(string exam, string Job)
        {
            string eType = getRegistryValues.GetRegistryValue("scanDir");
            ioLines.Clear(); 
            string sfile = UtilityClass.InstallationPath()+ @"necoscan\scan\subj.ref";
            using (StreamReader ioFile = new StreamReader(sfile))
            {

                while ((ioLine = ioFile.ReadLine()) != null)
                {
                    if (ioLine.Substring(0, 4).ToUpper() == exam.ToUpper().Trim())
                    {
                        if (ioLine.Contains(Job.ToUpper()))
                        {
                            if (eType.ToUpper().Contains("NOV"))
                            {
                                if(ioLine.Contains("@"))
                                   ioLines.Add(ioLine);
                            }
                            ioLines.Add(ioLine);
                        }
                    }

                }

            }
            string[] subjArray= new string [ioLines.Count];
            for (int i = 0; i < ioLines.Count; i++)
            {
                subjArray[i]=ioLines[i].ToString();
            }

            return subjArray;
        }
        
    }
}
