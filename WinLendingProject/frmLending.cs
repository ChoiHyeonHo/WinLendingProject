using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinLendingProject.DB;

namespace WinLendingProject
{
    public partial class frmLending : Form
    {
        public frmLending()
        {
            InitializeComponent();
        }

        private void btnLend_Click(object sender, EventArgs e)
        {
            frmNewLending frm = new frmNewLending();
            if(frm.ShowDialog() == DialogResult.OK)
            {
                //대여
                LendingDB db = new LendingDB();
                try
                {
                    db.LendBook(frm.StudentId, frm.SelectdBookID);
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
                finally
                {
                    db.Dispose();
                }
            }
            
        }
    }
}
