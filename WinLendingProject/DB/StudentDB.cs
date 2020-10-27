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
                string sql = $"insert into student (studentid, studentname, department) values ({std.ID}, '{std.Name}', '{std.Dept}')";
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

        public bool Update(Student std)
        {
            try
            {
                string sql = $@"update student set studentname = '{std.Name}', 
                                                   department = '{std.Dept}' 
                                               where studentid = {std.ID}";

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

        public bool Delete(int stuID)
        {
            try
            {
                string sql = $@"delete from student where studentid = '{stuID}'";

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

        public void Dispose()
        {
            conn.Close();
        }
    }
}
