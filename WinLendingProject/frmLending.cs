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

        private void frmLending_Load(object sender, EventArgs e)
        {
            // 데이터 그리드 뷰 컨트롤 초기 설정 => 컬럼구성

            //목록에 보여질 데이터 조회
            LoadData();
        }

        private void LoadData()
        {
            LendingDB db = new LendingDB();
            DataTable dt = db.GetLendAll();
            db.Dispose();

            DataView dv1 = new DataView(dt);
            dv1.RowFilter = "lendingstate = 0";
            dgvLendable.DataSource = dv1;

            DataView dv2 = new DataView(dt);
            dv2.RowFilter = "lendingstate = 1";
            dgvUnLendable.DataSource = dv2;
        }

        private void btnReserve_Click(object sender, EventArgs e)
        {
            frmReserve frm = new frmReserve();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    LendingDB db = new LendingDB();
                    bool result = db.ReserveBook(frm.StudentID, frm.BookID);
                    db.Dispose();

                    if (!result)
                        throw new Exception("예약을 다시 시도하여 주십시오.");
                    LoadData();
                }
                catch (Exception err)
                {
                    MessageBox.Show(err.Message);
                }
            }
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
