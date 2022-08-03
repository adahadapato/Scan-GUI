using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace scan
{
    static class getRegistryValues
    {
        static string rValue;
        public static void UpdateRegistry(string sKey,string[] regKey, string[] rValue)
        {
            try
            {
                RegistryKey mICParams = Registry.CurrentUser;
                mICParams = mICParams.OpenSubKey(sKey, true);
                for(int i=0;(i<regKey.Length  );i++)
                {
                    mICParams.SetValue(regKey[i],rValue[i]);
                 }
                mICParams.Close();
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Update Registry values");
            }

        }

        public static string GetRegistryValue(string regKey)
        {
            RegistryKey mICParams = Registry.CurrentUser;
            mICParams = mICParams.OpenSubKey(@"software\necoscan", false);
            rValue = mICParams.GetValue(regKey).ToString();
            return rValue;
        }
    }
}
