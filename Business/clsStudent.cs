﻿using System;
using System.CodeDom;
using System.Collections.Generic;
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

        public int StudentID { get; set; }
        private int _PersonID;
        public byte AcademicYear { get; set; }
        public int DepartmentID { get; set; }
        //public clsDepartment DepartmentInfo{ get; set; }

        public clsStudent():base() // call constructor of person when call student
        {
            this.StudentID = -1;
            this._PersonID = -1;
            this.AcademicYear = 0;
            this.DepartmentID = -1;
            this._StudentMode = eMode.AddNew;
            
        }

        public clsStudent(int stu_id, int personID,string fname,string lname,clsPerson.enGender gender,
            string phone,string address,DateTime dateOfBirth,string image_path,string email,string national_no ,byte academicYear, int departmentID)
            :base(personID,fname,lname,gender,phone,address,dateOfBirth,image_path,email,national_no)
        {
            this.StudentID = stu_id;
            this._PersonID = personID;
            this.AcademicYear = academicYear;
            this.DepartmentID = departmentID;
            //this.DepartmentInfo = clsDepartment.Find(this.DepartmentID);
            this._StudentMode = eMode.Update;
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
                return null; // if no user founded
        }


    }
}