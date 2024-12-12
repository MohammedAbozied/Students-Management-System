using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Data_Access
{
    public static class clsStudentData
    {
        public static bool GetStudentInfo(int stu_id,ref int personID, ref byte academicYear,ref int depID)
        {
            bool isFound = false;
            using(SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM Student WHERE Stu_ID = @stu_id";

                using(SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@stu_id", stu_id);

                    try
                    {
                        connection.Open();
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.Read())
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

        public static int AddNewStudent(int personID, byte academicYear,int departmentID)
        {
            int newID = -1;
            using (SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string query = @"INSERT INTO Student 
                                    VALUES(@personID,@academicYear,@departmentID);
                                SELECT SCOPE_IDENTITY()";

                using(SqlCommand command = new SqlCommand(query , connection))
                {
                    command.Parameters.AddWithValue("@personID", personID);
                    command.Parameters.AddWithValue("@academicYear", academicYear);
                    command.Parameters.AddWithValue("@departmentID", departmentID);

                    try
                    {
                        connection.Open();
                        object result = command.ExecuteScalar();
                        if(result != null && int.TryParse(result.ToString(), out int id))
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
            using(SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string query = @"UPDATE Student 
                                    SET AcademicYear = @academicYear,
                                        DepID = @departmentID 
                                WHERE Stu_ID = @studentID";

                using(SqlCommand command = new SqlCommand(query , connection))
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
            using(SqlConnection connection = new SqlConnection(DataAccessSettings.ConnectionString))
            {
                string query = "DELETE FROM Student WHERE Stu_ID = @studentID";
                using(SqlCommand command = new SqlCommand (query , connection))
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

        public static DataTable GetAllStudents()
        {
            DataTable dataTable = new DataTable();
            using(SqlConnection connection = new SqlConnection( DataAccessSettings.ConnectionString))
            {
                string query = "SELECT * FROM StudentsInfo_View"; // after making department classes will replace it with view to show all info. 

                using(SqlCommand command = new SqlCommand(query,connection))
                {
                    try
                    {
                        connection.Open();
                        using(SqlDataReader reader = command.ExecuteReader())
                        {
                            if(reader.HasRows)
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
        
        public static int CountMales()
        {
            int result = 0;
            using(SqlConnection connection = new SqlConnection( DataAccessSettings.ConnectionString))
            {
                string query = "SELECT Count(Stu_ID) FROM Student INNER JOIN Person ON Student.PersonID = Person.PersonID AND Gender = 0 ";  

                using(SqlCommand command = new SqlCommand(query,connection))
                {
                    try
                    {
                        connection.Open();
                        
                        object count = command.ExecuteScalar();
                        if(count != null && int.TryParse(count.ToString(), out int r))
                        {
                            result = r;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.ToString());
                    }
                }
            }

            return result;
        }



    }
}
