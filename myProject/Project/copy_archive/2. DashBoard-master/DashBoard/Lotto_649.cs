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
    public partial class Lotto_649 : Form
    {
        //Initialization
        Random random = new Random();


        public Lotto_649()
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
            tempo += "649 ";
            DateTime dt = new DateTime();
            dt = DateTime.Now;
            tempo += dt.ToShortDateString() + " ";
            tempo += dt.ToShortTimeString() + " ";
            int[] ranNumber = new int[1000];

            for (int i = 1; i <= 7; i++)
            {
                ranNumber[i] = random.Next(1,49);
                for (int j = 1; j < i; j++)
                {
                    if (ranNumber[i] == ranNumber[j])
                    {
                        ranNumber[j] = random.Next(1, 49);
                    }
                } 
            }
           
            for (int x = 1; x <= 7; x++)
            {
                
                if (x < 7)
                {
                    textBox1.AppendText(Convert.ToString(ranNumber[x] + ", "));
                    tempo += Convert.ToString(ranNumber[x]) + ", ";
                }
                else
                {
                    textBox1.AppendText(Convert.ToString(ranNumber[x]));
                    tempo += " Extra: "+Convert.ToString(ranNumber[x]) + "\n";
                }
            }

            textBox1.AppendText("\n");
            string pathf = path + "LottoNbrs.txt";
            try
            {
                if (File.Exists(pathf))
                {
                    File.Delete(pathf);
                }
                
                using (StreamWriter sw = new StreamWriter(pathf))
                {
                    sw.WriteLine(tempo);
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
                MessageBox.Show("The file could not be read:","Erro");
                MessageBox.Show(ex.Message);
            }
        }
        string path = @".\file\";
        private void Lotto_649_Load(object sender, EventArgs e)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }
    }
}
