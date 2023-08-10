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
    public partial class userControlPanel : Form
    {
        Controller controller = new Controller();
        public userControlPanel()
        {
            InitializeComponent();
        }

        private void userControlPanel_Load(object sender, EventArgs e)
        {
            FillData();
            
        }

        private void FillData()
        {
            List<LoginUser> users = controller.getUsers();
            
            dataGridView1.DataSource = users;
            dataGridView1.Columns[7].Visible = false;
            //---------DataGridView Filled-------------------

            foreach (LoginUser user in users)
            {
                if (!cb_authority.Items.Contains(user.authority))
                {
                    cb_authority.Items.Add(user.authority);
                }
                //-------- Authority Filled -----------

                if (!cb_question.Items.Contains(user.securityQue))
                {
                    cb_question.Items.Add(user.securityQue);
                }
                //-------- Sec Question Filled -----------
            }


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lbl_id.Text       = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_username.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txt_password.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txt_mail.Text     = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txt_answer.Text   = dataGridView1.CurrentRow.Cells[6].Value.ToString();

            cb_authority.SelectedIndex = cb_authority.Items.IndexOf(dataGridView1.CurrentRow.Cells[3].Value.ToString());

            cb_question.SelectedIndex = cb_question.Items.IndexOf(dataGridView1.CurrentRow.Cells[5].Value.ToString());
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            RecordStatus rs = controller.addUser(
                txt_username.Text,
                txt_password.Text,
                cb_authority.SelectedItem.ToString(),
                txt_mail.Text,
                cb_question.SelectedItem.ToString(),
                txt_answer.Text);

            if (rs==RecordStatus.Success)
                MessageBox.Show("Registration successfully added.");
            else if (rs== RecordStatus.Failed)
                MessageBox.Show("Failed to add record.");
            else if(rs == RecordStatus.MissingParameter)
                MessageBox.Show("Do not leave empty space!");

            FillData();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Are you sure you want to delete the record?", "info", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                RecordStatus rs = controller.deleteUser(int.Parse(lbl_id.Text));

                if (rs == RecordStatus.Success)
                    MessageBox.Show("Registration successfully deleted.");
                else if (rs == RecordStatus.Failed)
                    MessageBox.Show("record could not be deleted!.");
                else if (rs == RecordStatus.MissingParameter)
                    MessageBox.Show("Do not leave empty space!");
            }

            FillData();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            RecordStatus rs = controller.updateUser(
                int.Parse(lbl_id.Text),
                txt_username.Text,
                txt_password.Text,
                cb_authority.SelectedItem.ToString(),
                txt_mail.Text,
                cb_question.SelectedItem.ToString(),
                txt_answer.Text);

            if (rs == RecordStatus.Success)
                MessageBox.Show("Registration successfully UPDATED.");
            else if (rs == RecordStatus.Failed)
                MessageBox.Show("record could NOT be updated!.");
            //else if (rs == RecordStatus.MissingParameter)
            //    MessageBox.Show("Do not leave empty space!");

            FillData();
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            AdminPanel adminPanel = new AdminPanel();
            adminPanel.Show();
            this.Hide();
        }
    }
}
