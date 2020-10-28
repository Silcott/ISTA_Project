using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TrackITManagementSystem.BLL;

namespace TrackITManagementSystem.DAL
{
    class userDAL
    {
        //Create a Static String to Connect Database 
        static string myconnstring = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
        #region SELECT data from database (User Module)
        //what ever is written is shown when collapsed
        // the above region allows the developer to collapse/uncollapse everything
        // within it, as long as their IDE supports regions
        public DataTable Select() //create a Select method 
        {
            //Create an Object to connect database
            SqlConnection conn = new SqlConnection(myconnstring);
            
            //create a DataTable to hold the Data from Database
            DataTable dt = new DataTable();

            try//A try block identifies a block of code for which particular exceptions is activated. It is followed by one or more catch blocks.
            {
                //Write SQL Query to Get Data from Database
                String sql = "SELECT * FROM tbl_users";

                //Create SQL Command to Execute Query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Create Sql Data Adapter to hold the data from database temporarily
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //Open Database Connection
                conn.Open();

                //Transfer Data from SqlData Adapter to DataTable
                adapter.Fill(dt);
            }
            catch(Exception ex)//A program catches an exception with an exception handler at the place in a program where you want to handle the 
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
        #region Find Users with same Username

        private static bool isUsernameFound;
        public bool FindUsername(string columnName, string usernameToCompare)
        {
            //Create SQL Connection for database cooncetion
            SqlConnection conn = new SqlConnection(myconnstring);

            //Create a int variable to count username and set its default value to 0
            int numberOfUsers = 0; 
            
            try
            {
                //SQL Query to count tickets foir specific issue category
                string sql = $"SELECT username FROM tbl_users WHERE {columnName} ='" + usernameToCompare + "'";

                //SQL Command to Execute
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Sql Data Adapter to get teh  data from database
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //Datatable to hold the data temporarily
                DataTable dt = new DataTable();

                //Pass the value from SqlDataAdapter to DataTable
                adapter.Fill(dt);

                //Get the total numbers of tickets based on issue category
                numberOfUsers = dt.Rows.Count;

                //Check if the dt has a row, if it equals ONE it has a row and shows a username having the same name, return true 
                if (numberOfUsers == 1)
                {
                    isUsernameFound = true;
                }
                else
                {
                    isUsernameFound = false;
                }
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
            if (isUsernameFound == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #endregion
        #region INSERT data into Database for (User Module)
        public bool Insert(userBLL u)
        {
            //Create a boolean variable and set its default value to false
            bool isSuccess = false;

            //Create an Object of SqlConnection to connect Database
            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                //Create a String Variable to Store the INSERT Query
                String sql = "INSERT INTO tbl_users(username, email, password, full_name, phone, address, added_date, security_level, image_name) " +
                    "VALUES " +
                    "(@username, @email, @password, @full_name, @phone, @address, @added_date, @security_level, @image_name)";

                //Create a SQL Command to pass the value in our Query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Create the Parameter to pass get the value from UI and pass it on SQL Query above
                cmd.Parameters.AddWithValue("@username", u.username);
                cmd.Parameters.AddWithValue("@email", u.email);
                cmd.Parameters.AddWithValue("@password", HashPassword.CalculateSHA256(u.password));
                cmd.Parameters.AddWithValue("@full_name", u.full_name);
                cmd.Parameters.AddWithValue("@phone", u.phone);
                cmd.Parameters.AddWithValue("@address", u.address);
                cmd.Parameters.AddWithValue("@added_date", u.added_date);
                cmd.Parameters.AddWithValue("@image_name", u.image_name);
                cmd.Parameters.AddWithValue("@security_level", u.security_level);

                //Open Database Connection
                conn.Open();

                //Create an Integer Variable to hold the value after the query is executed
                int rows = cmd.ExecuteNonQuery();

                //The value of rows will be greater than 0 if the query is executed successfully
                //Else it will be 0

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

                //Display Error Message if there's any exceptional errors
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
        #region UPDATE Data in database (User Module)
        public bool Update(userBLL u)
        {
            //Create a Boolean variable and set its defualt value to false
            bool isSuccess = false;

            //Create an Object for database connection
            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                //Create a string variable to hold the sql query
                string sql = "UPDATE tbl_users SET username=@username, email=@email, password=@password, full_name=@full_name, phone=@phone, " +
                    "address=@address, added_date=@added_date, security_level=@security_level, image_name=@image_name WHERE user_id=@user_id";

                //Create Sql Command to execute query and pass the values to sql query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Now pass the values to SQL Query
                cmd.Parameters.AddWithValue("@username", u.username);
                cmd.Parameters.AddWithValue("@email", u.email);
                cmd.Parameters.AddWithValue("@password", u.password);
                cmd.Parameters.AddWithValue("@full_name", u.full_name);
                cmd.Parameters.AddWithValue("@phone", u.phone);
                cmd.Parameters.AddWithValue("@address", u.address);
                cmd.Parameters.AddWithValue("@added_date", u.added_date);
                cmd.Parameters.AddWithValue("@image_name", u.image_name);
                cmd.Parameters.AddWithValue("@user_id", u.user_id);
                cmd.Parameters.AddWithValue("@security_level", u.security_level);
                
                //Open Database Connection
                conn.Open();

                //Create an integer varibale to hold the value after teh query is executed
                int rows = cmd.ExecuteNonQuery();

                //If the query is executed successfully then the value of the rows will be greater than 0
                //else it'll be 0

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
                //Display error message if there is an exceptionaly error
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
        #region DELETE Data from Database (User Module)
        public bool Delete(userBLL u)
        {
            //Create a boolean varibale and set its default value to false
            bool isSuccess = false;

            //Create an Object for SqlConnection
            SqlConnection conn = new SqlConnection(myconnstring);

            try
            {
                //Create a string variable to hold the sql query to delete data
                String sql = "Delete FROM tbl_users WHERE user_id=@user_id";

                //Create Sql Command to Execute the Query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Pass the value through parameters
                cmd.Parameters.AddWithValue("@user_id", u.user_id);

                //Open the database Connection
                conn.Open();

                //Create an integer variable to hold the value after query is executed
                int rows = cmd.ExecuteNonQuery();

                //If the query is executed Successfully then the value of rows will be greater than 0
                //Else it'll be 0

                if (rows>0)
                {
                    //Query executed Susscessfully
                    isSuccess = true;
                }
                else
                {
                    //Failecd to Execute Query
                    isSuccess = false;
                }

            }
            catch (Exception ex)
            {
                //Display Error Message if there's any Exceptional Errors
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
        #region SEARCH
        public DataTable Search(string keywords)
        {
            //1. Create an SQL Connection to connect database
            SqlConnection conn = new SqlConnection(myconnstring);

            //2. Create Data Table to hold the data from the database temporarily
            DataTable dt = new DataTable();

            //Write code to search users
            try
            {
                //Write the SQL Query to serach the user from Database
                String sql = "SELECT * FROM tbl_users WHERE user_id LIKE '%" + keywords + "%' OR full_name LIKE '%" + keywords + "%' OR address LIKE '%" + keywords + "%' OR username LIKE '%" + keywords + "%'";

                //Create SQL Command to Execute the Query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Create SQL Data Adapter to gett he data from database
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                //Open Database Connection
                conn.Open();
                //Pass the data from adapter to datatable
                adapter.Fill(dt);
            }
            catch (Exception ex)
            {

                //Display Error Message if any exceptional errors
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //Close the Database Connect
                conn.Close();
            }
            return dt;
        }
        #endregion
        #region Get Creator Name from Username
        public string field;
        public string GetCreatorNameFromUser(string username)
        {
            userBLL u = new userBLL();

            //Create SQL Connection to connect database
            SqlConnection conn = new SqlConnection(myconnstring);

            //DataTable to hold the data from database temporarily
            DataTable dt = new DataTable();

            try
            {
                //SQL Query to get the id from username
                string sql = "SELECT full_name FROM tbl_users WHERE username='" + username + "'";

                //Create SQL Data Adapter
                SqlDataAdapter adapter =new SqlDataAdapter(sql, conn);

                //Open Database Connection
                conn.Open();

                //Fill the data in the dataatbale from Adapter
                adapter.Fill(dt);

                //If there's user based on the username then get the full_name
                if (dt.Rows.Count>0)
                {
                    field = dt.Rows[0].Field<string>(0);
                }
            }
            catch (Exception ex)
            {
                //Display exceptional error
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //Close Database Connection
                conn.Close();
            }
            return field;
        }
        #endregion
        #region Get User ID from Username

        public userBLL GetUserIdFromCreatorTicketId(string creatorTicketId)
        {
            userBLL u = new userBLL();

            //Create SQL Connection to connect database
            SqlConnection conn = new SqlConnection(myconnstring);

            //DataTable to hold the data from database temporarily
            DataTable dt = new DataTable();

            try
            {
                //SQL Query to get the id from username
                string sql = "SELECT user_id FROM tbl_users WHERE ticket_creator_userId='" + creatorTicketId + "'";

                //Create SQL Data Adapter
                SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);

                //Open Database Connection
                conn.Open();

                //Fill the data in the dataatbale from Adapter
                adapter.Fill(dt);

                //If there's user based on the username then get the full_name
                if (dt.Rows.Count > 0)
                {
                    u.full_name = dt.Rows[0]["full_name"].ToString();
                }
            }
            catch (Exception ex)
            {
                //Display exceptional errord
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //Close Database Connection
                conn.Close();
            }
            return u;
        }
        #endregion
    }
}
