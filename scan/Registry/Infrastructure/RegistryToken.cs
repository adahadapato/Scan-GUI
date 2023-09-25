using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SCRghelp.Infrastructure
{
    using Microsoft.Win32;
    using System;
    using System.Windows.Forms;

    public interface IRegistryMapper
    {
        string Getvalue(string regKey);
        string GetvalueEx(string regKey);
        void Setvalue(string regKey, string rValue);
        void SetvalueEx(string regKey, string rValue);
    }
    public class RegistryMapper : IRegistryMapper
    {

        public string GetvalueEx(string regKey)
        {
            try
            {
                RegistryKey mICParams = Registry.CurrentUser;
                mICParams = mICParams.OpenSubKey(@"software\DRS\Sosinpw\Job", true);
                return mICParams.GetValue(regKey).ToString();

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
            return string.Empty;
        }

        public string Getvalue(string regKey)
        {
            try
            {
                RegistryKey mICParams = Registry.CurrentUser;
                mICParams = mICParams.OpenSubKey(@"software\necoscan", true);
                return mICParams.GetValue(regKey).ToString();

            }
            catch (Exception e)
            {
               MessageBox.Show(e.Message);
            }
            return string.Empty;
        }


        public void Setvalue(string regKey, string rValue)
        {
            try
            {
                RegistryKey mICParams = Registry.CurrentUser;
                mICParams = mICParams.OpenSubKey(@"software\necoscan", true);
                mICParams.SetValue(regKey, rValue);
                mICParams.Close();
            }
            catch (Exception e)
            {
               MessageBox.Show(e.Message);
            }
        }
          
        public void SetvalueEx(string regKey, string rValue)
        {
            try
            {
                RegistryKey mICParams = Registry.CurrentUser;
                mICParams = mICParams.OpenSubKey(@"software\DRS\Sosinpw\Job", true);
                mICParams.SetValue(regKey, rValue);
                mICParams.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

    }
}
