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
    public partial class AdminPanel : Form
    {
        string resourcesPath = System.AppDomain.CurrentDomain.BaseDirectory + "\\..\\..\\Resources\\";

        public AdminPanel()
        {
            InitializeComponent();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            btnImage();
        }

        private void btnImage()
        {
            imageList_admin.Images.Add(Image.FromFile(resourcesPath + "\\adminPanelPic\\cikis.ico"));
            imageList_admin.Images.Add(Image.FromFile(resourcesPath + "\\adminPanelPic\\product.ico"));
            imageList_admin.Images.Add(Image.FromFile(resourcesPath + "\\adminPanelPic\\user.ico"));

            btn_userPanel.ImageList  = imageList_admin;
            btn_userPanel.ImageIndex = 2;
            button1.ImageList        = imageList_admin;
            button1.ImageIndex       = 1;
            button2.ImageList        = imageList_admin;
            button2.ImageIndex       = 0;
        }

        private void btn_userPanel_Click(object sender, EventArgs e)
        {
            this.Hide();
            userControlPanel userControlPanel = new userControlPanel();
            userControlPanel.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProductPanel productPanel = new ProductPanel();
            productPanel.Show();
            this.Hide();
        }
    }
}
