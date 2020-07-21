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
    public partial class Temperature : Form
    {
        public Temperature()
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

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox5.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
           

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox5.Clear();
        }

        String info = "";
        private void button3_Click(object sender, EventArgs e)
        {
            DateTime dt = new DateTime();
            dt = DateTime.Now;

            double converter = 0;
            if (radioButton1.Checked == true)
            {
                try
                {
                    converter = Convert.ToDouble(textBox1.Text);
                }
                catch (Exception)
                {
                    converter = 0;
                }

                textBox2.Text = Convert.ToString((converter * 9 / 5) + 32);
                textBox3.Text = "C";
                textBox4.Text = "F";
                switch (converter)
                {
                    case -40:
                        textBox5.Text = "Extremely Cold Day";
                        break;
                    case -18:
                        textBox5.Text = "Very Cold Day";
                        break;
                    case 0:
                        textBox5.Text = "Freezing point of water";
                        break;
                    case 10:
                        textBox5.Text = "Cool Day";
                        break;
                    case 21:
                        textBox5.Text = "Room temperature";
                        break;
                    case 30:
                        textBox5.Text = "Beach weather";
                        break;
                    case 37:
                        textBox5.Text = "Body temperature";
                        break;
                    case 40:
                        textBox5.Text = "Hot Bath";
                        break;
                    case 100:
                        textBox5.Text = "Water boils";
                        break;
                    default:
                        textBox5.Text = "";
                        break;
                }
            }
            else if (radioButton2.Checked == true)
            {
                try
                {
                    converter = Convert.ToDouble(textBox1.Text);
                }
                catch (Exception)
                {
                    converter = 0;
                }

                textBox2.Text = Convert.ToString((converter - 32) * 5 / 9);
                textBox3.Text = "F";
                textBox4.Text = "C";
                switch (converter)
                {
                    case -40:
                        textBox5.Text = "Extremely Cold Day";
                        break;
                    case 0:
                        textBox5.Text = "Very Cold Day";
                        break;
                    case 32:
                        textBox5.Text = "Freezing point of water";
                        break;
                    case 50:
                        textBox5.Text = "Cool Day";
                        break;
                    case 70:
                        textBox5.Text = "Room temperature";
                        break;
                    case 86:
                        textBox5.Text = "Beach weather";
                        break;
                    case 98.6:
                        textBox5.Text = "Body temperature";
                        break;
                    case 104:
                        textBox5.Text = "Hot Bath";
                        break;
                    case 212:
                        textBox5.Text = "Water boils";
                        break;
                    default:
                        textBox5.Text = "";
                        break;
                }
            }

            string pathf = path + "TempConversions.txt";
            try
            {
                if (File.Exists(pathf))
                {
                    File.Delete(pathf);
                }

                using (StreamWriter sw = new StreamWriter(pathf))
                {
                    info += textBox1.Text + " " + textBox3.Text + " = " + textBox2.Text + " " + textBox4.Text + ",  "+dt.ToShortDateString()+"  "+dt.ToShortTimeString()+ "\n";
                    sw.Write(info);
                    
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string pathf = path +"TempConversions.txt";
            try
            {   // Open the text file using a stream reader.
                FileStream fs = new FileStream(pathf,FileMode.OpenOrCreate);
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
            textBox1.Clear();
            textBox2.Clear();
            textBox5.Clear();

            string pathf = path +"TempConversions.txt";
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

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        string path = @".\file\";
        private void Temperature_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
