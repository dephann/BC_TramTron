using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NDPSo
{
    public partial class From : DevExpress.XtraBars.TabForm
    {
        public From()
        {
            InitializeComponent();
        }
        
        static int OpenFormCount = 1;
        public void EnabledCloseAllDocs()
        {
            
        }
    }

}
