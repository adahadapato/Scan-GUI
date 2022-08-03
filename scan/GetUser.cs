using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Windows.Forms;

namespace scan
{
    static class GetUser
    {
        static string UID,UName;
        public static string fetch(string tUID,string mfile)
        {
            try
            {
                UID = "";
                UName = "";
                XmlDataDocument users = new XmlDataDocument();
                users.Load(@"c:\program files\necoscan\scan\"+mfile+".xml");
                foreach (XmlNode node in users.SelectNodes("/Scan/staff"))
                {
                    if (node.Attributes["uid"].InnerText == tUID.Trim())
                    {
                        UName = node.Attributes["name"].InnerText.ToString();
                        UID = node.Attributes["uid"].InnerText.ToString();
                        break;
                    }


                }
            }
            catch (Exception ex)
            {
                UName = "";
                MessageBox.Show(ex.Message,"Get User");
            }

            return UName;
        }
    }
}
