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
    public partial class AddExpense : Form
    {
        public AddExpense()
        {
            InitializeComponent();
        }

        AddAllowance addAllowance = new AddAllowance();
        TeamSession teamSession = new TeamSession();

        private string expenseMoneyString, expenseComment;
        private float expenseMoney;

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            expenseMoneyString = (String)textBox1.Text;
            expenseComment = (String)textBox2.Text;

            try
            {
                expenseMoney = Convert.ToSingle(expenseMoneyString);
            }
            catch
            {
                MessageBox.Show("Please enter money");
            }
            //total spent is calculated
            addAllowance.TotalSpent(expenseMoney);
            //remaining balance is calculated after each expense
            addAllowance.RemainingBalance();
            string department = teamSession.getSession();

            setExpense(department, expenseMoney,expenseComment);

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

        private void button8_Click_1(object sender, EventArgs e)
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

        private void setExpense(string department, float expenseMoney, string expenseComment)
        {
            string date = DateTime.Now.ToString("dd/MM/yyyy");
            string connString = ConnectionString.Connection();
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            string query = "INSERT INTO dbo.Expense_table ([Department], [Expense], [Comment], [Date]) VALUES (@department, @expense, @comment, @date)";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@department", department);
            command.Parameters.AddWithValue("@expense", expenseMoney);
            command.Parameters.AddWithValue("@comment", expenseComment);
            command.Parameters.AddWithValue("@date", date);

            command.ExecuteReader();
            connection.Close();
        }
    }
}
