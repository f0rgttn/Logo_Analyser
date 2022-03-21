using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;

namespace Logo_Anl
{
    public partial class Registration : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public Registration()
        {
            InitializeComponent();
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Thom\source\repos\Logo_Anl\Logo_Anl\UserBase.mdf;Integrated Security=True");
            con.Open();
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
            if (CnfrmPsswrdTxtBx.Text != string.Empty || EntrPsswrdTxtBx.Text != string.Empty || EntrUsrNmTxtBx.Text != string.Empty)
            {
                if (EntrPsswrdTxtBx.Text == CnfrmPsswrdTxtBx.Text)
                {
                    cmd = new SqlCommand("select * from UserTable where username='" + EntrUsrNmTxtBx.Text + "'", con);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        dr.Close();
                        MessageBox.Show("Username Already exist please try another ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        dr.Close();
                        cmd = new SqlCommand("insert into UserTable values(@username,@password)", con);
                        cmd.Parameters.AddWithValue("username", EntrUsrNmTxtBx.Text);
                        cmd.Parameters.AddWithValue("password", EntrPsswrdTxtBx.Text);
                        cmd.ExecuteNonQuery();
                        Directory.CreateDirectory(@$".\..\..\..\{EntrUsrNmTxtBx.Text}");
                        MessageBox.Show("Your Account is created . Please login now.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
