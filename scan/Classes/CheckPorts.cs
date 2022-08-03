using System;
using System.Collections.Generic;
using System.Text;
using System.IO.Ports;

namespace scan
{
    static class CheckPorts
    {
        static string PortName;
        public static void PortStattus()
        {

            string[] PortNames = SerialPort.GetPortNames();
            foreach (string ports in PortNames)
            {
                //System.Windows.Forms.MessageBox.Show(ports);
                if (ports == "COM1")
                {
                    PortName = ports;
                    break;
                }
            }

            SerialPort ScanPort = new SerialPort(PortName);
            if (ScanPort.IsOpen)
            {
                //ScanPort.Open();
                System.Windows.Forms.MessageBox.Show("Port is Opened");
                System.Windows.Forms.MessageBox.Show(ScanPort.BaudRate.ToString());
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Port is not Opened");
            }
            ScanPort.Open();
            System.Windows.Forms.MessageBox.Show(ScanPort.BaudRate.ToString());

        }
    }
}
