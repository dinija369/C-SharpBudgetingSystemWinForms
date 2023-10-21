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
    public partial class Profile : Form
    {
        public Profile()
        {
            InitializeComponent();
        }

        TeamSession teamSession = new TeamSession();

        private void Profile_Load(object sender, EventArgs e)
        {
            string department = teamSession.getSession();
            string connString = ConnectionString.Connection();
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            string query = "SELECT [Department], [Supervisor], [Username] FROM dbo.Team_profile WHERE [Department] = @department";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@department", department);

            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                label4.Text = reader.GetString(0);
                label5.Text = reader.GetString(1);
                label6.Text = reader.GetString(2);
            }
            connection.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string newPassword = (String)textBox1.Text;

            string department = teamSession.getSession();
            string connString = ConnectionString.Connection();
            SqlConnection connection = new SqlConnection(connString);

            connection.Open();
            string queryPassword = "UPDATE dbo.Team_login SET [Password] = @password WHERE [Department] = @dep";
            SqlCommand commandPassword = new SqlCommand(queryPassword, connection);
            commandPassword.Parameters.AddWithValue("@dep", department);
            commandPassword.Parameters.AddWithValue("@password", newPassword);
            commandPassword.ExecuteReader();
            connection.Close();

            Profile profile = new Profile();
            profile.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string newSupervisor = (String)textBox1.Text;

            string department = teamSession.getSession();
            string connString = ConnectionString.Connection();
            SqlConnection connection = new SqlConnection(connString);

            connection.Open();
            string querySupervisor = "UPDATE dbo.Team_profile SET [Supervisor] = @supervisor WHERE [Department] = @dep";
            SqlCommand commandSupervisor = new SqlCommand(querySupervisor, connection);
            commandSupervisor.Parameters.AddWithValue("@dep", department);
            commandSupervisor.Parameters.AddWithValue("@supervisor", newSupervisor);
            commandSupervisor.ExecuteReader();
            connection.Close();

            Profile profile = new Profile();
            profile.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string newUsername = (String)textBox1.Text;

            string department = teamSession.getSession();
            string connString = ConnectionString.Connection();
            SqlConnection connection = new SqlConnection(connString);

            connection.Open();
            string queryUsername = "UPDATE dbo.Team_profile SET [Username] = @username WHERE [Department] = @dep";
            SqlCommand commandUsername = new SqlCommand(queryUsername, connection);
            commandUsername.Parameters.AddWithValue("@dep", department);
            commandUsername.Parameters.AddWithValue("@supervisor", newUsername);
            commandUsername.ExecuteReader();
            connection.Close();

            Profile profile = new Profile();
            profile.Show();
            this.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            TeamsHome teamsHome = new TeamsHome();
            teamsHome.Show();
            this.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            AddAllowance addAllowance = new AddAllowance();
            addAllowance.Show();
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            AddExpense expense = new AddExpense();
            expense.Show();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Notifications notifications = new Notifications();
            notifications.Show();
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Reports reports = new Reports();
            reports.Show();
            this.Close();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();
            this.Close();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
