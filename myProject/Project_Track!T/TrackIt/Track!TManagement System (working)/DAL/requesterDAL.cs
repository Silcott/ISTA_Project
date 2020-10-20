using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TrackITManagementSystem.BLL;

namespace TrackITManagementSystem.DAL
{
    class requesterDAL
    {
        //Create a Connection String to connect database
        private static string myconnstring = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
        #region SELECT to display data in DataGridView from database

        public DataTable Select()
        {
            //Create object of DataTable to hold the data from the database and return it
            DataTable dt = new DataTable();

            //Create object of SQL Connection to Connect Database
            SqlConnection conn = new SqlConnection(myconnstring);
            
            try
            {
                //Write SQL Query to Select the data from the database
                string sql = "SELECT * FROM tbl_requesters";

                //Create the SQLCommand to Execute the Query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Create SQL Data Adapter to hold the data temporarily
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //Open Database Connection
                conn.Open();

                //Pass int he data from the adapter to the DataTable
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                //Display error message if any exceptional errors
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //Close Database Connection
                conn.Close();
            }
            return dt;

        }
        #endregion
        #region INSERT data to database

        public bool Insert(requestersBLL r)
        {
            //Create a boolean variable and set its default value to false
            bool isSuccess = false;

            //Create SQL Connection to connect database
            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                //Write the Query to INSERT data into the database
                string sql =
                    "INSERT INTO tbl_requesters (" +
                    "first_name, " +
                    "last_name, email, " +
                    "ticket_creator_name, " +
                    "phone, location, " +
                    "issue_category, " +
                    "priority_level, " +
                    "issue_description, " +
                    "added_date, " +
                    "completed_date, " +
                    "cost, " +
                    "file_name_path) " +
                    "VALUES (" +
                    "@first_name, " +
                    "@last_name, " +
                    "@email, " +
                    "@ticket_creator_name, " +
                    "@phone, " +
                    "@location, " +
                    "@issue_category, " +
                    "@priority_level, " +
                    "@issue_description, " +
                    "@added_date, " +
                    "@completed_date, " +
                    "@cost, " +
                    "@file_name_path)";

                //Create SQL Command to Execute teh Query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Pass the value to the SQL Query
                cmd.Parameters.AddWithValue("@first_name", r.first_name);
                cmd.Parameters.AddWithValue("@last_name", r.last_name);
                cmd.Parameters.AddWithValue("@email", r.email);
                cmd.Parameters.AddWithValue("@ticket_creator_name", r.ticket_creator_name);
                cmd.Parameters.AddWithValue("@phone", r.phone);
                cmd.Parameters.AddWithValue("@location", r.location);
                cmd.Parameters.AddWithValue("@issue_category", r.issue_category);
                cmd.Parameters.AddWithValue("@priority_level", r.priority_level);
                cmd.Parameters.AddWithValue("@issue_description", r.issue_description);
                cmd.Parameters.AddWithValue("@added_date", r.added_date);
                cmd.Parameters.AddWithValue("@completed_date", r.completed_date);
                cmd.Parameters.AddWithValue("@cost", r.cost);
                cmd.Parameters.AddWithValue("@file_name_path", r.file_name_path);

                //Open Database Connection
                conn.Open();

                //Create an Integer Variable to check whether the query was executed successfully or not
                int rows = cmd.ExecuteNonQuery();

                //If Query is Executed Successfully the value of rows will be greater tha Zero else it will be Zero'
                if (rows>0)
                {
                    //Query Executed Successfully
                    isSuccess = true;
                }
                else
                {
                    //Failed to Execute Query
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                //Display error message if any exceptional errors
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //Close Database Connection 
                conn.Close();
            }

            return isSuccess;
        }

        #endregion
        #region UPDATE requesters in database

        public bool Update(requestersBLL r)
        {
            //Create a boolean variable and set its default value to false
            bool isSuccess = false;
            //Create SQLCOnnection to Connect Database
            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                //Create a SQL Query to Update Requesters
                string sql =
                    "UPDATE tbl_requesters SET " +
                    "first_name=@first_name, " +
                    "last_name=@last_name, " +
                    "email=@email, " +
                    "ticket_creator_name=@ticket_creator_name, " +
                    "phone=@phone, " +
                    "location=@location, " +
                    "issue_category=@issue_category, " +
                    "priority_level=@priority_level, " +
                    "issue_description=@issue_description, " +
                    "completed_date=@completed_date, " +
                    "cost=@cost, " +
                    "file_name_path=@file_name_path " +
                    "by WHERE ticket_id=@ticket_id";

                //Create SQL Command 
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Pass the value to the SQL Query
                cmd.Parameters.AddWithValue("@first_name", r.first_name);
                cmd.Parameters.AddWithValue("@last_name", r.last_name);
                cmd.Parameters.AddWithValue("@email", r.email);
                cmd.Parameters.AddWithValue("@ticket_creator_name", r.ticket_creator_name);
                cmd.Parameters.AddWithValue("@phone", r.phone);
                cmd.Parameters.AddWithValue("@location", r.location);
                cmd.Parameters.AddWithValue("@issue_category", r.issue_category);
                cmd.Parameters.AddWithValue("@priority_level", r.priority_level);
                cmd.Parameters.AddWithValue("@issue_description", r.issue_description);
                cmd.Parameters.AddWithValue("@completed_date", r.completed_date);
                cmd.Parameters.AddWithValue("@cost", r.cost);
                cmd.Parameters.AddWithValue("@file_name_path", r.file_name_path);
                cmd.Parameters.AddWithValue("@ticket_id", r.ticket_id);

                //Open Database COnnection
                conn.Open();

                //Create an Integer Variable to check if the query executed successfully
                int rows = cmd.ExecuteNonQuery();

                //If the query executed successfully than the value will be greater than 0 else it will be 0
                if (rows>0)
                {
                    isSuccess = true;
                }
                else
                {
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                //Display if any exceptional errors
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //CLose Database Connection
                conn.Close();
            }

            return isSuccess;
        }
        #endregion
        #region DELETE requesters from database

        public bool Delete(requestersBLL r)
        {
            //Create a boolean variable and set its default value to false
            bool isSuccess = false;

            //Create SQLConnection to Connect Database
            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                //Write the query to delete requestors from database
                string sql = "DELETE FROM tbl_requesters WHERE ticket_id=@ticket_id";

                //Create SQL Command
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Pass the value to Sql Query using Parameter
                cmd.Parameters.AddWithValue("@ticket_id", r.ticket_id);

                //Open Database Connection
                conn.Open();

                //Create an Integer Variable to check if the query executed successfully or not
                int rows = cmd.ExecuteNonQuery();

                //If Query Executed successfully than the value of rows will be greater than 0 else it wil be 0
                if (rows>0)
                {
                    //Query Executed Successfully
                    isSuccess = true;
                }
                else
                {
                    //Failed to execute the Query
                    isSuccess = false;
                }
            }
            catch (Exception ex)
            {
                //Display the exceptional error message
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //CLose the database connection
                conn.Close();
            }

            return isSuccess;
        }
#endregion
    }
}
