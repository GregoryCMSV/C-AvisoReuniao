using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeradorAvisoReuniao
{
    public partial class FrmNovoLocal : Form
    {
        public string LocalDigitado { get; private set; }

        public FrmNovoLocal()
        {
            InitializeComponent();
            LocalDigitado = "";
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (txtLocal.Text.Trim().Length == 0) return;
            LocalDigitado = txtLocal.Text;
            DialogResult = DialogResult.OK;
        }
    }
}
