using Market_otomasyon.controller;
using Market_otomasyon.Enumaration;
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
    public partial class ProductPanel : Form
    {
        Controller controller = new Controller();

        public ProductPanel()
        {
            InitializeComponent();
        }

        private void ProductPanel_Load(object sender, EventArgs e)
        {
            FillData();
        }

        private void FillData()
        {
            dataGridView1.DataSource = controller.getProduct();
            dataGridView1.Columns[7].Visible = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lbl_id.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txt_barcode.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            lbl_created.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            lbl_updated.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txt_name.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txt_stock.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txt_price.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            RecordStatus rs = controller.addProduct(
                txt_barcode.Text,
                txt_name.Text,
                int.Parse(txt_stock.Text),
                int.Parse(txt_price.Text));

            if (rs == RecordStatus.Success)
                MessageBox.Show("Record successfully added.");
            else if (rs == RecordStatus.Failed)
                MessageBox.Show("Record canNOT be added!");
            else if (rs == RecordStatus.MissingParameter)
                MessageBox.Show("Please, do NOT leave empty space.");

            FillData();

            //Buraya kayıt eklendikten sonra son eklenen kayıtı seç, yazdır.
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            RecordStatus rs = controller.updateProduct(
                int.Parse(lbl_id.Text),
                txt_barcode.Text,
                txt_name.Text,
                int.Parse(txt_stock.Text),
                int.Parse(txt_price.Text));

            if (rs == RecordStatus.Success)
                MessageBox.Show("Record successfully updated.");
            else if (rs == RecordStatus.Failed)
                MessageBox.Show("Record canNOT be update!");
            else if (rs == RecordStatus.MissingParameter)
                MessageBox.Show("Please, do NOT leave empty space.");

            FillData();
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {

            DialogResult dr = MessageBox.Show("Are you sure you want to delete this record?","?",MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.Yes)
            {
                RecordStatus rs = controller.deleteProduct(int.Parse(lbl_id.Text));

                if (rs == RecordStatus.Success)
                    MessageBox.Show("Record successfully deleted.");
                else if (rs == RecordStatus.Failed)
                    MessageBox.Show("Record canNOT be delete!");
                else if (rs == RecordStatus.MissingParameter)
                    MessageBox.Show("Please, choose some record on the list!");

                FillData();
            }


            
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < groupBox1.Controls.Count; i++)
            {
                if (groupBox1.Controls[i] is TextBox)
                {
                    groupBox1.Controls[i].Text = string.Empty;
                }
            }

            lbl_id.Text = "000";
            lbl_updated.Text = "00.00.0000 00.00.00";
            lbl_created.Text = "00.00.0000 00.00.00";
        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            AdminPanel adminPanel = new AdminPanel();

            adminPanel.Show();
            this.Hide();
        }

        private void ProductPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
