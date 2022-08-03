using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;
using SCRghelp.Infrastructure;

namespace scan
{
    static class QuitApplication
    {
        static RegistryHelperClass regHelper = new RegistryHelperClass();
        public static void Quit()
        {
            regHelper.LogOut = true;
            regHelper.UID = "Default";
            regHelper.OperatorId = "";
            regHelper.StartBatch = false;
            //string[] regKey = { "startBatch", "logout", "UID" };
            //string[] rValues = { "false", "true", "Default" };
            //getRegistryValues.UpdateRegistry(@"software\necoscan", regKey, rValues);    
        }
    }
}
