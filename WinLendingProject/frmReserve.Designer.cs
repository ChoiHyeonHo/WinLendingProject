namespace WinLendingProject
{
    partial class frmReserve
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtBookid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtStudentid = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(171, 125);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(109, 30);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "취소";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnOK.Location = new System.Drawing.Point(25, 125);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(140, 30);
            this.btnOK.TabIndex = 9;
            this.btnOK.Text = "확인";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtBookid
            // 
            this.txtBookid.Location = new System.Drawing.Point(100, 70);
            this.txtBookid.MaxLength = 8;
            this.txtBookid.Name = "txtBookid";
            this.txtBookid.Size = new System.Drawing.Size(180, 25);
            this.txtBookid.TabIndex = 7;
            this.txtBookid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStudentid_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "도서 번호";
            // 
            // txtStudentid
            // 
            this.txtStudentid.Location = new System.Drawing.Point(100, 29);
            this.txtStudentid.MaxLength = 7;
            this.txtStudentid.Name = "txtStudentid";
            this.txtStudentid.Size = new System.Drawing.Size(180, 25);
            this.txtStudentid.TabIndex = 5;
            this.txtStudentid.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStudentid_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 6;
            this.label1.Text = "학번";
            // 
            // frmReserve
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(317, 186);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtBookid);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtStudentid);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("굴림", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmReserve";
            this.Text = "도서예약";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtBookid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtStudentid;
        private System.Windows.Forms.Label label1;
    }
}