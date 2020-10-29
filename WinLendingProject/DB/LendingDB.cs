using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;
using System.Data;

namespace WinLendingProject
{
    public class LendingDB : IDisposable
    {
        MySqlConnection conn;
        public LendingDB()
        {
            string strConn = ConfigurationManager.ConnectionStrings["gudi"].ConnectionString;
            conn = new MySqlConnection(strConn);
            conn.Open();
        }

        public void LendBook(int studentID, int[] bookIDs)
        {
            StudentDB student = new StudentDB();
            bool result = student.IsValid(studentID);
            if (!result)
            {
                throw new Exception("존재하지 않는 학생입니다.");
            }
            student.Dispose();

            //대여 로직 시작

            // 1. Lending Insert 1건

            // 2. LendingItem Insert 여러 건
            //    Book Update 여러건(lendingState, reserveStuID)

            //예약한 학번이 대여학번과 동ㅇ리하면 예약학번을 Clear
            //update, delete는 where절이 참일때만 dml문장이 실행된다.
            //0건 적용이 되더라도 오류발생X

            //트랜잭션 : 여러개의 커맨드를 하나의 단위로 묶어서 처리
            //          여러개의 커맨드가 모두 성공이면 마지막에 commit(), 문제시 실행되었던 모든 커맨드를 rollback()
            MySqlTransaction trans = conn.BeginTransaction();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                MySqlCommand updateCmd = new MySqlCommand();
                MySqlCommand updateRevCmd = new MySqlCommand();
                //cmd.CommandText = "SP_StudentInsUp";
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandType = CommandType.Text;

                cmd.CommandText = $"insert into lending(studentid, lenddate) values (@studentid, now());select last_insert_id();";
                //-- 마스터 / 디테일의 관계로 Insert할 때에는 마스터를 insert하면서 동시에 AI된 값을 Select해아만 한다.
                cmd.Connection = conn;
                cmd.Transaction = trans;

                //MySqlParameter param = new MySqlParameter("@studentid", MySqlDbType.Int32);
                //param.Value = studentID;
                //cmd.Parameters.Add(param);

                cmd.Parameters.Add("@studentid", MySqlDbType.Int32);
                cmd.Parameters["@studentid"].Value = studentID;

                //cmd.Parameters.AddWithValue("@studentid", studentID); 
                // AddWithValue() 값에 따라서 자동으로 타입 결정

                int newLendingID = Convert.ToInt32(cmd.ExecuteScalar()); //신규 입력된 AI값

                //-------------------------------------------------------------------------
                cmd.Parameters.Clear();
                cmd.CommandText = $@"insert into lendingitem (lendingid, bookitem, bookid) 
                                         values(@lendingid, @bookitem, @bookid)";
                cmd.Parameters.Add("@lendingid", MySqlDbType.Int32);
                cmd.Parameters.Add("@bookitem", MySqlDbType.Int32);
                cmd.Parameters.Add("@bookid", MySqlDbType.Int32);

                updateCmd.Connection = conn;
                updateCmd.Transaction = trans;
                updateCmd.CommandText = $"update book set lendingstate = 1 where bookid = @bookid";
                updateCmd.Parameters.Add("@bookid", MySqlDbType.Int32);

                updateRevCmd.Connection = conn;
                updateRevCmd.Transaction = trans;
                updateRevCmd.CommandText = $"update book set reservestuid = 0 where bookid = @bookid and reservestuid = @reservestuid";
                updateRevCmd.Parameters.Add("@bookid", MySqlDbType.Int32);
                updateRevCmd.Parameters.Add("@reservestuid", MySqlDbType.Int32);

                for (int i = 0; i < bookIDs.Length; i++)
                {
                    cmd.Parameters["@lendingid"].Value = newLendingID;
                    cmd.Parameters["@bookitem"].Value = i + 1;
                    cmd.Parameters["@bookid"].Value = bookIDs[i];
                    cmd.ExecuteNonQuery();

                    //---------------------------------------------------------------------------

                    updateCmd.Parameters["@bookid"].Value = bookIDs[i];
                    updateCmd.ExecuteNonQuery();

                    //---------------------------------------------------------------------------

                    updateRevCmd.Parameters["@bookid"].Value = bookIDs[i];
                    updateRevCmd.Parameters["@reservestuid"].Value = studentID;
                    updateRevCmd.ExecuteNonQuery();
                }

                trans.Commit();
            }
            catch (Exception err)
            {
                trans.Rollback();
                throw err;
            }
        }

