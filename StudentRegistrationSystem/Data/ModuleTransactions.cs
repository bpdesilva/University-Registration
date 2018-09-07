using StudentRegistrationSystem.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationSystem.Data
{
    class ModuleTransactions
    {
        Module mod;
        SqlConnection con = new SqlConnection(@"Data Source=BPDESILVA;Initial Catalog=StaffordUniversity;Persist Security Info=True;User ID=sa;Password=123456");

        public void addModule(Module obj)
        {
            try
            {
                string sql = "INSERT INTO Module(MId, Programme, Faculty, Semester, Duration, ModuleFee, ModuleDescription)VALUES('" + obj.getID() + "','" + obj.getMName() + "','" + obj.getFaculty() + "','" + obj.getSemester() + "','" + obj.getDuration() + "','" + obj.getModulefee() + "','" + obj.getModuleOverview() + "')";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }

        public void deleteStudentModule(string ModId)
        {
            try
            {
                string sql = "DELETE FROM Module WHERE mid = '" + ModId + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }
        public void deleteModule(string ModId)
        {
            try
            {
                string sql = "DELETE FROM Module WHERE MId = '" + ModId + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }
        //Get all module Data
        public Module datafill(string id)
        {
            try
            {
                string sql = "SELECT * FROM Module where MId ='" + id + "'"; //sql query
                SqlCommand cmd = new SqlCommand(sql, con); //sql command
                con.Open(); // open sql connection
                SqlDataReader reader = cmd.ExecuteReader(); // Execute data reader
                //Validate row with where clause
                if (reader.Read())
                {
                    mod = new Module();//set values to instance
                    mod.setID(reader[0].ToString());
                    mod.setMName(reader[1].ToString());
                    mod.setFaculty(reader[2].ToString());
                    mod.setSemester(reader[3].ToString());
                    mod.setDuration(reader[4].ToString());
                    mod.setModulefee(reader[5].ToString());
                    mod.setModuleOverview(reader[6].ToString());
                }
            }
            finally
            {
                con.Close();//close sql connection
            }
            return mod;
        }

        public void updateModule(Module obj)
        {
            try
            {
                string sql = "Update Module SET MId ='" + obj.getID() + "', Programme ='" + obj.getMName() + "', Faculty ='" + obj.getFaculty() + "',Semester ='" + obj.getSemester() + "',Duration='" + obj.getDuration() + "',Modulefee='" + obj.getModulefee() + "',ModuleDescription='" + obj.getModulefee() + "' WHERE MId ='" + obj.getID() + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }
        public Module dataFillCMBX(string id)
        {
            try
            {
                string sql = "SELECT MId FROM Module";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    mod = new Module();
                    mod.setID(reader[0].ToString());
                }
            }
            finally
            {
                con.Close();
            }
            return mod;
        }

    }
}

