using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using TrackITManagementSystem.DAL;
using TrackITManagementSystem.UI;
using System.Windows.Forms.DataVisualization.Charting;
using System.Runtime.InteropServices;


namespace TrackITManagementSystem
{
    public partial class frmHome : Form
    {
        public static bool isAdmin;

        public frmHome()
        {
            InitializeComponent();
        }

        //Create the Object of Ticket DAL
        requesterDAL dal = new requesterDAL();

        public void frmHome_Load(object sender, EventArgs e)
        {
            //Display the USername of the logged In user
            lblUser.Text = frmLogin.loggedInUser.ToUpper();
            
            //Load all the Issue Category count when the form is loaded
            ChartLoad();
            DataTable dt = dal.LoadUserNameTickets(lblUser.Text);
            dvgUsers.DataSource = dt;
        }

        readonly ToolTip _tooltip = new ToolTip();
        public void chart1_GetToolTipText(object sender, ToolTipEventArgs e)
        {
            HitTestResult hitTestResult = chart1.HitTest(e.X, e.Y, ChartElementType.DataPoint);//need ChartElementType to display on both charts
            if (hitTestResult.ChartElementType == ChartElementType.DataPoint)
            {
                _tooltip.RemoveAll();
                myToolTip1.ForeColor = Color.DarkSlateGray;

                var results = chart1.HitTest(e.X, e.Y, false,
                    ChartElementType.DataPoint);
                foreach (var result in results)
                {
                    if (result.ChartElementType == ChartElementType.DataPoint)
                    {
                        var prop = result.Object as DataPoint;
                        if (prop != null)
                        {
                            var pointXPixel = result.ChartArea.AxisX.ValueToPixelPosition(prop.XValue);
                            var pointYPixel = result.ChartArea.AxisY.ValueToPixelPosition(prop.YValues[0]);

                            // check if the cursor is really close to the point (500 pixels around the point)
                            if (Math.Abs(e.X - pointXPixel) < 500 &&
                                Math.Abs(e.Y - pointYPixel) < 500)
                            {
                                myToolTip1.SetControlToolTip(chart1, $"{prop.YValues[0]}");
                            }
                        }
                    }
                }
            }
        }
        public void ChartLoad()
        {
            float innerSize = 60;
            float outerSize = 100;
            float baseDoughnutWidth = 25;

            //Clear any Chart
            chart1.Series.Clear();

            //Create Series in Chart
            Series S1 = chart1.Series.Add("Category");//Outer Chart
            Series S2 = chart1.Series.Add("Priority");//Inner Chart

            chart1.ChartAreas.Clear();
            //Create ChartAreas
            ChartArea CA1 = chart1.ChartAreas.Add("Category");//Outer Chart
            ChartArea CA2 = chart1.ChartAreas.Add("Priority");//Inner Chart

            //Chart Positioning
            CA1.Position = new ElementPosition(10, 0, 100, 100);
            CA2.Position = new ElementPosition(10, 0, 100, 100);
            CA1.InnerPlotPosition = new ElementPosition((75 - outerSize) / 2,
                (100 - outerSize) / 2 + 10, outerSize, outerSize - 10);
            CA2.InnerPlotPosition = new ElementPosition((75 - innerSize) / 2,
                (100 - innerSize) / 2 + 10, innerSize, innerSize - 10);

            //Chart Size Calculation
            S1["DoughnutRadius"] =
                Math.Min(baseDoughnutWidth * (100 / outerSize), 99).ToString().Replace(",", ".");
            S2["DoughnutRadius"] =
                Math.Min(baseDoughnutWidth * (100 / innerSize), 99).ToString().Replace(",", ".");

            //Name ChartAreas
            S1.ChartArea = CA1.Name;
            S2.ChartArea = CA2.Name;

            //Chart Type
            S1.ChartType = SeriesChartType.Doughnut;
            S2.ChartType = SeriesChartType.Doughnut;

            //Pie Chart Background
            CA1.BackColor = Color.Transparent;
            CA2.BackColor = Color.Transparent;
            chart1.Legends[0].BackColor = Color.Transparent;

            //Pie Chart Sizes - Input
            S1["DoughnutRadius"] = "41"; // leave just a little space!
            S2["DoughnutRadius"] = "99"; // 99 is the limit. a tiny spot remains open

            //Outer Chart Values named and tickets counted
            if (Convert.ToInt32(dal.countTickets("issue_category", "Technical")) > 0)
                S1.Points.AddXY("Technical", dal.countTickets("issue_category", "Technical"));
            if (Convert.ToInt32(dal.countTickets("issue_category", "Billing")) > 0)
                S1.Points.AddXY("Billing", dal.countTickets("issue_category", "Billing"));
            if (Convert.ToInt32(dal.countTickets("issue_category", "Shipping")) > 0)
                S1.Points.AddXY("Shipping", dal.countTickets("issue_category", "Shipping"));
            if (Convert.ToInt32(dal.countTickets("issue_category", "Other")) > 0)
                S1.Points.AddXY("Other", dal.countTickets("issue_category", "Other"));
            //Inner Chart Values named and tickets counted
            if (Convert.ToInt32(dal.countTickets("priority_level", "High")) > 0)
                S2.Points.AddXY("High", dal.countTickets("priority_level", "High"));
            if (Convert.ToInt32(dal.countTickets("priority_level", "Avg")) > 0)
                S2.Points.AddXY("Avg", dal.countTickets("priority_level", "Avg"));
            if (Convert.ToInt32(dal.countTickets("priority_level", "Low")) > 0)
                S2.Points.AddXY("Low", dal.countTickets("priority_level", "Low"));

            //Total Number of tickets
            var totalTicketCount = Convert.ToInt32(dal.countTickets("priority_level", "High")) +
                                   Convert.ToInt32(dal.countTickets("priority_level", "Avg")) +
                                   Convert.ToInt32(dal.countTickets("priority_level", "Low"));
            lblTotalTickets.Text = totalTicketCount.ToString();

            //Pie Chart 1 palette color
            S1.Palette = ChartColorPalette.Pastel;
    
            //Display Values as Name = false; Values as numbers = true
            S1.IsValueShownAsLabel = false;
            S2.IsValueShownAsLabel = false;

            //Pie Chart Label Fonts
            S1.Font = new Font("Segoe UI", 15, FontStyle.Bold);
            S2.Font = new Font("Segoe UI", 15, FontStyle.Bold);
            S1.LabelForeColor = Color.DarkSlateGray;
            S2.LabelForeColor = Color.DarkSlateGray;
            S1.BorderColor = Color.DarkSlateGray;
            S2.BorderColor = Color.DarkSlateGray;

            //Call the ToolTip
            chart1.GetToolTipText += new EventHandler<ToolTipEventArgs>(chart1_GetToolTipText);
        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            //Open Users Form
            frmLogin login = new frmLogin();//assigning frmUsers function that was created when the User
            //interface form was created automatically and assigned it the name'users'
            login.Show(); //users is now the opening the form when called upon, used by the WindowsForm 
            // function called Show() 
            Hide();
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open Users Form
            frmUsers users = new frmUsers(); //assigning frmUsers function that was created when the User
            //interface form was created automatically and assigned it the name'users'
            users.Show(); //users is now the opening the form when called upon, used by the WindowsForm 
            // function called Show() 
            Hide();
        }

