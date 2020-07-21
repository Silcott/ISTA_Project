using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackITManagementSystem.BLL;

namespace TrackITManagementSystem.DAL
{
    class userDAL
    {
        //Create a Static String to Connect Database 
        static string myconnstring = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;
        //this will add our database to config manager

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
                String sql = "INSERT INTO tbl_users(username, email, password, full_name, phone, address, added_date, image_name) " +
                    "VALUES " +
                    "(@username, @email, @password, @full_name, @phone, @address, @added_date, @image_name)";

                //Create a SQL Command to pass the value in our Query
                SqlCommand cmd = new SqlCommand(sql, conn);

                //Create the Parameter to pass get the value from UI and pass it on SQL Query above
                cmd.Parameters.AddWithValue("@username", u.username);
                cmd.Parameters.AddWithValue("@email", u.email);
                cmd.Parameters.AddWithValue("@password", u.password);
                cmd.Parameters.AddWithValue("@full_name", u.full_name);
                cmd.Parameters.AddWithValue("@phone", u.phone);
                cmd.Parameters.AddWithValue("@address", u.address);
                cmd.Parameters.AddWithValue("@added_date", u.added_date);
                cmd.Parameters.AddWithValue("@image_name", u.image_name);

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
                    "address=@address, added_date=@added_date, image_name=@image_name WHERE user_id=@user_id";

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
                //Create a string variable to hold the sql query to delet data
                String sql = "Delete FROM tbl_users WHERE user_id=user_id";

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
    }
}
