using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BudgetingSystem
{
    public partial class AddAllowance : Form
    {
        public AddAllowance()
        {
            InitializeComponent();
        }

        TeamSession teamSession = new TeamSession();
        private float allowancePerPerson;
        private int peopleInTeam;
        private float allowancePerTeam;
        private String allowancePerPersonString, peopleInTeamString, dateTo;
        private Decimal totalSpentDb = 0;
        private Decimal allowance = 0;

        //used for total spent in Expense method
        private float totalSpent = 0f;

        private static void updateAllowance(string department, string dateTo, float allowancePerTeam)
        {
            string date = DateTime.Now.ToString("dd/MM/yyyy");
            string connString = ConnectionString.Connection();
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            string query = "UPDATE dbo.Allowance_table SET [Allowance] = @allowance, [Date_from] = @date_from, [Date_to] = @date_to WHERE [Department] = @department";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@department", department);
            command.Parameters.AddWithValue("@allowance", allowancePerTeam);
            command.Parameters.AddWithValue("@date_from", date);
            command.Parameters.AddWithValue("@date_to", dateTo);

            command.ExecuteReader();
            connection.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            allowancePerPersonString = (String)textBox1.Text;
            dateTo = (String)textBox3.Text;
            peopleInTeamString = (String)textBox2.Text;

            try {
                try
                {
                    allowancePerPerson = Convert.ToSingle(allowancePerPersonString);
                } 
                catch
                {
                    MessageBox.Show("Please enter money");
                }

                try
                {
                    peopleInTeam = Convert.ToInt32(peopleInTeamString);
                }
                catch
                {
                    MessageBox.Show("Please enter a number");
                }

                try
                {
                    string format = "dd/MM/yyyy";
                    //checks the correct format was eneterd // TODO - learn more about CultureInfo class and add date check
                    DateTime result = DateTime.ParseExact(dateTo, format, CultureInfo.InvariantCulture);
                    dateTo = result.ToString();
                }
                catch
                {
                    MessageBox.Show("Wrong date format");
                }

                }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            string department = teamSession.getSession();
            allowancePerTeam = allowancePerPerson * peopleInTeam;
            SetAllowance(department, dateTo, allowancePerTeam);

        }

        private void SetAllowance(string department, string dateTo, float allowancePerTeam)
        {
            try
            {
                string date = DateTime.Now.ToString("dd/MM/yyyy");
                string connString = ConnectionString.Connection();
                SqlConnection connection = new SqlConnection(connString);
                connection.Open();
                string query = "INSERT INTO dbo.Allowance_table ([Department], [Allowance], [Date_from], [Date_to], [Money_left]) VALUES (@department, @allowance, @date_from, @date_to, @money_left)";
                SqlCommand command = new SqlCommand(query, connection);

                command.Parameters.AddWithValue("@department", department);
                command.Parameters.AddWithValue("@allowance", allowancePerTeam);
                command.Parameters.AddWithValue("@date_from", date);
                command.Parameters.AddWithValue("@date_to", dateTo);
                command.Parameters.AddWithValue("@money_left", allowancePerTeam);

                command.ExecuteReader();
                connection.Close();
            }
            catch
            {
                AddAllowance.updateAllowance(department, dateTo, allowancePerTeam);
                RemainingBalance();
            }
        }

        public void RemainingBalance()
        {
            float allowance = (float)PrintAllowance();
            float totalSpent = (float)PrintTotalSpent();
            string department = teamSession.getSession();
            float newRemainingBalance = allowance - totalSpent;
            if (allowancePerTeam > 0)
            {
                if (newRemainingBalance <= 0)
                {
                    MessageBox.Show("You have exceeded your budget!");

                }
            }
            setRemainingBalance(department, newRemainingBalance);
        }

        private static void setRemainingBalance(string department, float newRemainingBalance)
        {
            string connString = ConnectionString.Connection();
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            string query = "UPDATE dbo.Allowance_table SET [Money_left] = @balance WHERE [Department] = @department";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@department", department);
            command.Parameters.AddWithValue("@balance", newRemainingBalance);

            command.ExecuteReader();
            connection.Close();
        }

        public Decimal PrintAllowance()
        {
            string department = teamSession.getSession();
            string connString = ConnectionString.Connection();
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            string query = "SELECT [Allowance] FROM dbo.Allowance_table WHERE [Department] = @department";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@department", department);

            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                allowance = reader.GetDecimal(0);
                connection.Close();
            }
            return allowance;
        }

        public Decimal PrintTotalSpent()
        {
            string department = teamSession.getSession();
            string connString = ConnectionString.Connection();
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            string query = "SELECT [Total_spent] FROM dbo.Allowance_table WHERE [Department] = @department";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@department", department);

            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                try
                {
                    totalSpentDb = reader.GetDecimal(0);
                }
                catch (System.Data.SqlTypes.SqlNullValueException)
                {

                }
                connection.Close();
            }
            return totalSpentDb;
        }

        public void TotalSpent(float expenseMoney)
        {
            string department = teamSession.getSession();
            string connString = ConnectionString.Connection();
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            string query = "SELECT [Total_spent] FROM dbo.Allowance_table WHERE [Department] = @department";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@department", department);

            SqlDataReader reader = command.ExecuteReader();

            try
            {
                reader.Read();
                totalSpent = (float)reader.GetDecimal(0);
                connection.Close();
            }
            catch { totalSpent = 0; }

            totalSpent += expenseMoney;
            setTotalSpent(department, totalSpent);
        }

        private static void setTotalSpent(string department, float totalSpent)
        {
            string connString = ConnectionString.Connection();
            SqlConnection connection = new SqlConnection(connString);
            connection.Open();
            string query = "UPDATE dbo.Allowance_table SET [Total_spent] = @totalSpent WHERE [Department] = @department";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@department", department);
            command.Parameters.AddWithValue("@totalSpent", totalSpent);

            command.ExecuteReader();
            connection.Close();
        }


    }
}