        private void ticketsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Open Create Ticket Form
            frmRequesters ticket = new frmRequesters();
            ticket.Show();

            Hide();
        }

        private void frmHome_Activated(object sender, EventArgs e)
        {
            ChartLoad();
            DataTable dt = dal.Select();
            dvgUsers.DataSource = dt;
            dvgUsers.Sort(dvgUsers.Columns[10], ListSortDirection.Descending);

            dvgUsers.Columns[0].HeaderText = "Ticket ID";
            dvgUsers.Columns[1].HeaderText = "First Name";
            dvgUsers.Columns[2].HeaderText = "Last Name";
            dvgUsers.Columns[3].HeaderText = "Email";
            dvgUsers.Columns[4].HeaderText = "Ticket Creator Name";
            dvgUsers.Columns[5].HeaderText = "Phone Number";
            dvgUsers.Columns[6].HeaderText = "Location";
            dvgUsers.Columns[7].HeaderText = "Issue Category";
            dvgUsers.Columns[8].HeaderText = "Priority Level";
            dvgUsers.Columns[9].HeaderText = "Issue Description";
            dvgUsers.Columns[10].HeaderText = "Date Created";
            dvgUsers.Columns[11].HeaderText = "Date Completed";
            dvgUsers.Columns[12].HeaderText = "Cost";
            dvgUsers.Columns[13].HeaderText = "Picture File Path Name";
            
            dt = dal.LoadUserNameTickets(lblUser.Text);
            dvgUsers.DataSource = dt;
        }

        //Create method to move the windows around on screen with drag function
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
            int Msg, int wParam, int lParam);
        [DllImportAttribute("user32.dll")]
        //To access anywhere on the form
        public static extern bool ReleaseCapture();
        private void frmHome_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        //To access only on the menu strip
        private void menuStripTop_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private string security_levelValue;
        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataTable dt = frmUsers.SelectCurrentUser("security_level");
            foreach (DataRow row in dt.Rows)
                 security_levelValue = row[0].ToString().ToUpper();

            if (security_levelValue == "ADMIN")
                isAdmin = true;
            else
                isAdmin = false;

            if (isAdmin == true)
            {
                //Open Create Ticket Form
                frmAdmin admin = new frmAdmin();
                admin.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("You have insufficient rights to access Admin");
            }
        }
    }
}
