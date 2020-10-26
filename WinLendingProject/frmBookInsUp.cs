﻿using System;
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
    public partial class frmBookInsUp : Form
    {
        public Book bookInfo
        {
            get { return new Book(int.Parse(txtBookId.Text), txtBookName.Text, txtAuther.Text, txtPublisher.Text); }
            //set;
        }
        public frmBookInsUp()
        {
            InitializeComponent();
        }

        private void txtBookId_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != '\b' && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //유효성체크
            StringBuilder sb = new StringBuilder();

            if (txtBookId.Text.Trim().Length < 8)
            {
                sb.AppendLine("유효한 책번호가 아닙니다.");
            }

            if (string.IsNullOrEmpty(txtBookName.Text))
            {
                sb.AppendLine("책이름을 입력하세요.");
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
