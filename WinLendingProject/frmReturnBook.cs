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
    public partial class frmReturnBook : Form
    {
        public frmReturnBook()
        {
            InitializeComponent();
        }

        private void frmReturnBook_Load(object sender, EventArgs e)
        {
            LoadData();
        }
        private void LoadData()
        {
            LendingDB db = new LendingDB();
            DataTable dt = db.GetLendAll();
            db.Dispose();

            DataView dv1 = new DataView(dt);
            dv1.RowFilter = "lendingstate = 1";
            dgvLendable.DataSource = dv1; //대여중

            DataView dv2 = new DataView(dt);
            dv2.RowFilter = "lendingstate = 0";
            dgvUnLendable.DataSource = dv2; //대여가능
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            //유효성 체크
            if (txtbookID.Text.Trim().Length < 1)
            {
                MessageBox.Show("반납할 도서 번호를 입력하세요.");
                return;
            }

            //DB반영
            LendingDB db = new LendingDB();
            try
            {
                db.ReturnBook(int.Parse(txtbookID.Text));
                LoadData();
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
