using AForge.Video.DirectShow;
using Market_otomasyon.controller;
using Market_otomasyon.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Resources;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using ZXing;
using static System.Net.Mime.MediaTypeNames;

namespace Market_otomasyon
{
    public partial class Checkout : Form
    {
        int number1;
        int number2;
        int operation;

        FilterInfoCollection fic;
        VideoCaptureDevice vcd;

        string resourcesPath = System.Windows.Forms.Application.StartupPath + "\\..\\..\\Resources\\";


        public Checkout()
        {
            InitializeComponent();
        }

        private void Checkout_Load(object sender, EventArgs e)
        {
            #region Calculator icon
            txt_calculator.Text = "0";

            timer_clock.Start();

            lbl_sum.Visible= false;
            lbl_minus.Visible= false;
            lbl_times.Visible= false;
            lbl_divider.Visible = false;
            lbl_equal.Visible= false;
            #endregion

            fic = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            foreach(FilterInfo camera in fic)
            {
                cmb_cam.Items.Add(camera.Name);
            }
            //cmb_cam.SelectedIndex = 0;

            string appPath = System.Windows.Forms.Application.StartupPath;
            picbox_cam.Image = System.Drawing.Image.FromFile($"{appPath}\\..\\..\\Resources\\Camera.png");

        }
        #region Calculator
        private void number_click(object sender, EventArgs e)
        {
            if (txt_calculator.Text == "0")
            {
                txt_calculator.Text = "";
            }

            txt_calculator.Text += ((Button)sender).Text;//Basılan button'un text'ini aldık
        }

        private void btn_sum_Click(object sender, EventArgs e)
        {
            lbl_sum.Visible = true;
            lbl_minus.Visible = false;
            lbl_times.Visible = false;
            lbl_divider.Visible = false;
            lbl_equal.Visible = false;

            operation = 1; // Toplama işlemi
            number1 = int.Parse(txt_calculator.Text);
            txt_calculator.Text = "0";
        }


        private void btn_clear_Click(object sender, EventArgs e)
        {
            lbl_sum.Visible = false;
            lbl_minus.Visible = false;
            lbl_times.Visible = false;
            lbl_divider.Visible = false;
            lbl_equal.Visible = false;

            txt_calculator.Text = "0";
        }

        private void btn_minus_Click(object sender, EventArgs e)
        {
            lbl_sum.Visible = false;
            lbl_minus.Visible = true;
            lbl_times.Visible = false;
            lbl_divider.Visible = false;
            lbl_equal.Visible = false;

            operation = 2; // çıkarma işlemi
            number1 = int.Parse(txt_calculator.Text);
            txt_calculator.Text = "0";
        }

        private void btn_times_Click(object sender, EventArgs e)
        {
            lbl_sum.Visible = false;
            lbl_minus.Visible = false;
            lbl_times.Visible = true;
            lbl_divider.Visible = false;
            lbl_equal.Visible = false;

            operation = 3; // çarpma işlemi
            number1 = int.Parse(txt_calculator.Text);
            txt_calculator.Text = "0";
        }

        private void btn_divider_Click(object sender, EventArgs e)
        {
            lbl_sum.Visible = false;
            lbl_minus.Visible = false;
            lbl_times.Visible = false;
            lbl_divider.Visible = true;
            lbl_equal.Visible = false;

            operation = 4; // bölme işlemi
            number1 = int.Parse(txt_calculator.Text);
            txt_calculator.Text = "0";
        }
        private void btn_result_Click(object sender, EventArgs e)
        {
            lbl_sum.Visible = false;
            lbl_minus.Visible = false;
            lbl_times.Visible = false;
            lbl_divider.Visible = false;
            lbl_equal.Visible = true;

            if (operation == 1)
            {
                number2 = int.Parse(txt_calculator.Text);
                txt_calculator.Text = (number1 + number2).ToString();
            }
            else if (operation == 2)
            {
                number2 = int.Parse(txt_calculator.Text);
                txt_calculator.Text = (number1 - number2).ToString();
            }
            else if (operation == 3)
            {
                number2 = int.Parse(txt_calculator.Text);
                txt_calculator.Text = (number1 * number2).ToString();
            }
            else if (operation == 4)
            {
                number2 = int.Parse(txt_calculator.Text);
                txt_calculator.Text = (number1 / number2).ToString();
            }
        }

        private void btn_backspace_Click(object sender, EventArgs e)
        {
            if (txt_calculator.Text.Length>1)
            {

            txt_calculator.Text = txt_calculator.Text.Substring(0, txt_calculator.Text.Length - 1);
            }
            else if (txt_calculator.Text.Length ==1)
            {
                txt_calculator.Text = "0";
            }
        }
        #endregion
        private void timer_clock_Tick(object sender, EventArgs e)
        {
            lbl_clock.Text = DateTime.Now.ToString();
        }

        private void btn_camOpen_Click(object sender, EventArgs e)
        {
            vcd = new VideoCaptureDevice(fic[cmb_cam.SelectedIndex].MonikerString);

            vcd.NewFrame += Vcd_NewFrame;

            vcd.Start();

            timer_barcode.Start();
        }

        private void Vcd_NewFrame(object sender, AForge.Video.NewFrameEventArgs eventArgs)
        {
            picbox_cam.Image = (Bitmap)eventArgs.Frame.Clone();
        }

        private void btn_camClose_Click(object sender, EventArgs e)
        {
            
            vcd.Stop();
         
            picbox_cam.Image = System.Drawing.Image.FromFile($"{resourcesPath}Camera.png");

            timer_barcode.Stop();
        }

        private void timer_barcode_Tick(object sender, EventArgs e)
        {
            if (picbox_cam.Image != null)
            {
                BarcodeReader barcodeReader = new BarcodeReader();
                Result result = barcodeReader.Decode((Bitmap)picbox_cam.Image);

                if (result != null)
                {
                    txt_barcode.Text = result.ToString();
                    //timer_barcode.Stop();
                }
            }
        }

        private void txt_barcode_TextChanged(object sender, EventArgs e)
        {
            Controller controller = new Controller();

            Product getPro = controller.getProduct(txt_barcode.Text);

            txt_calculator.Text = getPro.price.ToString();
            lbl_productName.Text = getPro.name;

            SoundPlayer sound = new SoundPlayer(resourcesPath + "barkod.wav");

            sound.Play();
        }

        private void btn_exit_Click(object sender, EventArgs e)
        {
            StaffPanel staffPanel = new StaffPanel();
            staffPanel.Show();
            this.Hide();
        }
    }
}
