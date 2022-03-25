using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Logo_Anl
{
    public partial class ResetPassword : Form
    {
        SqlCommand cmd;
        SqlConnection conn = new SqlConnection(Program.connString);
        string username = ForgotPassword.username;

        string Token;
        public ResetPassword(string RandToken)
        {
            InitializeComponent();
            Token = RandToken;
        }

        private void ResetPassword_click(object sender, EventArgs e)
        {
            if(ConfirmToken.Text != string.Empty || NewPassword.Text != string.Empty || ConfirmPassword.Text != string.Empty)
            {
                if(ConfirmToken.Text == Token)
                {
                    if(NewPassword.Text == ConfirmPassword.Text)
                    {
                        cmd = new SqlCommand("dbo.Reset_Password", conn);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@username", username);
                        cmd.Parameters.AddWithValue("@password", NewPassword.Text);

                        MessageBox.Show("Your password has been changed succesfully, " + username);

                        this.Hide();
                        Login login = new Login();
                        login.ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("Passwords do not match");
                    }
                }
                else
                {
                    MessageBox.Show("incorrect token");
                }
            }
            else
            {
                MessageBox.Show("Please fill in the required information");
            }
        }

        private void BacktoLogin_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }
    }
}