        public DataTable GetLendAll()
        {
            DataTable dt = new DataTable();
            string sql = $@"select b.bookid, bookname, auther, publisehr, 
			                ifnull(lendingstate, 0) lendingstate, 
                            ifnull(studentid, 0) studentid,
                            ifnull(reservestuid, 0) reservestuid
                            from book b left outer join (select bookid, L.lendingid, studentid
                            from lending L inner join (select bookid, max(lendingid) lendingid
                            from lendingitem
                            group by bookid) Li
		                    on L.lendingid = Li.lendingid) L on b.bookid = L.bookid
                            where deleted = 0;";

            MySqlDataAdapter da = new MySqlDataAdapter(sql, conn);
            da.Fill(dt);

            return dt;
        }

        /// <summary>
        /// 도서예약
        /// </summary>
        /// <param name="stuid">학번</param>
        /// <param name="bookid">도서번호</param>
        /// <returns>예약성공여부</returns>
        public bool ReserveBook(int stuid, int bookid)
        {
            //유효성체크
            //학번이 유효한지, 도서번호가 유효한지, 대여가능한지, 예약상태인지
            //대여한 학생이 또 예약하는 것은 현재 허용
            StudentDB stu = new StudentDB();
            if (!stu.IsValid(stuid))
            {
                throw new Exception("유효한 학번이 아닙니다.");
            }
            stu.Dispose();

            BookDB bk = new BookDB();
            if (!bk.IsValid(bookid))
                throw new Exception("유효한 도서가 아닙니다.");
            else if (!bk.IsLended(bookid))
                throw new Exception("대여 가능한 도서입니다.");
            else
            {
                if (bk.IsReserved(bookid))
                {
                    throw new Exception("이미 예약된 도서입니다.");
                }
                bk.Dispose();

                try
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.CommandText = "update book set reservestuid = @reservestuid where bookid = @bookid";
                    cmd.Connection = conn;

                    cmd.Parameters.Add("@reservestuid", MySqlDbType.Int32);
                    cmd.Parameters["@reservestuid"].Value = stuid;

                    cmd.Parameters.Add("@bookid", MySqlDbType.Int32);
                    cmd.Parameters["@bookid"].Value = bookid;

                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception err)
                {
                    throw err;
                    //return false; //도달하지 않는 코드
                }
            }
        }

        /// <summary>
        /// 도서반납
        /// </summary>
        /// <param name="bookid">도서번호</param>
        public void ReturnBook(int bookid)
        {
            //유효성체크 - 도서번호가 유효한지
            BookDB book = new BookDB();
            if (!book.IsValid(bookid))
                throw new Exception("유효하지 않는 도서번호입니다.");

            MySqlTransaction trans = conn.BeginTransaction();

            try
            {
                string sql = "update book set lendingstate = 0 where bookid = @bookid;";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Transaction = trans;
                cmd.Parameters.Add("@bookid", MySqlDbType.Int32);
                cmd.Parameters["@bookid"].Value = bookid;
                cmd.ExecuteNonQuery();

                cmd.CommandText = @"update lendingitem set returndate = @time 
                                where bookid = @bookid and returndate is null;";

                cmd.Parameters.Add("@time", MySqlDbType.DateTime);
                cmd.Parameters["@time"].Value = DateTime.Now; //클래스의 시간

                cmd.ExecuteNonQuery();

                trans.Commit();
            }
            catch (Exception err)
            {
                trans.Rollback();
                throw err;
            }
        }

        public void Dispose()
        {
            conn.Close();
        }
    }
}
