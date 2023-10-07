using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;

namespace BudgetingSystem
{
    public partial class LogIn : Form
    {
        public LogIn()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            TeamSession teamSession = new TeamSession();
            string connString = ConnectionString.Connection();
            SqlConnection connection = new SqlConnection(connString);

            String username, EnteredPassword, password;

            username = (String)textBox1.Text;
            EnteredPassword = (String)textBox2.Text;

            try
            {

                connection.Open();
                string query = "SELECT [Password] FROM dbo.Team_profile WHERE [Username] = @username";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@username", username);

                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                password = reader.GetString(0);
                connection.Close();

                if (password == EnteredPassword)
                {
                    connection.Open();
                    query = "SELECT [Department] FROM dbo.Team_profile WHERE [Username] = @username";
                    command = new SqlCommand(query, connection);

                    command.Parameters.AddWithValue("@username", username);

                    reader = command.ExecuteReader();
                    reader.Read();
                    string department = reader.GetString(0);
                    teamSession.setSession(department);
                    //teamSession.setSession(department);
                    connection.Close();
                    //LoginExit = 2;
                    TeamsHome home = new TeamsHome();
                    home.Show();
                    this.Close();
                }
            } 
            catch
            {
                MessageBox.Show("Error");
            }
            finally { connection.Close(); }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Welcome welcome = new Welcome();
            welcome.Show();
            this.Close();
        }
    }
}
