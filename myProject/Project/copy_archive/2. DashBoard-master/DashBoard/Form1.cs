using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DashBoard
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            byte ans = Convert.ToByte(MessageBox.Show("Do you want to exit the application?","Exit",MessageBoxButtons.YesNo));
            if (ans == 6)
            {
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Lotto_649 l1 = new Lotto_649();
            l1.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            LottoMax l1 = new LottoMax();
            l1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Calculator c1 = new Calculator();
            c1.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Currency c1 = new Currency();
            c1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Temperature t1 = new Temperature();
            t1.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
