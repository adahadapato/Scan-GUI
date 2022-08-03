using scan.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace scan.Classes
{
    public class DependencyClass : Repository
    {
        private static readonly string BaseDir = $"{UtilityClass.InstallationPath()}\\necoscan";
        private static string CreateDir(string sPath)
        {
            try
            {
                var FPath = $"{BaseDir}\\{sPath}";
                if (!Directory.Exists(FPath))
                {
                    Directory.CreateDirectory(FPath);
                }
                return FPath;
            }
            catch { }
            return null;
        }

        public static void CleanDir(string sPath)
        {
            try
            {
                var FPath = $"{BaseDir}\\{sPath}";
                if (!Directory.Exists(FPath)) return;

                var files = Directory.GetFiles(FPath).ToList();
                if (files.Count > 0)
                {
                    foreach (var f in files)
                    {
                        File.Delete(f);
                    }
                }
            }
            catch { }
        }

        public static void  GetCompanion()
        {
            LongActionDialog.ShowDialog("Fetching dependencis [companion]...", Task.Run(async() =>
            {
                var sPath = CreateDir("Companion") ;
                if (sPath != null)
                {
                    var companionBytes = await GetFile("SCompanion");
                    File.WriteAllBytes($"{sPath}\\sCompanion.dll", companionBytes);

                    var ztoolBoxByte = await GetFile("ZToolBox");
                    File.WriteAllBytes($"{sPath}\\ZToolBox.dll", ztoolBoxByte);

                    var interoptByte = await GetFile("Interopt");
                    File.WriteAllBytes($"{sPath}\\Interop.Sosinpw.dll", interoptByte);

                    var sosinpWByte = await GetFile("SosinpW");
                    File.WriteAllBytes($"{sPath}\\Sosinpw.Companion.dll", sosinpWByte); 
                }
                
            }));
           
        }

        public static void GetExportFilter()
        {
            LongActionDialog.ShowDialog("Fetching dependencis [export filter]...", Task.Run(async () =>
            {
                var sPath = CreateDir("Assemblies");
                if (sPath != null)
                {
                    var exportFilterBytes = await GetFile("ExportFilter");
                    File.WriteAllBytes($"{sPath}\\ExpNeco.dll", exportFilterBytes);

                    var interoptByte = await GetFile("Interopt");
                    File.WriteAllBytes($"{sPath}\\Interop.Sosinpw.dll", interoptByte);
                }
            }));
        }
    }
}
