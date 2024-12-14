using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Data_Access
{
    public static class clsEnrollmentData
    {

        public static bool GetEnrollmentInfo(int enrollmentID, ref int stu_ID, ref int courseID, ref DateTime enrollmentDate, ref byte grade )
        {
            bool isFound = false;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Enrollments_View WHERE EnrollmentID = @enrollmentID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@enrollmentID", enrollmentID);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                stu_ID = (int)reader["Stu_ID"];
                                courseID = (int)reader["CourseID"];
                                enrollmentDate = (DateTime)reader["EnrollmentDate"];
                                grade = (byte)reader["Grade"];

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


        public static int AddNewEnrollment(int stu_ID, int courseID, DateTime enrollmentDate, byte grade)
        {
            int newID = -1;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO Enrollment 
                                    VALUES(@stu_ID,@courseID,@enrollmentDate,@grade);
                                SELECT SCOPE_IDENTITY()";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@stu_ID", stu_ID);
                    command.Parameters.AddWithValue("@courseID", courseID);
                    command.Parameters.AddWithValue("@enrollmentDate", enrollmentDate);
                    command.Parameters.AddWithValue("@grade", grade);


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

        public static bool UpdateEnrollmentGrade(int enrollmentID, byte grade) 
        {
            int affectedRows = 0;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE Enrollment 
                                    SET Grade = @grade
                                WHERE EnrollmentID = @enrollmentID";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@grade", grade);
                    command.Parameters.AddWithValue("@enrollmentID", enrollmentID);


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


        public static bool DeleteEnrollment(int enrollmentID)
        {
            int affectedRows = 0;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM Enrollment WHERE EnrollmentID = @enrollmentID";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@enrollmentID", enrollmentID);

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

       


        public static DataTable GetAllEnrollments()
        {
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Enrollments_View ORDER BY EnrollmentDate DESC";

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
