namespace N10三层架构.UI
{
    partial class N02改密码
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtOldPwd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNewPwd1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtNewPwd2 = new System.Windows.Forms.TextBox();
            this.btnUpdatePwd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "旧密码";
            // 
            // txtOldPwd
            // 
            this.txtOldPwd.Location = new System.Drawing.Point(60, 10);
            this.txtOldPwd.Name = "txtOldPwd";
            this.txtOldPwd.Size = new System.Drawing.Size(100, 21);
            this.txtOldPwd.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "新密码";
            // 
            // txtNewPwd1
            // 
            this.txtNewPwd1.Location = new System.Drawing.Point(60, 37);
            this.txtNewPwd1.Name = "txtNewPwd1";
            this.txtNewPwd1.Size = new System.Drawing.Size(100, 21);
            this.txtNewPwd1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "重复";
            // 
            // txtNewPwd2
            // 
            this.txtNewPwd2.Location = new System.Drawing.Point(60, 64);
            this.txtNewPwd2.Name = "txtNewPwd2";
            this.txtNewPwd2.Size = new System.Drawing.Size(100, 21);
            this.txtNewPwd2.TabIndex = 1;
            // 
            // btnUpdatePwd
            // 
            this.btnUpdatePwd.Location = new System.Drawing.Point(60, 101);
            this.btnUpdatePwd.Name = "btnUpdatePwd";
            this.btnUpdatePwd.Size = new System.Drawing.Size(75, 23);
            this.btnUpdatePwd.TabIndex = 2;
            this.btnUpdatePwd.Text = "更新密码";
            this.btnUpdatePwd.UseVisualStyleBackColor = true;
            this.btnUpdatePwd.Click += new System.EventHandler(this.btnUpdatePwd_Click);
            // 
            // N02改密码
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(177, 138);
            this.Controls.Add(this.btnUpdatePwd);
            this.Controls.Add(this.txtNewPwd2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNewPwd1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtOldPwd);
            this.Controls.Add(this.label1);
            this.Name = "N02改密码";
            this.Text = "N02改密码";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtOldPwd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNewPwd1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtNewPwd2;
        private System.Windows.Forms.Button btnUpdatePwd;
    }
}