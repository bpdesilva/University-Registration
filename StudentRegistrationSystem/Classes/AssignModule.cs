using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationSystem.Classes
{
    class AssignModule
    {
        private string mid;
        private string Programme;
        private string Faculty;
        private string Modulefee;
        private string Duration;
        private string Startdate;
        private string Enddate;
        private string profid;
        private string sid;
        public AssignModule()
        {

        }
        public AssignModule(string mmid, string mprogramme, string mfaculty, string modfee, string mduration, string mstartdate, string menddate, string mlecid, string msid)
        {
            mid = mmid;
            Programme = mprogramme;
            Faculty = mfaculty;
            Modulefee = modfee;
            Duration = mduration;
            Startdate = mstartdate;
            Enddate = menddate;
            profid = mlecid;
            sid = msid;
        }
        public string getmid()
        {
            return mid;
        }
        public void setmid(string mmid)
        {
            mid = mmid;
        }
        public string getprogramme()
        {
            return Programme;
        }
        public void setprogramme(string mprogramme)
        {
            Programme = mprogramme;
        }
        public string getfaculty()
        {
            return Faculty;
        }
        public void setfaculty(string mfaculty)
        {
            Faculty = mfaculty;
        }
        public string getmodfee()
        {
            return Modulefee;
        }
        public void setmodfee(string modfee)
        {
            Modulefee = modfee;
        }
        public string getduration()
        {
            return Duration;
        }
        public void setduration(string mduration)
        {
            Duration = mduration;
        }
        public string getstartdate()
        {
            return Startdate;
        }
        public void setstarddate(string mstartdate)
        {
            Startdate = mstartdate;
        }
        public string getenddate()
        {
            return Enddate;
        }
        public void setenddate(string menddate)
        {
            Enddate = menddate;
        }
        public string getlid()
        {
            return profsid;
        }
        public void setlid(string mlid)
        {
            profsid = mlid;
        }
        public string getsid()
        {
            return sid;
        }
        public void setsid(string msid)
        {
            sid = msid;
        }

        public string profsid { get; set; }
    }
}
