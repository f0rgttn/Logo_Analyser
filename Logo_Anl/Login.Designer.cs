
namespace Logo_Anl
{
    partial class Login
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
            this.lblUserName = new System.Windows.Forms.Label();
            this.lblPassword = new System.Windows.Forms.Label();
            this.EntrUsrNm = new System.Windows.Forms.TextBox();
            this.EntrPsswrd = new System.Windows.Forms.TextBox();
            this.UserNull = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.ForgottenPassword = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblUserName
            // 
            this.lblUserName.AutoSize = true;
            this.lblUserName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblUserName.Location = new System.Drawing.Point(8, 27);
            this.lblUserName.Name = "lblUserName";
            this.lblUserName.Size = new System.Drawing.Size(124, 21);
            this.lblUserName.TabIndex = 0;
            this.lblUserName.Text = "Enter Username:";
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPassword.Location = new System.Drawing.Point(13, 65);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(119, 21);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Enter Password:";
            // 
            // EntrUsrNm
            // 
            this.EntrUsrNm.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EntrUsrNm.Location = new System.Drawing.Point(138, 24);
            this.EntrUsrNm.Name = "EntrUsrNm";
            this.EntrUsrNm.Size = new System.Drawing.Size(385, 29);
            this.EntrUsrNm.TabIndex = 2;
            this.EntrUsrNm.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // EntrPsswrd
            // 
            this.EntrPsswrd.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.EntrPsswrd.Location = new System.Drawing.Point(138, 62);
            this.EntrPsswrd.Name = "EntrPsswrd";
            this.EntrPsswrd.Size = new System.Drawing.Size(385, 29);
            this.EntrPsswrd.TabIndex = 3;
            // 
            // UserNull
            // 
            this.UserNull.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UserNull.Location = new System.Drawing.Point(154, 178);
            this.UserNull.Name = "UserNull";
            this.UserNull.Size = new System.Drawing.Size(210, 50);
            this.UserNull.TabIndex = 5;
            this.UserNull.Text = "No account? Register here";
            this.UserNull.UseVisualStyleBackColor = true;
            this.UserNull.Click += new System.EventHandler(this.Btnregister_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnLogin.Location = new System.Drawing.Point(184, 122);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(160, 50);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.BtnLogin_Click);
            // 
            // ForgottenPassword
            // 
            this.ForgottenPassword.BackColor = System.Drawing.SystemColors.Control;
            this.ForgottenPassword.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ForgottenPassword.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            this.ForgottenPassword.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.ForgottenPassword.Font = new System.Drawing.Font("Segoe UI", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ForgottenPassword.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.ForgottenPassword.Location = new System.Drawing.Point(384, 98);
            this.ForgottenPassword.Name = "ForgottenPassword";
            this.ForgottenPassword.Size = new System.Drawing.Size(139, 23);
            this.ForgottenPassword.TabIndex = 6;
            this.ForgottenPassword.Text = "Forgot password?";
            this.ForgottenPassword.UseVisualStyleBackColor = false;
            this.ForgottenPassword.Click += new System.EventHandler(this.ForgotPassword_Click);
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(535, 263);
            this.Controls.Add(this.ForgottenPassword);
            this.Controls.Add(this.UserNull);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.EntrPsswrd);
            this.Controls.Add(this.EntrUsrNm);
            this.Controls.Add(this.lblPassword);
            this.Controls.Add(this.lblUserName);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Login";
            this.Text = "Login";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblUserName;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox EntrUsrNm;
        private System.Windows.Forms.TextBox EntrPsswrd;
        private System.Windows.Forms.Button UserNull;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Button ForgottenPassword;
    }
}