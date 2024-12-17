using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access
{
    public static class clsUser
    {
        public static bool GetUserInfo(int stu_id, ref int personID, ref byte academicYear, ref int depID)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Student WHERE Stu_ID = @stu_id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@stu_id", stu_id);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                personID = (int)reader["PersonID"];
                                academicYear = (byte)reader["AcademicYear"];
                                depID = (int)reader["DepID"];

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

        public static int AddNewStudent(int personID, byte academicYear, int departmentID)
        {
            int newID = -1;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO Student 
                                    VALUES(@personID,@academicYear,@departmentID);
                                SELECT SCOPE_IDENTITY()";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@personID", personID);
                    command.Parameters.AddWithValue("@academicYear", academicYear);
                    command.Parameters.AddWithValue("@departmentID", departmentID);

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

        public static bool UpdateStudent(int studentID, byte academicYear, int departmentID)
        {
            int affectedRows = 0;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE Student 
                                    SET AcademicYear = @academicYear,
                                        DepID = @departmentID 
                                WHERE Stu_ID = @studentID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@studentID", studentID);
                    command.Parameters.AddWithValue("@academicYear", academicYear);
                    command.Parameters.AddWithValue("@departmentID", departmentID);

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

        public static bool DeleteStudent(int studentID)
        {
            int affectedRows = 0;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM Student WHERE Stu_ID = @studentID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@studentID", studentID);

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

        


    }
}
