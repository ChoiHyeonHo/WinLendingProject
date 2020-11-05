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
    public partial class frmNewLending : Form
    {
        public int StudentId
        {
            get { return int.Parse(txtStudentid.Text); }
        }
        public int[] SelectdBookID
        {
            get
            {
                int[] bookIDs = new int[lstLendBook.Items.Count];
                for (int i = 0; i < bookIDs.Length; i++)
                {
                    string[] arr = lstLendBook.Items[i].ToString().Split('/');
                    bookIDs[i] = Convert.ToInt32(arr[0].Trim());
                }
                return bookIDs;
            }
        }
        public frmNewLending()
        {
            InitializeComponent();
        }

        private void NumberInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            BookDB db = new BookDB();
            int bookID = int.Parse(txtBookid.Text);
            //유효성체크
            // 1. 입력한 도서번호가 유효한 도서번호인지 체크
            if (!db.IsValid(bookID))
            {
                MessageBox.Show("도서가 존재하지 않습니다.");
            }

            // 2. 대여중인 도서인지 체크

            else if (db.IsLended(bookID))
            {
                MessageBox.Show("대여중인 도서입니다.");
            }


            // 3. 대여가능하지만 예약한 학번이 입력한 학번인지 체크

            else
            {
                int stuid = int.Parse(txtStudentid.Text);
                //예약한 학번 조회 (0 또는 이미 예약한 학번)
                int reserveStuid = db.GetReserveStuId(bookID);
                if (reserveStuid > 0 && reserveStuid != stuid)
                {
                    MessageBox.Show("이미 예약된 도서입니다.");
                }
                else
                {
                    //입력된 도서를 대여목록(ListBox)에 추가한다
                    Book curBook = db.GetBookInfo(bookID);
                    lstLendBook.Items.Add($"{curBook.BookID} / {curBook.BookName} / {curBook.Author} / {curBook.Publisher}");
                    txtBookid.Text = "";
                }
            }

            db.Dispose();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txtStudentid.Text.Length < 1)
            {
                MessageBox.Show("학번을 입력하세요");
            }
            else if(lstLendBook.Items.Count < 1)
            {
                MessageBox.Show("도서를 추가해 주세요");
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();

            }
        }
    }
}
