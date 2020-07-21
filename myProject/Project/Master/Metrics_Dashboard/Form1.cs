using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL;
using DAL.Classes;

namespace Metrics_Dashboard
{
    public partial class Form1 : Form
    {
        public Form1( )
        {
            InitializeComponent( );
        }

        private void btnClient_Save_Click( object sender, EventArgs e )
        {
            var bl = new Dashboard_BL( );
            bl.CreateClient( txtClientFirstName.Text, txtClientLastName.Text, txtClientEmail.Text, txtClientPassword.Text );

            MessageBox.Show( "New Client Created Successfully" );
        }

        private void btnClient_Update_Click( object sender, EventArgs e )
        {
            // Call the Client's ID
            var clientId = Convert.ToInt32( cboClientNameList.SelectedValue.ToString( ) );

            // Load Class and Properties for New Updates
            var client = new Client( );
            client.FirstName = txtClientFirstName.Text;
            client.LastName = txtClientLastName.Text;
            client.Email = txtClientEmail.Text;

            // Push New Updates to BL
            var bl = new Dashboard_BL( );
            bl.UpdateClient( clientId, client );
            MessageBox.Show( "Client Info Updated Successfully" );
        }

        private void btnClient_Delete_Click( object sender, EventArgs e )
        {
            // Call the Client's ID
            var clientId = Convert.ToInt32( cboClientNameList.SelectedValue.ToString( ) );
            var client = new Client( );

            // Push Delete of Client to BL
            var bl = new Dashboard_BL( );
            bl.DeleteClient( clientId );
            MessageBox.Show( "Client Info Deleted Successfully" );            
        }
    }
}
