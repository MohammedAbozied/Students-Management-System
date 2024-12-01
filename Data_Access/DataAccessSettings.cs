using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Reflection;
using static System.IO.Directory;

namespace Data_Access
{
    public static class DataAccessSettings
    {
        // the path to .exe
        static string current_path = Directory.GetCurrentDirectory(); 
        // path to project directory                                                                 
        static string project_path = GetParent(GetParent(GetParent(current_path).FullName).FullName).FullName;
        private static string _ConnectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={project_path}\Data_Access\data base\StudentManagementSystem_DataBase.mdf; Integrated Security=True";

        public static string ConnectionString 
        { 
            get
            {
                return _ConnectionString;
            }
        }
    }
}
