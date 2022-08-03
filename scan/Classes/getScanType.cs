using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace scan
{
    static class getScanType
    {
        static string[] sType= new string[2];
        public static string[] ScanOptions(bool[] scantype)
        {
            if (scantype[0] == true)
            {
                sType[0] = "Suplementary Scan";
                sType[1]="Sup_" + GetSystemName.SystemName().ToString();
            }
            if (scantype[1] == true)
            {
                sType[0] = "Blind Candiates";
                sType[1]="Blind_"+GetSystemName.SystemName().ToString ()  ;
            }
            if (scantype[2] == true)
            {
                sType[0] = "BECE Resit...";
                sType[1]="Resit_" + GetSystemName.SystemName().ToString();  
            }
            if (scantype[3]== true)
            {
                sType[0] = "Blank Ems";
                sType[1] = "Blank_" + GetSystemName.SystemName().ToString();
            }
            if (scantype[0] == false && scantype[1] == false && scantype[2] == false)
            {
                sType[0] = "Normal Scanning";
                sType[1]="Main_" + GetSystemName.SystemName().ToString();
            }
            return sType;
        }
       
    }
}
