using System;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;


namespace Logo_Anl
{
    public partial class Registration : Form
    {
        SqlConnection conn = new SqlConnection(AnalyserStartUp.connString);
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
                        cmd = new SqlCommand("select * from UserTable where email='" + EntrEmail.Text + "'", conn);
                        dr = cmd.ExecuteReader();
                        if (dr.Read())
                        {
                            dr.Close();
                            MessageBox.Show("Email already exist please try another ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            dr.Close();
                            int PasswordLength = EntrPsswrdTxtBx.Text.Length;
                            switch (PasswordLength)
                            {
                                case int n when n >= 6:
                                    //Regex rgx = new Regex("[^A-Za-z0-9]");
                                    //bool CheckSpecialCharacter = rgx.IsMatch(EntrPsswrdTxtBx.Text);
                                    if (CheckForNums(EntrPsswrdTxtBx.Text, false) == true /*&& CheckSpecialCharacter == true*/)
                                    {
                                        cmd = new SqlCommand("dbo.register", conn);
                                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                                        cmd.Parameters.AddWithValue("@username", EntrUsrNmTxtBx.Text.Trim());
                                        cmd.Parameters.AddWithValue("@password", EntrPsswrdTxtBx.Text.Trim());
                                        cmd.Parameters.AddWithValue("@email", EntrEmail.Text.Trim());
                                        conn.Close();

                                        MessageBox.Show("Your Account is created . Please login now.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    break;
                                case int n when n < 6:
                                    MessageBox.Show("Please ensure your password has atleast one numeric digit ");
                                    break;
                            }
                        }
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

        //Password must have a special character
        private static bool CheckForNums(string Password, bool c)
        {
            if (Password == "")
            {
                return c;
            }
            else
            {
                c = Char.IsDigit(Password[0]);
                return CheckForNums(Password.Substring(1), c);
            }
        }

            private void btnExistingUser_Click(object sender, EventArgs e)
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
