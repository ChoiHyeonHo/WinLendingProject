using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WinLendingProject
{
    class CommonUtil
    {
        public static void SetInitGridView(DataGridView dgv)
        {
            dgv.AutoGenerateColumns = false;
            dgv.AllowUserToAddRows = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        public static void AddGridTextColumn( 
                           DataGridView dgv, 
                           string headertext,
                           string dataPropertyName,
                           int colWidth = 100,
                           bool visibility = true,
                           DataGridViewContentAlignment textalien = DataGridViewContentAlignment.MiddleLeft)
        {
            DataGridViewTextBoxColumn col = new DataGridViewTextBoxColumn();
            col.HeaderText = headertext;
            col.DataPropertyName = dataPropertyName;
            col.Width = colWidth;
            col.DefaultCellStyle.Alignment = textalien;
            col.Visible = visibility;
            col.ReadOnly = true;
            dgv.Columns.Add(col);
        }


    }
}
