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
    public partial class frmUsers : Form
    {
        public frmUsers()
        {
            InitializeComponent();
        }

        private void lblPhone_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Add funtionality to close this form
            this.Hide();
        }


        //Create Objects of userBLL and userDAL
        userBLL u = new userBLL();
        userDAL dal = new userDAL();

        string imageName = "no-image.jpg";

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //Step 1: Get the values from UI form
            u.full_name = txtFullName.Text;
            u.email = txtEmail.Text;
            u.username = txtUserName.Text;
            u.password = txtPassword.Text;
            u.phone = txtPhone.Text;
            u.address = txtAddress.Text;
            u.added_date = DateTime.Now;
            u.image_name = imageName;

            //Step 2: Adding the values from the UI to the Database
            //Create a boolean variable to check whether the data is inserted successfully or not
            bool success = dal.Insert(u);

            //Step 3: Check whether the data is inserted successfully or not
            if (success == true)
            {
                //Data or User Added Successsfully
                MessageBox.Show("New User added Successfully.");
            }
            else
            {
                //Failed to Add User
                MessageBox.Show("Failed to Add New User.");
            }
        }
    }
}
