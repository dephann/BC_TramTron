using System;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace NDPSo
{
	public class ViewManager
	{
		public static object GetView(string name)
		{
			if (ViewManager._htbView.ContainsKey(name))
			{
				return ViewManager._htbView[name];
			}
			return null;
		}

		public static void ShowView(ControlViewBase ctrView, bool hasKeyDown = true)
		{
			XtraForm xtraForm = ViewManager.GetView(ctrView.Name) as XtraForm;
			if (xtraForm != null)
			{
				xtraForm.Activate();
				return;
			}
			xtraForm = new XtraForm();
			xtraForm.AutoScroll = true;
			ctrView.AutoScroll = true;
			xtraForm.Controls.Add(ctrView);
			ctrView.Dock = DockStyle.Fill;
			xtraForm.MdiParent = ViewManager._frmMain;
			xtraForm.Name = ctrView.Name;
			xtraForm.Text = ctrView.Caption;
			xtraForm.AutoScaleMode = AutoScaleMode.Font;
			xtraForm.FormClosed += ViewManager.frm_FormClosed;
			xtraForm.FormClosing += ViewManager.frm_FormClosing;
			if (hasKeyDown)
			{
				xtraForm.KeyPreview = true;
				xtraForm.KeyDown += ViewManager.frm_KeyDown;
			}
			ViewManager._htbView.Add(xtraForm.Name, xtraForm);
			xtraForm.Show();
			FrmMain frmMain = ViewManager._frmMain as FrmMain;
			frmMain.EnabledCloseAllDocs();
		}

		public static void ShowViewWindow(ControlViewBase ctrView, bool inTashbar, bool maxWindowState = false)
		{
			XtraForm xtraForm = new XtraForm();
			xtraForm.Size = ctrView.Size;
			xtraForm.ShowInTaskbar = inTashbar;
			xtraForm.MinimizeBox = false;
			xtraForm.MaximizeBox = false;
			xtraForm.FormBorderStyle = FormBorderStyle.FixedDialog;
			xtraForm.StartPosition = FormStartPosition.CenterParent;
			if (maxWindowState)
			{
				xtraForm.MinimizeBox = true;
				xtraForm.MaximizeBox = true;
				xtraForm.WindowState = FormWindowState.Maximized;
			}
			xtraForm.ClientSize = new Size(ctrView.ClientSize.Width, ctrView.ClientSize.Height);
			ctrView.Dock = DockStyle.Fill;
			xtraForm.Controls.Add(ctrView);
			xtraForm.Name = ctrView.Name;
			xtraForm.Text = ctrView.Caption;
			xtraForm.Show();
		}

		private static void frm_KeyDown(object sender, KeyEventArgs e)
		{
			XtraForm xtraForm = sender as XtraForm;
			ControlViewBase controlViewBase = xtraForm.Controls[0] as ControlViewBase;
			controlViewBase.DoKeyDown(sender, e);
		}

		private static void frm_FormClosing(object sender, FormClosingEventArgs e)
		{
			XtraForm xtraForm = sender as XtraForm;
			ControlViewBase controlViewBase = xtraForm.Controls[0] as ControlViewBase;
			controlViewBase.DoClosing(e);
		}

		private static void frm_FormClosed(object sender, FormClosedEventArgs e)
		{
			XtraForm xtraForm = sender as XtraForm;
			ViewManager._htbView.Remove(xtraForm.Name);
			ControlViewBase controlViewBase = xtraForm.Controls[0] as ControlViewBase;
			controlViewBase.DoClosed(e);
			xtraForm.Dispose();
			FrmMain frmMain = ViewManager._frmMain as FrmMain;
			if (frmMain.MdiChildren.Count<Form>() == 0)
			{
				frmMain.DisabledCloseAllDocs();
			}
		}

		public static void ShowViewDialog(ControlViewBase ctrView)
		{
			XtraForm xtraForm = new XtraForm();
			xtraForm.Size = ctrView.Size;
			xtraForm.ShowInTaskbar = false;
			xtraForm.MinimizeBox = false;
			xtraForm.MaximizeBox = false;
			xtraForm.FormBorderStyle = FormBorderStyle.FixedDialog;
			xtraForm.StartPosition = FormStartPosition.CenterParent;
			xtraForm.ClientSize = new Size(ctrView.ClientSize.Width, ctrView.ClientSize.Height);
			ctrView.Dock = DockStyle.Fill;
			xtraForm.Controls.Add(ctrView);
			xtraForm.Name = ctrView.Name;
			xtraForm.Text = ctrView.Caption;
			xtraForm.ShowDialog();
		}

		public static void ShowViewDialog(DialogViewBase dlgView)
		{
			dlgView.ShowDialog();
		}

		public static void CloseAllForm()
		{
			foreach (XtraForm xtraForm in ViewManager._frmMain.MdiChildren)
			{
				xtraForm.Close();
			}
		}

		public static Form FrmMain
		{
			get
			{
				return ViewManager._frmMain;
			}
			set
			{
				ViewManager._frmMain = value;
			}
		}

		private static Hashtable _htbView = new Hashtable();

		private static Form _frmMain = null;
	}
}
