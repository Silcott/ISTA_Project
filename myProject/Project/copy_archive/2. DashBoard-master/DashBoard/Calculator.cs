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

    public partial class Calculator : Form
    {
        CalculatorOp cal = new CalculatorOp();
        
        public Calculator()
        {
            InitializeComponent();
        }
        string path = @".\file\";

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            cal.CurrentValue = 0;
            cal.Operand1 = 0;
            cal.Operand2 = 0;
            cal.Op = null;

          string pathf = path+"Calculator.txt";
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

        private void button21_Click(object sender, EventArgs e)
        {
            byte ans = Convert.ToByte(MessageBox.Show("Do you want to exit the application?", "Exit?", MessageBoxButtons.YesNo));
            if (ans == 6)
            {
                Close();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" || textBox1.Text == "Error")
            {
                textBox1.Clear();
            }
            textBox1.Text = textBox1.Text + "0";
        }

        private void button18_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" || textBox1.Text == "Error")
            {
                textBox1.Clear();
            }
            textBox1.Text = textBox1.Text + "1";
        }

        private void button19_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" || textBox1.Text == "Error")
            {
                textBox1.Clear();
            }
            textBox1.Text = textBox1.Text + "2";
        }

        private void button20_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" || textBox1.Text == "Error")
            {
                textBox1.Clear();
            }
            textBox1.Text = textBox1.Text + "3";
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" || textBox1.Text == "Error")
            {
                textBox1.Clear();
            }
            textBox1.Text = textBox1.Text + "4";
        }

        private void button16_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" || textBox1.Text == "Error")
            {
                textBox1.Clear();
            }
            textBox1.Text = textBox1.Text + "5";
        }

        private void button17_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" || textBox1.Text == "Error")
            {
                textBox1.Clear();
            }
            textBox1.Text = textBox1.Text + "6";
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" || textBox1.Text == "Error")
            {
                textBox1.Clear();
            }
            textBox1.Text = textBox1.Text + "7";
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" || textBox1.Text == "Error")
            {
                textBox1.Clear();
            }
            textBox1.Text = textBox1.Text + "8";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" || textBox1.Text == "Error")
            {
                textBox1.Clear();
            }
            textBox1.Text = textBox1.Text + "9" ;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + ".";
        }

        private void Calculator_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" || textBox1.Text == "Error")
            {
                textBox1.Clear();
            }
            Button button = (Button)sender;
            textBox2.Text = textBox1.Text + button.Text;
            cal.Op = "/";
            try
            {
                cal.CurrentValue = Convert.ToDecimal(textBox1.Text);
                cal.Operand1 = cal.CurrentValue;
            }
            catch (Exception)
            {
                cal.CurrentValue = 0;
            }
            textBox1.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            cal.CurrentValue = 0;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" || textBox1.Text == "Error")
            {
                textBox1.Clear();
            }
            Button button = (Button)sender;
            textBox2.Text = textBox1.Text + button.Text;
            cal.Op = "-";
            try
            {
                cal.CurrentValue = Convert.ToDecimal(textBox1.Text);
                cal.Operand1 = cal.CurrentValue;
            }
            catch (Exception)
            {
                cal.CurrentValue = 0;
            }
            textBox1.Clear();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" || textBox1.Text == "Error")
            {
                textBox1.Clear();
            }
            Button button = (Button)sender;
            textBox2.Text = textBox1.Text + button.Text;
            cal.Op = "*";
            try
            {
                cal.CurrentValue = Convert.ToDecimal(textBox1.Text);
                cal.Operand1 = cal.CurrentValue;
            }
            catch (Exception)
            {
                cal.CurrentValue = 0;
            }
            textBox1.Clear();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            textBox2.Text += textBox1.Text + button.Text;
            try
            {
                cal.Operand2 = Convert.ToDecimal(textBox1.Text);
            }
            catch (Exception)
            {
                cal.Operand2 = 0;
            }
            
            textBox1.Clear();
            if (cal.Op == "+")
            {
                cal.CurrentValue = cal.Add();
                textBox1.Text = Convert.ToString(cal.CurrentValue);
            }
            if (cal.Op == "-")
            {
                cal.CurrentValue = cal.Subtract();
                textBox1.Text = Convert.ToString(cal.CurrentValue);
            }
            if (cal.Op == "*")
            {
                cal.CurrentValue = cal.Multiply();
                textBox1.Text = Convert.ToString(cal.CurrentValue);
            }
            if (cal.Op == "/")
            {
                if (cal.Operand2 == 0)
                {
                    textBox1.Text = "Error";
                }
                else
                {
                    cal.CurrentValue = cal.Divide();
                    textBox1.Text = Convert.ToString(cal.CurrentValue);
                }
            }
            DateTime dt = new DateTime();
            dt = DateTime.Now;
            RadioButton rb = new RadioButton();

           string pathf = path+"Calculator.txt";
            try
            {
                if (File.Exists(pathf))
                {
                    File.Delete(pathf);
                }

                using (StreamWriter sw = new StreamWriter(pathf))
                {
                    textBox3.AppendText(cal.Operand1 +" "+cal.Op+" "+cal.Operand2+" = "+textBox1.Text+"\n");
                    String info = textBox3.Text;
                    sw.Write(info);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" || textBox1.Text == "Error")
            {
                textBox1.Clear();
            }
            textBox1.Text = "-" + textBox1.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "0" || textBox1.Text == "Error")
            {
                textBox1.Clear();
            }
            Button button = (Button)sender;
            textBox2.Text = textBox1.Text + button.Text;
            cal.Op = "+";
            try
            {
                cal.CurrentValue = Convert.ToDecimal(textBox1.Text);
                cal.Operand1 = cal.CurrentValue;
            }
            catch (Exception)
            {
                cal.CurrentValue = 0;
            }
            textBox1.Clear();
        }

        private void button22_Click(object sender, EventArgs e)
        {
           string pathf = path+"Calculator.txt";
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
    }
 }

