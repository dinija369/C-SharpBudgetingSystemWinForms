using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BudgetingSystem
{
    public partial class SubmitNotification : Form
    {
        public SubmitNotification()
        {
            InitializeComponent();
        }

        private void SubmitNotification_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            TeamSession teamSession = new TeamSession();
            string connString = ConnectionString.Connection();
            SqlConnection connection = new SqlConnection(connString);

            String username, message, department;

            try
            {

                username = (String)textBox1.Text;
                message = (String)textBox2.Text;

                department = teamSession.getSession();

                connection.Open();

                string query = "SELECT [Username] FROM dbo.Manager_profile";
                SqlCommand command = new SqlCommand(query, connection);

                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    while (reader.Read())
                    {
                        if (reader.GetString(0) == username)
                        {
                            query = "INSERT INTO dbo.Manager_notifications ([Username], [Message], [Sender]) VALUES (@username, @message, @sender)";
                            command = new SqlCommand(query, connection);

                            command.Parameters.AddWithValue("@username", username);
                            command.Parameters.AddWithValue("@message", message);
                            command.Parameters.AddWithValue("@sender", department);

                            connection.Close();

                            MessageBox.Show("Message sent succesfully!");
                            Notifications notifications = new Notifications();
                            notifications.Show();
                            this.Close();
                        }

                        else
                        {
                            MessageBox.Show("Invalid username!");
                        }

                    }
                }

                else 
                {
                    MessageBox.Show("Invalid username!");
                }

            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally { connection.Close(); }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TeamsHome teamsHome = new TeamsHome();
            teamsHome.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddAllowance addAllowance = new AddAllowance();
            addAllowance.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddExpense addExpense = new AddExpense();
            addExpense.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Notifications notifications = new Notifications();
            notifications.Show();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Reports reports = new Reports();
            reports.Show();
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
