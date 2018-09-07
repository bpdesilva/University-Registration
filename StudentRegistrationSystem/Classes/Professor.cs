using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationSystem.Classes
{
    class Professor
    {
        private string PID;// professor id
        private string Firstname;
        private string lastname;
        private string dob; // date of birth
        private string ContatcNo;
        private string Email;
        private string Address;
        private string Gender;
        private string Username;
        private string Password;

        public Professor()
        {

        }
        public Professor(string Pid, string FName, string LName, string LDOB, string MNO, string EM, string Addrss, string LGend, string Uname, string Pass)
        {
            PID = Pid;
            Firstname = FName;
            lastname = LName;
            dob = LDOB;
            ContatcNo = MNO;
            Email = EM;
            Address = Addrss;
            Gender = LGend;
            Username = Uname;
            Password = Pass;
        }

        public string getid()
        {
            return PID;
        }
        public void setid(string Lid)
        {
            PID = Lid;
        }
        public string getFirstName()
        {
            return Firstname;
        }
        public void setFirstName(string Fname)
        {
            Firstname = Fname;
        }

        public string getLastName()
        {
            return lastname;
        }
        public void setLastName(string lname)
        {
            lastname = lname;
        }
        public string getDOB()
        {
            return dob;
        }
        public void setDOB(string pdob)
        {
            dob = pdob;
        }
        public string getContactNo()
        {
            return ContatcNo;
        }
        public void setContactNo(string mno)
        {
            ContatcNo = mno;
        }
        public string getEmail()
        {
            return Email;
        }
        public void setEmail(string pemail)
        {
            Email = pemail;
        }
        public string getAddress()
        {
            return Address;
        }
        public void setAddress(string lAddress)
        {
            Address = lAddress;
        }
        public string getGender()
        {
            return Gender;
        }
        public void setGender(string pgender)
        {
            Gender = pgender;
        }
        public string getUsername()
        {
            return Username;
        }
        public void setUsername(string pusername)
        {
            Username = pusername;
        }
        public string getPassword()
        {
            return Password;
        }
        public void setPassword(string pPassword)
        {
            Password = pPassword;
        }
        public string newId { get; set; }
        public string newmod { get; set; }
    }
}

