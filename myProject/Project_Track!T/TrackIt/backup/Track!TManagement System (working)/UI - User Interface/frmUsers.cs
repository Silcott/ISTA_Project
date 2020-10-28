using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
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

        //Global variable to store no image name for picturebox
        string imageName = "no-image.png";

        //When User clicks on back button, close current form and open Home form
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Add functionality to close this form
            Close();

            //Open Home Form
            frmHome home = new frmHome();
            home.Show();
        }
        #region SELECT data from database (User Module)
        //what ever is written is shown when collapsed
        // the above region allows the developer to collapse/uncollapsed everything
        // within it, as long as their IDE supports regions
        //Create a Static String to Connect Database 
        static string myconnstring = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
        public static DataTable SelectCurrentUser(string selectionName) //create a Select method 
        {
            //Create an Object to connect database
            SqlConnection conn = new SqlConnection(myconnstring);

            //create a DataTable to hold the Data from Database
            DataTable dt = new DataTable();

            try//A try block identifies a block of code for which particular exceptions is activated. It is followed by one or more catch blocks.
            {
                //Write SQL Query to Get Data from Database
                String sql = $"SELECT {selectionName} FROM tbl_users WHERE username = '{frmLogin.loggedInUser}' and password = '{frmLogin.loggedInPassword}'";
                //Create SQL Command to Execute Query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Create Sql Data Adapter to hold the data from database temporarily
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //Open Database Connection
                conn.Open();

                //Transfer Data from SqlData Adapter to DataTable
                adapter.Fill(dt);
            }
            catch (Exception ex)//A program catches an exception with an exception handler at the place in a program where you want to handle the 
            //problem. The catch keyword indicates the catching of an exception.
            {
                //Display Error Message if there's any exceptional errors
                MessageBox.Show(ex.Message);
            }
            finally//The finally block is used to execute a given set of statements, whether an exception is thrown or not thrown. For example, 
            //if you open a file, it must be closed whether an exception is raised or not
            {
                //Close Database Connection
                conn.Close();
            }
            return dt;
        }
        #endregion //must have a end
        #region LOAD form Functions
        private void frmUsers_Load(object sender, EventArgs e)
        {
            //If admin, make textboxes readonly
            if (frmLogin.loggedInUser.ToUpper() == "ADMIN")
            {
                txtUserName.ReadOnly = true;
                txtPassword.ReadOnly = true;
            }

            //Display the Username of the logged In user
            lblUser.Text = frmLogin.loggedInUser.ToUpper();

            //Display ONLY Tickets that are for the Logged In User
            //Username
            DataTable dt = SelectCurrentUser("username");
            foreach (DataRow row in dt.Rows)
                txtUserName.Text = row[0].ToString();
            //User_ID
            dt = SelectCurrentUser("user_id");
            foreach (DataRow row in dt.Rows)
                txtUserID.Text = row[0].ToString();
            //Email
            dt = SelectCurrentUser("email");
            foreach (DataRow row in dt.Rows)
                txtEmail.Text = row[0].ToString();
            //Password
            dt = SelectCurrentUser("password");
            foreach (DataRow row in dt.Rows)
                txtPassword.Text = row[0].ToString();
            //Phone
            dt = SelectCurrentUser("phone");
            foreach (DataRow row in dt.Rows)
                txtPhone.Text = row[0].ToString();
            //Full Name
            dt = SelectCurrentUser("full_name");
            foreach (DataRow row in dt.Rows)
                txtFullName.Text = row[0].ToString();
            //Address
            dt = SelectCurrentUser("address");
            foreach (DataRow row in dt.Rows)
                txtAddress.Text = row[0].ToString();
            //Image File Name
            dt = SelectCurrentUser("image_name");
            foreach (DataRow row in dt.Rows)
                imageName = row[0].ToString();
            //Security Level
            dt = SelectCurrentUser("security_level");
            foreach (DataRow row in dt.Rows)
                txtSecurityLevel.Text = row[0].ToString();

            //Display the Image of the selected User
            //Get the path of the image
            string paths = Application.StartupPath.Substring(0, (Application.StartupPath.Length - 10));

            if (imageName == "no-image.png")
            {
                //Path to Destination Folder for no image
                string imagePath = paths + "\\images\\no-image.png";
                //Display in Picture Box
                pictureBoxProfilePicture.Image = new Bitmap(imagePath);
            }
            else
            {
                //Path to Destination Folder, if there is a selected image
                string imagePath = paths + "\\images\\" + imageName;
                //Display in Picture Box
                pictureBoxProfilePicture.Image = new Bitmap(imagePath);
            }
        }
        #endregion
        #region UPDATE Button
        //Update Button Method When Clicked
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
            u.security_level = txtSecurityLevel.Text;

            //Step 2: Create a Boolean variable to check whether the data is updated successfully ot not
            bool success = dal.Update(u);

            //Check whether the data is updated or not
            if (success == true)
            {
                //Data Updated Successfully
                MessageBox.Show("User Updated Successfully.");
            }
        }
        #endregion
        #region SELECT Image Button
        //Select Image Button Method When Clicked
        private void btnSelectImage_Click_1(object sender, EventArgs e)
        {
            //Write the code to upload image of user
            //Open Dialog Box to select image
            OpenFileDialog open = new OpenFileDialog();

            //Filter the file type to only allow image file types
            open.Filter = "Image Files *.jpeg; *.jpg; *.png; *.PNG; *.gif;)|*.jpeg; *.jpg; *.png; *.PNG;";

            //Check if the file is selected or not
            if(open.ShowDialog() == DialogResult.OK)
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

                    //3. Rename the image, this renames it to the current datetime plus a random numbner between 0-1000 and adds the extension
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
        #region METHOD to move form around screen
        //Method to move the windows around on screen with drag function
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
            int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        //If User Presses the Mouse Button on the Form
        private void frmUsers_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        //If User Presses the Mouse Button on the Forms Top Panel
        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        #endregion
    }
}
