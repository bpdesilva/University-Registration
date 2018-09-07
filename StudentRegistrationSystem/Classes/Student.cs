using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationSystem.Classes
{
    class Student
    {
        private string StudentID;
        private string FirstName;
        private string LastName;
        private string DOB;//date of birth
        private string PhoneNo;
        private string Email;
        private string Address;
        private string Gender;
        private string Username;
        private string Password;

        public Student()
        {

        }

        public Student(string Sid, string FName, string LName, string dOB, string PhNo, string Em, string Addr, string Gen, string Uname, string Pass)
        {
            StudentID = Sid;
            FirstName = FName;
            LastName = LName;
            DOB = dOB;
            PhoneNo = PhNo;
            Email = Em;
            Address = Addr;
            Gender = Gen;
            Username = Uname;
            Password = Pass;
        }

        public string getid()
        {
            return StudentID;
        }
        public void setid(string SID)
        {
            StudentID = SID;
        }
        public string getFirstName()
        {
            return FirstName;
        }
        public void setFirstName(string Fname)
        {
            FirstName = Fname;
        }

        public string getLastName()
        {
            return LastName;
        }
        public void setLastName(string Lname)
        {
            LastName = Lname;
        }
        public string getDOB()
        {
            return DOB;
        }
        public void setDOB(string dob)
        {
            DOB = dob;
        }
        public string getContactNo()
        {
            return PhoneNo;
        }
        public void setContactNo(string PhNo)
        {
            PhoneNo = PhNo;
        }
        public string getEmail()
        {
            return Email;
        }
        public void setEmail(string Em)
        {
            Email = Em;
        }
        public string getAddress()
        {
            return Address;
        }
        public void setAddress(string Addr)
        {
            Address = Addr;
        }
        public string getGender()
        {
            return Gender;
        }
        public void setGender(string Gen)
        {
            Gender = Gen;
        }
        public string getUsername()
        {
            return Username;
        }
        public void setUsername(string Uname)
        {
            Username = Uname;
        }
        public string getPassword()
        {
            return Password;
        }
        public void setPassword(string Pass)
        {
            Password = Pass;
        }

    }

}
