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
    public partial class frmReserve : Form
    {
        public int StudentID
        {
            get { return int.Parse(txtStudentid.Text); }
        }
        public int BookID
        {
            get { return int.Parse(txtBookid.Text); }
        }

        public frmReserve()
        {
            InitializeComponent();
        }

        private void txtStudentid_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtBookid.Text.Length > 0 && txtBookid.Text.Length >0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("학번과 도서번호를 입력하여 주십시오.");
            }
        }
    }
}
