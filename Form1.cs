using Market_otomasyon.controller;
using Market_otomasyon.Enumaration;
using Market_otomasyon.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Market_otomasyon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            Controller controller = new Controller();

            LoginUser result = controller.Login(txt_username.Text, txt_password.Text);

            if (result != null && result.status == LoginStatus.Success && result.authority == "admin")
            {
                AdminPanel adminPanel = new AdminPanel();
                adminPanel.Show();
                this.Hide();
            }
            else if (result != null && result.status == LoginStatus.Success && result.authority == "staff")
            {
                StaffPanel staffPanel = new StaffPanel();
                staffPanel.Show();
                this.Hide();
            }
            else if (result != null && result.status == LoginStatus.Failed)
            {
                MessageBox.Show("Username or password wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Do not leave empty space!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void lbl_refreshPassword_Click(object sender, EventArgs e)
        {
            ResetPassword resetPassword = new ResetPassword();

            resetPassword.Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
