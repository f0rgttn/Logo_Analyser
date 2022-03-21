using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Logo_Anl
{
    public partial class Login : Form
    {
        SqlConnection con;
        SqlCommand cmd;
        SqlDataReader dr;

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Thom\source\repos\Logo_Anl\Logo_Anl\UserBase.mdf;Integrated Security=True");
            con.Open();
        }

        //textBox1 = username
        public virtual string userName { get; set; }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (EntrPsswrd.Text != string.Empty || EntrUsrNm.Text != string.Empty)
            {

                cmd = new SqlCommand("select * from UserTable where username='" + EntrUsrNm.Text + "' and password='" + EntrPsswrd.Text + "'", con);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    this.Hide();
                    userName = EntrUsrNm.Text;
                    MenuScreen menuScreen = new MenuScreen();
                    menuScreen.ShowDialog();
                }
                else
                {
                    dr.Close();
                    MessageBox.Show("No Account avilable with this username and password ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
    }
}
