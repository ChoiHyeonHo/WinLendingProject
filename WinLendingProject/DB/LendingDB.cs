using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace WinLendingProject.DB
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

                for (int i = 0; i < bookIDs.Length; i++)
                {
                    cmd.Parameters.Clear();
                    cmd.CommandText = $@"insert into lendingitem (lendingid, bookitem, bookid) 
                                         values(@newLendingID, @bookitem, @bookid)";

                    cmd.Parameters.Add("@lendingid", MySqlDbType.Int32);
                    cmd.Parameters["@newLendingID"].Value = newLendingID;

                    cmd.Parameters.Add("@bookitem", MySqlDbType.Int32);
                    cmd.Parameters["@bookitem"].Value = newLendingID;

                    cmd.Parameters.Add("@bookid", MySqlDbType.Int32);
                    cmd.Parameters["@bookid"].Value = newLendingID;
                    cmd.ExecuteNonQuery();

                    //---------------------------------------------------------------------------
                    
                    cmd.Parameters.Clear();
                    cmd.CommandText = $"update book set lendingstate = 1 where bookid = @bookid";

                    cmd.Parameters.Add("@bookid", MySqlDbType.Int32);
                    cmd.Parameters["@bookid"].Value = bookIDs;

                    cmd.ExecuteNonQuery();

                    //---------------------------------------------------------------------------

                    cmd.Parameters.Clear();
                    cmd.CommandText = $"update book set reservedid = 0 where bookid = @bookid and reservestuid = @reservestuid";

                    cmd.Parameters.Add("@bookid", MySqlDbType.Int32);
                    cmd.Parameters["@bookid"].Value = bookIDs[i];

                    cmd.Parameters.Add("@reservestuid", MySqlDbType.Int32);
                    cmd.Parameters["@reservestuid"].Value = studentID;

                    cmd.ExecuteNonQuery();
                }

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
