using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackITManagementSystem.BLL;
using TrackITManagementSystem.DAL;
using TrackITManagementSystem.UI;

namespace TrackITManagementSystem
{
    static class Program
    {
        

        private static string ShowInputDialog(ref string input)
        {
            System.Drawing.Size size = new System.Drawing.Size(280, 70);
            Form inputBox = new Form();

            inputBox.StartPosition = FormStartPosition.CenterScreen;
            inputBox.FormBorderStyle = FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = "Enter Password";

            TextBox textBox = new TextBox();
            textBox.Size = new System.Drawing.Size(size.Width - 10, 23);
            textBox.Location = new System.Drawing.Point(5, 5);
            textBox.Text = input;
            inputBox.Controls.Add(textBox);

            Button okButton = new Button();
            okButton.DialogResult = DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 39);
            inputBox.Controls.Add(okButton);

            Button cancelButton = new Button();
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(75, 23);
            cancelButton.Text = "&Cancel";
            cancelButton.Location = new System.Drawing.Point(size.Width - 80, 39);
            inputBox.Controls.Add(cancelButton);

            inputBox.AcceptButton = okButton;
            inputBox.CancelButton = cancelButton;

            DialogResult result = inputBox.ShowDialog();
            input = textBox.Text;
            return input;
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Create the object of BLL and DAL
            loginBLL l = new loginBLL();
            loginDAL dal = new loginDAL();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DialogResult dialogResult = MessageBox.Show("Run Program in ADMIN mode?", "Security Mode:", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string input = "password";
                string response = ShowInputDialog(ref input);
                //Code to login to the application
                //1. Get username and password from login form
                l.username = "admin";
                l.password = HashPassword.CalculateSHA256(response);

                //2. Check Login Credentials
                bool isSuccess = dal.loginCheck(l);

                //3. Check if login is success or not
                //If login is success then isSuccess will be true else it will be false
                if (isSuccess == true)
                {
                    //Save the username in loggedInUser Static Method
                   frmLogin.loggedInUser = l.username;
                   frmLogin.loggedInPassword = l.password;

                   //Send User - ADMIN to Admin Page
                   Application.Run(new frmAdmin());
                }
                else
                {
                    //Login Failed
                    //Display the error message
                    MessageBox.Show("Login Failed");
                    Application.Run(new frmSplash());
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                Application.Run(new frmSplash());
            }
        }
    }
}
