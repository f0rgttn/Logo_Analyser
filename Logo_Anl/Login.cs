using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Logo_Anl
{
    public partial class Login : Form
    {
        //pull the sql connection string from program.cs
        SqlConnection conn = new SqlConnection(AnalyserStartUp.connString); //initially conn had to be written multiple time, but by pulling from a known string it tidies up the program
        SqlCommand cmd;
       
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        //textBox1 = username

        private void BtnLogin_Click(object sender, EventArgs e)
        {     
            if (EntrPsswrd.Text != string.Empty || EntrUsrNm.Text != string.Empty)
            {

                //declare the stored procedure command
                cmd = new SqlCommand("dbo.usp_Login", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", EntrUsrNm.Text);
                cmd.Parameters.AddWithValue("@password", EntrPsswrd.Text);
                

                //open the connection, run the command, store result into an int and evaluate it afterwards
                conn.Open();

                int loginResult = Convert.ToInt32(cmd.ExecuteScalar());   //ExecuteScalar means we expect one thing to be returned

                conn.Close();

                //display a message for success
                if (loginResult == 1)
                {
                    this.Hide();
                    MenuScreen menuScreen = new MenuScreen();
                    menuScreen.ShowDialog();
                }
                else
                {
                    MessageBox.Show("Invalid Credentials");
                }
            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Btnregister_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registration registration = new Registration();
            registration.ShowDialog();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void ForgotPassword_Click(object sender, EventArgs e)
        {
            this.Hide();
            ForgotPassword forgotPassword = new ForgotPassword();
            forgotPassword.ShowDialog();
        }
    }
}
