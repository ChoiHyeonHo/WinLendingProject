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
            CommonUtil.AddGridTextColumn(dataGridView1, "출판사", "publisehr", 150);
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
            frm.bookInfo = bk;
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
            int rowIndex = dataGridView1.CurrentRow.Index;
            string bookname = dataGridView1[1, rowIndex].Value.ToString();

            if (MessageBox.Show($"{bookname}의 정보를 삭제하시겠습니까?", "삭제확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                int bookID = (int)dataGridView1[0, dataGridView1.CurrentRow.Index].Value;
                BookDB db = new BookDB();
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
            frmBookSearch frm = new frmBookSearch();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                int bookID = frm.BookID;

                DataTable dt = (DataTable)dataGridView1.DataSource;
                //DataRow[] rows = dt.Select("studentid = " + stuID);
                //if (rows.Length == 0)
                //{
                //    MessageBox.Show("등록된 정보를 찾을 수 없습니다.");
                //}
                //else
                //{
                //    MessageBox.Show(rows[0][1].ToString());
                //}

                DataView dv = dt.DefaultView;
                dv.Sort = "bookid";
                int rowIdx = dv.Find(bookID); //Find()를 사용하기 전에 찾는 값으로 Sort 먼저 해야함
                if (rowIdx == -1)
                {
                    MessageBox.Show("등록된 책 정보를 찾을 수 없습니다.");
                }
                else
                {
                    dataGridView1.ClearSelection();
                    dataGridView1.CurrentCell = dataGridView1.Rows[rowIdx].Cells[0];
                }
            }
        }
    }
}
