using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access
{
    public static class clsCourseData
    {
        public static bool GetCourseInfo(int course_id, ref string courseName,ref string code ,ref byte hours, ref int depID,ref int instructorID)
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Course WHERE CourseID = @course_id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@course_id", course_id);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                courseName = (string)reader["CourseName"];
                                code = (string)reader["Code"];
                                hours = (byte)reader["Hours"];
                                depID = (int)reader["DepID"];
                                instructorID = (int)reader["InstructorID"];

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


        public static int AddNewCourse(string courseName, string code, byte hours, int depID, int instructorID)
        {
            int newID = -1;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO Course 
                                    VALUES(@courseName,@code,@hours,@depID,@instructorID);
                                SELECT SCOPE_IDENTITY()";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@courseName", courseName);
                    command.Parameters.AddWithValue("@code", code);
                    command.Parameters.AddWithValue("@hours", hours);
                    command.Parameters.AddWithValue("@depID", depID);
                    command.Parameters.AddWithValue("@instructorID", instructorID);

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

        public static bool UpdateCourse(int courseID, string courseName, string code, byte hours, int depID, int instructorID)
        {
            int affectedRows = 0;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE Course 
                                    SET CourseName = @courseName,
                                        Code = @code, 
                                        Hours = @hours, 
                                        DepID = @depID, 
                                        InstructorID = @instructorID
                                WHERE CourseID = @courseID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@courseID", courseID);
                    command.Parameters.AddWithValue("@courseName", courseName);
                    command.Parameters.AddWithValue("@code", code);
                    command.Parameters.AddWithValue("@hours", hours);
                    command.Parameters.AddWithValue("@depID", depID);
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


        public static bool DeleteCourse(int courseID)
        {
            int affectedRows = 0;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM Course WHERE CourseID = @courseID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@courseID", courseID);

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

        public static DataTable GetAllCourses()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM CoursesInfo_View"; 

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
