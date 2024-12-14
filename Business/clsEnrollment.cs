using Data_Access;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class clsEnrollment
    {
        private enum enMode { AddNew = 0, Update = 1 }
        private enMode _Mode;

        public int EnrollmentID { get { return _EnrollmentID; } }

        private int _EnrollmentID;
        public int StudentID{ get; set; }
        public clsStudent StudentInfo;
        public int courseID { get; set; }
        public clsCourse CourseInfo;
        public DateTime EnrollmentDate { get; set; }
        public byte Grade { get; set; }

        public clsEnrollment()
        {
            this._EnrollmentID = -1;
            this.StudentID = -1;
            this.courseID = -1;
            this.EnrollmentDate = DateTime.Now;
            this.Grade = 0;

            this._Mode = enMode.AddNew;
        }

        private clsEnrollment(int enrollmentID,int studentID, int courseID, DateTime enrollmentDate, byte grade)
        {
            this._EnrollmentID = enrollmentID;

            this.StudentID = studentID;
            this.StudentInfo = clsStudent.FindStudent(this.StudentID);

            this.courseID = courseID;
            this.CourseInfo = clsCourse.Find(this.courseID);

            this.EnrollmentDate = enrollmentDate;
            this.Grade = grade;

            this._Mode = enMode.Update;
        }




        private bool _AddNewEnrollment()
        {
            this._EnrollmentID = clsEnrollmentData.AddNewEnrollment(this.StudentID, this.courseID, this.EnrollmentDate, this.Grade);
            return this._EnrollmentID != -1;
        }

        private bool _UpdateEnrollment()
        {
            return clsEnrollmentData.UpdateEnrollmentGrade(this._EnrollmentID,this.Grade);
        }

        public bool Save()
        {
            switch (this._Mode)
            {
                case enMode.AddNew:
                    {
                        if (_AddNewEnrollment())
                        {
                            this._Mode = enMode.Update;
                            return true;
                        }

                        return false;
                    }

                case enMode.Update:
                    return _UpdateEnrollment();

                default:
                    return false;
            }
        }


        public static clsEnrollment FindEnrollment(int enrollmentID)
        {
            int studentID = -1, courseID = -1;
            DateTime enrollmentDate = DateTime.MinValue;
            byte grade = 0;

            return clsEnrollmentData.GetEnrollmentInfo(enrollmentID, ref studentID, ref courseID, ref enrollmentDate, ref grade) ?
                new clsEnrollment(enrollmentID, studentID, courseID, enrollmentDate, grade) : null;

        }


        public bool Delete()
        {
            return clsEnrollmentData.DeleteEnrollment(this._EnrollmentID);
        }

        public static bool DeleteEnrollment(int enrollment)
        {
            return clsEnrollmentData.DeleteEnrollment(enrollment);

        }
       

        public static DataTable GetAllEnrollments()
        {
            return clsEnrollmentData.GetAllEnrollments();
        }

        

    }
}
