using DGVPrinterHelper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
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
        }

        //Create object of requester BLL and requester DAL
        requestersBLL r = new requestersBLL();
        requesterDAL dal = new requesterDAL();
        userDAL udal = new userDAL();

        //Global variable for file name path
        private string fileName = "no-file.txt";

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Close this form
            Hide();
            
            //Open Home Form
            frmHome home = new frmHome();
            home.Show();
        }
        public bool IsValidPhone(string Phone)
        {
            string pattern = @"\(?\d{3}\)?[-\.]? *\d{3}[-\.]? *[-\.]?\d{4}";
            try
            {
                if (string.IsNullOrEmpty(Phone))
                    return false;
                var r = new Regex(pattern);
                return r.IsMatch(Phone);

            }
            catch (Exception)
            {
                throw;
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtFirstName.Text == "" || 
                textLastName.Text == "" || 
                txtEmail.Text == "" || 
                txtPhone.Text == "" || 
                txtLocation.Text == "" || 
                txtissuecategory.Text == "" || 
                txtPriorityLevel.Text == "" || 
                textIssueDescription.Text == "")
            {
                if (txtFirstName.Text == "")
                    MessageBox.Show("First Name Required");
                if (textLastName.Text == "")
                    MessageBox.Show("Last Name Required");
                if (txtEmail.Text == "")
                    MessageBox.Show("Email Required");
                if (txtPhone.Text == "")
                    MessageBox.Show("Phone Required");
                if (txtLocation.Text == "")
                    MessageBox.Show("Location Required");
                if (txtissuecategory.Text == "")
                    MessageBox.Show("Issue Category Required");
                if (textIssueDescription.Text == "")
                    MessageBox.Show("Issue Decsription Required");
            }
            else
            {
                if (txtEmail.Text != "")
                {
                    string email = txtEmail.Text;
                    Regex regexEmail = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                                            + "@"
                                            + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");
                    Match matchEmail = regexEmail.Match(email);
                    if (!matchEmail.Success)
                        MessageBox.Show(email + " Email Format is Incorrect");
                    else
                    {
                        if (IsValidPhone(txtPhone.Text) == false)
                        {
                            MessageBox.Show(txtPhone.Text + " Phone Format is Incorrect. Try XXX-XXX-XXXX");

                        }
                        else
                        {
                            //Step 1. Get the data from the manage requesters form
                            r.first_name = txtFirstName.Text;
                            r.last_name = textLastName.Text;
                            r.email = txtEmail.Text;
                            r.phone = txtPhone.Text;
                            r.location = txtLocation.Text;
                            r.issue_category = txtissuecategory.Text;
                            r.priority_level = txtPriorityLevel.Text;
                            r.issue_description = textIssueDescription.Text;
                            r.added_date = DateTime.Now;
                            r.completed_date = textDateCompleted.Text;
                            r.cost = textCost.Text;
                            r.file_name_path = fileName;

                            //Get the ID of logged in user
                            string loggedInUser = frmLogin.loggedInUser;
                            userBLL usr = udal.GetIDFromUsername(loggedInUser);

                            r.ticket_creator_name = usr.full_name;

                            //Step 2. Inserting Data into Database
                            //Create a boolean variable to insert data into database and check whether the data inserted successfully or not
                            bool isSuccess = dal.Insert(r);

                            //If the data is inserted successfully then the values of isSuccess will be True else it will be false
                            if (isSuccess == true)
                            {
                                //Data INserted Successfully
                                MessageBox.Show("New Ticket Added Successfully");

                                //Refresh Datagrid View
                                DataTable dt = dal.Select();
                                dvgUsers.DataSource = dt;

                                //Clear all the textboxes
                                Clear();
                            }
                            else
                            {
                                //Failed to insert data
                                MessageBox.Show("Failed to Add new Ticket");
                            }
                        }
                    }
                }
            }
        }

        //Create a method to clear all the textboxes
        public void Clear()
        {
            //Clear all the textboxes
            txtTicketID.Text = "";
            txtFirstName.Text = "";
            textLastName.Text = "";
            txtEmail.Text = "";
            textTicketCreatorName.Text = "";
            txtPhone.Text = "";
            txtLocation.Text = "";
            txtissuecategory.Text = "";
            txtPriorityLevel.Text = "";
            textDateCreated.Text = "";
            textDateCompleted.Text = "";
            textCost.Text = "";
            txtFileNamePath.Text = "";
        }
        public void addItemsFirstName(AutoCompleteStringCollection col)
        {
            col.Add("James");
        }
        public void addItemsLastName(AutoCompleteStringCollection col)
        {
            col.Add("Silcott");
        }
        public void addItemsEmailName(AutoCompleteStringCollection col)
        {
            col.Add("silcott.jb@outlook.com");
        }
        public void addItemsPhoneName(AutoCompleteStringCollection col)
        {
            col.Add("907-250-7727");
        }
        public void addItemsLocationName(AutoCompleteStringCollection col)
        {
            col.Add("204 Betsinger Rd, Sherrill, NY 13461");
        }
        public void addItemsCostName(AutoCompleteStringCollection col)
        {
            col.Add("$0.00");
        }
        public void addItemsIssueDescriptionName(AutoCompleteStringCollection col)
        {
            col.Add("Issues");
        }
        public void addItemsDateCompletedName(AutoCompleteStringCollection col)
        {
            col.Add("TBD");
        }

        private void frmRequesters_Load(object sender, EventArgs e)
        {
            //First Name
            txtFirstName.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtFirstName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //Last Name
            textLastName.AutoCompleteMode = AutoCompleteMode.Suggest;
            textLastName.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //Email
            txtEmail.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtEmail.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //Phone
            txtPhone.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtPhone.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //Location
            txtLocation.AutoCompleteMode = AutoCompleteMode.Suggest;
            txtLocation.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //Cost
            textCost.AutoCompleteMode = AutoCompleteMode.Suggest;
            textCost.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //Issue Description
            textIssueDescription.AutoCompleteMode = AutoCompleteMode.Suggest;
            textIssueDescription.AutoCompleteSource = AutoCompleteSource.CustomSource;
            //Date Completed
            textDateCompleted.AutoCompleteMode = AutoCompleteMode.Suggest;
            textDateCompleted.AutoCompleteSource = AutoCompleteSource.CustomSource;

            AutoCompleteStringCollection DataCollectionFirstName = new AutoCompleteStringCollection();
            AutoCompleteStringCollection DataCollectionLastName = new AutoCompleteStringCollection();
            AutoCompleteStringCollection DataCollectionEmail = new AutoCompleteStringCollection();
            AutoCompleteStringCollection DataCollectionPhone = new AutoCompleteStringCollection();
            AutoCompleteStringCollection DataCollectionLocation = new AutoCompleteStringCollection();
            AutoCompleteStringCollection DataCollectionCost = new AutoCompleteStringCollection();
            AutoCompleteStringCollection DataCollectionIssueDescription = new AutoCompleteStringCollection();
            AutoCompleteStringCollection DataCollectionDateCompleted = new AutoCompleteStringCollection();

            addItemsFirstName(DataCollectionFirstName);
            addItemsLastName(DataCollectionLastName);
            addItemsEmailName(DataCollectionEmail);
            addItemsPhoneName(DataCollectionPhone);
            addItemsLocationName(DataCollectionLocation);
            addItemsCostName(DataCollectionCost);
            addItemsIssueDescriptionName(DataCollectionIssueDescription);
            addItemsDateCompletedName(DataCollectionDateCompleted);

            txtFirstName.AutoCompleteCustomSource = DataCollectionFirstName;
            textLastName.AutoCompleteCustomSource = DataCollectionLastName;
            txtEmail.AutoCompleteCustomSource = DataCollectionEmail;
            txtPhone.AutoCompleteCustomSource = DataCollectionPhone;
            txtLocation.AutoCompleteCustomSource = DataCollectionLocation;
            textCost.AutoCompleteCustomSource = DataCollectionCost;
            textIssueDescription.AutoCompleteCustomSource = DataCollectionIssueDescription;
            textDateCompleted.AutoCompleteCustomSource = DataCollectionDateCompleted;

            //Display the USername of the logged In user
            lblUser.Text = frmLogin.loggedInUser.ToUpper();

            //Display Requester in DataGrid View on Opening Screen
            DataTable dt = dal.Select();
            dvgUsers.DataSource = dt;

            dvgUsers.Columns[0].HeaderText = "Ticket ID";
            dvgUsers.Columns[1].HeaderText = "First Name";
            dvgUsers.Columns[2].HeaderText = "Last Name";
            dvgUsers.Columns[3].HeaderText = "Email";
            dvgUsers.Columns[4].HeaderText = "Creator Name";
            dvgUsers.Columns[5].HeaderText = "Phone Number";
            dvgUsers.Columns[6].HeaderText = "Location";
            dvgUsers.Columns[7].HeaderText = "Issue Category";
            dvgUsers.Columns[8].HeaderText = "Priority Level";
            dvgUsers.Columns[9].HeaderText = "Issue Description";
            dvgUsers.Columns[10].HeaderText = "Date Added";
            dvgUsers.Columns[11].HeaderText = "Date Completed";
            dvgUsers.Columns[12].HeaderText = "Cost";
            dvgUsers.Columns[13].HeaderText = "File Name";
        }

        private void dvgUsers_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //Select the data from the DataGrid view and display in the form
            //Find the row selected
            int RowIndex = e.RowIndex;
            txtTicketID.Text = dvgUsers.Rows[RowIndex].Cells[0].Value.ToString().Trim();
            txtFirstName.Text = dvgUsers.Rows[RowIndex].Cells[1].Value.ToString().Trim();
            textLastName.Text = dvgUsers.Rows[RowIndex].Cells[2].Value.ToString().Trim();
            txtEmail.Text = dvgUsers.Rows[RowIndex].Cells[3].Value.ToString().Trim();
            textTicketCreatorName.Text = dvgUsers.Rows[RowIndex].Cells[4].Value.ToString().Trim();
            txtPhone.Text = dvgUsers.Rows[RowIndex].Cells[5].Value.ToString().Trim();
            txtLocation.Text = dvgUsers.Rows[RowIndex].Cells[6].Value.ToString().Trim();
            txtissuecategory.Text = dvgUsers.Rows[RowIndex].Cells[7].Value.ToString().Trim();
            txtPriorityLevel.Text = dvgUsers.Rows[RowIndex].Cells[8].Value.ToString().Trim();
            textIssueDescription.Text = dvgUsers.Rows[RowIndex].Cells[9].Value.ToString().Trim();
            textDateCreated.Text = dvgUsers.Rows[RowIndex].Cells[10].Value.ToString().Trim();
            textDateCompleted.Text = dvgUsers.Rows[RowIndex].Cells[11].Value.ToString().Trim();
            textCost.Text = dvgUsers.Rows[RowIndex].Cells[12].Value.ToString().Trim();
            txtFileNamePath.Text = dvgUsers.Rows[RowIndex].Cells[13].Value.ToString().Trim();
          
            //Remove any spaces in the textboxes fields
            txtFirstName.Text = txtFirstName.Text.Trim();
            textLastName.Text = textLastName.Text.Trim();
            txtEmail.Text = txtEmail.Text.Trim();
            txtPhone.Text = txtPhone.Text.Trim();
            txtLocation.Text = txtLocation.Text.Trim();
            lblIssueCategory.Text = lblIssueCategory.Text.Trim();
            textIssueDescription.Text = textIssueDescription.Text.Trim();
            textCost.Text = textCost.Text.Trim();
            textDateCompleted.Text = textDateCompleted.Text.Trim();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtTicketID.Text == "")
            {
                MessageBox.Show("Select a Ticket to Update");
            }
            else
            {
                if (txtFirstName.Text == "" ||
                    textLastName.Text == "" ||
                    txtEmail.Text == "" ||
                    txtPhone.Text == "" ||
                    txtLocation.Text == "" ||
                    txtissuecategory.Text == "" ||
                    txtPriorityLevel.Text == "" ||
                    textIssueDescription.Text == "")
                {
                    if (txtFirstName.Text == "")
                        MessageBox.Show("First Name Required");
                    if (textLastName.Text == "")
                        MessageBox.Show("Last Name Required");
                    if (txtEmail.Text == "")
                        MessageBox.Show("Email Required");
                    if (txtPhone.Text == "")
                        MessageBox.Show("Phone Required");
                    if (txtLocation.Text == "")
                        MessageBox.Show("Location Required");
                    if (txtissuecategory.Text == "")
                        MessageBox.Show("Issue Category Required");
                    if (textIssueDescription.Text == "")
                        MessageBox.Show("Issue Decsription Required");
                }
                else
                {
                    if (txtEmail.Text != "")
                    {
                        string email = txtEmail.Text;
                        const string pattern = @"^((([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+(\.([a-z]|\d|[!#\$%&'\*\+\-\/=\?\^_`{\|}~]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])+)*)|((\x22)((((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(([\x01-\x08\x0b\x0c\x0e-\x1f\x7f]|\x21|[\x23-\x5b]|[\x5d-\x7e]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(\\([\x01-\x09\x0b\x0c\x0d-\x7f]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF]))))*(((\x20|\x09)*(\x0d\x0a))?(\x20|\x09)+)?(\x22)))@((([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|\d|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.)+(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])|(([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])([a-z]|\d|-|\.|_|~|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])*([a-z]|[\u00A0-\uD7FF\uF900-\uFDCF\uFDF0-\uFFEF])))\.?$";
                        Regex regexEmail = new Regex(pattern);
                        Match matchEmail = regexEmail.Match(email);
                        if (!matchEmail.Success)
                            MessageBox.Show(email + "\nEmail Format is Incorrect");
                        else
                        {
                            if (IsValidPhone(txtPhone.Text) == false)
                            {
                                MessageBox.Show(txtPhone.Text + " Phone Format is Incorrect. Try XXX-XXX-XXXX");

                            }
                            else
                            {
                                //Add functionality to update the tickets
                                //1. Get the values from Form
                                r.ticket_id = int.Parse(txtTicketID.Text);
                                r.first_name = txtFirstName.Text;
                                r.last_name = textLastName.Text;
                                r.email = txtEmail.Text;
                                r.phone = txtPhone.Text;
                                r.location = txtLocation.Text;
                                r.issue_category = txtissuecategory.Text;
                                r.priority_level = txtPriorityLevel.Text;
                                r.issue_description = textIssueDescription.Text;
                                r.completed_date = textDateCompleted.Text;
                                r.cost = textCost.Text;
                                r.file_name_path = txtFileNamePath.Text;

                                //Get the ID of logged in user
                                string loggedInUser = frmLogin.loggedInUser;
                                userBLL usr = udal.GetIDFromUsername(loggedInUser);

                                r.ticket_creator_name = usr.full_name;

                                //Create a boolean variable to check if the data updated successfully or not
                                bool isSuccess = dal.Update(r);

                                //If the data updated successfully then the value of the isSuccess will be true else it will be false
                                if (isSuccess == true)
                                {
                                    //Ticket Updated Successfully
                                    MessageBox.Show("Ticket Updated Successfully");
                                    Clear();

                                    //Refresh DatagridView
                                    DataTable dt = dal.Select();
                                    dvgUsers.DataSource = dt;
                                }
                                else
                                {
                                    //Failed to update
                                    MessageBox.Show("Failed to Update");
                                }
                            }
                        }
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            //Get the value from Form
            r.ticket_id = int.Parse(txtTicketID.Text);

            //Create Boolean variable to check if the ticket deleted or not
            bool isSuccess = dal.Delete(r);

            if (isSuccess == true)
            {
                //Ticket Deleted Successfully
                MessageBox.Show("Ticket Deleted Successfully");

                Clear();

                //Refresh Datagrid View
                DataTable dt = dal.Select();
                dvgUsers.DataSource = dt;
            }
            else
            {
                //Failed to Delete Ticket
                MessageBox.Show("Failed to Delete Ticket");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            //Clear the text boxes
            Clear();
        }
       
        //Create method to move the windows around on screen with drag function
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
            int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();
        private void frmRequesters_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void panelTop_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //Add functionality to search tickets
            //1. Get keywords typed on the search text box
            string keywords = txtSearch.Text;

            //Check if the text box is empty or not
            if (keywords != null)
            {
                //Display the information of tickets based on keywords
                DataTable dt = dal.Search(keywords);
                dvgUsers.DataSource = dt;
            }
            else
            {
                //Display all tickets
                DataTable dt = dal.Select();
                dvgUsers.DataSource = dt;
            }
        }
        string file_name_path = "no-file.txt";
        string destionationPath = "";
        private void btnUploadFile_Click(object sender, EventArgs e)
        {
            //Write the code to upload file from user
            //Open Dialog Box to select image
            OpenFileDialog open = new OpenFileDialog();

            //Filter the file type to only allow image file types
            open.Filter = "Document Files *.doc; *.docm; *.docx; *.dot; *.dotm;)|*.dotx; *.htm; *.html; *.mhtml; *.odt; *.pdf; *.rtf; *.txt; *.wps; *.xml; *.xps; *.xlsx;";

            //Check if the file is selected or not
            if (open.ShowDialog() == DialogResult.OK)
            {
                //Check if the file exists or not
                if (open.CheckFileExists)
                {
                    //Display the selected file 
                    //pictureBoxProfilePicture.Image = new Bitmap(open.FileName);

                    //Rename the File Selected
                    //1. Get the extension of image
                    string ext = Path.GetExtension(open.FileName);

                    //2. Generate Random Integer
                    Random random = new Random();
                    int RandInt = random.Next(0, 1000);

                    //3. Rename the image, this renames it to the current datetime plus a random numbner between 0-1000 and adds the extension
                    file_name_path = DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss") + RandInt + ext;

                    //4. Set the path for the selected images
                    string sourcePath = open.FileName;

                    //5. Get the the path of destination
                    string paths = Application.StartupPath.Substring(0, Application.StartupPath.Length - 10);
                    //Paths to destination folder
                    destionationPath = paths + "\\files\\" + file_name_path;

                    //6. Copy image to the destionation folder
                    File.Copy(sourcePath, destionationPath);

                    //7. Display Message
                    MessageBox.Show("File Successfully Uploaded.");

                    txtFileNamePath.Text = destionationPath;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            destionationPath = txtFileNamePath.Text;
            if (destionationPath == "" || destionationPath.Contains("no-file.txt"))
            {
                MessageBox.Show("There are No Files Uploaded to this Ticket");
            }
            else
            {
            System.Diagnostics.Process.Start(destionationPath);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Code to Print Users
            DGVPrinter printer = new DGVPrinter();

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
    }
}
