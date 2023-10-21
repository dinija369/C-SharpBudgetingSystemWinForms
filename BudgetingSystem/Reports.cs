using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BudgetingSystem
{
    public partial class Reports : Form
    {
        public Reports()
        {
            InitializeComponent();
        }

        TeamSession teamSession = new TeamSession();

        private void Reports_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'budgetManagerDataSet.Expense_table' table. You can move, or remove it, as needed.
            this.expense_tableTableAdapter.Fill(this.budgetManagerDataSet.Expense_table);
            string department = teamSession.getSession();
            string connString = ConnectionString.Connection();
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            string query = "SELECT [Expense], [Comment], [Date] FROM dbo.Expense_table WHERE [Department] = @department";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@department", department);

            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();

            sqlDataAdapter.Fill(dataTable);

            //connection.Close();
        }

        //public void ReportSummary()
        //{
            //total spent and money left is also printed
            //Console.WriteLine("|Total Spent: {0, 14}", allowanceBalance.PrintTotalSpent());
            //Console.WriteLine("----------------------------------------------------------------------------------" + "|");
            //Console.WriteLine("|Remaining balance: {0, 8}", allowanceBalance.getRemainingBalance());
            //Console.WriteLine(" _________________________________________________________________________________" + "|");
        //}

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

        private void button5_Click(object sender, EventArgs e)
        {
            Notifications notifications = new Notifications();
            notifications.Show();
            this.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Profile profile = new Profile();
            profile.Show();
            this.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Reports reports = new Reports();
            reports.Show();
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddExpense expense = new AddExpense();
            expense.Show();
            this.Close();
        }
    }


}
