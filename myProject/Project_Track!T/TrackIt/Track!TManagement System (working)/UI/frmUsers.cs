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

        //Create Objects of userBLL and userDAL
        userBLL u = new userBLL();
        userDAL dal = new userDAL();

        string imageName = "no-image.jpg";

        private void lblPhone_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Add funtionality to close this form
            this.Hide();
        }

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

                //Display the user in DataGrid View
                DataTable dt = dal.Select();
                dvgUsers.DataSource = dt;

                //Clear Text Boxes
                Clear();
            }
            else
            {
                //Failed to Add User
                MessageBox.Show("Failed to Add New User.");
            }
        }

        //Method of Function to Clear Text Boxes
        public void Clear()
        {
            txtFullName.Text = "";
            txtEmail.Text = "";
            txtUserName.Text = "";
            txtPhone.Text = "";
            txtPassword.Text = "";
            txtAddress.Text = "";
            txtUserID.Text = "";
        }

        private void dvgUsers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Find the Row Index of the Row Clicked on Users Data Grid View
            int RowIndex = e.RowIndex;
            txtUserID.Text = dvgUsers.Rows[RowIndex].Cells[0].Value.ToString();
            txtUserName.Text = dvgUsers.Rows[RowIndex].Cells[1].Value.ToString();
            txtEmail.Text = dvgUsers.Rows[RowIndex].Cells[2].Value.ToString();
            txtPassword.Text = dvgUsers.Rows[RowIndex].Cells[3].Value.ToString();
            txtFullName.Text = dvgUsers.Rows[RowIndex].Cells[4].Value.ToString();
            txtPhone.Text = dvgUsers.Rows[RowIndex].Cells[5].Value.ToString();
            txtAddress.Text = dvgUsers.Rows[RowIndex].Cells[6].Value.ToString();
            imageName = dvgUsers.Rows[RowIndex].Cells[7].Value.ToString();
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            //Display the Users in Data Grid View when the form is loaded
            DataTable dt = dal.Select();
            dvgUsers.DataSource = dt;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            //Step 1: Get the values from UI
            u.user_id = int.Parse(txtUserID.Text);
            u.full_name = txtFullName.Text;
            u.email = txtEmail.Text;
            u.username = txtUserName.Text;
            u.password = txtPassword.Text;
            u.phone = txtPhone.Text;
            u.address = txtAddress.Text;
            u.added_date = DateTime.Now;
            u.image_name = imageName;

            //Step 2: Create a Boolean variable to check whether the data is updated successfully ot not
            bool success = dal.Update(u);

            //Let's check whether the data is updated or not
            if (success == true)
            {
                //Data Updated Successfully
                MessageBox.Show("User Updated Successfully.");

                //Refresh Data Grid View
                DataTable dt = dal.Select();
                dvgUsers.DataSource = dt;

                //Clear the Text Boxes
                Clear();

            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Step 1: Get ehe UsersId from the Text Box to Delete teh User
            u.user_id = int.Parse(txtUserID.Text);

            //Step 2: Create Boolean value to check whether the user deleted or not
            bool success = dal.Delete(u);

            //Check whether the user is Deleted or Not
            if (success == true)
            {
                //User Deleted Successfully
                MessageBox.Show("User Deleted Successfully.");

                //Refresh Data Grid View
                DataTable dt = dal.Select();
                dvgUsers.DataSource = dt;

                //Clear the Text Boxes
                Clear();
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Call the user function
            Clear();
        }
    }
}
