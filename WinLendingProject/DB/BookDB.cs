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

    class BookDB : IDisposable
    {
        MySqlConnection conn;
        public BookDB()
        {
            string strConn = ConfigurationManager.ConnectionStrings["gudi"].ConnectionString;
            conn = new MySqlConnection(strConn);
            conn.Open();
        }

        public DataTable GetBookImage()
        {
            string sql = "select bookID, bookName, author, publisher, bookImage from book;";

            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        public bool AddBookImage(int bid, string path)
        {
            string sql = @"insert into book(bookID, bookImage) 
                           values(@bid, @path)";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.Add("@bid", MySqlDbType.Int32);
            cmd.Parameters["@bid"].Value = bid;

            cmd.Parameters.Add("@path", MySqlDbType.VarChar);
            cmd.Parameters["@path"].Value = path;

            int iResult = cmd.ExecuteNonQuery();
            if (iResult > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Insert(Book book)
        {
            try
            {
                string sql = $@"update book set bookID = @bookID,  bookName = @bookName, author = @author, publisher = @publisher
                                 where bookImage = @bookImage; ";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.Clear();

                cmd.Parameters.Add("@bookid", MySqlDbType.Int32);
                cmd.Parameters["@bookid"].Value = book.BookID;

                cmd.Parameters.Add("@bookname", MySqlDbType.VarChar);
                cmd.Parameters["@bookname"].Value = book.BookName;

                cmd.Parameters.Add("@author", MySqlDbType.VarChar);
                cmd.Parameters["@author"].Value = book.Author;

                cmd.Parameters.Add("@publisher", MySqlDbType.VarChar);
                cmd.Parameters["@publisher"].Value = book.Publisher;

                cmd.Parameters.Add("@bookImage", MySqlDbType.VarChar);
                cmd.Parameters["@bookImage"].Value = book.BookImage;

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
                string sql = $"update book set bookname = @bookname, auther = @auther, publisehr = @publisehr where bookid = @bookid;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.Clear();

                cmd.Parameters.Add("@bookname", MySqlDbType.VarChar);
                cmd.Parameters["@bookname"].Value = book.BookName;

                cmd.Parameters.Add("@auther", MySqlDbType.VarChar);
                cmd.Parameters["@auther"].Value = book.Author;

                cmd.Parameters.Add("@publisehr", MySqlDbType.VarChar);
                cmd.Parameters["@publisehr"].Value = book.Publisher;

                cmd.Parameters.Add("@bookid", MySqlDbType.Int32);
                cmd.Parameters["@bookid"].Value = book.BookID;

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
                string sql = $"update book set deleted 1 where bookid = @bookid";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.Clear();

                cmd.Parameters.Add("@bookid", MySqlDbType.Int32);
                cmd.Parameters["@bookid"].Value = book;

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return false;
            }
        }

        public bool IsValid(int bkID) // 도서번호가 유효하면 true
        {
            string sql = $"select count(*) from book where deleted = 0 and bookid = @bookid";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.Clear();

            cmd.Parameters.Add("@bookid", MySqlDbType.Int32);
            cmd.Parameters["@bookid"].Value = bkID;

            int cnt = Convert.ToInt32(cmd.ExecuteScalar()); //1개의 정보를 가져올때
            if (cnt == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsReserved(int bkID) // 예약중이면 true
        {
            string sql = "select ifnull(reservestuid, 0) reservestuid from book where deleted = 0 and bookid = @bookid;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.Add("@bookid", MySqlDbType.Int32);
            cmd.Parameters["@bookid"].Value = bkID;

            int cnt = Convert.ToInt32(cmd.ExecuteScalar());
            if (cnt > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsLended(int bkID) // 대여중이면 true
        {
            string sql = $"select ifnull(lendingstate, 0) lendingstate from book where deleted = 0 and bookid = @bookid;";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.Clear();

            cmd.Parameters.Add("@bookid", MySqlDbType.Int32);
            cmd.Parameters["@bookid"].Value = bkID;

            int cnt = Convert.ToInt32(cmd.ExecuteScalar());
            if (cnt > 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public int GetReserveStuId(int bkID) // 도서를 예약한 학번 (예약이 없는경우 0, 있으면 학번)
        {
            string sql = $@"select ifnull(reservestuid, 0) reservestid
                              from book where deleted = 0 and bookid = @bookid; ";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.Clear();

            cmd.Parameters.Add("@bookid", MySqlDbType.Int32);
            cmd.Parameters["@bookid"].Value = bkID;

            int stuId = Convert.ToInt32(cmd.ExecuteScalar());
            //Convert.ToInt32() => null일 경우 0반환
            return stuId;
        }

        public Book GetBookInfo(int bkID) //특정 도서번호에 해당하는 도서 정보를 반환
        {
            Book book = new Book();
            string sql = $@"select bookid, bookname, auther, publisehr from book where bookid = @bookid";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.Clear();

            cmd.Parameters.Add("@bookid", MySqlDbType.Int32);
            cmd.Parameters["@bookid"].Value = bkID;

            MySqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                book.BookID = Convert.ToInt32(reader["bookid"]);
                book.BookName = reader["bookname"].ToString();
                book.Author = reader["auther"].ToString();
                book.Publisher = reader["publisehr"].ToString();
            }
            return book;
        }

        public DataTable GetAllData()
        {
            try
            {
                string sql = $@"select bookID, bookName, author, publisher,
                                case when ifnull(lendingstate, 0) = 0  then '대여가능'
                                else '대여중' end lendingstate, resesrvestuid
                                from book;";
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
