using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackITManagementSystem.BLL;
using TrackITManagementSystem.DAL;

namespace TrackITManagementSystem.UI
{
    public partial class frmRequesters : Form
    {
        public frmRequesters()
        {
            InitializeComponent();
            InitializeTimePicker();
        }
        private DateTimePicker timePicker;

        private void InitializeTimePicker()
        {
            timePicker = new DateTimePicker();
            timePicker.Format = DateTimePickerFormat.Time;
            timePicker.ShowUpDown = true;
            timePicker.Location = new Point(10, 10);
            timePicker.Width = 100;
            Controls.Add(timePicker);
        }
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new frmRequesters());
        }

        //Create object of requeste BLL and requester DAL
        requestersBLL r = new requestersBLL();
        requesterDAL dal = new requesterDAL();

        private void lblFormTitle_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblUserName_Click(object sender, EventArgs e)
        {

        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Close this form
            this.Hide();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Step 1. Get teh data from the manage requesters form
            r.first_name = txtFirstName.Text;
            r.last_name = textLastName.Text;
            r.email = txtEmail.Text;
            r.ticket_creator_name = 1; //TODO get the ID of the logged user
            r.phone = txtPhone.Text;
            r.location = txtLocation.Text;
            r.issue_category = txtissuecategory.Text;
            r.priority_level = txtPriorityLevel.Text;
            r.added_date = DateTime.Now;
            r.completed_date = DateTimePicker;
            r.cost = textCost.Text;
            r.file_name_path = txtFileNamePath.Text;

        }
    }
}
