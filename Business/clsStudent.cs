using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data_Access;

namespace Business
{
    public class clsStudent:clsPerson // we here inherit all properties of person
    {
        public enum eMode { AddNew = 0 , Update = 1 }
        private eMode _StudentMode;

        public int StudentID { get { return _StudentID; } } // to prevent editing ID by object.
        private int _StudentID { get; set; }
        private int _PersonID;
        public byte AcademicYear { get; set; }
        public int DepartmentID { get; set; }
        public clsDepartment DepartmentInfo { get; set; }

        public clsStudent():base() // call constructor of person when call student
        {
            this._StudentID = -1;
            this._PersonID = -1;
            this.AcademicYear = 0;
            this.DepartmentID = -1;
            this._StudentMode = eMode.AddNew;
            
        }

        private clsStudent(int stu_id, int personID,string fname,string lname,clsPerson.enGender gender,
            string phone,string address,DateTime dateOfBirth,string image_path,string email,string national_no ,byte academicYear, int departmentID)
            :base(personID,fname,lname,gender,phone,address,dateOfBirth,image_path,email,national_no)
        {
            this._StudentID = stu_id;
            this._PersonID = personID;
            this.AcademicYear = academicYear;
            this.DepartmentID = departmentID;
            this.DepartmentInfo = clsDepartment.FindDepartment(this.DepartmentID);

            this._StudentMode = eMode.Update;
        }

        private bool _AddNewStudent()
        {
            this._StudentID = clsStudentData.AddNewStudent(base.PersonID, this.AcademicYear, this.DepartmentID);
            return _StudentID != -1;

        }

        private bool _UpdateStudent()
        {
            return clsStudentData.UpdateStudent(this._StudentID, this.AcademicYear, this.DepartmentID);
        }

        public bool Save()
        {
            
            if (!base.Save())
                return false;

            switch(this._StudentMode)
            {
                case eMode.AddNew:
                    {
                        if(_AddNewStudent())
                        {
                            this._StudentMode = eMode.Update;
                            return true;
                        }
                        return false;
                    }

                case eMode.Update:
                    return _UpdateStudent();

                default:
                    return false;
            }
        }

        public static clsStudent FindStudent(int studentID)
        {
            int personID = -1, departmentID = -1;
            byte academicYear = 0;

            if(clsStudentData.GetStudentInfo(studentID,ref personID,ref academicYear,ref departmentID))
            {
                clsPerson personInfo = clsPerson.FindPerson(personID); // to get info from clsPerson

                return new clsStudent(studentID, personID, personInfo.FirstName, personInfo.LastName, personInfo.Gender,
                    personInfo.Phone, personInfo.Address, personInfo.DateOfBirth, personInfo.Image_Path, personInfo.Email,
                    personInfo.National_NO, academicYear, departmentID);
            }
            else
                return null; // if no student founded
        }

        // delete 
        public bool Delete()
        {
            return DeleteAllEnrollmentsForStudent(this._StudentID) && clsStudentData.DeleteStudent(this._StudentID) && base.Delete();
        }

        public static bool DeleteStudent(int studentID)
        {
            clsStudent targetStudent = FindStudent(studentID);

            // make sure student is existed.
            if(targetStudent != null)
            {
                return targetStudent.Delete();
            }

            return false;
        }

        public static bool DeleteAllEnrollmentsForStudent(int studentID)
        {
            if (!clsStudentData.StudentHasEnrollments(studentID))
                return true; // if student hasn't any enrollments return true.

            return clsStudentData.DeleteAllEnrollmentsForStudentID(studentID);
        }

        public static DataTable GetAllStudents()
        {
            return clsStudentData.GetAllStudents();
        }

        public static int CountMales()
        {
            return clsStudentData.CountMales();
        }

        
    }
}
