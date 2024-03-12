using DevExpress.XtraEditors;
using NDPSo.Data;
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

namespace NDPSo.MasterData
{
    public partial class UcLogicSiloAgg : UcLogicBase
    {
        public int numSelected;
        public BindingList<ObjSilo> _blstSiloLogicAgg = new BindingList<ObjSilo>();
        public BindingList<ObjSilo> _blstSiloLogicAggSelected1 = new BindingList<ObjSilo>();
        public BindingList<ObjSilo> _blstSiloLogicAggSelected2 = new BindingList<ObjSilo>();
        public UcLogicSiloAgg()
        {
            InitializeComponent();
        }
        public void SetBlistSiloLogic(BindingList<ObjSilo> _blstSilo)
        {
            Support.UpdateListSiloLogic(_blstSilo, (string)this.lueWeigh1.EditValue);
        }
        public override void GetBlstSiloLogic(BindingList<ObjSilo> _blstSilo) 
        {
            if (_blstSilo != null)
            {
                this.lueWeigh1.Properties.DataSource = _blstSilo;
                //this.lueWeigh2.Properties.DataSource = this._blstSiloLogicAggSelected1;
            }
        }
        /*protected override void lueWeigh1_EditValueChanged(object sender, EventArgs e)
        {
           *//* if (this.ChangeValueBlstLogic_01 == null)
            {
                return;
            }
            this.ChangeValueBlstLogic_01((object)this, new EventArgs());*//*
            //Support.GetListSiloLogic(this._blstSiloLogicAggSelected1, this.lueWeigh1);
            //lbase.ChangeValueBlstLogic_01 += this.SetBlistSiloLogic()

        }*/
        protected override void lueWeigh2_EditValueChanged(object sender, EventArgs e)
        {
            //Support.GetListSiloLogic(this._blstSiloLogicAggSelected2, numSelected);
        }
    }
}
