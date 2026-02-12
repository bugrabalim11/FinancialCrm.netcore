namespace FinancialCrm.netcore
{
    partial class FrmLogin
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
            txtUserName = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtPassword = new TextBox();
            panel5 = new Panel();
            label17 = new Label();
            btnLogin = new Button();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // txtUserName
            // 
            txtUserName.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtUserName.Location = new Point(129, 57);
            txtUserName.Name = "txtUserName";
            txtUserName.Size = new Size(125, 32);
            txtUserName.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label1.Location = new Point(6, 60);
            label1.Name = "label1";
            label1.Size = new Size(118, 24);
            label1.TabIndex = 1;
            label1.Text = "Kullanıcı Adı:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label2.Location = new Point(72, 98);
            label2.Name = "label2";
            label2.Size = new Size(52, 24);
            label2.TabIndex = 3;
            label2.Text = "Şifre:";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Calibri", 12F, FontStyle.Regular, GraphicsUnit.Point, 162);
            txtPassword.Location = new Point(129, 95);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(125, 32);
            txtPassword.TabIndex = 2;
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.ActiveCaption;
            panel5.Controls.Add(label17);
            panel5.Location = new Point(1, 0);
            panel5.Name = "panel5";
            panel5.Size = new Size(1069, 41);
            panel5.TabIndex = 5;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Font = new Font("Calibri", 12F, FontStyle.Bold);
            label17.ForeColor = SystemColors.ButtonHighlight;
            label17.Location = new Point(19, 15);
            label17.Name = "label17";
            label17.Size = new Size(218, 24);
            label17.TabIndex = 0;
            label17.Text = "Finncial CRM Giriş Paneli";
            // 
            // btnLogin
            // 
            btnLogin.Location = new Point(129, 147);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(125, 45);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Giriş Yap";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // FrmLogin
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveBorder;
            ClientSize = new Size(1037, 450);
            Controls.Add(btnLogin);
            Controls.Add(panel5);
            Controls.Add(label2);
            Controls.Add(txtPassword);
            Controls.Add(label1);
            Controls.Add(txtUserName);
            Name = "FrmLogin";
            Text = "FrmLogin";
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtUserName;
        private Label label1;
        private Label label2;
        private TextBox txtPassword;
        private Panel panel5;
        private Label label17;
        private Button btnLogin;
    }
}