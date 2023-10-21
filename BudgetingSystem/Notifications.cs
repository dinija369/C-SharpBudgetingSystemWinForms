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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BudgetingSystem
{
    public partial class Notifications : Form
    {
        public Notifications()
        {
            InitializeComponent();
        }

        TeamSession teamSession = new TeamSession();
        private void Notifications_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'budgetManagerDataSet1.Team_notifications' table. You can move, or remove it, as needed.
            this.team_notificationsTableAdapter.Fill(this.budgetManagerDataSet1.Team_notifications);
            string department = teamSession.getSession();
            string connString = ConnectionString.Connection();
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            string query = "SELECT [Message], [Sender] FROM dbo.Team_notifications WHERE [Department] = @department";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@department", department);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            sqlDataAdapter.Fill(dataTable);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SubmitNotification submitNotifications = new SubmitNotification();
            submitNotifications.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TeamsHome teamsHome = new TeamsHome();
            teamsHome.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddAllowance addAllowance = new AddAllowance();
            addAllowance.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddExpense expense = new AddExpense();
            expense.Show();
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

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
