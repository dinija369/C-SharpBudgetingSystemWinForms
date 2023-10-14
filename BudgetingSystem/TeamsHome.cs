using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
            label5.Text = allowance + " £";
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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

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
    }
}
