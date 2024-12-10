using Data_Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class clsDepartment
    {

        private enum enMode { AddNew = 0 , Update = 1 }
        private enMode _Mode;

        public int DepartmentID { get { return _DepartmentID; }  }

        private int _DepartmentID;
        public string DepartmentName { get; set; }
        public int HOD { get; set; }
        public clsInstructor HOD_Info;

        public clsDepartment()
        {
            this._DepartmentID = 0;
            this.DepartmentName = string.Empty;
            this.HOD = 0;

            this._Mode = enMode.AddNew;
        }
        
        public clsDepartment(int departmentID, string departmentName, int HOD)
        {
            this._DepartmentID = departmentID;
            this.DepartmentName = departmentName;
            this.HOD = HOD;
            this.HOD_Info = clsInstructor.FindInstructor(this.HOD);
            this._Mode = enMode.Update;
        }


        private bool _AddNewDepartment()
        {
            this._DepartmentID = clsDepartmentData.AddNewDepartment(this.DepartmentName,this.HOD);
            return this._DepartmentID != -1;
        }

        private bool _UpdateDepartment()
        {
            return clsDepartmentData.UpdateDepartment(this._DepartmentID,this.DepartmentName,this.HOD);
        }

        public bool Save()
        {
            switch(this._Mode)
            {
                case enMode.AddNew:
                    {
                        if(_AddNewDepartment())
                        {
                            this._Mode = enMode.Update;
                            return true;
                        }

                        return false;
                    }

                case enMode.Update:
                    return _UpdateDepartment();

                default:
                    return false;
            }
        }


        public static clsDepartment FindDepartment(int departmentID)
        {
            int HOD = 0;
            string departmentName = string.Empty;

            return clsDepartmentData.GetDepartmentInfo(departmentID, ref departmentName, ref HOD) ?
                new clsDepartment(departmentID, departmentName, HOD) : null;

        }


        public bool Delete()
        {
            return clsDepartmentData.DeleteDepartment(this._DepartmentID);
        }

        public static bool DeleteDepartment(int departmentID)
        {
            return clsDepartmentData.DeleteDepartment(departmentID);

        }

        public static DataTable GetAllDepartments()
        {
            return clsDepartmentData.GetAllDepartments();
        }


    }
}
