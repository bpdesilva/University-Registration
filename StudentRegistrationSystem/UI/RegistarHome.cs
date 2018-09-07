using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetroFramework.Forms;
using MetroFramework;
using System.Text.RegularExpressions;
using StudentRegistrationSystem.Data;
using StudentRegistrationSystem.Classes;
using System.Windows.Forms;

namespace StudentRegistrationSystem.UI
{
    public partial class RegistarHome : MetroForm
    {

        public RegistarHome()
        {
            InitializeComponent();

        }

        private void RegistarHome_Load(object sender, EventArgs e)
        {
            metroLabelUser.Text = Login.u;
            ToolTip t1 = new ToolTip();

        }

        void DataGridViewStudents()
        {
            StudentTransactions c = new StudentTransactions();
            string sql = "SELECT * FROM Student";
            DataTable dt = c.searchData(sql);
            metroGridStudents.DataSource = dt;
        }

        void loadSessionStudentModule()
        {
            CommonDBTransaction c = new CommonDBTransaction();
            string sql = "SELECT * FROM StudentModule WHERE mid = '" + metroComboBoxMod.Text + "'";
            DataTable dt = c.searchData(sql);
            if (dt.Rows.Count > 0)
            {
                metroGridStd.DataSource = dt;
            }
        }
        void loadSessionProfessorModule()
        {
            CommonDBTransaction c = new CommonDBTransaction();
            string sql = "SELECT * FROM ProfessorModule WHERE mid = '" + metroComboBoxMod.Text + "'";
            DataTable dt = c.searchData(sql);
            if (dt.Rows.Count > 0)
            {
                metroGridProf.DataSource = dt;
            }
        }

        void DataGridViewProf()
        {
            ProffessorTransactions c1 = new ProffessorTransactions();
            string sql1 = "SELECT * FROM Professor";
            DataTable dt1 = c1.searchData(sql1);
            metroGridProfessor.DataSource = dt1;
        }
        void DataGridViewModules()
        {

            DataRow dr;
            CommonDBTransaction c = new CommonDBTransaction();
            string sql = "SELECT * FROM Module";
            DataTable dt = c.searchData(sql);
            metroGridModules.DataSource = dt;
            if (metroTabControlR.SelectedTab.Equals(AssignModules))
            {
                dr = dt.NewRow();
                dr.ItemArray = new object[] { "--Select Module--" };
                dt.Rows.InsertAt(dr, 0);
                metroComboBoxMod.ValueMember = "MId";
                metroComboBoxMod.DisplayMember = "MId";
                metroComboBoxMod.DataSource = dt;
            }

        }
        void DataGridViewReg()
        {
            RegistarTransactions c = new RegistarTransactions();
            string sql = "SELECT * FROM Registar";
            DataTable dt = c.searchData(sql);
            metroGridRegs.DataSource = dt;
        }
        void clearStudent()
        {
            metroTextBoxStudentId.Clear();
            metroTextBoxFirstName.Clear();
            metroTextBoxLastName.Clear();
            metroTextBoxMobileNo.Clear();
            metroTextBoxEmail.Clear();
            metroTextBoxDOB.Clear();
            metroTextBoxUsername.Clear();
            metroTextBoxAddress.Clear();
            metroTextBoxPassword.Clear();
        }
        void clearProfessor()
        {
            metroTextBoxProfessorId.Clear();
            metroTextBoxFname.Clear();
            metroTextBoxLName.Clear();
            metroTextBoxMNo.Clear();
            metroTextBoxEm.Clear();
            metroTextBoxDOB2.Clear();
            metroTextBoxUName.Clear();
            metroTextBoxPW.Clear();
        }
        void clearModule()
        {
            metroTextBoxModuleId.Clear();
            metroTextBoxModuleName.Clear();
            metroTextBoxFaculty.Clear();
            metroTextBoxFee.Clear();
            metroTextBoxDescription.Clear();

        }
        void clearReg()
        {
            metroTextBoxUnames.Clear();
            metroTextBoxPws.Clear();

        }



        private void metroRadioAdd_CheckedChanged(object sender, EventArgs e)
        {
            metroTextSearch.Enabled = false;
        }

