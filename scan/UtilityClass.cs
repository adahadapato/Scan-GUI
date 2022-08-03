using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO ;
using System.Security.AccessControl ;
using System.Runtime.InteropServices;
using System.Diagnostics;
using scan.Models;

namespace scan
{
    public static class UtilityClass
    {
        static string BatchCounter;
        static int Position;


        static bool is64BitProcess = (IntPtr.Size == 8);
        static bool is64BitOperatingSystem = is64BitProcess || InternalCheckIsWow64();

        [DllImport("kernel32.dll", SetLastError = true, CallingConvention = CallingConvention.Winapi)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool IsWow64Process(
            [In] IntPtr hProcess,
            [Out] out bool wow64Process
        );

        public static bool InternalCheckIsWow64()
        {
            if ((Environment.OSVersion.Version.Major == 5 && Environment.OSVersion.Version.Minor >= 1) ||
                Environment.OSVersion.Version.Major >= 6)
            {
                using (Process p = Process.GetCurrentProcess())
                {
                    bool retVal;
                    if (!IsWow64Process(p.Handle, out retVal))
                    {
                        return false;
                    }
                    return retVal;
                }
            }
            else
            {
                return false;
            }
        }


        public static string InstallationPath()
        {
            //bool is64 = System.Environment.Is64BitOperatingSystem;

            if (InternalCheckIsWow64())
                return @"c:\program files (x86)\";
            else
                return @"c:\program files\"; 

            //return @"c:\program files\";
        }

        public static TextBox txtToolTip(TextBox txt, string txtTip)
        {
            ToolTip tt = new ToolTip();
            tt.SetToolTip(txt, txtTip);
            return txt;
        }
        public static string ProgramVersion()
        {
            string Version;
            Version = " 15";
            return Version;
        }



      


        public static ComboBox getMonths(ComboBox cbo)
        {
            string[] month ={"January","February","March","April","May",
                             "June","July","August","September","October","November",
                             "December"};
            foreach (string months in month)
            {
                cbo.Items.Add(months);
            }
            return cbo;
        }

        

        public static LoginModel ShowLogin(string caption)
        {
            Form form = new Form();
            Label LblPwd = new Label();
            TextBox TxtPwd = new TextBox();
            Label LblUid = new Label();
            TextBox TxtUid = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();


            form.Text = caption;// "Operator Login";

            //form.Icon =
            //form.BackColor = Color.Red;// "255,255,128";

            LblPwd.Text = "Password";
            LblUid.Text = "File No.";
            
            //textBox.Text = value;

            TxtPwd.PasswordChar = Convert.ToChar("*");

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            //buttonOk.FlatStyle = ButtonState.Normal; 

            LblUid.SetBounds(16, 20, 372, 13);
            TxtUid.SetBounds(70, 20, 200, 20);
            LblPwd.SetBounds(16, 45, 372, 13);
            TxtPwd.SetBounds(70, 45, 300, 20);
            buttonOk.SetBounds(212, 72, 75, 23);
            buttonCancel.SetBounds(296, 72, 75, 23);

            LblPwd.AutoSize = true;
            LblUid.AutoSize = true;
            TxtPwd.Anchor = TxtPwd.Anchor | AnchorStyles.Right;
            TxtUid.Anchor = TxtUid.Anchor | AnchorStyles.Right;
            
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonOk.Cursor = Cursors.Hand;
            buttonOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            buttonOk.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            buttonOk.UseVisualStyleBackColor = true;
            buttonOk.TextAlign = ContentAlignment.MiddleCenter;

            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Cursor = Cursors.Hand;
            buttonCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            buttonCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.TextAlign = ContentAlignment.MiddleCenter;


            form.Opacity = 100;
            form.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { TxtUid, TxtPwd, buttonOk, buttonCancel, LblUid, LblPwd });
            form.ClientSize = new Size(Math.Max(300, LblPwd.Right + 10), form.ClientSize.Height);
            form.ClientSize = new Size(Math.Max(300, LblUid.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.TopMost = false;
            form.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.ControlBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            //DialogResult dialogResult = form.ShowDialog();
            form.ShowDialog();
            var value = new LoginModel
            {
                username = TxtUid.Text.ToUpper(),
                password = TxtPwd.Text
            };
            return value;
            //return form;
        }


        public static ChangePWD ChangePassword()
        {
            Form form = new Form();
            Label LblPwd = new Label();
            TextBox TxtPwd = new TextBox();
            Label LblUid = new Label();
            TextBox TxtUid = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();
            Button BtnShowPWD = new Button();
            bool IsClikced = false;

            form.Text = "Change Password";

            //form.Icon =
            //form.BackColor = Color.Red;// "255,255,128";

            LblPwd.Text = "Confirm Password";
            LblUid.Text = "New Password";

            //textBox.Text = value;

            TxtPwd.PasswordChar = Convert.ToChar("*");
            TxtUid.PasswordChar = Convert.ToChar("*");

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            BtnShowPWD.Text = "Sh";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            //buttonOk.FlatStyle = ButtonState.Normal; 

            LblUid.SetBounds(16, 20, 372, 13);
            TxtUid.SetBounds(110, 20, 255, 20);
            LblPwd.SetBounds(16, 45, 372, 13);
            TxtPwd.SetBounds(110, 45, 255, 20);
            buttonOk.SetBounds(212, 72, 75, 23);
            buttonCancel.SetBounds(296, 72, 75, 23);
            BtnShowPWD.SetBounds(370, 18, 20, 23);

            LblPwd.AutoSize = true;
            LblUid.AutoSize = true;
            TxtPwd.Anchor = TxtPwd.Anchor | AnchorStyles.Right;
            TxtUid.Anchor = TxtUid.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            BtnShowPWD.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            BtnShowPWD.Click += new System.EventHandler(BtnShowPWD_Click);

            form.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { TxtUid, TxtPwd, buttonOk, buttonCancel, BtnShowPWD, LblUid, LblPwd });
            form.ClientSize = new Size(Math.Max(300, LblPwd.Right + 10), form.ClientSize.Height);
            form.ClientSize = new Size(Math.Max(300, LblUid.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            
            void BtnShowPWD_Click(object sender, EventArgs e)
            {
                if (!IsClikced)
                {
                    TxtPwd.PasswordChar = TxtUid.PasswordChar = '\0';
                    IsClikced = true;
                }
                else
                {
                    TxtPwd.PasswordChar = TxtUid.PasswordChar = Convert.ToChar("*");
                    IsClikced = false;
                }
                
            }

            //DialogResult dialogResult = form.ShowDialog();
            form.ShowDialog();
            //List<string> Data = new List<string>();
            //Data.Add(TxtUid.Text);
            //Data.Add(TxtPwd.Text);

            var  value = new ChangePWD
            { 
               ConfirmPassword = TxtUid.Text, 
               NewPassword = TxtPwd.Text
            };
            return value;

        }

        public static string GetPassword(string title, string promptText)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            //Button buttonCancel = new Button();

            form.Text = title;
            
            //form.Icon =
            //form.BackColor = Color.Red;// "255,255,128";

            label.Text = promptText;
            //label.Font.Style = FontStyle.Bold;             
            //textBox.Text = value;
            
            textBox.PasswordChar = Convert.ToChar ("*"); 

            buttonOk.Text = "OK";
            //buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            //buttonCancel.DialogResult = DialogResult.Cancel;

            //buttonOk.FlatStyle = ButtonState.Normal; 

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(212, 70, 75, 23);
            //buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            //buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            //form.CancelButton = buttonCancel;

            //DialogResult dialogResult = form.ShowDialog();
            form.ShowDialog();
            string value = textBox.Text;
            return value;

        }

        public static string Dialogue(string title, string promptText, bool PWD)
        {
            Form dform = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            //Button buttonCancel = new Button();

            dform.Text = title;
            dform.TopMost = true;

            //form.Icon =
            //form.BackColor = Color.Red;// "255,255,128";

            label.Text = promptText;
            //label.Font.Style = FontStyle.Bold;             
            //textBox.Text = value;
            if (PWD==true )
            {
                textBox.PasswordChar = Convert.ToChar("*");
            }

            buttonOk.Text = "OK";
            //buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            //buttonCancel.DialogResult = DialogResult.Cancel;

            //buttonOk.FlatStyle = ButtonState.Normal; 

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(212, 70, 75, 23);
            //buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            //buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            dform.ClientSize = new Size(396, 107);
            dform.Controls.AddRange(new Control[] { label, textBox, buttonOk });
            dform.ClientSize = new Size(Math.Max(300, label.Right + 10), dform.ClientSize.Height);
            dform.FormBorderStyle = FormBorderStyle.FixedDialog;
            dform.StartPosition = FormStartPosition.CenterScreen;
            dform.MinimizeBox = false;
            dform.MaximizeBox = false;
            dform.AcceptButton = buttonOk;
            //form.CancelButton = buttonCancel;

            //DialogResult dialogResult = form.ShowDialog();
            dform.ShowDialog();
            string value = textBox.Text;
            return value;

        }

        public static void AddDirectorySecurity(string Dir, string Account, FileSystemRights Rights, AccessControlType ControlType)
        {
            try
            {
                //NTAccount identity = new NTAccount(Account);
                //SecurityIdentifier sid = (SecurityIdentifier)identity.Translate(typeof(SecurityIdentifier));  
                /*DirectoryInfo dInfo = new DirectoryInfo(Dir);
                DirectorySecurity dSecurity = dInfo.GetAccessControl();//AccessControlSections.None);
                dSecurity.AddAccessRule(new FileSystemAccessRule(Account   , Rights, ControlType));
                dInfo.SetAccessControl(dSecurity);*/

                FileSecurity security = File.GetAccessControl(Dir);
                security.AddAccessRule(new FileSystemAccessRule(Account, Rights, ControlType));
                File.SetAccessControl(Dir, security);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message+"  "+ex.StackTrace , "Lock Dir");
            }
        }
        public static string Left(string str,int index)
        {
            string iLeft = "";
            iLeft = str.Substring(0, index);
            return iLeft;
        }
        public static string Right(string str, int index)
        {
            string iRight = "";
            iRight = str.Substring((str.Length -index)  ,index);
            if (iRight.ToUpper() == "TXT")
            {
                iRight = "000";
            }
            return iRight;
        }
      
        public static  int Instr(string tString, string SearchItem)
        {
            try
            {
                char[] store = new char[tString.Length];
                for (int i = 0; i < tString.Length; i++)
                {
                    store[i] = tString[i];

                }
                for (int j = 0; j < tString.Length; j++)
                {
                    if (store[j].ToString() == SearchItem)
                    {
                        Position = j;
                        break;
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Position = 0;
            }
            return Position;
        }
        

        public static void DisplayToolTip(Control ctl, string toolTip)
        {
            ToolTip ttip = new ToolTip();
            ttip.IsBalloon = true;
            ttip.UseAnimation = true;
            ttip.UseFading = true;
            string msg="";
            string job = getRegistryValues.GetRegistryValue("Job");
            switch (job){
                case "Obj":
                    msg = "OMR Scanning";
                    break;
                case "Essay":
                    msg = "EMS Scanning";
                    break;
                case "Registration":
                    msg = "Registration";
                    break;
                case "Validation":
                    msg = "Validation";
                    break;
                case "Dummy":
                    msg = "Dummy";
                    break;
                case "Malpractice":
                    msg = "Malpractice";
                    break;
                default:
                    msg = "";
                    break;

            }
            ttip.ToolTipTitle = "NECO " + getRegistryValues.GetRegistryValue("examType") + " "+getRegistryValues.GetRegistryValue("examYear")
                + " " + msg + " Exercise";
            ttip.BackColor = Color.GreenYellow ;
            ttip.SetToolTip(ctl, toolTip);
        }
        

    }
}
