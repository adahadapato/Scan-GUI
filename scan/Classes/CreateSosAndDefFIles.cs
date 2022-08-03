using System;
using System.Windows.Forms;
using System.IO;
using scan.Data;
using System.Threading.Tasks;
using SCRghelp.Infrastructure;

namespace scan
{
    
    static class CreateSosAndDefFIles
    {
        static RegistryHelperClass _rHelper = new RegistryHelperClass();
        public static async Task<bool> CreateSosFile(string newfile)
        {
           
            try
            {
                if (!File.Exists(newfile ))
                {
                    var fileBytes = (_rHelper.ExamType=="NCEE") ? await Repository.GetFile("sos", _rHelper.Paper) : await Repository.GetFile("sos", _rHelper.Job);
                    File.WriteAllBytes(newfile, fileBytes);
                    //File.Copy(UtilityClass.InstallationPath()+@"necoscan\Sosinp\" + filename + ".sos", newfile, true);
                   // File.Copy($"\\192.168.1.2\\e$\\{1}", computerName, fileName),Path.Combine(localPath, fileName),true);
                }
                return  true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Create Sos file");
            }
            return false;
        }

        public static async Task<bool> CreateDefFile(string newfile)
        {
            try
            {
                if (!File.Exists(newfile))
                {
                    var fileBytes = (_rHelper.ExamType=="NCEE")? await Repository.GetFile("def", _rHelper.Paper) : await Repository.GetFile("def", _rHelper.Job);
                    File.WriteAllBytes(newfile, fileBytes);
                }
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "Create Def file");
            }
            return false;
        }
    }
}
