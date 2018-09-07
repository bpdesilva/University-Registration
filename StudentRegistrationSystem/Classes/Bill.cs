using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentRegistrationSystem.Classes
{
    class Bill
    {
        private string Date;//Date
        private string bId;//Bill id
        private string sId;//student id
        private string mId;//module id
        private string Amount;//amount
        private string paymentMethod;//payment method
        public Bill()
        {

        }
        public Bill(string bpaymentmethod, string bbid)
        {
            paymentMethod = bpaymentmethod;
            bId = bbid;
        }
        public Bill(string bAmount, string bsid, string bmId)
        {
            Amount = bAmount;
            sId = bsid;
            mId = bmId;
        }
        public Bill(string bDate, string bbid, string bsid, string bmId, string brupee, string bpaymentmethod)
        {
            Date = bDate;
            bId = bbid;
            sId = bsid;
            mId = bmId;
            Amount = brupee;
            paymentMethod = bpaymentmethod;
        }
        public string getDate()
        {
            return Date;
        }
        public void setDate(string bDate)
        {
            Date = bDate;
        }
        public string getbid()
        {
            return bId;
        }
        public void setbid(string bbid)
        {
            bId = bbid;
        }
        public string getsid()
        {
            return sId;
        }
        public void setsid(string bsid)
        {
            sId = bsid;
        }
        public string getmId()
        {
            return mId;
        }
        public void setmId(string bmId)
        {
            mId = bmId;
        }
        public string getAmount()
        {
            return Amount;
        }
        public void setAmount(string Amounts)
        {
            Amount = Amounts;
        }
        public string getpaymentmethod()
        {
            return paymentMethod;
        }
        public void setpaymentmethod(string bpaymentmethod)
        {
            paymentMethod = bpaymentmethod;
        }
    }
}
