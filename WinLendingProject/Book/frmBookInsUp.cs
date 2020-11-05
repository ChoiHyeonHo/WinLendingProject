using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WinLendingProject
{
    public partial class frmBookInsUp : Form
    {
        int bookId;
        public enum OpenMode { Insert, Update }

        public Book bookInfo
        {
            get { return new Book(int.Parse(txtBookId.Text), txtBookName.Text, txtAuther.Text, txtPublisher.Text, textBox2.Text); }
            set
            {
                txtBookId.Text = value.BookID.ToString();
                txtBookName.Text = value.BookName;
                txtAuther.Text = value.Author;
                txtPublisher.Text = value.Publisher;
                textBox2.Text = value.BookImage;
            }
        }
        public frmBookInsUp(OpenMode open)
        {
            InitializeComponent();

            if (open == OpenMode.Insert)
            {
                this.Text = "책 정보 등록";
                txtBookId.Enabled = true;
            }
            else
            {
                this.Text = "책 정보 수정";
                txtBookId.Enabled = false;
            }
        }

        private void txtBookId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //유효성체크
            StringBuilder sb = new StringBuilder();

            if (txtBookId.Text.Trim().Length < 8)
            {
                sb.AppendLine("유효한 책번호가 아닙니다.");
            }

            if (string.IsNullOrEmpty(txtBookName.Text))
            {
                sb.AppendLine("책이름을 입력하세요.");
            }

            if (sb.ToString().Length > 0)
            {
                MessageBox.Show(sb.ToString());
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Images Files(*.jpg;*.gif;*jpeg;*.png;,*.bmp)|*.jpg;*.gif;*jpeg;*.png;,*.bmp";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                textBox2.Text = dlg.FileName;
                pictureBox1.Image = Image.FromFile(dlg.FileName);
                pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                pictureBox1.Tag = dlg.FileName;
                SavePahtImage();
            }
        }

        private void SavePahtImage()
        {
            string sPath = $"BookImage/{bookId}";
            string localFile = pictureBox1.Tag.ToString();
            string sExt = localFile.Substring(localFile.LastIndexOf("."));
            string newFileName = DateTime.Now.ToString("yyyyMMddHHmmssfff") + sExt;
            string destFileName = Path.Combine(sPath, newFileName);
            textBox2.Text = destFileName;
            DirectoryInfo dir = new DirectoryInfo(sPath);
            if (!dir.Exists)
            {
                dir.Create();
            }

            File.Copy(localFile, destFileName, true);
            BookDB db = new BookDB();
            bool bResult = db.AddBookImage(bookId, destFileName);
            if (bResult)
            {
                MessageBox.Show("이미지 추가가 완료되었습니다.");
                //textBox2.Text = newFileName;
            }
            else
            {
                MessageBox.Show("이미지 저장에 실패했습니다. 다시 시도하여 주십시오.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SavePahtImage();
        }
    }
}
