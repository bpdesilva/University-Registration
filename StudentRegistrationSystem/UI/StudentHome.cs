using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework.Forms;
using StudentRegistrationSystem.Classes;
using StudentRegistrationSystem.Data;
using System.Windows.Forms;
using MetroFramework;

namespace StudentRegistrationSystem.UI
{
    public partial class StudentHome : MetroForm
    {
        //public variables 
        public static string stdId;
        public static string modId;
        public static string modFee;
        public StudentHome()
        {
            InitializeComponent();
        }
        Student s = new Student(); //student instance 
        //load combo box
        void loadCombo()
        {

            DataRow dr;
            CommonDBTransaction c = new CommonDBTransaction(); // new insance 
            string sql = "SELECT * FROM Module";
            DataTable dt = c.searchData(sql); // execute query
            if (metroTabControlStudent.SelectedTab.Equals(metroTabPageRegister)) // based on page execute code
            {
                dr = dt.NewRow();
                dr.ItemArray = new object[] { "--Select Faculty--" }; // load data to array
                dt.Rows.InsertAt(dr, 0);
                metroComboBoxFaculty.ValueMember = "Faculty";//displat only faculty
                metroComboBoxFaculty.DisplayMember = "Faculty";
                metroComboBoxFaculty.DataSource = dt;
            }

        }
        //load registered modules
        void loadComboShowMods()
        {
            StudentTransactions std = new StudentTransactions();
            std.getStudentId(metroLabelUser.Text);
            String stid = s.getid();
            DataRow dr;
            CommonDBTransaction c = new CommonDBTransaction();
            string sql = "SELECT mid FROM StudentModule WHERE sid = '" + stid + "'";
            DataTable dt = c.searchData(sql);
                if (dt.Rows.Count > 0) {
                dr = dt.NewRow();
                dr.ItemArray = new object[] { "--Select Module--" };
                dt.Rows.InsertAt(dr, 0);
                metroComboBoxMods.ValueMember = "mid";
                metroComboBoxMods.DisplayMember = "mid";
                metroComboBoxMods.DataSource = dt;
                

            }
            
        }

        void loadComboTab()
        {
            StudentTransactions std = new StudentTransactions();
            std.getStudentId(metroLabelUser.Text);
            String stid = s.getid();
            DataRow dr;
            CommonDBTransaction c = new CommonDBTransaction();
            string sql = "SELECT mid FROM StudentModule WHERE sid = '" + stid + "'";
            DataTable dt = c.searchData(sql);
          
                if (dt.Rows.Count > 0)
                {
                    dr = dt.NewRow();
                    dr.ItemArray = new object[] { "--Select Module--" };
                    dt.Rows.InsertAt(dr, 0);
                    metroComboBoxModl.ValueMember = "mid";
                    metroComboBoxModl.DisplayMember = "mid";
                    metroComboBoxModl.DataSource = dt;
                
            }
        }
        //load faculty
        void loadModuleFaculty()
        {
            CommonDBTransaction c = new CommonDBTransaction();
            string sql = "SELECT * FROM Module WHERE Faculty='" + metroComboBoxFaculty.Text + "'";
            DataTable dt = c.searchData(sql);
            metroGridModules.DataSource = dt;
        }

        private void StudentHome_Load(object sender, EventArgs e)
        {
            metroLabelUser.Text = Login.u; //logged in user name
            StudentTransactions st = new StudentTransactions();
            s = st.getStudentId(metroLabelUser.Text); // get user id
            stdId = s.getid();
            //execute methods onload
            loadCombo();
            loadComboShowMods();
            loadComboTab();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

        }

        private void metroComboBoxFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadModuleFaculty();//load combo box
        }

