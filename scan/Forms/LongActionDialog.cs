using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scan
{
    public partial class LongActionDialog : Form
    {
		#region Private constructor

		private LongActionDialog(string title)
		{
			InitializeComponent();
			lblTitle.Text = title;
		}

		#endregion

		#region Private fields

		private bool _canClose = false;
		private Task _task = null;

		#endregion

		#region Public static methods

		public static T ShowDialog<T>(IWin32Window owner, string title, Task<T> task)
		{
			var dialog = new LongActionDialog(title)
			{
				_task = task
			};
			dialog.ShowDialog(owner);
			return task.Result;
		}

		public static T ShowDialog<T>(string title, Task<T> task)
		{
			var dialog = new LongActionDialog(title)
			{
				_task = task
			};
			dialog.ShowDialog();
			return task.Result;
		}

		public static void ShowDialog(IWin32Window owner, string title, Task task)
		{
			var dialog = new LongActionDialog(title)
			{
				_task = task
			};
			dialog.ShowDialog(owner);
		}


		public static void ShowDialog(string title, Task task)
		{
			var dialog = new LongActionDialog(title)
			{
				_task = task
			};
			dialog.ShowDialog();
		}
		#endregion

		#region Private methods

		private void LongTaskFormFormClosing(object sender, FormClosingEventArgs e)
		{
			e.Cancel = !_canClose;
		}

		private void LongActionDialogShown(object sender, EventArgs e)
		{
			_task.ContinueWith(t =>
			{
				_canClose = true;
				if (InvokeRequired)
					BeginInvoke(new Action(Close));
				else
					Close();
			});
		}

        #endregion

        private void LongActionDialog_Load(object sender, EventArgs e)
        {

        }
    }

}
