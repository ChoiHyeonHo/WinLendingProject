using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinLendingProject
{
    public partial class UserControl1 : UserControl
    {
        public delegate void AddShoppingListEventHandler(object sender, AddShoppingListEventArgs e);
        public event AddShoppingListEventHandler AddCart;

        int bookID;

        public int BookID
        {
            get { return bookID; }
            set { bookID = value; }
        }

        public string BookName
        {
            get { return lblName.Text; }
            set { lblName.Text = value; }
        }
        public string Author
        {
            get { return lblAuthor.Text; }
            set { lblAuthor.Text = value; }
        }
        public string Publisher
        {
            get { return lblPublisher.Text; }
            set { lblPublisher.Text = value; }
        }
        public string BookImage
        {
            get { return pictureBox1.ImageLocation; }
            set { pictureBox1.ImageLocation = value; }
        }

        public UserControl1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (AddCart != null)
            {
                AddShoppingListEventArgs args = new AddShoppingListEventArgs();
                args.BookID = BookID;
                args.BookName = BookName;
                args.Author = Author;
                args.Publisher = Publisher;

                AddCart(this, args);
            }
        }
    }


    public class AddShoppingListEventArgs : EventArgs
    {
        string bookName, author, publisher;
        int bookID;

        public int BookID 
        {
            get { return bookID; }
            set { bookID = value; }
        }
        public string BookName
        {
            get { return bookName; }
            set { bookName = value; }
        }
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        public string Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }

    }
}
