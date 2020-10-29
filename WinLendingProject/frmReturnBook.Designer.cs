namespace WinLendingProject
{
    partial class frmReturnBook
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvLendable = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvUnLendable = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtbookID = new System.Windows.Forms.TextBox();
            this.btnReturn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLendable)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnLendable)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvLendable
            // 
            this.dgvLendable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLendable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLendable.Location = new System.Drawing.Point(3, 21);
            this.dgvLendable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvLendable.Name = "dgvLendable";
            this.dgvLendable.RowTemplate.Height = 23;
            this.dgvLendable.Size = new System.Drawing.Size(795, 152);
            this.dgvLendable.TabIndex = 1;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvUnLendable);
            this.groupBox2.Location = new System.Drawing.Point(12, 194);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(801, 176);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "대여가능 목록(반납 목록)";
            // 
            // dgvUnLendable
            // 
            this.dgvUnLendable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUnLendable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUnLendable.Location = new System.Drawing.Point(3, 21);
            this.dgvUnLendable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvUnLendable.Name = "dgvUnLendable";
            this.dgvUnLendable.RowTemplate.Height = 23;
            this.dgvUnLendable.Size = new System.Drawing.Size(795, 152);
            this.dgvUnLendable.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvLendable);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(801, 176);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "대여중 목록(반납대상)";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(707, 385);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(103, 36);
            this.btnClose.TabIndex = 14;
            this.btnClose.Text = "닫기";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 401);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 15);
            this.label1.TabIndex = 17;
            this.label1.Text = "도서 번호";
            // 
            // txtbookID
            // 
            this.txtbookID.Location = new System.Drawing.Point(109, 396);
            this.txtbookID.Name = "txtbookID";
            this.txtbookID.Size = new System.Drawing.Size(129, 25);
            this.txtbookID.TabIndex = 18;
            // 
            // btnReturn
            // 
            this.btnReturn.Location = new System.Drawing.Point(244, 393);
            this.btnReturn.Name = "btnReturn";
            this.btnReturn.Size = new System.Drawing.Size(103, 28);
            this.btnReturn.TabIndex = 19;
            this.btnReturn.Text = "반납";
            this.btnReturn.UseVisualStyleBackColor = true;
            this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
            // 
            // frmReturnBook
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 443);
            this.Controls.Add(this.btnReturn);
            this.Controls.Add(this.txtbookID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnClose);
            this.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmReturnBook";
            this.Text = "반납관리";
            this.Load += new System.EventHandler(this.frmReturnBook_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLendable)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnLendable)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLendable;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvUnLendable;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtbookID;
        private System.Windows.Forms.Button btnReturn;
    }
}