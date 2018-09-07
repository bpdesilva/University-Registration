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
using StudentRegistrationSystem.UI;

namespace StudentRegistrationSystem
{
    public partial class Login : MetroForm
    {
        public static string u;
        public Login()
        {
            InitializeComponent();
        }
        StudentTransactions st = new StudentTransactions();
        RegistarTransactions rt = new RegistarTransactions();
        ProffessorTransactions pt = new ProffessorTransactions();

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void btnLogin_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string type = metroComboBoxType.SelectedItem.ToString();
            metroComboBoxType.Enabled = false;
            if (txtUsername.Text == "" && txtPassword.Text == "" || type.Equals(""))
            {
                MetroMessageBox.Show(this, "Please fill all fields in order to proceed.", "Fields are Empty ! ", MessageBoxButtons.OKCancel, MessageBoxIcon.Hand);

            }
            else
            {
                switch (type)
                {
                    case "Student":
                        Student s = new Student();
                        s.setUsername(txtUsername.Text);
                        s.setPassword(txtPassword.Text);
                        if (st.Login(s) == true)
                        {
                            u = txtUsername.Text;
                            Hide();
                            StudentHome sh = new StudentHome();
                            sh.Show();
                        }
                        break;
                    case "Professor":
                        Professor l = new Professor();
                        l.setUsername(txtUsername.Text);
                        l.setPassword(txtPassword.Text);
                        if (pt.Login(l)==true) {
                            u = txtUsername.Text;
                           Hide();
                            ProfessorHome ph = new ProfessorHome();
                            ph.Show();
                        }
                        break;
                    case "Registar":
                        Registar r = new Registar();
                        r.setUsername(txtUsername.Text);
                        r.setPassword(txtPassword.Text);
                        if (rt.Login(r)==true) {
                            u = txtUsername.Text;
                            Hide();
                            RegistarHome rh = new RegistarHome();
                            rh.Show();
                        }
                        break;
                    default:
                        break;
                }


            }
        }

        private void metroComboBoxType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
