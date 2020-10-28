using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using TrackITManagementSystem.BLL;
using TrackITManagementSystem.DAL;

namespace TrackITManagementSystem.UI
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();

            //Load Admin Form to update security level if needed 
            frmAdmin admin = new frmAdmin();
            admin.Show();
            admin.Hide();
        }

        //Create the object of BLL and DAL
        static loginBLL l = new loginBLL();
        static loginDAL dal = new loginDAL();

        //Create a static string method to save the username
        public static string loggedInUser;
        public static string loggedInPassword;
        public static int loggedInUserID;

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Code to close application
            Application.Exit();
        }
        //Create method to move the windows around on screen with drag function
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
            int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        //To access anywhere on the form
        public static extern bool ReleaseCapture();
        private void frmLogin_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        public void StartLoginCheck()
        {
            //Code to login to the application
            //1. Get username and password from login form
            l.username = txtUsername.Text;
            l.password = HashPassword.CalculateSHA256(txtPassword.Text);

            //2. Check Login Credentials
            bool isSuccess = dal.loginCheck(l);

            l.userID = dal.getUserID(txtUsername.Text);

            loggedInUserID = l.userID;
            //3. Check if login is success or not
            //If login is success then isSuccess will be true else it will be false
            if (isSuccess == true)
            {
                //Login Success
                //Display Success Message
                MessageBox.Show("Login Successful");

                //Save the username in loggedInUser Static Method
                loggedInUser = l.username;
                loggedInPassword = l.password;

                //Display home form
                frmHome home = new frmHome();
                home.Show();
                Hide();//To close login form
            }
            else
            {
                //Login Failed
                //Display the error message
                MessageBox.Show("Login Failed, Please Try Again");
            }
        }
        //If Login Button is Pressed with mouse click
        private void btnLogin_Click(object sender, EventArgs e)
        {
            StartLoginCheck();
        }
        //If Login is activated with ENTER key
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
               StartLoginCheck();
            }
        }
    }
}
