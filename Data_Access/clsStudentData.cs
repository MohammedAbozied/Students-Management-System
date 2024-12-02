using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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







    }
}
