using Data_Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class clsCourse
    {
        private enum enMode { AddNew = 0, Update =  1 }
        private enMode _Mode;

        private int _CourseID;
        public int CourseID 
        { 
            get 
            {
                return _CourseID;
            }  
        }
        public string CourseName { get; set; }
        public string Code { get; set; }
        public byte Hours { get; set; }
        public int DepartmentID { get; set; }
        //public clsDepartment DepartmentInfo
        //{ 
        //    get 
        //    {
        //        return clsDepartment.Find(DepartmentID);
        //    } 
        //}
        public int InstructorID { get; set; }
        //public clsInstructor InstructorInfo
        //{
        //    get { return clsInstructor.Find(InstructorID)}; 
        //}

        public clsCourse()
        {
            this._CourseID = -1;
            this.CourseName = "";
            this.Code = "";
            this.Hours = 0;
            this.DepartmentID = -1;
            this.InstructorID = -1;

            this._Mode = enMode.AddNew;
        }
        private clsCourse(int courseID, string courseName, string code, byte hours,
            int departmentID,int instructorID)
        {
            this._CourseID = courseID;
            this.CourseName = courseName;
            this.Code = code;
            this.Hours = hours;
            this.DepartmentID = departmentID;
            this.InstructorID = instructorID;

            this._Mode = enMode.Update;
        }

        private bool _AddNewCourse()
        {
            this._CourseID = clsCourseData.AddNewCourse(this.CourseName, this.Code,
                this.Hours, this.DepartmentID, this.InstructorID);

            return this._CourseID != -1;
        }

        private bool _UpdateCourse()
        {
            return clsCourseData.UpdateCourse(this._CourseID, this.CourseName,
                this.Code, this.Hours, this.DepartmentID, this.InstructorID);
        }

        public bool Save()
        {
            switch(this._Mode)
            {
                case enMode.AddNew:
                    {
                        if(_AddNewCourse())
                        {
                            this._Mode = enMode.Update;
                            return true;
                        }

                        return false;
                    }

                case enMode.Update:
                    return _UpdateCourse();

                default:
                    return false;
            }
        }

        public static clsCourse Find(int courseID)
        {
            string courseName = "", code = "";
            byte hours = 0;
            int depID = -1, instructorID = -1;

            return clsCourseData.GetCourseInfo(courseID, ref courseName, ref code, ref hours, ref depID, ref instructorID) ?
                new clsCourse(courseID, courseName, code, hours, depID, instructorID) : null;
        }

        public bool Delete() // to delete course in this object
        {
            return clsCourseData.DeleteCourse(this._CourseID);
        }

        public static bool DeleteCourse(int courseID)
        {
            return clsCourseData.DeleteCourse(courseID);
        }

        public static DataTable GetAllCourses()
        {
            return clsCourseData.GetAllCourses();
        }


    }
}
