using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Logo_Anl
{
    public partial class Registration : Form
    {
        SqlConnection conn = new SqlConnection(Program.connString);
        SqlCommand cmd;
        SqlDataReader dr;

        public Registration()
        {
            InitializeComponent();
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            conn.Open();
        }

        private void EntrUsrNmTxtBx_TextChanged(object sender, EventArgs e)
        {

        }

        private void EntrPsswrdTxtBx_TextChanged(object sender, EventArgs e)
        {

        }

        private void CnfrmPsswrdTxtBx_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (CnfrmPsswrdTxtBx.Text != string.Empty || EntrPsswrdTxtBx.Text != string.Empty || EntrUsrNmTxtBx.Text != string.Empty || EntrEmail.Text != string.Empty)
            {
                if (EntrPsswrdTxtBx.Text == CnfrmPsswrdTxtBx.Text)
                {
                    cmd = new SqlCommand("select * from UserTable where username='" + EntrUsrNmTxtBx.Text + "'", conn);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        dr.Close();
                        MessageBox.Show("Username Already exist please try another ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        dr.Close();

                        cmd = new SqlCommand("dbo.register", conn);
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@username", EntrUsrNmTxtBx.Text.Trim());
                        cmd.Parameters.AddWithValue("@password", EntrPsswrdTxtBx.Text.Trim());
                        cmd.Parameters.AddWithValue("@email", EntrEmail.Text.Trim());
                        conn.Close();

                        MessageBox.Show("Your Account is created . Please login now.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        //cmd = new SqlCommand("insert into UserTable values(@username,@password,@email)", conn);
                        //cmd.Parameters.AddWithValue("username", EntrUsrNmTxtBx.Text);
                        //cmd.Parameters.AddWithValue("password", EntrPsswrdTxtBx.Text);
                        //cmd.Parameters.AddWithValue("email", EntrEmail.Text);
                        //cmd.ExecuteNonQuery();
                        //Directory.CreateDirectory(@$".\..\..\..\{EntrUsrNmTxtBx.Text}");
                        //MessageBox.Show("Your Account is created . Please login now.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Please enter both password same ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExistingCustomer_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
