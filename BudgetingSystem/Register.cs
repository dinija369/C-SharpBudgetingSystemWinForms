using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BudgetingSystem
{
    public partial class Register : Form
    {
        public Register()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            TeamSession teamSession = new TeamSession();
            string connString = ConnectionString.Connection();
            SqlConnection connection = new SqlConnection(connString);

            String username, password, department, supervisor;

            try
            {

                department = (String)textBox1.Text;
                supervisor = (String)textBox2.Text;
                password = (String)textBox3.Text;
                username = (String)textBox4.Text;

                teamSession.setSession(department);

                connection.Open();
                string query = "INSERT INTO dbo.Team_profile ([Department], [Supervisor], [Username], [Password]) VALUES (@department, @supervisor, @username, @password)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@department", department);
                command.Parameters.AddWithValue("@supervisor", supervisor);
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password);

                command.ExecuteReader();
                TeamsHome form3 = new TeamsHome();
                form3.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { connection.Close(); }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Welcome welcome = new Welcome();
            welcome.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
