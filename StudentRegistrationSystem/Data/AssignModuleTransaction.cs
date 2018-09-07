using StudentRegistrationSystem.Classes;
using StudentRegistrationSystem.UI;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentRegistrationSystem.Data
{
    class AssignModuleTransaction
    {
        AssignModule amod;//assign module instance 
        //sql connection string
        SqlConnection con = new SqlConnection(@"Data Source=BPDESILVA;Initial Catalog=StaffordUniversity;Persist Security Info=True;User ID=sa;Password=123456");
        //add a module
        public void addModule(AssignModule obj)
        {
            try
            {
                //sql query
                string sql = "INSERT INTO AssignModule(MId,Programme,Faculty,ModuleFee,Duration,StartDate,EndDate,pId,sId)VALUES('" + obj.getmid() + "','" + obj.getprogramme() + "','" + obj.getfaculty() + "','" + obj.getmodfee() + "','" + obj.getduration() + "','" + obj.getstartdate() + "','" + obj.getenddate() + "','" + obj.getlid() + "','" + obj.getmid() + "')";
                SqlCommand cmd = new SqlCommand(sql, con); // sql command
                con.Open();//open connection
                cmd.ExecuteNonQuery(); //execute query
            }
            finally
            {
                con.Close(); // close connection
            }
        }
        //fill data to combo
        public AssignModule fillData(string id)
        {
            try
            {
                //sql query
                string sql = "SELECT * FROM AssignModule WHERE MId ='" + id + "'AND sid='" + StudentHome.stdId + "'";
                SqlCommand cmd = new SqlCommand(sql, con); //sql command
                con.Open();//open connection
                SqlDataReader reader = cmd.ExecuteReader(); //read table
                if (reader.Read()) //loop unitl data found
                {
                    amod = new AssignModule(); // new instance
                    amod.setmid(reader[0].ToString());
                    amod.setprogramme(reader[1].ToString());
                    amod.setfaculty(reader[2].ToString());
                    amod.setmodfee(reader[3].ToString());
                    amod.setduration(reader[4].ToString());
                    amod.setstarddate(reader[5].ToString());
                    amod.setenddate(reader[6].ToString());
                }
                else
                {
                    //error message
                    MessageBox.Show("The Module has not yet been assigned");
                }
            }
            finally
            {
                con.Close();//close connection
            }
            return amod; // return obejct
        }
        //Fill data
        public AssignModule fillDataProf(string id)
        {
            try
            {
                //sql query
                string sql = "SELECT * FROM AssignModule WHERE MId ='" + id + "'AND pId='" + ProfessorHome.profid + "'";
                SqlCommand cmd = new SqlCommand(sql, con); // sql command
                con.Open(); // open connection
                SqlDataReader reader = cmd.ExecuteReader(); //read table
                if (reader.Read()) //loop until data found
                {
                    amod = new AssignModule();
                    amod.setmid(reader[0].ToString());
                    amod.setprogramme(reader[1].ToString());
                    amod.setfaculty(reader[2].ToString());
                    amod.setmodfee(reader[3].ToString());
                    amod.setduration(reader[4].ToString());
                    amod.setstarddate(reader[5].ToString());
                    amod.setenddate(reader[6].ToString());
                }
                else
                {
                    MessageBox.Show("The Module has not yet been assigned"); //errror message
                }
            }
            finally
            {
                con.Close(); //close connection
            }
            return amod; //return object
        }
        //Delete student module
        public void deleteStudentModule(string ModId)
        {
            try
            {
                con.Open();//open connection
                string sql = "DELETE FROM AssignModule WHERE MId = '" + ModId + "'"; // sql query
                SqlCommand cmd = new SqlCommand(sql, con); // sql command
                cmd.ExecuteNonQuery(); // execute query
            }
            finally
            {
                con.Close();//close connection
            }
        }
    }
}