        private void metroGridModules_CellContentClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            //get data from table to textboxes and combo box
            int index = e.RowIndex;
            DataGridViewRow row = this.metroGridModules.Rows[index];
            metroTextBoxModId.Text = row.Cells["MId"].Value.ToString();
            metroTextBoxMod.Text = row.Cells["Programme"].Value.ToString();
            metroComboBoxFaculty.Text = row.Cells["Faculty"].Value.ToString();
            metroTextBoxSem.Text = row.Cells["Semester"].Value.ToString();
            metroTextBoxDuration.Text = row.Cells["Duration"].Value.ToString();
            metroTextBoxMFee.Text = row.Cells["ModuleFee"].Value.ToString();
            metroTextBoxMOverview.Text = row.Cells["ModuleDescription"].Value.ToString();
            metroTextBoxModId.ReadOnly = true;
            metroTextBoxMod.ReadOnly = true;
            metroTextBoxSem.ReadOnly = true;
            metroTextBoxDuration.ReadOnly = true;
            metroTextBoxMFee.ReadOnly = true;
            metroTextBoxMOverview.ReadOnly = true;
        }

        private void metroGridModules_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //get data from table to textboxes and combo box
            int index = e.RowIndex;
            DataGridViewRow row = this.metroGridModules.Rows[index];
            metroTextBoxModId.Text = row.Cells["MId"].Value.ToString();
            metroTextBoxMod.Text = row.Cells["Programme"].Value.ToString();
            metroComboBoxFaculty.Text = row.Cells["Faculty"].Value.ToString();
            metroTextBoxSem.Text = row.Cells["Semester"].Value.ToString();
            metroTextBoxDuration.Text = row.Cells["Duration"].Value.ToString();
            metroTextBoxMFee.Text = row.Cells["ModuleFee"].Value.ToString();
            metroTextBoxMOverview.Text = row.Cells["ModuleDescription"].Value.ToString();
            metroTextBoxModId.ReadOnly = true;
            metroTextBoxMod.ReadOnly = true;
            metroTextBoxSem.ReadOnly = true;
            metroTextBoxDuration.ReadOnly = true;
            metroTextBoxMFee.ReadOnly = true;
            metroTextBoxMOverview.ReadOnly = true;
        }

        private void metroButtonRegister_Click(object sender, EventArgs e)
        {
            //validate data
            if (metroTextBoxModId.Text == "" || metroTextBoxMod.Text == "" || metroComboBoxFaculty.Text == "" || metroTextBoxSem.Text == "" || metroTextBoxDuration.Text == "" || metroTextBoxMFee.Text == "" || metroTextBoxMOverview.Text == "")
            {
                MetroMessageBox.Show(this, "Fields cannot be left empty");
            }
            else
            {
                modId = metroTextBoxModId.Text;
                StudentTransactions st = new StudentTransactions();
                string uname = metroLabelUser.Text;
                CommonDBTransaction c = new CommonDBTransaction();
                string sqlcheck = "SELECT SId FROM Student WHERE username= '" + uname + "'";
                DataTable d = c.searchData(sqlcheck); //validate data from db
                string profid = d.ToString();
                CommonDBTransaction co = new CommonDBTransaction();
                modId = metroTextBoxModId.Text;
                string sql = "SELECT * FROM StudentModule WHERE sid = '" + profid + "'AND mid='" + modId + "'";
                DataTable dt = co.searchData(sql);//validate data from db 
                if (dt.Rows.Count > 0)
                {
                    MetroMessageBox.Show(this, "You have already registered for this module!", "Warning");
                    metroGridModules.DataSource = dt;
                    metroGridModules.Refresh();
                }
                else
                {
                    st.addstudentModule(); // insert data
                    modFee = metroTextBoxMFee.Text;
                    Bill b = new Bill(modFee, stdId, modId);
                    BillTransaction bt = new BillTransaction();
                    bt.addBill(b); //insert data 
                    this.Hide();
                    Billing bill = new Billing();
                    bill.Show();
                    MetroMessageBox.Show(this, "Registration successful");
                }    
            }
        }

        private void metroComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //load values to input fields
            AssignModule am = new AssignModule();
            AssignModuleTransaction amt = new AssignModuleTransaction();
            try
            {
                am = amt.fillData(metroComboBoxMods.Text);
                metroComboBoxMods.Text = am.getmid();
                metroTextBoxMFac.Text = am.getfaculty();
                metroTextBoxProgram.Text = am.getprogramme();
                metroTextBoxMFees.Text = am.getmodfee();
                metroTextBoxstDate.Text = am.getstartdate();
                metroTextBoxedDate.Text = am.getenddate();
            }
            catch
            {
                MetroMessageBox.Show(this, "Course not yet assinged");
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            loadComboShowMods();
        }

        private void metroComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //load values to input fields
            AssignModule am = new AssignModule();
            AssignModuleTransaction amt = new AssignModuleTransaction();
            try
            {
                am = amt.fillData(metroComboBoxMods.Text);
                metroComboBoxMods.Text = am.getmid();
                metroTextBoxMFac.Text = am.getfaculty();
                metroTextBoxProgram.Text = am.getprogramme();
                metroTextBoxMFees.Text = am.getmodfee();
                metroTextBoxstDate.Text = am.getstartdate();
                metroTextBoxedDate.Text = am.getenddate();
            }
            catch
            {
                MetroMessageBox.Show(this, "Course not yet assinged");
            }
        }

        private void metroButtonDrops_Click(object sender, EventArgs e)
        {
            //validate data
            if (metroComboBoxModl.Text=="") {
                MetroMessageBox.Show(this,"Please select module to proceed!");
            }
            else
            {
                AssignModuleTransaction amt = new AssignModuleTransaction();
                amt.deleteStudentModule(metroComboBoxModl.Text); // delete data from db
                MetroMessageBox.Show(this, "Successfully Deleted");// message
            }
        }

        private void metroButtonRef_Click(object sender, EventArgs e)
        {
            loadComboTab(); // load combobox
        }

        private void metroLabelLogout_Click(object sender, EventArgs e)
        {
            //logout
            DialogResult dr = MetroMessageBox.Show(this, "\n\nContinue Logging Out?", " Student | LOG OUT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Close();
                new Login().Show();
            }
        }

        private void metroTabPage3_Click(object sender, EventArgs e)
        {
            
        }

        private void metroTabPage4_Click(object sender, EventArgs e)
        {
            
        }

        private void metroTabPageRegister_Click(object sender, EventArgs e)
        {

        }
    }
}
  