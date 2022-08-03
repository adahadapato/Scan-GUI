using System;
using System.Collections.Generic;
using System.Text;

namespace scan
{
    static class InitializeValues
    {
        static string ComDefFile, ComCompanion;
        static string DFile;
        //internal static string[] StoreVals(string cexam, string year, string  comJob,string ComSubject,string comSheet, int AnswerSheet, string OthersPath)
        internal static string[] StoreVals(string cexam, string comJob, string ComSubject, int AnswerSheet, string OthersPath)
        {
            switch (cexam.Substring(0,4) )
            {
                case "SSCE"://SSCE NOV/DEC Variables
                    if (comJob == "Essay")
                    {
                        ComDefFile = "ssce_ems";
                    }
                    if (comJob == "Obj")
                    {
                       ComDefFile = LoadDefFile(AnswerSheet,cexam ); 
                    }
                    break;
                
                case "BECE":
                    if (comJob == "Essay")
                    {
                       ComDefFile = "bece_ems";

                    }
                    if (comJob == "Obj")
                    {
                       ComDefFile = LoadDefFile(AnswerSheet,cexam); 
                        
                    }
                    break;
                case "NCEE":
                    
                    ComDefFile = "ncescan" + ComSubject.Substring(6, 1);
                    break;
                case "NEEF":
                    
                    ComDefFile = "neefscan" + ComSubject.Substring(6, 1);
                    break;
                case "Others":
                    
                    break;
            }
            if (!string.IsNullOrEmpty(OthersPath))
            {
                ComCompanion = "";
            }
            else
            {
                switch (getRegistryValues.GetRegistryValue("Scanner"))
                {
                    case "CD":
                        ComCompanion = "dCompanion.companion";
                        break;
                    case "PS":
                        ComCompanion = "sCompanion.companion, " + UtilityClass.InstallationPath()+@"necoscan\companion\sCompanion.dll";
                        break;
                    default:
                        ComCompanion = "";
                        break;
                }
                
            }
            string[] retVal = {ComDefFile ,ComCompanion };
            return retVal;
        }
        internal static string LoadDefFile(int AnswerSheet,string exam)
        {
            
            if (exam.Contains("SSCE"))
            {
                switch (AnswerSheet)
                {
                    case 0:
                        DFile = "sscescan";
                        break;
                    case 1:
                        DFile = "sscescan1";
                        break;
                    case 2:
                        DFile = "sscescan2";
                        break;
                }
            }
            if (exam.Contains("BECE"))
            {
                switch (AnswerSheet)
                {
                    case 0:
                        DFile = "becescan";
                        //ComScanDir = ComSosDir + comSheet;
                        break;
                    case 1:
                        DFile = "becescan1";
                        break;
                    case 2:
                        DFile = "becescan2";
                        break;
                    case 3:
                        DFile = "becescan3";
                        break;
                }
            }

            return DFile;
        }

        
    }
}
