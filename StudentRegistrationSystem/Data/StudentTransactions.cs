using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentRegistrationSystem.Classes;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using StudentRegistrationSystem.UI;

namespace StudentRegistrationSystem.Data
{
    class StudentTransactions
    {
        Student std; // student instance
        //sql connection string
        SqlConnection con = new SqlConnection(@"Data Source=BPDESILVA;Initial Catalog=StaffordUniversity;Persist Security Info=True;User ID=sa;Password=123456");
        //Add Student
        public void addstudent(Student obj)
        {
            try
            {
                //sql query
                string sql = "INSERT INTO Student (SId,FirstName,LastName,DOB,PhoneNo,Email,Address,Gender,username,password)values('" + obj.getid() + "','" + obj.getFirstName() + "','" + obj.getLastName() + "','" + obj.getDOB() + "','" + obj.getContactNo() + "','" + obj.getEmail() + "','" + obj.getAddress() + "','" + obj.getGender() + "','" + obj.getUsername() + "','" + obj.getPassword() + "')";
                SqlCommand cmd = new SqlCommand(sql, con);//sql command
                con.Open();//open connection
                cmd.ExecuteNonQuery();//execute query
            }
            finally
            {
                con.Close();//close connection
            }
        }
        //Update Student
        public void updateStudent(Student obj)
        {
            try
            {
                //sql query
                string sql = "UPDATE Student SET SId ='" + obj.getid() + "', FirstName = '" + obj.getFirstName() + "', LastName ='" + obj.getLastName() + "', DOB ='" + obj.getDOB() + "', PhoneNo='" + obj.getContactNo() + "', Email='" + obj.getEmail() + "', Address='" + obj.getAddress() + "', Gender='" + obj.getGender() + "',username='" + obj.getUsername() + "',password='" + obj.getPassword() + "' where SId = '" + obj.getid() + "'";
                SqlCommand cmd = new SqlCommand(sql, con);//sql command
                con.Open();//open connection
                cmd.ExecuteNonQuery();//execute query
            }
            finally
            {
                con.Close();//close connection
            }
        }
        //Get Data by Student id to text box
        public Student dataFill(string studentid)
        {
            try
            {
                string sql = "SELECT * FROM Student WHERE SId ='" + studentid + "'";//SQL Query 
                SqlCommand cmd = new SqlCommand(sql, con);//Get Connection details and parse in query
                con.Open();//open connection
                SqlDataReader reader = cmd.ExecuteReader(); // send command to the connection
                //Read row by row from the table until query condition is satisfied 
                if (reader.Read())
                {
                    std = new Student(); // new student instance 
                    std.setid(reader[0].ToString());
                    std.setFirstName(reader[1].ToString());
                    std.setLastName(reader[2].ToString());
                    std.setDOB(reader[3].ToString());
                    std.setContactNo(reader[4].ToString());
                    std.setEmail(reader[5].ToString());
                    std.setAddress(reader[6].ToString());
                    std.setGender(reader[7].ToString());
                    std.setUsername(reader[8].ToString());
                    std.setPassword(reader[9].ToString());
                }
            }
            finally
            {
                con.Close(); // Close connection
            }
            return std; //return student object
        }
        //delete from student module
        public void deleteFromStudentModule(String studentid)
        {
            try
            {
                //sql query
                string sql = "DELETE FROM StudentModule WHERE sid = '" + studentid + "'";
                SqlCommand cmd = new SqlCommand(sql, con);//sql command
                con.Open();//open connection
                cmd.ExecuteNonQuery(); // execute sql query
            }
            finally
            {
                con.Close();// close connection
            }
        }
        //delete student
        public void deleteStudent(string studentid)
        {
            try
            {
                //sql query
                string sql = "DELETE FROM Student WHERE SId = '" + studentid + "'";
                SqlCommand cmd = new SqlCommand(sql, con); //sql command
                con.Open(); // open connection
                cmd.ExecuteNonQuery();//execute sql query
            }
            finally
            {
                con.Close();//close connection
            }
        }
        //search data
        public DataTable searchData(string query)
        {
            try
            {
                DataTable table = new DataTable();//data table instance
                //sql connection string
                using (SqlConnection con = new SqlConnection(@"Data Source=BPDESILVA;Initial Catalog=StaffordUniversity;Persist Security Info=True;User ID=sa;Password=123456"))
                {
                    //sql data adapter instance 
                    using (SqlDataAdapter da = new SqlDataAdapter(query, con))
                        da.Fill(table);//get data
                }
                return table; //return data to datagrid view
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.ToString());
                return null;
            }
        }
        //login
        public bool Login(Student obj)
        {
            //sql connection string
            SqlConnection con = new SqlConnection(@"Data Source=BPDESILVA;Initial Catalog=StaffordUniversity;Persist Security Info=True;User ID=sa;Password=123456");
            bool log = false;//variable boolean for status
            string query = "SELECT * FROM Student where username ='" + obj.getUsername() + "'";//sql query
            SqlCommand cmd = new SqlCommand(query, con); //sql command
            con.Open();//open connection
            try
            {
                //sql data reader
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read()) // read data until condition satisfied
                {
                    if (reader[9].Equals(obj.getPassword())) //validate password
                    {
                        log = true;
                    }
                    else
                    {
                        MessageBox.Show("Incorrect!"); // error message
                    }
                }
                else
                {
                    MessageBox.Show("Incorrect!");//error message
                }
            }
            finally
            {
                con.Close();//close connection
            }
            return log;// return login
        }
        //get student id
        public Student getStudentId(string username)
        {
            try
            {
                //sql query
                string sql = "SELECT * FROM Student WHERE username = '" + username + "'";
                SqlCommand cmd = new SqlCommand(sql, con); //sql command
                con.Open();//open connection
                SqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.Read()) //read data until condition satisfied
                {
                    std = new Student(); // new instance
                    std.setid(dataReader[0].ToString());
                 
                }
                dataReader.Close(); //stop data reader
            }
            catch
            {
                con.Close();// close connection
            }
            return std; // reutrn student
        }

        //add student module
        public void addstudentModule()
        {
            try
            {
                //sql query
                string sql = "INSERT INTO StudentModule (sid,mid)values('" + StudentHome.stdId + "','" + StudentHome.modId + "')";
                SqlCommand cmd = new SqlCommand(sql, con);//sql command
                con.Open();//open connection
                cmd.ExecuteNonQuery();//execute query
            }
            finally
            {
                con.Close(); // close connection
            }
        }
    }
}
