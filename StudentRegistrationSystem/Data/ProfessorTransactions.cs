using StudentRegistrationSystem.Classes;
using StudentRegistrationSystem.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StudentRegistrationSystem.Data
{
    class ProffessorTransactions
    {
        Professor prof; // professor instanace
        //Sql Connection string
        SqlConnection con = new SqlConnection(@"Data Source=BPDESILVA;Initial Catalog=StaffordUniversity;Persist Security Info=True;User ID=sa;Password=123456");
        //Add Proffessor 
        public void addProffessor(Professor obj)
        {
            try
            {
                //sql query
                string sql = "INSERT INTO Professor(PId,FirstName,LastName,DOB,PhoneNo,Email,Address,Gender,username,password)values('" + obj.getid() + "','" + obj.getFirstName() + "','" + obj.getLastName() + "','" + obj.getDOB() + "','" + obj.getContactNo() + "','" + obj.getEmail() + "','" + obj.getAddress() + "','" + obj.getGender() + "','" + obj.getUsername() + "','" + obj.getPassword() + "')";
                SqlCommand cmd = new SqlCommand(sql, con); //sql command
                con.Open();//open connection
                cmd.ExecuteNonQuery(); //execute query
            }
            finally
            {
                con.Close();//close connection
            }
        }

        public void updateProffessor(Professor obj)
        {
            try
            {
                string sql = "UPDATE Professor SET PId ='" + obj.getid() + "', FirstName = '" + obj.getFirstName() + "', LastName ='" + obj.getLastName() + "', DOB ='" + obj.getDOB() + "', PhoneNo='" + obj.getContactNo() + "', Email='" + obj.getEmail() + "', Address='" + obj.getAddress() + "', Gender='" + obj.getGender() + "',username='" + obj.getUsername() + "',password='" + obj.getPassword() + "' where PId = '" + obj.getid() + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();

            }
            finally
            {
                con.Close();
            }
        }
        public Professor dataFill(string profid)
        {
            try
            {
                string sql = "SELECT * FROM Professor WHERE PId ='" + profid + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    prof = new Professor();
                    prof.setid(reader[0].ToString());
                    prof.setFirstName(reader[1].ToString());
                    prof.setLastName(reader[2].ToString());
                    prof.setDOB(reader[3].ToString());
                    prof.setContactNo(reader[4].ToString());
                    prof.setEmail(reader[5].ToString());
                    prof.setAddress(reader[6].ToString());
                    prof.setGender(reader[7].ToString());
                    prof.setUsername(reader[8].ToString());
                    prof.setPassword(reader[9].ToString());
                }
            }
            finally
            {
                con.Close();
            }
            return prof;
        }
        public void deleteFromProffessorModule(String profid)
        {
            try
            {
                string sql = "DELETE FROM ProfessorModule  WHERE PId = '" + profid + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }
        public void deleteProffessorr(string profid)
        {
            try
            {
                string sql = "DELETE FROM Professor WHERE PId = '" + profid + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }
        public DataTable searchData(string query)
        {
            try
            {
                DataTable table = new DataTable();
                using (SqlConnection con = new SqlConnection(@"Data Source=BPDESILVA;Initial Catalog=StaffordUniversity;Persist Security Info=True;User ID=sa;Password=123456"))
                {
                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                        da.Fill(table);
                }
                return table;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
                return null;
            }
        }

        public Professor getdetails(string username)
        {
            try
            {
                string sql = "SELECT * FROM Professor WHERE username = '" + username + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader datareader = cmd.ExecuteReader();
                if (datareader.Read())
                {
                    Professor prof = new Professor();
                    prof.setid(datareader[0].ToString());
                    prof.setFirstName(datareader[1].ToString());
                    prof.setLastName(datareader[2].ToString());
                    prof.setDOB(datareader[3].ToString());
                    prof.setContactNo(datareader[4].ToString());
                    prof.setEmail(datareader[5].ToString());
                    prof.setAddress(datareader[6].ToString());
                    prof.setGender(datareader[7].ToString());
                    prof.setUsername(datareader[8].ToString());
                    prof.setPassword(datareader[9].ToString());
                }
                datareader.Close();
            }
            catch
            {
                con.Close();
            }
            return prof;
        }
        public bool Login(Professor obj)
        {
            SqlConnection con = new SqlConnection(@"Data Source=BPDESILVA;Initial Catalog=StaffordUniversity;Persist Security Info=True;User ID=sa;Password=123456");
            bool log = false;
            string query = "SELECT * FROM Professor where username ='" + obj.getUsername() + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader[9].Equals(obj.getPassword()))
                    {
                        log = true;
                    }
                    else
                    {
                        MessageBox.Show("Incorrect!");
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect!");
                }
            }
            finally
            {
                con.Close();
            }
            return log;
        }

        public Professor getProfessorId(string username)
        {
            try
            {
                string sql = "SELECT * FROM Professor WHERE username = '" + username + "'";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.Read())
                {
                    prof = new Professor();
                    prof.setid(dataReader[0].ToString());
                }
                dataReader.Close();
            }
            catch
            {
                con.Close();
            }
            return prof;
        }

        public void addProffessorModule()
        {
            try
            {
                string sql = "INSERT INTO ProfessorModule (pId,mid)values('" + ProfessorHome.profid + "','" + ProfessorHome.modId + "')";
                con.Open();
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }
    }
}
