using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework.Forms;
using StudentRegistrationSystem.Data;
using MetroFramework;
using StudentRegistrationSystem.Classes;
using MetroFramework.Controls;
using System.Windows.Forms;

namespace StudentRegistrationSystem.UI
{
    public partial class ProfessorHome : MetroForm
    {
        public static string profid;
        Professor p = new Professor();
        public static string modId;
        ProffessorTransactions pt = new ProffessorTransactions();
        public ProfessorHome()
        {
            InitializeComponent();
            ViewModules();

        }

        void DataGridViewMod()
        {
            CommonDBTransaction c = new CommonDBTransaction();
            string sql = "SELECT MId,Programme,Faculty,Semester,Duration,ModuleFee FROM Module WHERE MId='" + metroComboBoxMod.Text + "'";
            DataTable dt = c.searchData(sql);
            metroGridSelectMod.DataSource = dt;
        }

        void ViewModules()
        {

            DataRow dr;
            CommonDBTransaction c = new CommonDBTransaction();
            string sql = "SELECT MId FROM Module";
            DataTable dt = c.searchData(sql);
            dr = dt.NewRow();
            dr.ItemArray = new object[] { "--Select Module--" };
            dt.Rows.InsertAt(dr, 0);
            metroComboBoxMod.ValueMember = "MId";
            metroComboBoxMod.DisplayMember = "MId";
            metroComboBoxMod.DataSource = dt;
        }

        void loadComboShowMods()
        {
            DataRow dr;
            CommonDBTransaction c = new CommonDBTransaction();
            string sql = "SELECT mid FROM ProfessorModule WHERE pId = '" + profid + "'";
            DataTable dt = c.searchData(sql);

            if (dt.Rows.Count > 0)
            {
                dr = dt.NewRow();
                dr.ItemArray = new object[] { "--Select Module--" };
                dt.Rows.InsertAt(dr, 0);
                metroComboBoxRMods.ValueMember = "mid";
                metroComboBoxRMods.DisplayMember = "mid";
                metroComboBoxRMods.DataSource = dt;
            }



        }

        void loadComboTab()
        {
            DataRow dr;
            CommonDBTransaction c = new CommonDBTransaction();
            string sql = "SELECT mid FROM StudentModule";
            DataTable dt = c.searchData(sql);
            if (metroTabControlP.SelectedTab.Equals(metroTabPageModuleRoster))
            {
                if (dt.Rows.Count > 0)
                {
                    dr = dt.NewRow();
                    dr.ItemArray = new object[] { "--Select Module--" };
                    dt.Rows.InsertAt(dr, 0);
                    metroComboBoxMr.ValueMember = "mid";
                    metroComboBoxMr.DisplayMember = "mid";
                    metroComboBoxMr.DataSource = dt;
                }

            }
        }


        private void LecturerHome_Load(object sender, EventArgs e)
        {

            metroLabeluname.Text = Login.u;
            ProffessorTransactions pt = new ProffessorTransactions();
            p = pt.getProfessorId(metroLabeluname.Text);
            profid = p.getid();
            loadComboShowMods();
            loadComboTab();
        }

        private void metroTabPageSelectCourse_Click(object sender, EventArgs e)
        {

        }


        private void metroTabControlP_Selected(object sender, System.Windows.Forms.TabControlEventArgs e)
        {

        }

        private void metroTabControlP_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tabindex = metroTabControlP.SelectedIndex.ToString();
            if (tabindex == "0")
            {
                ViewModules();
                DataGridViewMod();
            }
            else if (tabindex == "1")
            {
                loadComboShowMods();
            }
            else if (tabindex == "2")
            { }
            else if (tabindex == "3")
            {
            }
            else if (tabindex == "4")
            {
                ViewModules();
            }
        }

        private void metroComboBoxMod_SelectedIndexChanged(object sender, EventArgs e)
        {
            Module m = new Module();
            ModuleTransactions mt = new ModuleTransactions();
            mt.dataFillCMBX(metroComboBoxMod.Text);
            m = mt.datafill(metroComboBoxMod.Text);
            metroComboBoxMod.Text = m.getID();
            metroTextBoxMod.Text = m.getMName();
            metroTextBoxF.Text = m.getFaculty();
            metroTextD.Text = m.getDuration();
            metroTextBoxMFee.Text = m.getModulefee();
            metroTextBoxSem.Text = m.getSemester();

        }

        private void metroButton1_Click(object sender, EventArgs e)
        {

            string uname = metroLabeluname.Text;
            CommonDBTransaction c = new CommonDBTransaction();
            string sqlcheck = "SELECT PId FROM Professor WHERE username= '" + uname + "'";
            DataTable d = c.searchData(sqlcheck);
            string profid = d.ToString();
            CommonDBTransaction co = new CommonDBTransaction();
            modId = metroComboBoxMod.Text;
            string sql = "SELECT * FROM ProfessorModule WHERE pId = '" + profid + "'AND mid='" + modId + "'";
            DataTable dt = co.searchData(sql);
            if (dt.Rows.Count > 0)
            {
                MetroMessageBox.Show(this, "You have already registered for this module!", "Warning");
                metroGridSelectMod.DataSource = dt;
                metroGridSelectMod.Refresh();
            }
            else
            {
                pt.addProffessorModule();
                MetroMessageBox.Show(this, "Registration successful");

            }
        }

