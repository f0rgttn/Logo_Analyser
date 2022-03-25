using System;
using System.Net;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Logo_Anl
{
    public partial class ForgotPassword : Form
    {
        SqlConnection conn = new SqlConnection(Program.connString); 
        SqlCommand cmd;
        string RandToken;
        public static string to;
        static public string username;

        public ForgotPassword()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if(textBox1.Text  != string.Empty || textBox2.Text != string.Empty)
            {
                username = textBox1.Text;
                cmd = new SqlCommand("dbo.Forgot_Password", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@username", textBox1.Text);
                cmd.Parameters.AddWithValue("@email", textBox2.Text);

                conn.Open();

                int EmailUsernameMatch = Convert.ToInt32(cmd.ExecuteScalar());   //ExecuteScalar means we expect one thing to be returned

                if (EmailUsernameMatch != 0)
                {
                    string from, pass, messageBody;
                    Random rand = new Random();
                    RandToken = (rand.Next(999999)).ToString();
                    MailMessage message = new MailMessage();
                    to = (textBox2.Text).ToString();
                    from = "logoanalysernea@gmail.com"; //email created for this feature
                    pass = "LAN1234!";
                    messageBody = "your reset token is: " + RandToken;
                    message.To.Add(to);
                    message.From = new MailAddress(from);
                    message.Body = messageBody;
                    message.Subject = "Logo analyser password reset";
                    SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                    smtp.EnableSsl = true;
                    smtp.Port = 587;
                    smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                    smtp.Credentials = new NetworkCredential(from, pass);
                    try
                    {
                        smtp.Send(message);
                        MessageBox.Show("Token sent successfully");
                        this.Hide();
                        ResetPassword resetPassword = new ResetPassword(RandToken);
                        resetPassword.ShowDialog();
                        
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                } 
                else
                {
                    MessageBox.Show("Invalid Credentials");
                }

                conn.Close();
            }
            else
            {
                MessageBox.Show("Please fill out the required information");
            }
        }

        private void cancelReset_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
        }
    }
}
