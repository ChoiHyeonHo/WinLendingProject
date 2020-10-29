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
    public partial class frmMain : Form
    {

        public frmMain()
        {
            InitializeComponent();
        }

        private void 학생관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmStudent frm = frmStudent.CreateStudentForm();
            frm.MdiParent = this;
            frm.WindowState = FormWindowState.Maximized;
            frm.Show();
            frm.Activate();
        }

        private void 도서관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBook frm = new frmBook();
            frm.MdiParent = this;
            frm.Activate();
            frm.Show();
        }

        private void 대여관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLending frm = new frmLending();
            frm.MdiParent = this;
            frm.Show();
            frm.Activate();
        }

        private void 반납관리ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReturnBook frm = new frmReturnBook();
            frm.MdiParent = this;
            frm.Show();
        }
    }
}
