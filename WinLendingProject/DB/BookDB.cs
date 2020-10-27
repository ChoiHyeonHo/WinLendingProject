using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Data;

namespace WinLendingProject
{
    public struct Book
    {
        public int BookID;
        public string BookName;
        public string Auther;
        public string Publisher;

        public Book(int bookID, string bookName, string auther, string publisher)
        {
            this.BookID = bookID;
            this.BookName = bookName;
            this.Auther = auther;
            this.Publisher = publisher;
        }
    }

    class BookDB : IDisposable
    {
        MySqlConnection conn;
        public BookDB()
        {
            string strConn = ConfigurationManager.ConnectionStrings["gudi"].ConnectionString;
            conn = new MySqlConnection(strConn);
            conn.Open();
        }
        public bool Insert(Book book)
        {
            try
            {
                string sql = $"insert into book(bookid, bookname, auther, publisehr) values ({book.BookID}, '{book.BookName}', '{book.Auther}', '{book.Publisher}')";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return false;
            }
        }
        public bool Update(Book book)
        {
            try
            {
                string sql = $"update book set bookname = '{book.BookName}', auther = '{book.Auther}', publisehr = '{book.Auther}' where bookid = '{book.BookID}';";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return false;
            }
        }
        public bool Delete(int book)
        {
            try
            {
                string sql = $"delete from book where bookid = '{book}'";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return false;
            }
        }
        public DataTable GetAllData()
        {
            try
            {
                string sql = $"select bookid, bookname, auther, publisehr from book where deleted = 0";
                MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return null;
            }
        }

        public void Dispose()
        {
            conn.Close();
        }
    }
}
