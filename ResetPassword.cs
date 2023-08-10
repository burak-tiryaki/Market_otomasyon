using Market_otomasyon.controller;
using Market_otomasyon.Enumaration;
using Market_otomasyon.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Market_otomasyon
{
    public partial class ResetPassword : Form
    {
        int code;

        public ResetPassword()
        {
            InitializeComponent();
        }

        private void ResetPassword_Load(object sender, EventArgs e)
        {
            Controller controller = new Controller();

            List<LoginTable> loginTableList = controller.getLoginTable();

            groupBox2.Visible = false;
            groupBox3.Enabled = false;

            foreach (LoginTable lt in loginTableList)
            {
                cmb_que.Items.Add(lt.securityQue);
            }

            cmb_que.SelectedIndex = 0;
        }

        private void btn_check_Click(object sender, EventArgs e)
        {
            Controller controller = new Controller();

            LoginStatus ls = controller.getVerify(txt_username.Text.Trim(), cmb_que.SelectedItem.ToString(), txt_answer.Text.ToLower());

            if (ls == LoginStatus.Success)
            {
                groupBox3.Enabled = true;
            }
            else if (ls == LoginStatus.missingParameter)
            {
                MessageBox.Show("Boş alan bırakmayınız!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Hatalı cevap veya kullanıcı adı!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btn_sendCode_Click(object sender, EventArgs e)
        {
            Controller controller = new Controller();

            Random rnd = new Random();
            code = rnd.Next(000000, 999999);

            if (!string.IsNullOrEmpty(txt_email.Text))
            {
                if (txt_email.Text == controller.checkEmail(txt_username.Text))
                {
                    #region Sent MAil
                    MailAddress mailReceiver = new MailAddress(txt_email.Text, txt_username.Text);

                    MailAddress mailSender = new MailAddress("burak459@outlook.com", "Burak");

                    MailMessage msg = new MailMessage();

                    msg.To.Add(mailReceiver);
                    msg.From = mailSender;

                    msg.Subject = "Change Password";
                    msg.Body = "Recovery code: " + code;

                    SmtpClient smtp = new SmtpClient("smtp-mail.outlook.com", 587);
                    smtp.Credentials = new NetworkCredential("burak459@outlook.com", "burak123");
                    smtp.EnableSsl = true;
                    smtp.Send(msg);

                    MessageBox.Show("Verification code sent", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                #endregion
                }
                else
                    MessageBox.Show("Enter the e-mail adress linked to your account!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                MessageBox.Show("Email adress cannot be empty!","Error!",MessageBoxButtons.OK,MessageBoxIcon.Error);    

        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            if (code.ToString() == txt_code.Text)
            {
                groupBox2.Visible = true;
            }
            else
                MessageBox.Show("Wrong verification code!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btn_change_Click(object sender, EventArgs e)
        {
            Controller ctrl = new Controller();

            if (txt_newPassword.Text == txt_passwordConfirm.Text)
            {
               LoginStatus ls = ctrl.ChangePasswrod(txt_email.Text,txt_passwordConfirm.Text);

                if (ls== LoginStatus.Success)
                {
                    MessageBox.Show("Password changed successfully!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                    MessageBox.Show("Could not change password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Confirm password do not match!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
