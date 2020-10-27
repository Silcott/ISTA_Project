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
                    "last_name, " +
                    "email, " +
                    "ticket_creator_name, " +
                    "phone, " +
                    "location, " +
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
                    "WHERE ticket_id=@ticket_id";

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
        #region Count Tickets by Issue Category & Priority

        public string countTickets(string columnName, string fields)
        {
            //Create SQL Connection for database cooncetion
            SqlConnection conn = new SqlConnection(myconnstring);

            //Create a astring variable for ticket count and set its default value to 0
            string tickets = "0";

            try
            {
                //SQL Query to count tickets foir specific issue category
                string sql = $"SELECT * FROM tbl_requesters WHERE {columnName} ='"+ fields +"'";

                //SQL Command to Execute
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Sql Data Adapter to get teh  data from database
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //Datatable to hold the data temporarily
                DataTable dt = new DataTable();

                //Pass the value from SqlDataAdapter to DataTable
                adapter.Fill(dt);

                //Get the total numbers of tickets based on issue category
                tickets = dt.Rows.Count.ToString();
            }
            catch (Exception ex)
            {
                //Display any exceptional errors
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //CLose Database Connection
                conn.Close();
            }

            return tickets;
        }

        #endregion
        #region Load Username Ticket on Home Screen

        public DataTable LoadUserNameTickets(string fields)
        {
            //Create SQL Connection for database cooncetion
            SqlConnection conn = new SqlConnection(myconnstring);
         
            //Create object of DataTable to hold the data from the database and return it
            DataTable dt = new DataTable();
            try
            {
                //SQL Query to count tickets foir specific issue category
                string sql = "SELECT ticket_id, first_name, last_name, email, phone, location, issue_category, priority_level, added_date, cost FROM tbl_requesters WHERE ticket_creator_name = '"+ fields +"'";

                //SQL Command to Execute
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Sql Data Adapter to get teh  data from database
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //Pass the value from SqlDataAdapter to DataTable
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                //Display any exceptional errors
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //CLose Database Connection
                conn.Close();
            }
            return dt;
        }
        #endregion
        #region Method to Search Tickets
        public DataTable Search(string keywords)
        {
            //SQL Connection to Connect Database
            SqlConnection conn = new SqlConnection(myconnstring);

            //Create DataTable to hold the data temporarily
            DataTable dt = new DataTable();

            try
            {
                //Code to search tickets based on keywords typed in textbox
                //SQL Query to Search Tickets
                string sql = "SELECT * FROM tbl_requesters WHERE ticket_id LIKE '%" + keywords +
                             "%' OR first_name LIKE '%" + keywords +
                             "%' OR last_name LIKE '%" + keywords +
                             "%' OR email LIKE '%" + keywords +
                             "%' OR ticket_creator_name LIKE '%" + keywords +
                             "%' OR phone LIKE '%" + keywords +
                             "%' OR location LIKE '%" + keywords +
                             "%' OR issue_category LIKE '%" + keywords +
                             "%' OR added_date LIKE '%" + keywords +
                             "%' OR completed_date LIKE '%" + keywords +
                             "%' OR cost LIKE '%" + keywords +
                             "%' OR file_name_path LIKE '%" + keywords + "' ";

                //SQL Command to execute the query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //SQLDataAdapter to save the data from database
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //Open Database Connection
                conn.Open();

                //Transfer the data from sql data adapter to datatable
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {
                //Display exceptional errors
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //CLose the Database Connection
                conn.Close();
            }

            return dt;
        }

        #endregion
    }
}
