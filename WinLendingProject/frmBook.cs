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
    public partial class frmBook : Form
    {
        public frmBook()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmBookInsUp frm = new frmBookInsUp();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Book book = frm.bookInfo;
                BookDB bookdb = new BookDB();
                bool result = bookdb.Insert(book);
                bookdb.Dispose();
                if (result)
                {
                    MessageBox.Show("추가 되었습니다.");
                    LoadData();
                }
                else
                    MessageBox.Show("다시 시도하여 주십시오.");
            }
        }

        private void frmBook_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        public void LoadData()
        {
            BookDB bookdb = new BookDB();
            DataTable dt = bookdb.GetAllData();
            bookdb.Dispose();
            dataGridView1.DataSource = dt;
        }
    }
}
