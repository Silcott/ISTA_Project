using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace TrackITManagementSystem.UI
{
    public partial class frmSplash : Form
    {
        public frmSplash()
        {
            InitializeComponent();
        }

        private int _move;
        private void timerSplash_Tick(object sender, EventArgs e)
        {
            //Code to show Loading Animation
            timerSplash.Interval = 10;
            panelMoveable.Width += 5;

            _move += 5;//pixels

            //If the loading is complete then display the login form
            if (_move == 1040)
            {
                //Stop timer and close form
                timerSplash.Stop();
                Hide();

                //Display the login form
                frmLogin login = new frmLogin();
                login.Show();
            }
        }
        private void frmSplash_Load(object sender, EventArgs e)
        {
            //Load the timer
            timerSplash.Start();
        }
        #region METHOD to move form around screen
        //Create method to move the windows around on screen with drag function
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd,
            int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        private void frmSplash_MouseDown(object sender, MouseEventArgs e)
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
