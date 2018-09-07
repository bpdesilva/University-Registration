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
    class CommonDBTransaction
    {
        SqlConnection con = new SqlConnection(@"Data Source=BPDESILVA;Initial Catalog=StaffordUniversity;Persist Security Info=True;User ID=sa;Password=123456");
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


    }
}
