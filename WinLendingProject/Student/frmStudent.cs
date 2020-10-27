using MySqlX.XDevAPI.Common;
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
    public partial class frmStudent : Form
    {
        public frmStudent()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmStudentInsUp frm = new frmStudentInsUp(frmStudentInsUp.OpenMode.Insert);
            if (frm.ShowDialog() == DialogResult.OK)
            {
                //입력받은 값으로 DB에 저장
                Student stu = frm.stuInfo;
                StudentDB db = new StudentDB();
                bool result = db.Insert(stu);
                db.Dispose();
                if (result)
                {
                    MessageBox.Show("추가 되었습니다.");
                    LoadData();
                }
                else
                    MessageBox.Show("다시 시도하여 주십시오.");
            }
        }

        private void frmStudent_Load(object sender, EventArgs e)
        {
            //폼 로드 이벤트에는 주로 폼의 컨트롤들의 초기 세팅.
            CommonUtil.SetInitGridView(dataGridView1);
            CommonUtil.AddGridTextColumn(dataGridView1, "학번", "studentid", 150);
            CommonUtil.AddGridTextColumn(dataGridView1, "학생명", "studentname", 200);
            CommonUtil.AddGridTextColumn(dataGridView1, "학과", "department", 300);
            LoadData();
        }

        private void LoadData()
        {
            StudentDB db = new StudentDB();
            DataTable dt = db.GetAllData();
            db.Dispose();
            dataGridView1.DataSource = dt; //DataSet, DataTable, DataView, List<T> 등등 가능
            //dataGridView1.ClearSelection(); 로드시 파란색줄 선택 없게하는
        }

        private void btnUpdate_Click(object sender, EventArgs e)//수정
        {
            //현재 그리드뷰에서 선택된 학생 정보를 조회
            int rowIndex = dataGridView1.CurrentRow.Index;

            Student stu;
            stu.ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            stu.Name = dataGridView1[1, rowIndex].Value.ToString(); //위와 같지만 다른 방법
            stu.Dept = dataGridView1[2, rowIndex].Value.ToString();

            //학생 정보를 수정폼에 전달해서 오픈
            frmStudentInsUp frm = new frmStudentInsUp(frmStudentInsUp.OpenMode.Update);
            frm.stuInfo = stu;
            if(frm.ShowDialog() == DialogResult.OK)
            {
                //변경된 학생 정보를 DB에 수정
                StudentDB db = new StudentDB();
                bool result = db.Update(frm.stuInfo);
                db.Dispose();
                if (result)
                {
                    MessageBox.Show("수정 되었습니다.");
                    LoadData();
                }
                else
                    MessageBox.Show("다시 시도하여 주십시오.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //선택된 학생을 삭제할건지 확인
            int rowIndex = dataGridView1.CurrentRow.Index;
            string name = dataGridView1[1, rowIndex].Value.ToString();

            if (MessageBox.Show($"{name} 학생 정보를 삭제하시겠습니까?", "삭제 확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //DB에서 데이터 삭제

                int stuID = (int)dataGridView1[0, dataGridView1.CurrentRow.Index].Value;
                StudentDB db = new StudentDB();
                bool result = db.Delete(stuID);
                db.Dispose();

                if (result)
                {
                    //MessageBox.Show("삭제되었습니다.");
                    LoadData();
                }
                else
                {
                    MessageBox.Show("다시 시도하여 주십시오.");
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            //formClose (e.Calcel = true) => formClosed
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            frmStudentSearch frm = new frmStudentSearch();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                int stuID = frm.StudentID; //팝업창에서 입력받은 학번 정보를 stuid에 준다

                DataTable dt = (DataTable)dataGridView1.DataSource;
                //DataRow[] rows = dt.Select("studentid = " + stuID);
                //if (rows.Length == 0)
                //{
                //    MessageBox.Show("등록된 정보를 찾을 수 없습니다.");
                //}
                //else
                //{
                //    MessageBox.Show(rows[0][1].ToString());
                //}

                DataView dv = dt.DefaultView;
                dv.Sort = "studentid";
                int rowIdx = dv.Find(stuID); //Find()를 사용하기 전에 찾는 값으로 Sort 먼저 해야함
                if(rowIdx == -1)
                {
                    MessageBox.Show("등록된 정보를 찾을 수 없습니다.");
                }
                else
                {
                    dataGridView1.ClearSelection();
                    dataGridView1.CurrentCell = dataGridView1.Rows[rowIdx].Cells[0];
                    //CurrentRow 가리키는 화살표의 이동 없이 Row만 선택
                    //dataGridView1.Rows[rowIdx].Selected = true;
                }


                //datagridview 에서 입력된 학번으로 데이터 검색하고 Row 선택

                //bool bFlag = false;
                //for (int i = 0; i < dataGridView1.Rows.Count; i++)
                //{
                //    if (Convert.ToInt32(dataGridView1[0, i].Value) == stuID)
                //    {
                //        dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];
                //        dataGridView1.ClearSelection(); //선택된 Row를 선택해제
                //        dataGridView1.Rows[i].Selected = true;
                //        bFlag = true;
                //        break;
                //    }
                //}
                //if (!bFlag)
                //{
                //    MessageBox.Show("등록된 정보를 찾을 수 없습니다.");
                //}
            }
        }
    }
}
