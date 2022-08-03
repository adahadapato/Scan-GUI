using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.IO;
using Microsoft.Win32;
using System.Diagnostics;

namespace scan
{
    public partial class frmuid : Form
    {

        bool pass = false;
        string puid,uname,comJob;
        string plainText;
        Encrypt crypt = new Encrypt();
        public frmuid()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Length >= 7)
            {
                getuser();
                if (pass)
                {
                    if (ReadRegistryValue() != "Dummy")
                    {
                        frmnewscan f = new frmnewscan();
                        f.Show();
                    }
                    else
                    {
                        Process.Start(@"C:\projects\c#projects\Dummy\Dummy\bin\Debug\dummy.exe");
                        this.Dispose();
                        //Application.Exit();
                    }

                }
            }
            else
            {
                MessageBox.Show("Operator ID must be (7) digits and above", "Operator ID");
                textBox1.Text = "";
                textBox1.Focus();
                return;
            }
            
            
        }
        internal void getuser()
        {
            if (textBox1.Text.Trim() == "whiskers")
            {
                frmsettings f = new frmsettings();
                this.Hide();
                f.Show();
            }
            else
            {
                puid = GetUser.fetch(Decrypt(textBox1.Text.Trim()), "users");
                if (string.IsNullOrEmpty(puid))
                {
                    MessageBox.Show("Invalid User ID");
                    textBox1.Text = "";
                    textBox1.Focus();
                    pass = false;
                }
                else
                {
                    uname = puid;
                    pass = true;
                    WriteRegistryValue();
                }
            }
        }


        private string ReadRegistryValue()
        {

           
            RegistryKey mICParams = Registry.CurrentUser;
            mICParams = mICParams.OpenSubKey("software", true);
            foreach (string Keyname in mICParams.GetSubKeyNames())
            {

                if (Keyname == "necoscan")
                {
                    mICParams = mICParams.OpenSubKey("necoscan", true);
                  comJob =  mICParams.GetValue("Job").ToString ();
                    //mICParams.SetValue("UID",uname);
                    
                   break;

                }

            }
            mICParams.Close();
            return comJob;
        
        }

        private void WriteRegistryValue()
        {
            RegistryKey mICParams = Registry.CurrentUser;
            mICParams = mICParams.OpenSubKey("software", true);
            foreach (string Keyname in mICParams.GetSubKeyNames())
            {

                if (Keyname == "necoscan")
                {
                    mICParams = mICParams.OpenSubKey("necoscan", true);
                    mICParams.SetValue("Logout", false);
                    mICParams.SetValue("UID",uname);
                    
                   break;

                }

            }
            mICParams.Close();
        }

        private void frmuid_Load(object sender, EventArgs e)
        {
                 

        }
        

        private void Encrypt()
        {
           MessageBox.Show(crypt.iEncrypt(textBox1.Text.Trim()));
        }
        private string Decrypt(string text)
        {
            plainText = crypt.iDecrypt(text);
            return plainText;
            
        }

       
    }
}
