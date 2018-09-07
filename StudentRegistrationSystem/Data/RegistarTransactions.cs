using StudentRegistrationSystem.Classes;
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
    class RegistarTransactions
    {
        Registar std;
        SqlConnection con = new SqlConnection(@"Data Source=BPDESILVA;Initial Catalog=StaffordUniversity;Persist Security Info=True;User ID=sa;Password=123456");
        //add data
        public void addRegistar(Registar obj)
        {
            try
            {
                string sql = "INSERT INTO Registar (RId,Username,Password)values('2','" + obj.getUsername() + "','" + obj.getPassword() + "')";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }
        //search data
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
        //login
        public bool Login(Registar obj)
        {
            SqlConnection con = new SqlConnection(@"Data Source=BPDESILVA;Initial Catalog=StaffordUniversity;Persist Security Info=True;User ID=sa;Password=123456");
            bool log = false;
            string query = "SELECT * FROM Registar where username ='" + obj.getUsername() + "'";
            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    if (reader[2].Equals(obj.getPassword()))
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
    }
}
