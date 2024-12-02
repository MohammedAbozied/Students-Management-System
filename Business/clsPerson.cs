using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using Data_Access;

namespace Business
{
    public class clsPerson // we use this class to inherit it by 'users , student, instructor'
    {
        protected enum enMode { AddNew = 1 , Update=2}
        protected enMode _Mode; // protected to allow access in inheritance in child class

        public enum enGender:byte { Male = 0 , Female = 1 }
        
        protected int PersonID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return FirstName + " " + LastName; } }
        public enGender Gender {  get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Image_Path { get; set; }
        public string Email { get; set; }
        public string National_NO { get; set; }

        protected clsPerson() // use this constructor add new person
        {
            this.PersonID = -1;
            this.FirstName = string.Empty;
            this.LastName = string.Empty;
            this.Gender = enGender.Male;
            this.Phone = string.Empty;
            this.Address = string.Empty;
            this.DateOfBirth = DateTime.Now;
            this.Image_Path = string.Empty;
            this.Email = string.Empty;
            this.National_NO = string.Empty;

            this._Mode = enMode.AddNew;
        }

        // use this constructor to update person in find method 
        protected clsPerson(int personID,string fname,string lname,enGender Gendor,string phone,
            string address,DateTime DateOfBirth, string image_path,string email,string nationalNo)
        {
            this.PersonID = personID;
            this.FirstName = fname;
            this.LastName = lname;
            this.Gender = Gendor;
            this.Phone = phone;
            this.Address = address;
            this.DateOfBirth = DateOfBirth;
            this.Image_Path = image_path;
            this.Email = email;
            this.National_NO = nationalNo;

            this._Mode = enMode.Update;
        }

        private bool _AddNewPerson()
        {
            this.PersonID = clsPersonData.AddNewPerson(this.FirstName, this.LastName, (byte)this.Gender,
                this.Phone, this.Address, this.DateOfBirth, this.Image_Path, this.Email, this.National_NO);

            return this.PersonID != -1;
        }

        private bool _UpdatePerson()
        {
            return clsPersonData.UpdatePerson(this.PersonID, this.FirstName,this.LastName,(byte)this.Gender,
                this.Phone,this.Address,this.DateOfBirth,this.Image_Path,this.Email,this.National_NO);
        }

        protected bool Save()
        {
            switch(this._Mode)
            {
                case enMode.AddNew:
                    {
                        if(_AddNewPerson())
                        {
                            this._Mode = enMode.Update;
                            return true;
                        }
                        return false;
                    }
                case enMode.Update:
                    return _UpdatePerson();
                default:
                    return false;
            }
        }

        protected static clsPerson FindPerson(int personID)
        {

            string FirstName = string.Empty, LastName = string.Empty, Phone = string.Empty,
                Address = string.Empty, Image_Path = string.Empty, Email = string.Empty,
                National_NO = string.Empty;
            DateTime DateOfBirth = DateTime.Now;
            byte Gender = 0;

            // if person existed return object form person else return null.
            return clsPersonData.GetPersonInfo(personID, ref FirstName, ref LastName, ref Gender, ref Phone,
                ref Address, ref DateOfBirth, ref Image_Path, ref Email, ref National_NO) ?
                new clsPerson(personID, FirstName, LastName, (enGender)Gender, Phone, Address, DateOfBirth,
                Image_Path, Email, National_NO) : null;
        }

        protected bool Delete() // to delete this object
        {
            return clsPersonData.DeletePerson(this.PersonID);
        }
        protected static bool DeletePerson(int personID) // to delete another object
        {
            return clsPersonData.DeletePerson(personID);
        }

        protected static DataTable GetAllPeople()
        {
            return clsPersonData.GetAllPeople();
        }




    }
}
