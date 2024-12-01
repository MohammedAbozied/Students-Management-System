using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access
{
    public class clsPersonData
    {
        public static int AddNewPerson(string Fname, string Lname, byte gender,string phone,string address,
            DateTime DOB,string image_path,string email,string national_no)
        {
            int newID = -1;
            using(SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO Person
                                VALUES (@Fname,
                                        @Lname,
                                        @gender,
                                        @phone,
                                        @address,
                                        @DOB,
                                        @image_path,
                                        @email,
                                        @national_no);
                                SELECT SCOPE_IDENTITY();";

                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Fname", Fname);
                    command.Parameters.AddWithValue("@Lname", Lname);
                    command.Parameters.AddWithValue("@gender", gender);
                    command.Parameters.AddWithValue("@phone", phone);
                    command.Parameters.AddWithValue("@address", address);
                    command.Parameters.AddWithValue("@DOB", DOB);
                    command.Parameters.AddWithValue("@image_path", string.IsNullOrEmpty(image_path) ? (object)DBNull.Value : image_path);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@national_no", national_no);

                    try
                    {
                        connection.Open();
                        object result= command.ExecuteScalar(); // return newID
                        if(result != null && int.TryParse(result.ToString(),out int ID))
                        {
                            newID = ID;
                        }
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }

            return newID;
        }

        public static bool UpdatePerson(int personID, string Fname, string Lname,
            byte gender, string phone, string address, DateTime DOB,
            string image_path, string email, string national_no)
        {
            int affectedRows = 0;
            using(SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE Person 
                            SET Fname = @Fname,
                                Lname = @Lname,
                                Gender = @gender,
                                Phone = @phone,
                                Address = @address,
                                DOB = @DOB,
                                Image_Path = @image_path,
                                Email = @email,
                                National_No = @national_no
                            WHERE PersonID = @personID";

                using(SqlCommand command = new SqlCommand (query, connection))
                {
                    command.Parameters.AddWithValue("@personID", personID);
                    command.Parameters.AddWithValue("@Fname", Fname);
                    command.Parameters.AddWithValue("@Lname", Lname);
                    command.Parameters.AddWithValue("@gender", gender);
                    command.Parameters.AddWithValue("@phone", phone);
                    command.Parameters.AddWithValue("@address", address);
                    command.Parameters.AddWithValue("@DOB", DOB);
                    command.Parameters.AddWithValue("@image_path", string.IsNullOrEmpty(image_path) ? (object)DBNull.Value : image_path);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@national_no", national_no);

                    try
                    {
                        connection.Open();
                        affectedRows = command.ExecuteNonQuery();
                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        affectedRows = 0;
                    }
                }
            }

            return affectedRows>0;
        }

        public static bool GetPersonInfo(int personID,ref string Fname,ref string Lname,
            ref byte gender, ref string phone, ref string address, ref DateTime DOB,
            ref string image_path, ref string email, ref string national_no)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Person WHERE PersonID = @personID";
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@personID",personID);

                    try
                    {
                        connection.Open();
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.Read())
                            {
                                Fname = (string)reader["Fname"];
                                Lname = (string)reader["Lname"];
                                gender = (byte)reader["Gender"];
                                phone = (string)reader["Phone"];
                                address = (string)reader["Address"];
                                DOB = (DateTime)reader["DOB"];
                                // image path is nullable
                                image_path = reader["Image_Path"] as string ?? string.Empty; // as : returns null if failed in casting 
                                email = (string)reader["Email"];
                                national_no = (string)reader["National_No"];

                                isFound = true;
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        isFound = false;
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
            return isFound;
        }
        public static DataTable GetAllPeople()
        {
            DataTable dataTable = new DataTable();
            using(SqlConnection connection = new SqlConnection( DataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Person";
                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                                dataTable.Load(reader);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }
            return dataTable;
        }

        public static bool DeletePerson(int personID)
        {
            int affectedRows = 0; 
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM Person WHERE PersonID = @personID";
                using(SqlCommand command = new SqlCommand(query,connection))
                {
                    command.Parameters.AddWithValue("@personID",personID);
                    try
                    {
                        connection.Open();
                        affectedRows = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                        affectedRows = 0;
                    }
                }
            }

            return affectedRows > 0;
        }


    }
}
