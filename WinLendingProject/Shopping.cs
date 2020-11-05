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
    public partial class Shopping : Form
    {
        DataTable dtShopping;

        public Shopping()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InitShopping();

            BookDB db = new BookDB();
            DataTable dt = db.GetBookImage();
            db.Dispose();

            int idx = 1;
            //int rowCnt = (int)Math.Ceiling(dt.Rows.Count / 2.0);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int k = 0; k < 1; k++)
                {
                    if (idx > dt.Rows.Count)
                    {
                        break;
                    }
                    UserControl1 book = new UserControl1();
                    book.Name = $"Book{idx}";
                    book.Text = idx.ToString();
                    book.Location = new Point((k) + 10, (i * 50) + 10);
                    book.Size = new Size(430, 55);
                    book.BookID = Convert.ToInt32(dt.Rows[idx - 1]["bookID"]);
                    book.BookName = dt.Rows[idx - 1]["bookName"].ToString();
                    book.Author = dt.Rows[idx - 1]["author"].ToString();
                    book.Publisher =dt.Rows[idx - 1]["Publisher"].ToString();
                    book.BookImage = dt.Rows[idx - 1]["bookImage"].ToString();
                    book.AddCart += Book_AddShoppingList;

                    panel1.Controls.Add(book);
                    idx++;
                }
            }
        }

        private void InitShopping()
        {
            dtShopping = new DataTable();
            dtShopping.Columns.Add(new DataColumn("BookID", typeof(int)));
            dtShopping.Columns.Add(new DataColumn("BookName", typeof(string)));
            dtShopping.Columns.Add(new DataColumn("Author", typeof(string)));
            dtShopping.Columns.Add(new DataColumn("Publisher", typeof(string)));
            dtShopping.Columns.Add(new DataColumn("BookQty", typeof(int)));
        }

        private void Book_AddShoppingList(object sender, AddShoppingListEventArgs e)
        {
            DataRow[] drRows = dtShopping.Select("BookID=" + e.BookID);
            if (drRows.Length > 0) // 리스트에 이미 있는 경우
            {
                drRows[0]["BookQty"] = Convert.ToInt32(drRows[0]["bookQty"]) + 1;
            }
            else
            {
                DataRow dr = dtShopping.NewRow();
                dr["BookID"] = e.BookID;
                dr["BookName"] = e.BookName;
                dr["Author"] = e.Author;
                dr["Publisher"] = e.Publisher;
                dr["BookQty"] = 1;
                dtShopping.Rows.Add(dr);
            }

            dtShopping.AcceptChanges();
            dataGridView1.DataSource = dtShopping;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.ClientSize = new System.Drawing.Size(1004, 413);
            btnOpen.Visible = false;
            btnFold.Visible = true;
        }

        private void Shopping_Load(object sender, EventArgs e)
        {
            btnFold.Visible = false;
        }

        private void btnFold_Click(object sender, EventArgs e)
        {
            this.ClientSize = new Size(464, 413);
            btnFold.Visible = false;
            btnOpen.Visible = true;
        }
    }
}
