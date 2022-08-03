using scan.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Newtonsoft.Json;

namespace scan.Classes
{
    public class CreateOperators
    {
        public static void CeateOperator(string useName)
        {
            try
            {
                var scanDir = getRegistryValues.GetRegistryValue("sosDir");
                var Ofile = string.Format($"{scanDir}\\Ofile.txt");
                /*if (!File.Exists(Ofile))
                {
                    File.Create(Ofile);
                }*/

                var tdate = DateTime.Today.Date.ToShortDateString();

                /*OStatModel model = new OStatModel
                {
                    operatorid = useName,
                    total = 0,
                    date = tdate
                };*/
                bool IsOperatorInFile = false;
                    
                if (File.Exists(Ofile))
                {
                    IsOperatorInFile = File.ReadLines(Ofile).Where(line => line != null)
                      .Select(line => Regex.Matches(line, useName).Count > 0).FirstOrDefault();
                }

                StringBuilder sb = new StringBuilder();

                //var json=JsonConvert.SerializeObject(model);

                if (!IsOperatorInFile)
                {
                    using (StreamWriter w = File.AppendText(Ofile))
                    {
                        w.WriteLine(useName);
                        w.Flush();
                    }
                }
                else
                {

                }
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
            
                   

        }
    }
}
