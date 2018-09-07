
using StudentRegistrationSystem.Classes;
using StudentRegistrationSystem.UI;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationSystem.Data
{
    class BillTransaction
    {
        Bill b = new Bill();
        SqlConnection con = new SqlConnection(@"Data Source=BPDESILVA;Initial Catalog=StaffordUniversity;Persist Security Info=True;User ID=sa;Password=123456");
        public void addBill(Bill obj)
        {
            try
            {
                string sql = "INSERT INTO Bill (Amount,sid,mid)values('" + obj.getAmount() + "','" + obj.getsid() + "','" + obj.getmId() + "')";
                SqlCommand cmd = new SqlCommand(sql, con);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }
        public void updateBill()
        {
            SqlConnection con1 = new SqlConnection("Data Source=BPDESILVA;Initial Catalog=StaffordUniversity;Persist Security Info=True;User ID=sa;Password=123456");
            SqlCommand cmd = new SqlCommand("SELECT * FROM Bill WHERE sid ='" + b.getsid() + "' and mid='" + b.getmId() + "'", con1);
            con1.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            string amt = b.getAmount();
            if (reader.Read())
            {
                amt = reader[0].ToString();
            }
            con1.Close();
            SqlCommand cmd1 = new SqlCommand("UPDATE Bill SET Date='" + b.getDate() + "' WHERE BId='" + b.getbid() + "'", con);
            con.Open();
            cmd1.ExecuteNonQuery();
            con.Close();
        }
        public void addPayment()
        {
            SqlCommand cmd = new SqlCommand("UPDATE Bill SET PaymentMethod='" + b.getpaymentmethod() + "' WHERE BId='" + b.getbid() + "'", con);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
        }
    }
}
