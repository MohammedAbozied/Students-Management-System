using Data_Access;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class clsInstructor: clsPerson
    {

        public enum eMode { AddNew = 0, Update = 1 }
        private eMode _InstructorMode;
         
        public int InstructorID { get { return _InstructorID; } } 
        private int _InstructorID { get; set; }
        public int DepartmentID { get; set; }
        public decimal Salary { get; set; } 
        //public clsDepartment DepartmentInfo{ get; set; }

        public clsInstructor() : base() // call constructor of person when call instructor
        {
            this._InstructorID = -1;
            this.DepartmentID = 0;
            this.Salary = 0;
            this._InstructorMode = eMode.AddNew;

        }

        private clsInstructor(int instructorID, int personID, string fname, string lname, clsPerson.enGender gender,
            string phone, string address, DateTime dateOfBirth, string image_path, string email, string national_no, int departmentID, decimal salary)
            : base(personID, fname, lname, gender, phone, address, dateOfBirth, image_path, email, national_no)
        {
            this._InstructorID = instructorID;
            this.DepartmentID = departmentID;
            this.Salary = salary;
            //this.DepartmentInfo = clsDepartment.Find(this.DepartmentID);
            this._InstructorMode = eMode.Update;
        }

        private bool _AddNewInstructor()
        {
            this._InstructorID = clsInstructorData.AddNewInstructor(base.PersonID, this.DepartmentID, this.Salary);
            return _InstructorID != -1; 

        }

        private bool _UpdateInstructor()
        {
            return clsInstructorData.UpdateInstructor(this._InstructorID, this.DepartmentID, this.Salary);
        }

        public bool Save()
        {

            if (!base.Save())
                return false;

            switch (this._InstructorMode)
            {
                case eMode.AddNew:
                    {
                        if (_AddNewInstructor())
                        {
                            this._InstructorMode = eMode.Update;
                            return true;
                        } 
                        return false;
                    }

                case eMode.Update:
                    return _UpdateInstructor();

                default:
                    return false;
            }
        }

        public static clsInstructor FindInstructor(int instructorID) 
        {
            int personID = -1, departmentID = -1;
            decimal salary= 0; 

            if (clsInstructorData.GetInstructorInfo(instructorID, ref personID, ref departmentID, ref salary))
            {
                clsPerson personInfo = clsPerson.FindPerson(personID); // to get info from clsPerson

                return new clsInstructor(instructorID, personID, personInfo.FirstName, personInfo.LastName, personInfo.Gender,
                    personInfo.Phone, personInfo.Address, personInfo.DateOfBirth, personInfo.Image_Path, personInfo.Email,
                    personInfo.National_NO, departmentID, salary);
            }
            else
                return null; // if no instructor founded
        }

        // delete 
        public bool Delete()
        {
            // after making enrollment class ,we should delete it first.
            return clsInstructorData.DeleteInstructor(this._InstructorID) && base.Delete();
        }

        public static bool DeleteInstructor(int instructorID)
        {
            clsInstructor targetInstructor = FindInstructor(instructorID);

            // make sure student is existed.
            if (targetInstructor != null)
            {
                return targetInstructor.Delete();
            }

            return false;
        }

        public static DataTable GetAllInstructors()
        {
            return clsInstructorData.GetAllInstructors();
        }


    }
}
