using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access
{
    public static class clsInstructorData  
    { 
        public static bool GetInstructorInfo(int instructorID, ref int personID, ref int depID, ref decimal salary)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Instructor WHERE InstructorID = @instructorID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@instructorID", instructorID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                personID = (int)reader["PersonID"];
                                depID = (int)reader["DepID"];
                                salary = (decimal)reader["Salary"];

                                isFound = true;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        isFound = false;
                        Console.WriteLine(ex.ToString());
                    }
                }
            }

            return isFound;
        }

        public static int AddNewInstructor(int personID, int depID, decimal salary)
        {
            int newID = -1;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO Instructor 
                                    VALUES(@personID,@depID,@salary);
                                SELECT SCOPE_IDENTITY()";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@personID", personID);
                    command.Parameters.AddWithValue("@depID", depID);
                    command.Parameters.AddWithValue("@salary", salary);

                    try 
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if (result != null && int.TryParse(result.ToString(), out int id))
                        {
                            newID = id;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }

            return newID;
        }

        public static bool UpdateInstructor(int instructorID, int depID, decimal salary) 
        {
            int affectedRows = 0;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE Instructor 
                                    SET DepID = @depID,
                                        Salary = @salary 
                                WHERE InstructorID = @instructorID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@depID", depID);
                    command.Parameters.AddWithValue("@salary", salary);
                    command.Parameters.AddWithValue("@instructorID", instructorID);

                    try
                    {
                        connection.Open();
                        affectedRows = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }

            return affectedRows > 0;
        }

        public static bool DeleteInstructor(int instructorID)  
        {
            int affectedRows = 0;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM Instructor WHERE InstructorID = @instructorID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@instructorID", instructorID);

                    try
                    {
                        connection.Open();
                        affectedRows = command.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }

            return affectedRows > 0;
        }

        public static DataTable GetAllInstructors() 
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Instructor_View";  

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                dataTable.Load(reader);
                            }
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


    }
}
