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
    public partial class LottoMax : Form
    {
        string path = @".\file\";

        public LottoMax()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte ans = Convert.ToByte(MessageBox.Show("Do you want to exit the application?", "Exit", MessageBoxButtons.YesNo));
            if (ans == 6)
            {
                Close();
            }
        }
        string tempo = "";
        private void button3_Click(object sender, EventArgs e)
        {
            tempo += "Max, ";
            DateTime dt = new DateTime();
            dt = DateTime.Now;
            tempo += dt.ToShortDateString() + " ";
            tempo += dt.ToShortTimeString() + " ";

            Random random = new Random();
            int[] ranNumber = new int[1000];

            for (int i = 1; i <= 8; i++)
            {
                ranNumber[i] = random.Next(1, 49);
                for (int j = 1; j < i; j++)
                {
                    if (ranNumber[i] == ranNumber[j])
                    {
                        ranNumber[j] = random.Next(1, 49);
                    }
                }
            }
            for (int x = 1; x <= 8; x++)
            {
                if (x < 8)
                {
                    tempo += Convert.ToString(ranNumber[x]) + ", ";
                    textBox1.AppendText(Convert.ToString(ranNumber[x] + ", "));
                }
                else
                {
                    tempo += " Extra: " + Convert.ToString(ranNumber[x])+"\n";
                    textBox1.AppendText(Convert.ToString(ranNumber[x]));
                }
            }
            textBox1.AppendText("\n");
            string pathf = path+"LottoNbrs.txt";
            try
            {
                if (File.Exists(pathf))
                {
                    File.Delete(pathf);
                }

                using (StreamWriter sw = new StreamWriter(pathf))
                {
                    sw.Write(tempo);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string pathf = path+"LottoNbrs.txt";
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(pathf))
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

        private void LottoMax_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
