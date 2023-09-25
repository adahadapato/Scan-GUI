using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using SCRghelp.Infrastructure;
using System.Threading.Tasks;
using scan.Data;

namespace scan.Classes
{
    public class InventoryClass
    {
        
        public static async Task<string> GetTotalScanned()
        {
            var totalScanned = await Repository.GetTotalScanned();
            return totalScanned.ToString();
        }
        
        public static async Task<List<string>> GetLocalInventory()
        {
            RegistryHelperClass _rHelper = new RegistryHelperClass();
            var missingFiles = new List<string>();
            try
            {

                var exts = new[] { ".sos", ".def" };


                var localFileList = Directory.GetFiles(_rHelper.SosDir, "*.*", SearchOption.AllDirectories)
                        .Where(d => !d.Contains("Images") && !exts.Any(x => d.EndsWith(x, StringComparison.OrdinalIgnoreCase))).ToList();

                if (localFileList == null || localFileList.Count == 0) return null;

                var result = await Repository.GetServerInventory();

                if (result == null)
                    return missingFiles;

                var remoteFiles = result.Data;// GetRemoteInventory();
                                              //if (remoteFiles == null) return null;
                                              //if (remoteFiles.Count == 0 && localFileList.Count == 0) return null;
                var remoteFileList = remoteFiles.Select(r => r.FileName).ToList();

                //missingFiles = localFileList.Where(d => !remoteFileList.Any(r => r == Path.GetFileName(d))).ToList();
                missingFiles = localFileList.Where(d => !remoteFiles.Any(r => r.FileName == Path.GetFileName(d))).ToList();
                if (missingFiles.Count > 0)
                {
                    var message = $"There is/are {missingFiles.Count} files that are not saved on the server\n"
                        + "It is recommended that the file(s) be saved to the server to avoid possible data loss\n"
                        + "Please inform the shift suppervisor for necessary action.";
                    MessageBox.Show(message, "House keeping", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    Program.housekeeping = true;

                }
                return missingFiles;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
           

            return null;
        }


       /* public static List<string> GetInconsistentFiles()
        {
            var exts = new[] { ".sos", ".def" };
            var remoteFiles = GetRemoteInventory();
            if (remoteFiles == null) return null;
            if (remoteFiles.Count == 0) return null;
            var remoteFileList = remoteFiles.Select(r => r.FileName).ToList();
            var localFileList = Directory.GetFiles(Reg.SosDir, "*.*", SearchOption.AllDirectories)
                    .Where(d => !d.Contains("Images") && !exts.Any(x => d.EndsWith(x, StringComparison.OrdinalIgnoreCase))).ToList();

            var missingFiles = localFileList.Where(d => !remoteFileList.Any(r => r == Path.GetFileName(d))).ToList();
            if (missingFiles.Count > 0)
            {
                var message = $"There is/are {missingFiles.Count} files that are not saved on the server\n"
                    + "It is recommended that the file(s) be saved to the server to avoid possible data loss\n"
                    + "Please inform the shift suppervisor for necessary action.";
                MessageBox.Show(message, "House keeping", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                /*var dialogueResult = MessageBox.Show("Do you want to continue without saving the file(s)", "House keeping", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if(dialogueResult == DialogResult.No)
                {
                    Program.housekeeping = true;
                }
                else
                {
                    Program.housekeeping = false;
                }*/

               /* Program.housekeeping = true;
                return missingFiles;
            }

            return null;
        }*/
    }
}
