using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationSystem.Classes
{
    class Module
    {
        private string MId;
        private string MName;
        private string Faculty;
        private string Semester;
        private string Duration;
        private string Modulefee;
        private string Moduleoverview;
        public Module()
        {

        }
        public Module(string mid, string MMName, string MFaculty, string MSemester, string MDuration, string MModulefee, string MModuleview)
        {
            MId = mid;
            MName = MMName;
            Faculty = MFaculty;
            Semester = MSemester;
            Duration = MDuration;
            Modulefee = MModulefee;
            Moduleoverview = MModuleview;
        }

        public string getID()
        {
            return MId;
        }
        public void setID(string mid)
        {
            MId = mid;
        }
        public string getMName()
        {
            return MName;
        }
        public void setMName(string mMName)
        {
            MName = mMName;
        }
        public string getFaculty()
        {
            return Faculty;
        }
        public void setFaculty(string mFaculty)
        {
            Faculty = mFaculty;
        }
        public string getSemester()
        {
            return Semester;
        }
        public void setSemester(string mSemester)
        {
            Semester = mSemester;
        }
        public string getDuration()
        {
            return Duration;
        }
        public void setDuration(string mDuration)
        {
            Duration = mDuration;
        }
        public string getModulefee()
        {
            return Modulefee;
        }
        public void setModulefee(string mModulefee)
        {
            Modulefee = mModulefee;
        }
        public string getModuleOverview()
        {
            return Moduleoverview;
        }
        public void setModuleOverview(string mModuleoverview)
        {
            Moduleoverview = mModuleoverview;
        }
    }
}
