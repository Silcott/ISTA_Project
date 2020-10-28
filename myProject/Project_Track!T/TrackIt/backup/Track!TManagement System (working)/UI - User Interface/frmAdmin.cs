using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using DGVPrinterHelper;
using TrackITManagementSystem.BLL;
using TrackITManagementSystem.DAL;

namespace TrackITManagementSystem.UI
{
    public partial class frmAdmin : Form
    {
        //public static DataGridView dvgUsers;
        public frmAdmin()
        {
            InitializeComponent();
        }
        //Create Objects of userBLL and userDAL
        userBLL u = new userBLL();
        userDAL dal = new userDAL();
        //Global variable for the no image 
        private string imageName = "no-image.png";
        //Global variable for the image to delete
        private string rowHeaderImage;
        //Counter & Boolean variable for the Activated Form Function
        public static int count = 0;
        public static bool stopCount = false;
        #region BACK Button Function
        private void btnBackUserPage_Click_1(object sender, EventArgs e)
        {
            //Open Home Form
            frmHome home = new frmHome();
            home.Show();
            //Add functionality to close this form
            Hide();
        }
        #endregion
        #region ADD Button Function
        private void btnAdd_Click_1(object sender, EventArgs e)
        {
            //Step 1: Get the values from UI form
            if (txtUserName.Text == "")
                MessageBox.Show("Username is Blank. Must Input a Value");
            else
            {
                //Search database to see if the user already exists before adding
                DataTable dt = dal.Search(txtUserName.Text);
                dvgUsers.DataSource = dt;
                if (dal.FindUsername("username", txtUserName.Text) == true)
                {
                    MessageBox.Show("That Username Already Exists.  Pick Another");
                    //Display the user in DataGrid View
                    dt = dal.Select();
                    dvgUsers.DataSource = dt;
                }
                else
                {
                    //Display the user in DataGrid View
                    dt = dal.Select();
                    dvgUsers.DataSource = dt;
                    //Assign the values from textboxes to the database
                    u.username = txtUserName.Text;
                    u.full_name = txtFullName.Text;
                    u.email = txtEmail.Text;
                    u.password = txtPassword.Text;
                    u.phone = txtPhone.Text;
                    u.address = txtAddress.Text;
                    u.added_date = DateTime.Now;
                    u.image_name = imageName;
                    u.security_level = txtSecurityLevelChange.Text;
                    //Step 2: Adding the values from the UI to the Database
                    //Create a boolean variable to check whether the data is inserted successfully or not
                    bool success = dal.Insert(u);
                    //Step 3: Check whether the data is inserted successfully or not
                    if (success == true)
                    {
                        //Data or User Added Successsfully
                        MessageBox.Show("New User added Successfully.");
                        //Refresh the user in DataGrid View
                        dt = dal.Select();
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
            }
        }
        #endregion
        #region CLEAR Function
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
            txtSecurityLevelChange.Text = "";
            //Path to Destination Folder for no image
            //Get the path of the image
            string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));//subtract 10 characters to allow for the path
            string imagePath = paths + "\\images\\no-image.png";
            //Display in Picture Box
            pictureBoxProfilePicture.Image = new Bitmap(imagePath);
        }
        #endregion
        #region DataViewGrid SELECT & INSERT Data & Profile Picture
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
            imageName = dvgUsers.Rows[RowIndex].Cells[8].Value.ToString();
            txtSecurityLevel.Text = dvgUsers.Rows[RowIndex].Cells[9].Value.ToString();
            //Update the value of the global variable of rowHeaderImage
            rowHeaderImage = imageName;
            //Display the Image of the selected User
            //Get the path of the image
            string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
            //Determine if image exists 
            if (imageName != "no-image.png")
            {
                //Path to Destination Folder, if there is a selected image
                string imagePath = paths + "\\images\\" + imageName;
                //This is in case a file is moved by outside source and needs to be reset
                if (!File.Exists(imagePath))
                {
                    MessageBox.Show("Picture Was Deleted.  Reset to Default");
                    imageName = "no-image.png";
                    u.image_name = imageName;
                }
                else
                {
                    //Path to Destination Folder, if there is a selected image
                    //Display in Picture Box
                    pictureBoxProfilePicture.Image = new Bitmap(imagePath);
                    u.image_name = imageName;
                }
            }
            else
            {
                //Path to Destination Folder for no image
                string imagePath = paths + "\\images\\no-image.png";
                //Display in Picture Box
                pictureBoxProfilePicture.Image = new Bitmap(imagePath);
            }
        }
        #endregion
        #region LOAD Method
        private void frmAdmin_Load(object sender, EventArgs e)
        {
            //Display the Users in Data Grid View when the form is loaded
            DataTable dt = dal.Select();
            dvgUsers.DataSource = dt;
            //Change the headers of the DataViewGrid
            dvgUsers.Columns[0].HeaderText = "User ID";
            dvgUsers.Columns[1].HeaderText = "Username";
            dvgUsers.Columns[2].HeaderText = "Email";
            dvgUsers.Columns[3].HeaderText = "Password";
            dvgUsers.Columns[4].HeaderText = "Full Name";
            dvgUsers.Columns[5].HeaderText = "Phone";
            dvgUsers.Columns[6].HeaderText = "Address";
            dvgUsers.Columns[7].HeaderText = "Date Added";
            dvgUsers.Columns[8].HeaderText = "Profile Picture File Name";
            dvgUsers.Columns[9].HeaderText = "Security Level";
            //Display the Image of the selected User
            //Get the path of the image
            string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
            //Determine if image exists
            if (imageName != "no-image.png")
            {
                //Path to Destination Folder, if there is a selected image
                string imagePath = paths + "\\images\\" + imageName;
                //Display in Picture Box
                pictureBoxProfilePicture.Image = new Bitmap(imagePath);
            }
            else
            {
                //Path to Destination Folder for no image
                string imagePath = paths + "\\images\\no-image.png";
                //Display in Picture Box
                pictureBoxProfilePicture.Image = new Bitmap(imagePath);
            }
        }


        #endregion
        #region UPDATE Button Method
        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            //If user name is blank, don't update
            if (txtUserID.Text == "")
            {
                MessageBox.Show("You Can't Update Without a User Id. Select User.");
            }
            else
            {
                //If Admin isn't the user, than set the values in the database, else update everythong except the security level
                //To ensure the ADMIN always has the "admin" security level
                if (txtUserName.Text.ToUpper() != "ADMIN")
                {
                    //Step 1: Get the values from UI
                    u.user_id = int.Parse(txtUserID.Text);
                    u.full_name = txtFullName.Text;
                    u.email = txtEmail.Text;
                    u.username = txtUserName.Text;
                    u.password = HashPassword.CalculateSHA256(txtPassword.Text);
                    u.phone = txtPhone.Text;
                    u.address = txtAddress.Text;
                    u.added_date = DateTime.Now;
                    u.image_name = imageName;
                    u.security_level = txtSecurityLevelChange.Text;
                    //Step 2: Create a Boolean variable to check whether the data is updated successfully ot not
                    bool success = dal.Update(u);
                    //Check whether the data is updated or not
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
                else
                {
                    u.user_id = int.Parse(txtUserID.Text);
                    u.full_name = txtFullName.Text;
                    u.email = txtEmail.Text;
                    u.username = txtUserName.Text;
                    u.password = HashPassword.CalculateSHA256(txtPassword.Text);
                    u.phone = txtPhone.Text;
                    u.address = txtAddress.Text;
                    u.added_date = DateTime.Now;
                    u.image_name = imageName;
                    u.security_level = "Admin";//Leave to ensure ADMIN never loses this security level
                    //Boolean to check update
                    bool success = dal.Update(u);
                    //Check whether the data is updated or not
                    if (success == true)
                    {
                        MessageBox.Show("Updated everything except security level");
                        //Refresh Data Grid View
                        DataTable dt = dal.Select();
                        dvgUsers.DataSource = dt;
                        //Clear the Text Boxes
                        Clear();
                    }
                }
            }
        }
        #endregion
        #region DELETE Button Method
        private void btnDelete_Click_1(object sender, EventArgs e)
        {
            //Assign the user to database to ensure the latest person is logged in
            u.username = txtUserName.Text;
            //Check if user is trying to delete self, else delete user
            if (frmLogin.loggedInUser.ToUpper() == u.username.ToUpper())
                MessageBox.Show("You Can't Delete the Yourself");
            else
            {
                if (txtUserID.Text == "")
                    MessageBox.Show("You Can't Delete Without a User Id. Select User.");
                else
                {
                    //Step 1: Get the UsersId from the Text Box to Delete the User
                    u.user_id = int.Parse(txtUserID.Text);
                    //Remove physical file of the user profile
                    if (rowHeaderImage != "no-image.png") //default image name
                    {
                        //Path of the project folder
                        string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));
                        //Give the path of the image folder
                        string imagePath = paths + "\\images\\" + rowHeaderImage;
                        //Call clear function to clear all textboxes and picturebox
                        Clear();
                        //Call Garbage Collection Function
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        //Delete the physical file of the user profile
                        File.Delete(imagePath);
                    }
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
            }
        }
        #endregion
        #region CLEAR Button Method
        private void btnClear_Click_1(object sender, EventArgs e)
        {
            //Call the clear user function
            Clear();
        }
        #endregion
        #region SELECT Image Button
        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            //Write the code to upload image of user
            //Open Dialog Box to select image
            OpenFileDialog open = new OpenFileDialog();
            //Filter the file type to only allow image file types
            open.Filter = "Image Files *.jpeg; *.jpg; *.png; *.PNG; *.gif; *.jpeg; *.jpg; *.png; *.PNG; *.gif;)|";
            //Check if the file is selected or not
            if (open.ShowDialog() == DialogResult.OK)
            {
                //Check if the file exists or not
                if (open.CheckFileExists)
                {
                    //Display the selected file on Picture Box
                    pictureBoxProfilePicture.Image = new Bitmap(open.FileName);
                    //Rename the Image we select
                    //1. Get the extension of image
                    string ext = Path.GetExtension(open.FileName);
                    //2. Generate Random Integer
                    Random random = new Random();
                    int RandInt = random.Next(0, 1000);
                    //3. Rename the image, this renames it to the current datetime plus a random number between 0-1000 and adds the extension
                    imageName = DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + RandInt + ext;
                    //4. Set the path for the selected images
                    string sourcePath = open.FileName;
                    //5. Get the the path of destination
                    string paths = Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);
                    //Paths to destination folder
                    string destionationPath = paths + "\\images\\" + imageName;
                    //6. Copy image to the destionation folder
                    File.Copy(sourcePath, destionationPath);
                    //7. Display Message
                    MessageBox.Show("Image Successfully Uploaded.");
                }
            }
        }
        #endregion
        #region SEARCH Textbox Method
        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            //Write the code to get users based on keywords
            //1. Get the keywords form the TextBox
            String keywords = txtSearch.Text;

            //Check whether the textbox is empty ot not
            if (keywords != null)
            {
                //TextBox is not empty, display users on Data Grid View based on the ketywords
                DataTable dt = dal.Search(keywords);
                dvgUsers.DataSource = dt;
            }
            else
            {
                //TextBox is empty and display all the users on the Data Grid View
                DataTable dt = dal.Select();
                dvgUsers.DataSource = dt;
            }
        }
        #endregion
        #region METHOD to move form around screen
        //Create method to move the windows around on screen with drag function
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
            int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void frmAdmin_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void panelTop_MouseDown_1(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion
        #region PRINTER Button Method
        private void btnPrintUsers_Click(object sender, EventArgs e)
        {
            //Code to Print Users
            DGVPrinter printer = new DGVPrinter();
            //Make additions to the form
            printer.Title = "\r\n\r\nTICKET TRACKER MANAGEMENT SYSTEM, CO.";
            printer.SubTitle = "James B. Silcott \r\nPhone: 907-250-7727\r\nEmail: silcott.jb@outlook.com";
            printer.SubTitleFormatFlags = StringFormatFlags.LineLimit | StringFormatFlags.NoClip;
            printer.PageNumbers = true;
            printer.PageNumberInHeader = false;
            printer.PorportionalColumns = true;
            printer.HeaderCellAlignment = StringAlignment.Near;
            printer.Footer =
                $"Thank you \"{frmLogin.loggedInUser}\" for using the Ticket Management System \r\nTimestamp: {DateTime.Now}";
            printer.FooterSpacing = 15;
            printer.PrintDataGridView(dvgUsers);
        }
        #endregion
        #region ACTIVATE Form Function
        //To ensure the Admin Page shows the name of the user
        private void frmAdmin_Activated(object sender, EventArgs e)
        {
            //Still expression to exit the count
            //Once the user enters the admin page the count will be 2
            //This is due tot the admin page loading on login
            //If the admin page is loaded prior to login then 
            //Error will occur to not have the name to show
            //This prevents that error
            if (stopCount == false)
                count = count + 1;
            if (count >= 2)
                if (frmLogin.loggedInUser == "")
                    MessageBox.Show("No User has Logged in");
                else
                    lblUser.Text = frmLogin.loggedInUser.ToUpper();
            stopCount = true;
        }
        #endregion
    }
}

