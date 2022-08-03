using scan.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace scan
{
    static class InitializeListView
    {
        public static ListView FillListView(ListView lstv, List<OStatModel> data)
        {
            //lstv.Columns.Remove(View.Details); 
            lstv.Items.Clear();
            //ListViewItem lvi = new ListViewItem(pet.Name);
            //Initialize(lstv);
            foreach (var s in data )
            {
                ListViewItem lvi = new ListViewItem(s.date);
                lvi.SubItems.Add(s.file);
                lvi.SubItems.Add(s.total.ToString());

                lstv.Items.Add(lvi);
            }
            return lstv;
        }

        static internal ListView Initialize( ListView lstv)
        {
            lstv.FullRowSelect = true;
            lstv.View = View.Details;
            // Add a column with width 20 and left alignment.
            lstv.Columns.Add("Date", 90, HorizontalAlignment.Left);
            lstv.Columns.Add("Files", 120, HorizontalAlignment.Left);
            lstv.Columns.Add("Total", 70, HorizontalAlignment.Left);
            return lstv;
        }


        public static ListView InitializeEx(ListView lstv)
        {
            lstv.FullRowSelect = true;
            lstv.View = View.Details;
            // Add a column with width 20 and left alignment.
            lstv.Columns.Add("Date", 100, HorizontalAlignment.Left);
            lstv.Columns.Add("Operator", 250, HorizontalAlignment.Left);
            lstv.Columns.Add("Files", 150, HorizontalAlignment.Left);
            lstv.Columns.Add("Total", 70, HorizontalAlignment.Left);
            return lstv;
        }
    }
}
