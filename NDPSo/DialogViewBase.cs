using DevExpress.XtraEditors;
using NDPSo.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDPSo
{
    public partial class DialogViewBase : DevExpress.XtraEditors.XtraForm
    {
		private bool _eventIsPrevented;
		protected bool EventIsPrevented
		{
			get
			{
				return this._eventIsPrevented;
			}
		}
		protected virtual void PopulateStaticData()
		{
		}

		protected virtual void PopulateData()
		{
		}

		protected virtual void SetupLayout()
		{
		}

		protected virtual void BindData()
		{
		}

		protected virtual void AdjustCulture()
		{
		}

		protected override void OnLoad(EventArgs e)
		{
			try
			{
				this.SetupLayout();
				this.AdjustCulture();
				this.PopulateStaticData();
				this.PopulateData();
				this.BindData();
				base.OnLoad(e);
				this.InitLayout();
			}
			catch (Exception ex)
			{
				TramTronLogger.WriteError(ex);
				//TramTromMessageBox.ShowDNErrorDialog(ex);
				base.Close();
			}
		}
		protected void StartPreventEvent()
		{
			this._eventIsPrevented = true;
		}

		protected void EndPreventEvent()
		{
			this._eventIsPrevented = false;
		}


		public DialogViewBase()
        {
            InitializeComponent();
        }
    }
}