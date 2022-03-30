
namespace Logo_Anl
{
    partial class Registration
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.UserName = new System.Windows.Forms.Label();
            this.EntrUsrNmTxtBx = new System.Windows.Forms.TextBox();
            this.EntrPsswrdTxtBx = new System.Windows.Forms.TextBox();
            this.CnfrmPsswrdTxtBx = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnExistingCustomer = new System.Windows.Forms.Button();
            this.EntrEmail = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(35, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Confirm Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(56, 96);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Enter Password:";
            // 
            // UserName
            // 
            this.UserName.AutoSize = true;
            this.UserName.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.UserName.Location = new System.Drawing.Point(48, 64);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(127, 21);
            this.UserName.TabIndex = 3;
            this.UserName.Text = "Enter UserName:";
            // 
            // EntrUsrNmTxtBx
            // 
            this.EntrUsrNmTxtBx.Location = new System.Drawing.Point(182, 61);
            this.EntrUsrNmTxtBx.Name = "EntrUsrNmTxtBx";
            this.EntrUsrNmTxtBx.Size = new System.Drawing.Size(443, 23);
            this.EntrUsrNmTxtBx.TabIndex = 6;
            this.EntrUsrNmTxtBx.TextChanged += new System.EventHandler(this.EntrUsrNmTxtBx_TextChanged);
            // 
            // EntrPsswrdTxtBx
            // 
            this.EntrPsswrdTxtBx.Location = new System.Drawing.Point(182, 94);
            this.EntrPsswrdTxtBx.Name = "EntrPsswrdTxtBx";
            this.EntrPsswrdTxtBx.PasswordChar = '*';
            this.EntrPsswrdTxtBx.Size = new System.Drawing.Size(443, 23);
            this.EntrPsswrdTxtBx.TabIndex = 7;
            this.EntrPsswrdTxtBx.TextChanged += new System.EventHandler(this.EntrPsswrdTxtBx_TextChanged);
            // 
            // CnfrmPsswrdTxtBx
            // 
            this.CnfrmPsswrdTxtBx.Location = new System.Drawing.Point(182, 123);
            this.CnfrmPsswrdTxtBx.Name = "CnfrmPsswrdTxtBx";
            this.CnfrmPsswrdTxtBx.PasswordChar = '*';
            this.CnfrmPsswrdTxtBx.Size = new System.Drawing.Size(443, 23);
            this.CnfrmPsswrdTxtBx.TabIndex = 8;
            this.CnfrmPsswrdTxtBx.TextChanged += new System.EventHandler(this.CnfrmPsswrdTxtBx_TextChanged);
            // 
            // btnRegister
            // 
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnRegister.Location = new System.Drawing.Point(191, 195);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(314, 49);
            this.btnRegister.TabIndex = 9;
            this.btnRegister.Text = "Register Now";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnExistingCustomer
            // 
            this.btnExistingCustomer.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnExistingCustomer.Location = new System.Drawing.Point(191, 250);
            this.btnExistingCustomer.Name = "btnExistingCustomer";
            this.btnExistingCustomer.Size = new System.Drawing.Size(314, 49);
            this.btnExistingCustomer.TabIndex = 10;
            this.btnExistingCustomer.Text = "Have Account? Login Now";
            this.btnExistingCustomer.UseVisualStyleBackColor = true;
            this.btnExistingCustomer.Click += new System.EventHandler(this.btnExistingUser_Click);
            // 
            // EntrEmail
            // 
            this.EntrEmail.Location = new System.Drawing.Point(182, 32);
            this.EntrEmail.Name = "EntrEmail";
            this.EntrEmail.Size = new System.Drawing.Size(443, 23);
            this.EntrEmail.TabIndex = 12;
            this.EntrEmail.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(84, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 21);
            this.label3.TabIndex = 11;
            this.label3.Text = "Enter Email:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // Registration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(677, 314);
            this.Controls.Add(this.EntrEmail);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnExistingCustomer);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.CnfrmPsswrdTxtBx);
            this.Controls.Add(this.EntrPsswrdTxtBx);
            this.Controls.Add(this.EntrUsrNmTxtBx);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.UserName);
            this.Name = "Registration";
            this.Text = "Register";
            this.Load += new System.EventHandler(this.Registration_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label UserName;
        private System.Windows.Forms.TextBox EntrUsrNmTxtBx;
        private System.Windows.Forms.TextBox EntrPsswrdTxtBx;
        private System.Windows.Forms.TextBox CnfrmPsswrdTxtBx;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnExistingCustomer;
        private System.Windows.Forms.TextBox EntrEmail;
        private System.Windows.Forms.Label label3;
    }
}

