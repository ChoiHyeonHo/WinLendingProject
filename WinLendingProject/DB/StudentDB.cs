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
{/// <summary>
/// 학생정보
/// </summary>
    public struct Student
    {
        //학번 이름 전공을 하나로 묶어주는 Class
        public int ID;
        public string Name;
        public string Dept;
        public Student(int stuID, string stuName, string stuDept)
        {
            ID = stuID;
            Name = stuName;
            Dept = stuDept;
        }
    }

    /// <summary>
    /// 학생관리를 위한 CRUD 메서드를 정의
    /// </summary>
    public class StudentDB : IDisposable
    {
        MySqlConnection conn;
        public StudentDB()
        {
            string strConn = ConfigurationManager.ConnectionStrings["gudi"].ConnectionString;
            conn = new MySqlConnection(strConn);
            conn.Open();
        }

        public bool Insert(Student std)
        {
            try
            {
                string sql = $@"insert into student (studentid, studentname, department) 
                                values (@studentid, @studentname, @department)";
                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.Add("@studentid", MySqlDbType.Int32);
                cmd.Parameters["@studentid"].Value = std.ID;

                cmd.Parameters.Add("@studentname", MySqlDbType.VarChar);
                cmd.Parameters["@studentname"].Value = std.Name;

                cmd.Parameters.Add("@department", MySqlDbType.VarChar);
                cmd.Parameters["@department"].Value = std.Dept;

                
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return false;
            }
        }

        public bool Update(Student std)
        {
            try
            {
                string sql = $@"update student set studentname = @studentname, 
                                                   department = @department 
                                               where studentid = @studentid";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.Clear();

                cmd.Parameters.Add("@studentname", MySqlDbType.VarChar);
                cmd.Parameters["@studentname"].Value = std.Name;

                cmd.Parameters.Add("@department", MySqlDbType.VarChar);
                cmd.Parameters["@department"].Value = std.Dept;

                cmd.Parameters.Add("@studentid", MySqlDbType.VarChar);
                cmd.Parameters["@studentid"].Value = std.ID;

                cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception err)
            {
                Debug.WriteLine(err.Message);
                return false;
            }
        }

        public bool Delete(int stuID)
        {
            try
            {
                string sql = $@"update student set deleted 1 where studentid = @studentid";

                MySqlCommand cmd = new MySqlCommand(sql, conn);

                cmd.Parameters.Clear();

                cmd.Parameters.Add(@"studentid", MySqlDbType.Int32);
                cmd.Parameters[@"studentid"].Value = stuID;

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
                string sql = $"select studentid, studentname, department from student where deleted = 0";
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

        public bool IsValid(int stuID) //학번이 유효하면 true
        {
            string sql = $"select count(*) from student where deleted = 0 and studentid = @studentid";
            MySqlCommand cmd = new MySqlCommand(sql, conn);

            cmd.Parameters.Add("@studentid", MySqlDbType.Int32);
            cmd.Parameters["@studentid"].Value = stuID;

            int cnt = Convert.ToInt32(cmd.ExecuteScalar());
            if (cnt ==1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public void Dispose()
        {
            conn.Close();
        }
    }
}
