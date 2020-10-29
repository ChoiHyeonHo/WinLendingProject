namespace WinLendingProject
{
    partial class frmLending
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgvUnLendable = new System.Windows.Forms.DataGridView();
            this.btnList = new System.Windows.Forms.Button();
            this.btnLend = new System.Windows.Forms.Button();
            this.btnReserveList = new System.Windows.Forms.Button();
            this.btnReserve = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLendable)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnLendable)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvLendable
            // 
            this.dgvLendable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLendable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLendable.Location = new System.Drawing.Point(3, 22);
            this.dgvLendable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvLendable.Name = "dgvLendable";
            this.dgvLendable.RowTemplate.Height = 23;
            this.dgvLendable.Size = new System.Drawing.Size(795, 151);
            this.dgvLendable.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvLendable);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBox1.Location = new System.Drawing.Point(15, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(801, 176);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "대여가능목록";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgvUnLendable);
            this.groupBox2.Location = new System.Drawing.Point(15, 194);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(801, 176);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "대여중목록";
            // 
            // dgvUnLendable
            // 
            this.dgvUnLendable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUnLendable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUnLendable.Location = new System.Drawing.Point(3, 22);
            this.dgvUnLendable.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dgvUnLendable.Name = "dgvUnLendable";
            this.dgvUnLendable.RowTemplate.Height = 23;
            this.dgvUnLendable.Size = new System.Drawing.Size(795, 151);
            this.dgvUnLendable.TabIndex = 1;
            // 
            // btnList
            // 
            this.btnList.Location = new System.Drawing.Point(15, 401);
            this.btnList.Name = "btnList";
            this.btnList.Size = new System.Drawing.Size(93, 36);
            this.btnList.TabIndex = 3;
            this.btnList.Text = "대여목록";
            this.btnList.UseVisualStyleBackColor = true;
            this.btnList.Click += new System.EventHandler(this.btnList_Click);
            // 
            // btnLend
            // 
            this.btnLend.Location = new System.Drawing.Point(192, 401);
            this.btnLend.Name = "btnLend";
            this.btnLend.Size = new System.Drawing.Size(93, 36);
            this.btnLend.TabIndex = 0;
            this.btnLend.Text = "대여";
            this.btnLend.UseVisualStyleBackColor = true;
            this.btnLend.Click += new System.EventHandler(this.btnLend_Click);
            // 
            // btnReserveList
            // 
            this.btnReserveList.Location = new System.Drawing.Point(369, 401);
            this.btnReserveList.Name = "btnReserveList";
            this.btnReserveList.Size = new System.Drawing.Size(93, 36);
            this.btnReserveList.TabIndex = 5;
            this.btnReserveList.Text = "예약목록";
            this.btnReserveList.UseVisualStyleBackColor = true;
            // 
            // btnReserve
            // 
            this.btnReserve.Location = new System.Drawing.Point(546, 401);
            this.btnReserve.Name = "btnReserve";
            this.btnReserve.Size = new System.Drawing.Size(93, 36);
            this.btnReserve.TabIndex = 6;
            this.btnReserve.Text = "예약";
            this.btnReserve.UseVisualStyleBackColor = true;
            this.btnReserve.Click += new System.EventHandler(this.btnReserve_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(723, 401);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(93, 36);
            this.btnClose.TabIndex = 7;
            this.btnClose.Text = "닫기";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // frmLending
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(831, 464);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnReserve);
            this.Controls.Add(this.btnReserveList);
            this.Controls.Add(this.btnLend);
            this.Controls.Add(this.btnList);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "frmLending";
            this.Text = "frmLending";
            this.Load += new System.EventHandler(this.frmLending_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLendable)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUnLendable)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLendable;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgvUnLendable;
        private System.Windows.Forms.Button btnList;
        private System.Windows.Forms.Button btnLend;
        private System.Windows.Forms.Button btnReserveList;
        private System.Windows.Forms.Button btnReserve;
        private System.Windows.Forms.Button btnClose;
    }
}