using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DashBoard
{
    public partial class Currency : Form
    {
        public Currency()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            byte ans = Convert.ToByte(MessageBox.Show("Do you want to exit the application?", "Exit", MessageBoxButtons.YesNo));
            if (ans == 6)
            {
                Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        String info = "";
        private void button3_Click(object sender, EventArgs e)
        {
            DateTime dt = new DateTime();
            dt = DateTime.Now;
            RadioButton rb = new RadioButton();
            Double amount = 0;
            try
            {
                amount = Convert.ToDouble(textBox1.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Invalid value entered, try again!", "Erro");
            }

            Double convValue = 0;

            if ((radioButton1.Checked) && (radioButton6.Checked))
            {
                textBox2.Text = Convert.ToString(amount * 1);
                info += textBox1.Text + " " +radioButton1.Text+" = "+textBox2.Text +" "+radioButton6.Text +"  "+ dt.ToShortDateString() + "  "+dt.ToShortTimeString()+"\n";  
            }
            else if ((radioButton1.Checked) && (radioButton8.Checked))
            {
                textBox2.Text = Convert.ToString(amount * 1.1306);
                info += textBox1.Text + " " + radioButton1.Text + " = " + textBox2.Text + " " + radioButton8.Text + "  " + dt.ToShortDateString() + "  " + dt.ToShortTimeString() + "\n";
            }
            else if ((radioButton1.Checked) && (radioButton10.Checked))
            {
                textBox2.Text = Convert.ToString(amount * 1.7369);
                info += textBox1.Text + " " + radioButton1.Text + " = " + textBox2.Text + " " + radioButton10.Text + "  " + dt.ToShortDateString() + "  " + dt.ToShortTimeString() + "\n";
            }
            else if ((radioButton1.Checked) && (radioButton9.Checked))
            {
                textBox2.Text = Convert.ToString(amount * 1.3213);
                info += textBox1.Text + " " + radioButton1.Text + " = " + textBox2.Text + " " + radioButton9.Text + "  " + dt.ToShortDateString() + "  " + dt.ToShortTimeString() + "\n";
            }
            else if ((radioButton1.Checked) && (radioButton7.Checked))
            {
                textBox2.Text = Convert.ToString(amount * 5.1950);
                info += textBox1.Text + " " + radioButton1.Text + " = " + textBox2.Text + " " + radioButton7.Text + "  " + dt.ToShortDateString() + "  " + dt.ToShortTimeString() + "\n";
            }
            else if ((radioButton2.Checked) && (radioButton6.Checked))
            {
                textBox2.Text = Convert.ToString(amount * 0.8845);
                info += textBox1.Text + " " + radioButton2.Text + " = " + textBox2.Text + " " + radioButton6.Text + "  " + dt.ToShortDateString() + "  " + dt.ToShortTimeString() + "\n";
            }
            else if ((radioButton2.Checked) && (radioButton8.Checked))
            {
                textBox2.Text = Convert.ToString(amount * 1);
                info += textBox1.Text + " " + radioButton2.Text + " = " + textBox2.Text + " " + radioButton8.Text + "  " + dt.ToShortDateString() + "  " + dt.ToShortTimeString() + "\n";
            }
            else if ((radioButton2.Checked) && (radioButton10.Checked))
            {
                textBox2.Text = Convert.ToString(amount * 1.5360);
                info += textBox1.Text + " " + radioButton2.Text + " = " + textBox2.Text + " " + radioButton10.Text + "  " + dt.ToShortDateString() + "  " + dt.ToShortTimeString() + "\n";
            }
            else if ((radioButton2.Checked) && (radioButton9.Checked))
            {
                textBox2.Text = Convert.ToString(amount * 1.1682);
                info += textBox1.Text + " " + radioButton2.Text + " = " + textBox2.Text + " " + radioButton9.Text + "  " + dt.ToShortDateString() + "  " + dt.ToShortTimeString() + "\n";
            }
            else if ((radioButton2.Checked) && (radioButton7.Checked))
            {
                textBox2.Text = Convert.ToString(amount * 4.5931);
                info += textBox1.Text + " " + radioButton2.Text + " = " + textBox2.Text + " " + radioButton7.Text + "  " + dt.ToShortDateString() + "  " + dt.ToShortTimeString() + "\n";
            }
            //CAD
            else if ((radioButton3.Checked) && (radioButton6.Checked))
            {
                textBox2.Text = Convert.ToString(amount * 0.7606);
                info += textBox1.Text + " " + radioButton3.Text + " = " + textBox2.Text + " " + radioButton6.Text + "  " + dt.ToShortDateString() + "  " + dt.ToShortTimeString() + "\n";
            }
            else if ((radioButton3.Checked) && (radioButton8.Checked))
            {
                textBox2.Text = Convert.ToString(amount * 0.6509);
                info += textBox1.Text + " " + radioButton3.Text + " = " + textBox2.Text + " " + radioButton8.Text + "  " + dt.ToShortDateString() + "  " + dt.ToShortTimeString() + "\n";
            }
            else if ((radioButton3.Checked) && (radioButton10.Checked))
            {
                textBox2.Text = Convert.ToString(amount * 1);
                info += textBox1.Text + " " + radioButton3.Text + " = " + textBox2.Text + " " + radioButton10.Text + "  " + dt.ToShortDateString() + "  " + dt.ToShortTimeString() + "\n";
            }
            else if ((radioButton3.Checked) && (radioButton9.Checked))
            {
                textBox2.Text = Convert.ToString(amount * 0.7607);
                info += textBox1.Text + " " + radioButton3.Text + " = " + textBox2.Text + " " + radioButton9.Text + "  " + dt.ToShortDateString() + "  " + dt.ToShortTimeString() + "\n";
            }
            else if ((radioButton3.Checked) && (radioButton7.Checked))
            {
                textBox2.Text = Convert.ToString(amount * 2.9909);
                info += textBox1.Text + " " + radioButton3.Text + " = " + textBox2.Text + " " + radioButton7.Text + "  " + dt.ToShortDateString() + "  " + dt.ToShortTimeString() + "\n";
            }
            //USD
            else if ((radioButton4.Checked) && (radioButton6.Checked))
            {
                textBox2.Text = Convert.ToString(amount * 0.7572);
                info += textBox1.Text + " " + radioButton4.Text + " = " + textBox2.Text + " " + radioButton6.Text + "  " + dt.ToShortDateString() + "  " + dt.ToShortTimeString() + "\n";
            }
            else if ((radioButton4.Checked) && (radioButton8.Checked))
            {
                textBox2.Text = Convert.ToString(amount * 0.8559);
                info += textBox1.Text + " " + radioButton4.Text + " = " + textBox2.Text + " " + radioButton8.Text + "  " + dt.ToShortDateString() + "  " + dt.ToShortTimeString() + "\n";
            }
            else if ((radioButton4.Checked) && (radioButton10.Checked))
            {
                textBox2.Text = Convert.ToString(amount * 1.3149);
                info += textBox1.Text + " " + radioButton4.Text + " = " + textBox2.Text + " " + radioButton10.Text + "  " + dt.ToShortDateString() + "  " + dt.ToShortTimeString() + "\n";
            }
            else if ((radioButton4.Checked) && (radioButton9.Checked))
            {
                textBox2.Text = Convert.ToString(amount * 1);
                info += textBox1.Text + " " + radioButton4.Text + " = " + textBox2.Text + " " + radioButton9.Text + "  " + dt.ToShortDateString() + "  " + dt.ToShortTimeString() + "\n";
            }
            else if ((radioButton4.Checked) && (radioButton7.Checked))
            {
                textBox2.Text = Convert.ToString(amount * 3.9319);
                info += textBox1.Text + " " + radioButton4.Text + " = " + textBox2.Text + " " + radioButton7.Text + "  " + dt.ToShortDateString() + "  " + dt.ToShortTimeString() + "\n";
            }
            //BRL
            else if ((radioButton5.Checked) && (radioButton6.Checked))
            {
                textBox2.Text = Convert.ToString(amount * 0.1926);
                info += textBox1.Text + " " + radioButton5.Text + " = " + textBox2.Text + " " + radioButton6.Text + "  " + dt.ToShortDateString() + "  " + dt.ToShortTimeString() + "\n";
            }
            else if ((radioButton5.Checked) && (radioButton8.Checked))
            {
                textBox2.Text = Convert.ToString(amount * 0.2177);
                info += textBox1.Text + " " + radioButton5.Text + " = " + textBox2.Text + " " + radioButton8.Text + "  " + dt.ToShortDateString() + "  " + dt.ToShortTimeString() + "\n";
            }
            else if ((radioButton5.Checked) && (radioButton10.Checked))
            {
                textBox2.Text = Convert.ToString(amount * 0.3344);
                info += textBox1.Text + " " + radioButton5.Text + " = " + textBox2.Text + " " + radioButton10.Text + "  " + dt.ToShortDateString() + "  " + dt.ToShortTimeString() + "\n";
            }
            else if ((radioButton5.Checked) && (radioButton9.Checked))
            {
                textBox2.Text = Convert.ToString(amount * 0.2543);
                info += textBox1.Text + " " + radioButton5.Text + " = " + textBox2.Text + " " + radioButton9.Text + "  " + dt.ToShortDateString() + "  " + dt.ToShortTimeString() + "\n";
            }
            else if ((radioButton5.Checked) && (radioButton7.Checked))
            {
                textBox2.Text = Convert.ToString(amount * 1);
                info += textBox1.Text + " " + radioButton5.Text + " = " + textBox2.Text + " " + radioButton7.Text + "  " + dt.ToShortDateString() + "  " + dt.ToShortTimeString() + "\n";
            }

            string pathf = path + "MoneyConversions.txt";
            try
            {
                if (File.Exists(pathf))
                {
                    File.Delete(pathf);
                }

                using (StreamWriter sw = new StreamWriter(pathf))
                {
                    sw.WriteLine(info);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string pathf = path + "MoneyConversions.txt";
            try
            {   // Open the text file using a stream reader.
                FileStream fs = new FileStream(pathf, FileMode.OpenOrCreate);
                using (StreamReader sr = new StreamReader(fs))
                {
                    String line = sr.ReadToEnd();
                    MessageBox.Show(line, "Read File");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("The file could not be read:", "Erro");
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "0";
            textBox2.Text = "";
            radioButton3.Checked = true;
            radioButton6.Checked = true;
            string pathf = path + "MoneyConversions.txt";
            try
            {
                if (File.Exists(pathf))
                {
                    File.Delete(pathf);
                }
            }

            catch
            {
                MessageBox.Show("No files to clean", "Alert");
            }
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void radioButton9_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Clear();
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            textBox2.Clear();
        }
        string path = @".\file\";
        private void Currency_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}

