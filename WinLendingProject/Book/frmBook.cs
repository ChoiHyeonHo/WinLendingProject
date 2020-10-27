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
            frmBookInsUp frm = new frmBookInsUp(frmBookInsUp.OpenMode.Insert);
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
            CommonUtil.SetInitGridView(dataGridView1);
            CommonUtil.AddGridTextColumn(dataGridView1, "책 번호", "bookid", 150);
            CommonUtil.AddGridTextColumn(dataGridView1, "책 이름", "bookname", 200);
            CommonUtil.AddGridTextColumn(dataGridView1, "저자", "auther", 100);
            CommonUtil.AddGridTextColumn(dataGridView1, "출판사", "publisher", 150);
            LoadData();
        }

        public void LoadData()
        {
            BookDB bookdb = new BookDB();
            DataTable dt = bookdb.GetAllData();
            bookdb.Dispose();
            dataGridView1.DataSource = dt;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int rowIndex = dataGridView1.CurrentRow.Index;

            Book bk;
            bk.BookID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            bk.BookName = dataGridView1[1, rowIndex].Value.ToString(); //위와 같지만 다른 방법
            bk.Auther = dataGridView1[2, rowIndex].Value.ToString();
            bk.Publisher = dataGridView1[3, rowIndex].Value.ToString();

            frmBookInsUp frm = new frmBookInsUp(frmBookInsUp.OpenMode.Update);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                Book book = frm.bookInfo;
                BookDB bookdb = new BookDB();
                bool result = bookdb.Update(book);
                bookdb.Dispose();
                if (result)
                {
                    MessageBox.Show("추가되었습니다.");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("다시 시도하여 주십시오.");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string bookname = dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString();

            if (MessageBox.Show($"{bookname}의 정보를 삭제하시겠습니까?", "삭제확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int bookID = (int)dataGridView1[0, dataGridView1.CurrentRow.Index].Value;
                StudentDB db = new StudentDB();
                bool result = db.Delete(bookID);
                db.Dispose();

                if (result)
                {
                    LoadData();
                }
                else
                {
                    MessageBox.Show("다시 시도하여 주십시오.");
                }

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }
    }
}
