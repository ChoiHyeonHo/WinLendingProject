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
    public partial class frmStudentInsUp : Form
    {
        public enum OpenMode { Insert, Update }

        public Student stuInfo 
        {
            get //값을 받아옴
            { 
                return new Student(int.Parse(txtStudentID.Text), txtStudentName.Text, txtDepartment.Text);
            }
            set //값을 넘겨줌
            {
                txtStudentID.Text = value.ID.ToString();
                txtStudentName.Text = value.Name;
                txtDepartment.Text = value.Dept;
            }
        }

        public frmStudentInsUp(OpenMode open)
        {
            InitializeComponent();

            if (open == OpenMode.Insert)
            {
                this.Text = "학생 정보 입력";
                txtStudentID.Enabled = true;
            }
            else
            {
                this.Text = "학생 정보 수정";
                txtStudentID.Enabled = false;
            }
        }

        private void txtStudentID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //유효성체크
            StringBuilder sb = new StringBuilder();

            if (txtStudentID.Text.Trim().Length < 7)
            {
                sb.AppendLine("유효한 학번이 아닙니다.");
            }

            if (string.IsNullOrEmpty(txtStudentName.Text))
            {
                sb.AppendLine("학생명을 입력하세요.");
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
    }
}