        private void metroButtonProceed_Click(object sender, EventArgs e)
        {
            if (metroComboBoxOptStd.Text == "Add")
            {

                if (metroTextBoxStudentId.Text == "" || metroTextBoxFirstName.Text == "" || metroTextBoxLastName.Text == "" || metroTextBoxDOB.Text == "" || metroTextBoxMobileNo.Text == "" || metroTextBoxEmail.Text == "" || metroTextBoxAddress.Text == "" || metroComboBoxGen.Text == "" || metroTextBoxUsername.Text == "" || metroTextBoxPassword.Text == "")
                {
                    MetroMessageBox.Show(this, "Fields cannot be left empty");
                }
                if (!Regex.Match(metroTextBoxMobileNo.Text, @"^\d{10}$").Success)
                {
                    MetroMessageBox.Show(this, "Please re-enter the contact number", "Warning");
                    metroTextBoxMobileNo.Focus();
                }
                if (!Regex.Match(metroTextBoxEmail.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,4})+)$").Success)
                {
                    MetroMessageBox.Show(this, "Invalid E-Mail address Please re-enter correct address");
                    metroTextBoxEmail.Focus();
                }
                else
                {
                    CommonDBTransaction c = new CommonDBTransaction();
                    string sql = "SELECT * FROM Student WHERE SId = '" + metroTextBoxStudentId.Text + "' or Username = '" + metroTextBoxUsername.Text + "'";
                    DataTable d = c.searchData(sql);
                    metroGridStudents.DataSource = d;
                    if (d.Rows.Count > 0)
                    {
                        MetroMessageBox.Show(this, "This Data already exist");
                    }
                    else
                    {
                        Student obj = new Student(metroTextBoxStudentId.Text, metroTextBoxFirstName.Text, metroTextBoxLastName.Text, metroTextBoxDOB.Text, metroTextBoxMobileNo.Text, metroTextBoxEmail.Text, metroTextBoxAddress.Text, metroComboBoxGen.Text, metroTextBoxUsername.Text, metroTextBoxPassword.Text);
                        StudentTransactions tr = new StudentTransactions();
                        tr.addstudent(obj);
                        MetroMessageBox.Show(this, "Data Saved Sucessfully !");
                        clearStudent();
                        metroGridStudents.Refresh();
                    }
                }
            }
            else if (metroComboBoxOptStd.Text == "Update")
            {
                if (metroTextBoxStudentId.Text == "" || metroTextBoxFirstName.Text == "" || metroTextBoxLastName.Text == "" || metroTextBoxDOB.Text == "" || metroTextBoxMobileNo.Text == "" || metroTextBoxEmail.Text == "" || metroTextBoxAddress.Text == "" || metroComboBoxGen.Text == "" || metroTextBoxUsername.Text == "" || metroTextBoxPassword.Text == "")
                {
                    MetroMessageBox.Show(this, "Fields cannot be left empty");
                }
                if (!Regex.Match(metroTextBoxMobileNo.Text, @"^\d{10}$").Success)
                {
                    MetroMessageBox.Show(this, "Please re-enter the contact number", "Warning");
                    metroTextBoxMobileNo.Focus();
                }
                if (!Regex.Match(metroTextBoxEmail.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,4})+)$").Success)
                {
                    MetroMessageBox.Show(this, "Invalid E-Mail address Please re-enter correct address");
                    metroTextBoxEmail.Focus();
                }
                else
                {
                    Student obj = new Student(metroTextBoxStudentId.Text, metroTextBoxFirstName.Text, metroTextBoxLastName.Text, metroTextBoxDOB.Text, metroTextBoxMobileNo.Text, metroTextBoxEmail.Text, metroTextBoxAddress.Text, metroComboBoxGen.Text, metroTextBoxUsername.Text, metroTextBoxPassword.Text);
                    StudentTransactions tr = new StudentTransactions();
                    tr.updateStudent(obj);
                    MetroMessageBox.Show(this, "Data Saved Sucessfully !");
                    clearStudent();
                    metroGridStudents.Refresh();
                }
            }
            else if (metroComboBoxOptStd.Text == "Search")
            {
                Student obj = new Student();
                StudentTransactions tr2 = new StudentTransactions();
                try
                {
                    obj = tr2.dataFill(metroTextSearch.Text);
                    metroTextBoxStudentId.Text = obj.getid();
                    metroTextBoxFirstName.Text = obj.getFirstName();
                    metroTextBoxLastName.Text = obj.getLastName();
                    metroTextBoxDOB.Text = obj.getDOB();
                    metroTextBoxMobileNo.Text = obj.getContactNo();
                    metroTextBoxEmail.Text = obj.getEmail();
                    metroTextBoxAddress.Text = obj.getAddress();
                    metroComboBoxGen.Text = obj.getGender();
                    metroTextBoxUsername.Text = obj.getUsername();
                    metroTextBoxPassword.Text = obj.getPassword();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Stafford University Registration System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            else if (metroComboBoxOptStd.Text == "Delete")
            {
                if (metroGridStudents.Rows.Count == 0)
                {
                    MetroMessageBox.Show(this, "No data found to delete");
                }
                else
                {
                    DialogResult del = MessageBox.Show("Are you Sure you want to delete :" + metroTextBoxStudentId.Text + "", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (del == DialogResult.Yes)
                    {
                        StudentTransactions tr3 = new StudentTransactions();
                        try
                        {
                            tr3.deleteFromStudentModule(metroTextBoxStudentId.Text);
                            tr3.deleteStudent(metroTextBoxStudentId.Text);
                            MetroMessageBox.Show(this, "Successfully Deleted");
                            clearStudent();
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message, "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ok. As per confirmation, this record has not been deleted.");
                    }
                }

            }
            else
            {
                MetroMessageBox.Show(this, "Please select a option button to Proceed!");
            }
        }

        private void Student_Click(object sender, EventArgs e)
        {

        }



        private void Lecturer_Click(object sender, EventArgs e)
        {

        }

        private void metroRadioAddLec_CheckedChanged(object sender, EventArgs e)
        {
            metroTextBoxSearchLec.Enabled = false;
        }

        private void metroButtonSearch_Click(object sender, EventArgs e)
        {
            Student obj = new Student();
            StudentTransactions tr2 = new StudentTransactions();
            try
            {
                obj = tr2.dataFill(metroTextSearch.Text);
                metroTextBoxStudentId.Text = obj.getid();
                metroTextBoxFirstName.Text = obj.getFirstName();
                metroTextBoxLastName.Text = obj.getLastName();
                metroTextBoxDOB.Text = obj.getDOB();
                metroTextBoxMobileNo.Text = obj.getContactNo();
                metroTextBoxEmail.Text = obj.getEmail();
                metroTextBoxAddress.Text = obj.getAddress();
                metroComboBoxGen.Text = obj.getGender();
                metroTextBoxUsername.Text = obj.getUsername();
                metroTextBoxPassword.Text = obj.getPassword();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message, "Stafford University Registration System", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void metroButtonProceedLect_Click(object sender, EventArgs e)
        {
            if (metroComboBoxOptProf.Text == "Add")
            {
                if (metroTextBoxProfessorId.Text == "" || metroTextBoxFname.Text == "" || metroTextBoxLName.Text == "" || metroTextBoxDOB2.Text == "" || metroTextBoxMNo.Text == "" || metroTextBoxEm.Text == "" || metroTextBoxAddr.Text == "" || metroComboBoxGend.Text == "" || metroTextBoxUName.Text == "" || metroTextBoxPW.Text == "")
                {
                    MetroMessageBox.Show(this, "Fields cannot be left empty");
                }
                if (!Regex.Match(metroTextBoxMNo.Text, @"^\d{10}$").Success)
                {
                    MetroMessageBox.Show(this, "Please re-enter the contact number", "Warning");
                    metroTextBoxMNo.Focus();
                }
                if (!Regex.Match(metroTextBoxEm.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,4})+)$").Success)
                {
                    MetroMessageBox.Show(this, "Invalid E-Mail address Please re-enter correct address");
                    metroTextBoxEm.Focus();
                }
                else
                {
                    ProffessorTransactions c = new ProffessorTransactions();
                    string sql = "SELECT * FROM Professor WHERE PId = '" + metroTextBoxProfessorId.Text + "' or Username = '" + metroTextBoxUName.Text + "'";
                    DataTable d = c.searchData(sql);
                    metroGridStudents.DataSource = d;
                    if (d.Rows.Count > 0)
                    {
                        MetroMessageBox.Show(this, "This Data already exist");
                    }
                    else
                    {
                        Professor obj = new Professor(metroTextBoxProfessorId.Text, metroTextBoxFname.Text, metroTextBoxLName.Text, metroTextBoxDOB2.Text, metroTextBoxMNo.Text, metroTextBoxEm.Text, metroTextBoxAddr.Text, metroComboBoxGend.Text, metroTextBoxUName.Text, metroTextBoxPW.Text);
                        ProffessorTransactions tr = new ProffessorTransactions();
                        tr.addProffessor(obj);
                        MetroMessageBox.Show(this, "Data Saved Sucessfully !");
                        clearProfessor();
                        metroGridProfessor.Refresh();
                    }
                }
            }
            else if (metroComboBoxOptProf.Text == "Update")
            {
                if (metroTextBoxProfessorId.Text == "" || metroTextBoxFname.Text == "" || metroTextBoxLName.Text == "" || metroTextBoxDOB2.Text == "" || metroTextBoxMNo.Text == "" || metroTextBoxEm.Text == "" || metroTextBoxAddr.Text == "" || metroComboBoxGend.Text == "" || metroTextBoxUName.Text == "" || metroTextBoxPW.Text == "")
                {
                    MetroMessageBox.Show(this, "Fields cannot be left empty");
                }
                if (!Regex.Match(metroTextBoxMNo.Text, @"^\d{10}$").Success)
                {
                    MetroMessageBox.Show(this, "Please re-enter the contact number", "Warning");
                    metroTextBoxMNo.Focus();
                }
                if (!Regex.Match(metroTextBoxEm.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,4})+)$").Success)
                {
                    MetroMessageBox.Show(this, "Invalid E-Mail address Please re-enter correct address");
                    metroTextBoxEm.Focus();
                }
                else
                {
                    Professor obj = new Professor(metroTextBoxProfessorId.Text, metroTextBoxFname.Text, metroTextBoxLName.Text, metroTextBoxDOB2.Text, metroTextBoxMNo.Text, metroTextBoxEm.Text, metroTextBoxAddr.Text, metroComboBoxGend.Text, metroTextBoxUName.Text, metroTextBoxPW.Text);
                    ProffessorTransactions tr = new ProffessorTransactions();
                    tr.updateProffessor(obj);
                    MetroMessageBox.Show(this, "Data Saved Sucessfully !");
                    clearProfessor();
                    metroGridProfessor.Refresh();
                }
            }
            else if (metroComboBoxOptProf.Text == "Search")
            {
                Professor obj = new Professor();
                ProffessorTransactions tr2 = new ProffessorTransactions();
                try
                {
                    obj = tr2.dataFill(metroTextBoxSearchLec.Text);
                    metroTextBoxProfessorId.Text = obj.getid();
                    metroTextBoxFname.Text = obj.getFirstName();
                    metroTextBoxLName.Text = obj.getLastName();
                    metroTextBoxDOB2.Text = obj.getDOB();
                    metroTextBoxMNo.Text = obj.getContactNo();
                    metroTextBoxEm.Text = obj.getEmail();
                    metroTextBoxAddr.Text = obj.getAddress();
                    metroComboBoxGend.Text = obj.getGender();
                    metroTextBoxUName.Text = obj.getUsername();
                    metroTextBoxPW.Text = obj.getPassword();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Stafford University Registration System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (metroComboBoxOptProf.Text == "Delete")
            {
                if (metroGridProfessor.Rows.Count == 0)
                {
                    MetroMessageBox.Show(this, "No data found to delete");
                }
                else
                {
                    DialogResult del = MessageBox.Show("Are you Sure you want to delete :" + metroTextBoxStudentId.Text + "", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (del == DialogResult.Yes)
                    {
                        ProffessorTransactions tr3 = new ProffessorTransactions();
                        try
                        {
                            tr3.deleteFromProffessorModule(metroTextBoxStudentId.Text);
                            tr3.deleteProffessorr(metroTextBoxStudentId.Text);
                            MetroMessageBox.Show(this, "Successfully Deleted");
                            metroGridProfessor.Refresh();
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message, "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ok. As per confirmation, this record has not been deleted.");
                    }
                }

            }
            else
            {
                MetroMessageBox.Show(this, "Please select a option button to Proceed!");
            }
        }

        private void metroButtonSearchLec_Click(object sender, EventArgs e)
        {
            if (metroTextBoxSearchLec.Text == "")
            {
                MetroMessageBox.Show(this, "Search Field cannot be left empty");
            }
            else
            {
                Professor obj = new Professor();
                ProffessorTransactions tr2 = new ProffessorTransactions();
                try
                {
                    obj = tr2.dataFill(metroTextBoxSearchLec.Text);
                    metroTextBoxProfessorId.Text = obj.getid();
                    metroTextBoxFname.Text = obj.getFirstName();
                    metroTextBoxLName.Text = obj.getLastName();
                    metroTextBoxDOB2.Text = obj.getDOB();
                    metroTextBoxMNo.Text = obj.getContactNo();
                    metroTextBoxEm.Text = obj.getEmail();
                    metroTextBoxAddr.Text = obj.getAddress();
                    metroComboBoxGend.Text = obj.getGender();
                    metroTextBoxUName.Text = obj.getUsername();
                    metroTextBoxPW.Text = obj.getPassword();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Stafford University Registration System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void metroButtonProceedMod_Click(object sender, EventArgs e)
        {
            if (metroComboBoxMods.Text == "Add")
            {
                if (metroTextBoxModuleId.Text == "" || metroTextBoxModuleName.Text == "" || metroTextBoxFaculty.Text == "" || metroTextBoxFaculty.Text == "" || metroTextBoxDuration.Text == "" || metroTextBoxFee.Text == "" || metroTextBoxDescription.Text == "")
                {
                    MetroMessageBox.Show(this, "Please fill all fields in order to add a new Module!");
                }
                else
                {
                    CommonDBTransaction c = new CommonDBTransaction();
                    string sql = "SELECT * FROM Module WHERE MId = '" + metroTextBoxModuleId.Text + "'";
                    DataTable d = c.searchData(sql);
                    metroGridModules.DataSource = d;
                    if (d.Rows.Count > 0)
                    {
                        MetroMessageBox.Show(this, "This Data already exist");
                    }
                    else
                    {
                        Module obj = new Module(metroTextBoxModuleId.Text, metroTextBoxModuleName.Text, metroTextBoxFaculty.Text, metroComboBoxSemester.Text, metroTextBoxDuration.Text, metroTextBoxFee.Text, metroTextBoxDescription.Text);
                        ModuleTransactions tr = new ModuleTransactions();
                        tr.addModule(obj);
                        MetroMessageBox.Show(this, "Data Saved Sucessfully !");
                        clearModule();
                        metroGridModules.Refresh();
                    }
                }
            }
            else if (metroComboBoxMods.Text == "Update")
            {
                if (metroTextBoxModuleId.Text == "" || metroTextBoxModuleName.Text == "" || metroTextBoxFaculty.Text == "" || metroTextBoxFaculty.Text == "" || metroTextBoxDuration.Text == "" || metroTextBoxFee.Text == "" || metroTextBoxDescription.Text == "")
                {
                    MetroMessageBox.Show(this, "Please fill all fields in order to add a new Module!");
                }
                else
                {
                    Module obj = new Module(metroTextBoxModuleId.Text, metroTextBoxModuleName.Text, metroTextBoxFaculty.Text, metroComboBoxSemester.Text, metroTextBoxDuration.Text, metroTextBoxFee.Text, metroTextBoxDescription.Text);
                    ModuleTransactions tr = new ModuleTransactions();
                    tr.updateModule(obj);
                    MetroMessageBox.Show(this, "Data Saved Sucessfully !");
                    clearModule();
                    metroGridModules.Refresh();
                }
            }
            else if (metroComboBoxMods.Text == "Search")
            {
                Module obj = new Module();
                ModuleTransactions tr2 = new ModuleTransactions();
                try
                {
                    obj = tr2.datafill(metroTextBoxSearchMod.Text);
                    metroTextBoxModuleId.Text = obj.getID();
                    metroTextBoxModuleName.Text = obj.getMName();
                    metroTextBoxFaculty.Text = obj.getFaculty();
                    metroComboBoxSemester.Text = obj.getSemester();
                    metroTextBoxDuration.Text = obj.getDuration();
                    metroTextBoxFee.Text = obj.getModulefee();
                    metroTextBoxDescription.Text = obj.getModuleOverview();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Stafford University Registration System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (metroComboBoxMods.Text == "Delete")
            {
                if (metroGridModules.Rows.Count == 0)
                {
                    MetroMessageBox.Show(this, "No data found to delete");
                }
                else
                {
                    DialogResult del = MessageBox.Show("Are you Sure you want to delete :" + metroTextBoxSearchMod.Text + "", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (del == DialogResult.Yes)
                    {
                        ModuleTransactions tr3 = new ModuleTransactions();
                        try
                        {
                            tr3.deleteStudentModule(metroTextBoxSearchMod.Text);
                            tr3.deleteModule(metroTextBoxSearchMod.Text);
                            MetroMessageBox.Show(this, "Successfully Deleted");
                            metroGridModules.Refresh();
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show(ex.Message, "Delete Student", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Ok. As per confirmation, this record has not been deleted.");
                    }
                }
            }
            else
            {
                MetroMessageBox.Show(this, "Please select a option button to Proceed!");
            }
        }

        private void metroRadioAddMod_CheckedChanged(object sender, EventArgs e)
        {
            metroTextBoxSearchMod.Enabled = false;
        }

        private void metroTabPage3_Click(object sender, EventArgs e)
        {

        }

        private void metroButtonRegAddU_Click(object sender, EventArgs e)
        {
            if (metroTextBoxUnames.Text == "" || metroTextBoxPws.Text == "")
            {
                MessageBox.Show("Fields cannot be empty");
            }
            else
            {
                CommonDBTransaction c = new CommonDBTransaction();
                string sql = "SELECT * FROM Registar WHERE Username = '" + metroTextBoxUnames.Text + "'";
                DataTable d = c.searchData(sql);
                metroGridRegs.DataSource = d;
                if (d.Rows.Count > 0)
                {
                    MetroMessageBox.Show(this, "This Data already exist");
                }
                else
                {
                    Registar obj = new Registar(metroTextBoxUnames.Text, metroTextBoxPws.Text);
                    RegistarTransactions tr = new RegistarTransactions();
                    tr.addRegistar(obj);
                    MetroMessageBox.Show(this, "Data Saved Sucessfully !");
                    clearReg();
                }
            }
        }

        private void metroTabPage4_Click(object sender, EventArgs e)
        {

        }

        private void metroLabel42_Click(object sender, EventArgs e)
        {

        }

        private void metroComboBoxFac_SelectedIndexChanged(object sender, EventArgs e)
        {
            Module m = new Module();
            ModuleTransactions mt = new ModuleTransactions();
            mt.dataFillCMBX(metroComboBoxMod.Text);
            m = mt.datafill(metroComboBoxMod.Text);
            metroComboBoxMod.Text = m.getID();
            metroTextBoxModule.Text = m.getMName();
            metroTextBoxFac.Text = m.getFaculty();
            metroTextBoxDur.Text = m.getDuration();
            metroTextBoxMFee.Text = m.getModulefee();
            loadSessionProfessorModule();
            loadSessionStudentModule();
        }

        private void metroTextBox7_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBoxFac_Click(object sender, EventArgs e)
        {

        }

        private void metrobuttonAssignMod_Click(object sender, EventArgs e)
        {
            if (metroComboBoxMod.Text == "" && metroTextBoxFac.Text == "" && metroTextBoxDur.Text == "" && metroTextBoxMFee.Text == "" && metroTextBoxModule.Text == "" && metroTextBoxStDate.Text == "" && metroTextBoxEDate.Text == "")
            {
                MetroMessageBox.Show(this, "Fields cannot be left empty");
            }
            else
            {
                CommonDBTransaction c = new CommonDBTransaction();
                string sql = "SELECT * FROM AssignModule WHERE mid ='" + metroComboBoxMod.Text + "'";
                DataTable d = c.searchData(sql);
                if (d.Rows.Count > 0)
                {
                    MetroMessageBox.Show(this, "This Data already exist");
                }
                else
                {
                    if (metroGridProf.Rows.Count < 2)
                    {
                        MetroMessageBox.Show(this, "Insuffcient Students for the module requirement!");
                    }
                    else if (metroGridProf.Rows.Count > 9)
                    {
                        MetroMessageBox.Show(this, "The number of students for this module has been equiped with!");
                    }
                    else
                    {
                        AssignModule am = new AssignModule();
                        am.setmid(metroComboBoxMod.Text);
                        am.setprogramme(metroTextBoxModule.Text);
                        am.setfaculty(metroTextBoxFac.Text);
                        am.setmodfee(metroTextBoxMFee.Text);
                        am.setduration(metroTextBoxDur.Text);
                        am.setstarddate(metroTextBoxStDate.Text);
                        am.setenddate(metroTextBoxEDate.Text);
                        StringBuilder sb = new StringBuilder();
                        string seperator = "";
                        for (int i = 0; i < metroGridStd.Rows.Count; i++)
                        {
                            sb.AppendFormat("{0}{1}", seperator, metroGridStd.Rows[i].Cells[0].Value.ToString());
                            seperator = ",";
                        }
                        string lid = sb.ToString();
                        am.setlid(lid);
                        StringBuilder sb1 = new StringBuilder();
                        string seperator1 = "";
                        for (int i = 0; i < metroGridProf.Rows.Count; i++)
                        {
                            sb1.AppendFormat("{0}{1}", seperator1, metroGridProf.Rows[i].Cells[0].Value.ToString());
                            seperator1 = ",";
                        }
                        string sid = sb1.ToString();
                        am.setsid(sid);
                        AssignModuleTransaction amt = new AssignModuleTransaction();
                        amt.addModule(am);

                    }
                }
            }

        }

        private void metroTextBoxMobileNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void metroTextBoxMNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void metroTextBoxFee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsNumber(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void metroGridProfessor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Professor_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void metroTabControlR_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tabindex = metroTabControlR.SelectedIndex.ToString();
            if (tabindex == "0")
            {
                DataGridViewStudents();
            }
            else if (tabindex == "1")
            {
                DataGridViewProf();
            }
            else if (tabindex == "2")
            {
                DataGridViewModules();
            }
            else if (tabindex == "3")
            {
                DataGridViewReg();
            }
            else if (tabindex == "4")
            {
                DataGridViewModules();
                loadSessionProfessorModule();
                loadSessionStudentModule();
            }
        }

        private void AssignModules_Click(object sender, EventArgs e)
        {

        }

        private void metroButtonSearchMod_Click(object sender, EventArgs e)
        {
            if (metroComboBoxOptProf.Text == "Search")
            {
                Module obj = new Module();
                ModuleTransactions tr2 = new ModuleTransactions();
                try
                {
                    obj = tr2.datafill(metroTextSearch.Text);
                    metroTextBoxModuleId.Text = obj.getID();
                    metroTextBoxModuleName.Text = obj.getMName();
                    metroComboBoxSemester.Text = obj.getSemester();
                    metroTextBoxFaculty.Text = obj.getFaculty();
                    metroTextBoxDuration.Text = obj.getDuration();
                    metroTextBoxDescription.Text = obj.getModuleOverview();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message, "Stafford University Registration System", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MetroMessageBox.Show(this, "Please select the search option!");
            }
        }

        private void metroTextBoxSearchMod_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBoxModuleId_Click(object sender, EventArgs e)
        {

        }

        private void metroTextBoxModuleName_Click(object sender, EventArgs e)
        {

        }

        private void metroLabelLogout_Click(object sender, EventArgs e)
        {
            DialogResult dr = MetroMessageBox.Show(this, "\n\nContinue Logging Out?", " Registar | LOG OUT", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
            {
                Close();
                new Login().Show();
            }
        }

        private void metroButtonProceed_MouseHover(object sender, EventArgs e)
        {
            ToolTip t1 = new ToolTip();
            t1.Show("Select option from drop down to proceed", metroButtonProceed);
        }

        private void metroButtonProceedProf_MouseHover(object sender, EventArgs e)
        {
            ToolTip t2 = new ToolTip();
            t2.Show("Select option from drop down to proceed", metroButtonProceed);
        }

        private void metroLabel45_Click(object sender, EventArgs e)
        {

        }

        private void metroComboBoxMods_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