        private void metroLabelLogout_Click(object sender, EventArgs e)
        {
            DialogResult dr = MetroMessageBox.Show(this, "\n\nContinue Logging Out?", " Professor | LOG OUT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Close();
                new Login().Show();
            }
        }

        private void metroComboBoxRMods_SelectedIndexChanged(object sender, EventArgs e)
        {
            AssignModule am = new AssignModule();
            AssignModuleTransaction amt = new AssignModuleTransaction();
            try
            {
                am = amt.fillDataProf(metroComboBoxRMods.Text);
                metroComboBoxRMods.Text = am.getmid();
                metroTextBoxFacM.Text = am.getfaculty();
                metroTextBoxP.Text = am.getprogramme();
                metroTextBoxModFees.Text = am.getmodfee();
                metroTextBoxStd.Text = am.getstartdate();
                metroTextBoxEnd.Text = am.getenddate();
            }
            catch
            {
                MetroMessageBox.Show(this, "Course not yet assinged");
            }
        }

        private void metroComboBoxMr_SelectedIndexChanged(object sender, EventArgs e)
        {

            StudentTransactions c = new StudentTransactions();
            string sql = "SELECT * FROM StudentModule";
            DataTable dt = c.searchData(sql);
            metroGridMRos.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                metroLabeltotal.Text = metroGridMRos.Rows.Count.ToString();
            }
            else
            {
                MetroMessageBox.Show(this, "Still no one has registered for the " + metroComboBoxMr.Text + " Courses.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void metroButton2_Click(object sender, EventArgs e)
        {
            AssignModule am = new AssignModule();
            AssignModuleTransaction amt = new AssignModuleTransaction();
            try
            {
                am = amt.fillDataProf(metroComboBoxRMods.Text);
                metroComboBoxRMods.Text = am.getmid();
                metroTextBoxFacM.Text = am.getfaculty();
                metroTextBoxP.Text = am.getprogramme();
                metroTextBoxModFees.Text = am.getmodfee();
                metroTextBoxStd.Text = am.getstartdate();
                metroTextBoxEnd.Text = am.getenddate();
            }
            catch
            {
                MetroMessageBox.Show(this, "Course not yet assinged");
            }
        }

        private void metroButton3_Click(object sender, EventArgs e)
        {
            StudentTransactions c = new StudentTransactions();
            string sql = "SELECT * FROM StudentModule";
            DataTable dt = c.searchData(sql);
            metroGridMRos.DataSource = dt;
            if (dt.Rows.Count > 0)
            {
                metroLabeltotal.Text = metroGridMRos.Rows.Count.ToString();
            }
            else
            {
                MetroMessageBox.Show(this, "Still no one has registered for the " + metroComboBoxMr.Text + " Courses.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
        }

        private void metroTabPageRegisterCourse_Click(object sender, EventArgs e)
        {
            DataGridViewMod();
        }

        private void metroGridSelectMod_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow row = this.metroGridSelectMod.Rows[index];
            metroComboBoxMod.Text = row.Cells["MId"].Value.ToString();
            metroTextBoxMod.Text = row.Cells["Programme"].Value.ToString();
            metroTextBoxF.Text = row.Cells["Faculty"].Value.ToString();
            metroTextBoxSem.Text = row.Cells["Semester"].Value.ToString();
            metroTextD.Text = row.Cells["Duration"].Value.ToString();
            metroTextBoxMFee.Text = row.Cells["ModuleFee"].Value.ToString();
            metroTextBoxMod.ReadOnly = true;
            metroTextBoxSem.ReadOnly = true;
            metroTextD.ReadOnly = true;
            metroTextBoxMFee.ReadOnly = true;

        }

        private void metroGridSelectMod_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int index = e.RowIndex;
            DataGridViewRow row = this.metroGridSelectMod.Rows[index];
            metroComboBoxMod.Text = row.Cells["MId"].Value.ToString();
            metroTextBoxMod.Text = row.Cells["Programme"].Value.ToString();
            metroTextBoxF.Text = row.Cells["Faculty"].Value.ToString();
            metroTextBoxSem.Text = row.Cells["Semester"].Value.ToString();
            metroTextD.Text = row.Cells["Duration"].Value.ToString();
            metroTextBoxMFee.Text = row.Cells["ModuleFee"].Value.ToString();
            metroTextBoxMod.ReadOnly = true;
            metroTextBoxSem.ReadOnly = true;
            metroTextD.ReadOnly = true;
            metroTextBoxMFee.ReadOnly = true;
        }
    }
}
