using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using NDPSo.Utils;
namespace NDPSo
{
    public partial class ControlViewBase : System.Windows.Forms.UserControl
    {
        protected bool IsSuccess = false;
        protected DialogResult _dlgRes = DialogResult.Cancel;
        private string _caption = "Control View";
        private Enums.FormAction _action;
        private bool _eventIsPrevented;

        public event ControlViewBase.DelFormClosingEventHandler ControlClosing;

        public event ControlViewBase.DelFormClosedEventHandler ControlClosed;

        public string Caption
        {
            get => this._caption;
            set
            {
                this._caption = value;
                if (this.Parent == null || !(this.Parent is XtraForm parent))
                    return;
                parent.Text = this._caption;
                
            }
        }

        protected Enums.FormAction FormAction
        {
            get => this._action;
            set => this._action = value;
        }

        protected bool EventIsPrevented => this._eventIsPrevented;

        

        protected virtual void PopulateStaticData()
        {
        }

        protected virtual void PopulateData()
        {
        }

        protected virtual void BindData()
        {
        }

        protected virtual void SetupLayout()
        {
        }

        protected virtual void Loaded()
        {
        }

        protected virtual void AdjustCulture()
        {
        }

        protected override void OnLoad(EventArgs e)
        {
            this.SetupLayout();
            try
            {
                this.AdjustCulture();
            }
            catch (System.Exception ex)
            {
            }
            this.PopulateStaticData();
            this.PopulateData();
            this.BindData();
            base.OnLoad(e);
            this.InitLayout();
            this.Loaded();
        }

        protected void StartPreventEvent() => this._eventIsPrevented = true;

        protected void EndPreventEvent() => this._eventIsPrevented = false;

        protected void FocusRow(GridView grv, int focusedRowHandle)
        {
            if (grv.RowCount == 0)
                return;
            if (focusedRowHandle >= grv.RowCount)
                --focusedRowHandle;
            grv.ClearSelection();
            grv.SelectRows(focusedRowHandle, focusedRowHandle);
            grv.FocusedRowHandle = focusedRowHandle;
        }

        protected void FocusRow(AdvBandedGridView gra, int focusedRowHandle)
        {
            if (gra.RowCount == 0)
                return;
            if (focusedRowHandle >= gra.RowCount)
                --focusedRowHandle;
            gra.ClearSelection();
            gra.SelectRows(focusedRowHandle, focusedRowHandle);
            gra.FocusedRowHandle = focusedRowHandle;
        }

        public void DoClosed(FormClosedEventArgs e)
        {
            if (this.ControlClosed == null)
                return;
            this.ControlClosed((object)this, new FormClosedEventArgs(CloseReason.MdiFormClosing));
        }

        public void DoClosing(FormClosingEventArgs e)
        {
            if (this.ControlClosing == null)
                return;
            this.ControlClosing((object)this, e);
        }

        protected void Close()
        {
            if (this.Parent == null || !(this.Parent is XtraForm parent))
                return;
            parent.Close();
            parent.Dispose();
        }

        private void frm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.ControlClosing == null)
                return;
            this.ControlClosing(sender, e);
        }

        private void frm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.ControlClosed == null)
                return;
            this.ControlClosed(sender, e);
        }

        public virtual List<T> GetSelectedObjects<T>() where T : class => throw new NotImplementedException();

        public DialogResult GetDialogResult()
        {
            return this._dlgRes;
        }
        public bool GetIsSuccess()
        {
            return this.IsSuccess;
            
        }
        public virtual void DoKeyDown(object sender, KeyEventArgs e)
        {
        }
        public ControlViewBase()
        {
            InitializeComponent();
        }
        public delegate void DelFormClosingEventHandler(object sender, FormClosingEventArgs e);

        public delegate void DelFormClosedEventHandler(object sender, FormClosedEventArgs e);
    }
}
