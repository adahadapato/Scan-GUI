using System;
using Microsoft.VisualBasic.ApplicationServices;
using System.Windows.Forms;
using scan.Models;
using HttpService.ApiInfrastructure;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using HttpService.ApiInfrastructure.Client;
using HttpService.ApiHelper.Client;
using HttpService.ApiHelper;
using System.Threading.Tasks;
using SCRghelp.Infrastructure;
using scan.Data;

namespace scan
{
    public class SingleInstanceController : WindowsFormsApplicationBase
    {
        bool Islogout = true;
        
        private readonly RegistryHelperClass _rHelper;
        public SingleInstanceController(bool Islogout)
        {
            this.Islogout = Islogout;
            // Set whether the application is single instance
            this.IsSingleInstance = true;

            this.StartupNextInstance += new
              StartupNextInstanceEventHandler(this_StartupNextInstance);

            //tokenContainer = new TokenContainer();
            
            _rHelper = new RegistryHelperClass();
        }

        void this_StartupNextInstance(object sender, StartupNextInstanceEventArgs e)
        {
            // Here you get the control when any other instance is
            // invoked apart from the first one.
            // You have args here in e.CommandLine.

            // You custom code which should be run on other instances
           System.Windows.Forms.MessageBox.Show("Application is already running", "Scanning",
               System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Error);
        }
        protected override void OnCreateMainForm()
        {
            base.OnCreateMainForm();
            //Task.Run(() =>
            //{
            //    try
            //    {
            //        //var comp = GetNetworkHostNames();
            //        if (Islogout == false)
            //        {
            //            this.MainForm = new frmnewscan();
            //        }
            //        else
            //        {
            //            Login();
            //            if (IsLoginSuceed)
            //            {
            //                this.MainForm = new frmnewscan();
            //            }
            //            else
            //            {
            //                Application.Exit();
            //                return;
            //            }
            //        }
            //    }
            //    catch (Exception) { Application.Exit(); return; }
            //});

            try
            {
                //var comp = GetNetworkHostNames();
                if (Islogout == false)
                {
                    this.MainForm = new frmnewscan();
                }
                else
                {
                    Login();
                    if (IsLoginSuceed)
                    {
                        this.MainForm = new frmnewscan();
                    }
                    else
                    {
                        Application.Exit();
                        return;
                    }
                }
            }
            catch (Exception) { Application.Exit(); return; }

        }

        bool IsLoginSuceed = false;
        void Login()
        {
            try
            {
                var login = UtilityClass.ShowLogin("SSCE 2022 Scanning : Operator Login");
               
                if (login == null)
                {
                    IsLoginSuceed = false;
                    MessageBox.Show("The operation was cancelled by te user", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (string.IsNullOrWhiteSpace(login.password) || string.IsNullOrWhiteSpace(login.username))
                {
                    IsLoginSuceed = false;
                    MessageBox.Show("All entries are mandetory", "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;// Task.CompletedTask;
                }
                var PersonnelNo = login.username;
                var Password = login.password;
                string message = "";
                bool ChangePWD = false;
                LongActionDialog.ShowDialog("please wait ...", Task.Run(async () =>
                {
                    var DeviceId = $"SYS{GetSystemName.SystemName()}";
                    var (Isuccess, IsChangePWD, ResponseMessage) = await Repository.Login(PersonnelNo, Password, DeviceId);
                    IsLoginSuceed = Isuccess;
                    message = ResponseMessage;
                    ChangePWD = IsChangePWD;
                }));

                if (!ChangePWD && IsLoginSuceed)
                {
                    IsLoginSuceed = false;
                    MessageBox.Show(message, "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var chgPWD = UtilityClass.ChangePassword();
                    if (chgPWD == null)
                    {
                        IsLoginSuceed = false;
                        MessageBox.Show("The operation was cancelled by te user", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;// Task.CompletedTask;
                    }

                    if (string.IsNullOrWhiteSpace(chgPWD.NewPassword) || string.IsNullOrWhiteSpace(chgPWD.ConfirmPassword))
                    {
                        IsLoginSuceed = false;
                        MessageBox.Show("All entries are mandetory", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;// Task.CompletedTask;
                    }

                    if (chgPWD.NewPassword != chgPWD.ConfirmPassword)
                    {
                        IsLoginSuceed = false;
                        MessageBox.Show("Password confirmation mismatch", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;// Task.CompletedTask;
                    }

                    if (chgPWD.NewPassword.Trim() == Password.Trim())
                    {
                        IsLoginSuceed = false;
                        MessageBox.Show("Please create a different Password", "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;// Task.CompletedTask;
                    }

                    bool _state = false;
                    string _msg = "";
                    LongActionDialog.ShowDialog("please wait ...", Task.Run(async () =>
                    {
                        string NewPassord = chgPWD.NewPassword;
                        string ConfirmPasword = chgPWD.ConfirmPassword;
                        var (_status, _message) = await Repository.ChangePWD(PersonnelNo, Password, NewPassord, ConfirmPasword);
                        _state = _status;
                        _msg = _message;
                    }));

                    if (_state)
                    {
                        var msg = _msg + "\n" +
                            "Please login with your new password\n" +
                            "to continue scanning";
                        MessageBox.Show(msg, "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(_msg, "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    return;// Task.CompletedTask;
                }
                
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Change Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return;// Task.CompletedTask;
        }
    }
}
