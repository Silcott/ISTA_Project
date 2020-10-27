using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TrackITManagementSystem.BLL;


namespace TrackITManagementSystem.DAL
{
    class loginDAL
    {
        //Create static string to connect to database
        private static string myconnstring = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        public bool loginCheck(loginBLL l)
        {
            //Create boolean variable and set its default value to false
            bool isSuccess = false;

            //Connecting Database
            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                //SQL Query to check login based on username and password
                string sql = "SELECT * FROM tbl_users WHERE username=@username and password=@password";

                //Create SQL Command to pass the value to SQL Query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Pass the value to SQL Query using Parameters
                cmd.Parameters.AddWithValue("@username", l.username);
                cmd.Parameters.AddWithValue("@password", l.password);
               
                //SQL Data Adapter to get the data from database
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //DataTable to hold the data from the database temporarily
                DataTable dt = new DataTable();

                //Fill the data from the adapter to dt
                adapter.Fill(dt);

                //Check if user exists or not
                if (dt.Rows.Count>0)
                {
                    //User Exists and Login Successful
                    isSuccess = true;
                }
                else
                {
                    //Login Failed
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                //Display exception errors
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //Close the database
                conn.Close();
            }

            return isSuccess;
        }

    }
}
