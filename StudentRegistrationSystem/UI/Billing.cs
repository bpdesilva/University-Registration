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
using MetroFramework;

namespace StudentRegistrationSystem.UI
{
    public partial class Billing : MetroForm
    {
        Bitmap bmp;
        Bill b = new Bill();
        public Billing()
        {
            InitializeComponent();
            dtconvert();
        }
        void dtconvert()
        {
            metroDateTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            metroDateTime.CustomFormat = "dd/mm/yy";
            metroLabelDate.Text = metroDateTime.Value.ToString();
        }
        private void Billing_Load(object sender, EventArgs e)
        {

            metroLabelStdId.Text = StudentHome.stdId;
            metroLabelModId.Text = StudentHome.modId;
            metroLabelAmount.Text = StudentHome.modFee;
            b.setsid(StudentHome.stdId);
            b.setmId(StudentHome.modId);
            b.setAmount(StudentHome.modFee);
            b.setbid(metroTextBoxBillno.Text);
            b.setDate(metroLabelDate.Text);
            BillTransaction bt = new BillTransaction();
            bt.updateBill();
        }

        private void metroButtonPay_Click(object sender, EventArgs e)
        {
            if (metroComboBoxPay.Text=="") {
                MetroMessageBox.Show(this, "Please Select payment option!");
            }
            else {
                BillTransaction bt = new BillTransaction();
                bt.addPayment();
                Graphics g = this.CreateGraphics();
                bmp = new Bitmap(this.Size.Width, this.Size.Height, g);
                Graphics mg = Graphics.FromImage(bmp);
                mg.CopyFromScreen(this.Location.X, this.Location.Y, 0, 0, this.Size);
                printPreviewDialog.ShowDialog();
            }
        }

        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bmp, 0, 0);
        }

        private void Back_Click(object sender, EventArgs e)
        {
            Hide();
            StudentHome sh = new StudentHome();
            sh.Show();
        }
    }
}
