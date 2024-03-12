using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NDPSo.MasterData.TronOnlineView.UserControls
{
    public partial class UcHeThongAuto : UserControl
    {
		public event EventHandler ButtonClick;
		private bool _isAuto = true;
		private CheDo _cheDo;
		public CheDo CheDoChay
        {
			get => _cheDo;
            set
            {
				this._cheDo = value;
                switch (this._cheDo)
                {
					case CheDo.Auto:
                        {
							picBackground.BackgroundImage = ResourceNDP.SelectorSwitchRight;
							IsAuto = true;
							break;
						}
						
					case CheDo.Manual:
                        {
							picBackground.BackgroundImage = ResourceNDP.SelectorSwitchLeft;
							IsAuto = false;
							break;
						}
						
                }
            }
        }
		public enum CheDo
        {
			Auto,
			Manual
        } 
		public UcHeThongAuto()
        {
            InitializeComponent();
        }

		public bool IsAuto
		{
			get => _isAuto;
			set
			{
				_isAuto = value;
				
			}
		}


		private void picBackground_Click(object sender, EventArgs e)
        {
			OnButtonClick(EventArgs.Empty);
		}

		protected virtual void OnButtonClick(EventArgs e)
		{
			ButtonClick?.Invoke(this, e);
            if (CheDoChay == CheDo.Auto)
            {
				CheDoChay = CheDo.Manual;
				//IsAuto = false;
            }
            else if(CheDoChay == CheDo.Manual)
            {
				CheDoChay = CheDo.Auto;
				//IsAuto = true;
            }
		}
    }
}
