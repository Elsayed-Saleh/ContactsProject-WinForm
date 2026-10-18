using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactDataAccessLayer
{
    public class clsDataAccessLayer
    {

        public static bool GetContactInfoByID(int ID, ref string FirstName, ref string LastName, ref string Email, ref string Phone
            , ref string Address, ref DateTime DateOfBirth, ref string ImagePath, ref int ConturyID)
        {
            bool result = false;
            SqlConnection connection=new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = "select * from Contacts where ContactID=@ContactID;";

            SqlCommand command= new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@ContactID", ID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if(reader.Read())
                {
                    result = true;
                    FirstName = (string)reader["FirstName"];
                    LastName = (string)reader["LastName"];
                    Email = (string)reader["Email"];
                    Phone = (string)reader["Phone"];
                    Address = (string)reader["Address"];
                    DateOfBirth = (DateTime)reader["DateOfBirth"];
                   
                    if (reader["ImagePath"]!=DBNull.Value)
                    {

                        ImagePath = (string)reader["ImagePath"];
                    }
                    else
                    {
                        ImagePath = "";
                    }
                }
                else
                {
                    result = false;
                }

                reader.Close();
            }
            catch
            {
                result=false;
            }
            finally
            {
                connection.Close();
            }
               
            return result;


        }

        public  static int AddNewContact(string FirstName, string LastName, string Email, string Phone, string Address, 
            DateTime DateOfBirth, int CountryID, string ImagePath)
            
        {
            int ContactID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query= (@"INSERT INTO Contacts (FirstName, LastName, Email, Phone, Address, 
                           DateOfBirth, CountryID, ImagePath) VALUES (@FirstName, @LastName, @Email
                           ,@Phone, @Address, @DateOfBirth,@CountryID, @ImagePath);
                            select scope_identity();");

            SqlCommand command =new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@CountryID", CountryID);
            command.Parameters.AddWithValue("@ImagePath", ImagePath);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int InsertedID))
                {
                    ContactID = InsertedID;
                }


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                
            }
            finally
            {
                
                connection.Close();

            }
            return ContactID; 

        }

        public static bool UpdateContact(int ContactID, string FirstName, string LastName, string Email,
         string Phone, string Address, DateTime DateOfBirth, string ImagePath, int CountryID)
        {
            int RowsAfeected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);
            string query = (@"UPDATE Contacts 
                        SET FirstName = @FirstName,
                            LastName =@LastName,
                            Email = @Email,
                            Phone =@Phone,
                            Address =@Address,
                            DateOfBirth = @DateOfBirth,
                            CountryID = @CountryID,
                            ImagePath = @ImagePath 
                            WHERE ContactID=@ContactID;");
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("ContactID", ContactID);
            command.Parameters.AddWithValue("@FirstName", FirstName);
            command.Parameters.AddWithValue("@LastName", LastName);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Phone", Phone);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            command.Parameters.AddWithValue("@CountryID", CountryID);
            if (ImagePath != null)
            {
                command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            else
            {
                command.Parameters.AddWithValue("@ImagePath", System.DBNull.Value);
            }

            try
            {
                connection.Open();
                RowsAfeected = command.ExecuteNonQuery();


            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }
            return (RowsAfeected > 0);

        }

        public static DataTable GetAllContacts()
        {
            DataTable dataTable = new DataTable();

            SqlConnection connection = new SqlConnection(clsDataAccessSetting.ConnectionString);

            string query = "SELECT * from Contacts;";
            
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dataTable.Load(reader);

                }

                reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }


            return dataTable;
        }
    }
}
