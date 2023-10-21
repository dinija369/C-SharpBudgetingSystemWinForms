using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BudgetingSystem
{
    public partial class TeamsHome : Form
    {
        public TeamsHome()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            AddAllowance addAllowance = new AddAllowance();
            string allowance = addAllowance.PrintAllowance().ToString();
            string totalSpent = addAllowance.PrintTotalSpent().ToString();
            decimal remainingBalance = addAllowance.getRemainingBalance();
            label5.Text = allowance + " £";
            label6.Text = totalSpent + " £";
            label7.Text = remainingBalance + " £";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {
            //Graphics g = this.panel8.CreateGraphics();
            //Pen pen = new Pen(Color.Gray, 1);

            //PointF pointOne = new PointF(100.0F, 70.0F);
            //PointF pointTwo = new PointF(100.0F, 70.0F);

            //e.Graphics.DrawLine(pen, pointOne, pointTwo);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            TeamsHome teamsHome = new TeamsHome();
            teamsHome.Show();
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            AddAllowance addAllowance = new AddAllowance();
            addAllowance.Show();
            this.Close();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            AddExpense addExpense = new AddExpense();
            addExpense.Show();
            this.Close();
        }

        private void button5_Click_1(object sender, EventArgs e)
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

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
