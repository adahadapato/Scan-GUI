using System;
using System.Windows.Forms;
using System.Diagnostics;
using SCRghelp.Infrastructure;
//using System.IO.Ports;

namespace scan
{
    static class Program
    {
        public static string Job = "";
        public static bool housekeeping = false; //Do not perform house keeping
        //public static string SupervisorAccessToken = "";
        public static string ProblemType = "";
        static RegistryHelperClass regHelper = new RegistryHelperClass();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                string[] args = Environment.GetCommandLineArgs();

                //NetworkBrowser brw = new NetworkBrowser();
                //var t = brw.getNetworkComputers();
                regHelper.DeviceId = GetSystemName.SystemName();
                SingleInstanceController controller = new SingleInstanceController(regHelper.LogOut);
                controller.Run(args);
            }
            catch (Exception) { }
        }


        static void ShutDown()
        {
            var client = "SYSAA";
            string shutdownString = @"/c shutdown -s -t 1 -f -m \\" + client;
            try
            {
                ProcessStartInfo psiOpt = new ProcessStartInfo("cmd.exe", shutdownString);
                psiOpt.WorkingDirectory = Environment.GetFolderPath(Environment.SpecialFolder.System);
                psiOpt.WindowStyle = ProcessWindowStyle.Hidden;
                psiOpt.RedirectStandardOutput = true;
                psiOpt.UseShellExecute = false;
                psiOpt.CreateNoWindow = true;
                Process procCommand = Process.Start(psiOpt);
                procCommand.WaitForExit();

               // return "success";

            }
            catch (Exception e)
            {
                string eError = e.Message;
               // return "failed";
            }
        }

    }
}
