using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackITManagementSystem.UI;

namespace TrackITManagementSystem
{
    public partial class frmHome : Form
    {
        public frmHome()
        {
            InitializeComponent();
        }

        private void frmHome_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            // Code used to close this application, can use this.Close(); 
            // which will close the application, 'hide' closes but keeps the 
            // window running in the background
            this.Hide(); 
            // the keyword 'this' refers to the current instance of the class and 
            // the object called 'hide' conceals the control from the user which is 
            // from the WindowsForm class called 'Control'
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open Users Form
            frmUsers users = new frmUsers();//assigning frmUsers function that was created when the User
            //interface form was created automatically and assigned it the name'users'
            users.Show();//users is now the opening the form when called upon, used by the WindowsForm 
            // function called Show() 
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblFormTitle_Click(object sender, EventArgs e)
        {

        }

        private void lblTicketTodayCount_Click(object sender, EventArgs e)
        {

        }

        private void ticketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open Create Ticket Form
            frmRequesters ticket = new frmRequesters();
            ticket.Show();
        }
    }
}
