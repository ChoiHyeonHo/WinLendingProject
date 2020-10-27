using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinLendingProject
{
    public partial class frmBookSearch : Form
    {
        public int BookID
        {
            get { return int.Parse(txtbookid.Text); }
        }
        public frmBookSearch()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtbookid.Text.Length < 8)
            {
                MessageBox.Show("8자리의 책번호를 입력해 주십시오.");
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void txtbookid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtbookid.Text.Length == 8)
                {
                    btnOK.PerformClick();
                }
                else
                {
                    btnCancle.PerformClick();
                }
            }
            else if(! char.IsNumber(e.KeyChar) && e.KeyChar != '\b' )
            {
                e.Handled = true;
            }
        }
    }
}
