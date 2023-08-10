namespace Market_otomasyon
{
    partial class StaffPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StaffPanel));
            this.btn_meat = new System.Windows.Forms.Button();
            this.ımageList1 = new System.Windows.Forms.ImageList(this.components);
            this.btn_milk = new System.Windows.Forms.Button();
            this.btn_vegetable = new System.Windows.Forms.Button();
            this.btn_legumes = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lbl_time = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // btn_meat
            // 
            this.btn_meat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_meat.ImageKey = "et.ico";
            this.btn_meat.ImageList = this.ımageList1;
            this.btn_meat.Location = new System.Drawing.Point(28, 39);
            this.btn_meat.Name = "btn_meat";
            this.btn_meat.Size = new System.Drawing.Size(123, 114);
            this.btn_meat.TabIndex = 0;
            this.btn_meat.UseVisualStyleBackColor = true;
            // 
            // ımageList1
            // 
            this.ımageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ımageList1.ImageStream")));
            this.ımageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ımageList1.Images.SetKeyName(0, "baklagil.ico");
            this.ımageList1.Images.SetKeyName(1, "et.ico");
            this.ımageList1.Images.SetKeyName(2, "meyveAndsebze.ico");
            this.ımageList1.Images.SetKeyName(3, "süt.ico");
            // 
            // btn_milk
            // 
            this.btn_milk.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_milk.ImageKey = "süt.ico";
            this.btn_milk.ImageList = this.ımageList1;
            this.btn_milk.Location = new System.Drawing.Point(210, 39);
            this.btn_milk.Name = "btn_milk";
            this.btn_milk.Size = new System.Drawing.Size(123, 114);
            this.btn_milk.TabIndex = 1;
            this.btn_milk.UseVisualStyleBackColor = true;
            // 
            // btn_vegetable
            // 
            this.btn_vegetable.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_vegetable.ImageKey = "meyveAndsebze.ico";
            this.btn_vegetable.ImageList = this.ımageList1;
            this.btn_vegetable.Location = new System.Drawing.Point(210, 170);
            this.btn_vegetable.Name = "btn_vegetable";
            this.btn_vegetable.Size = new System.Drawing.Size(123, 114);
            this.btn_vegetable.TabIndex = 3;
            this.btn_vegetable.UseVisualStyleBackColor = true;
            this.btn_vegetable.Click += new System.EventHandler(this.btn_vegetable_Click);
            // 
            // btn_legumes
            // 
            this.btn_legumes.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_legumes.ImageKey = "baklagil.ico";
            this.btn_legumes.ImageList = this.ımageList1;
            this.btn_legumes.Location = new System.Drawing.Point(28, 170);
            this.btn_legumes.Name = "btn_legumes";
            this.btn_legumes.Size = new System.Drawing.Size(123, 114);
            this.btn_legumes.TabIndex = 2;
            this.btn_legumes.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.ForeColor = System.Drawing.Color.Red;
            this.button1.Location = new System.Drawing.Point(108, 300);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 32);
            this.button1.TabIndex = 4;
            this.button1.Text = "EXIT";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbl_time
            // 
            this.lbl_time.AutoSize = true;
            this.lbl_time.Location = new System.Drawing.Point(227, 9);
            this.lbl_time.Name = "lbl_time";
            this.lbl_time.Size = new System.Drawing.Size(106, 13);
            this.lbl_time.TabIndex = 5;
            this.lbl_time.Text = "00.00.0000 00:00:00";
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // StaffPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 344);
            this.Controls.Add(this.lbl_time);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_legumes);
            this.Controls.Add(this.btn_vegetable);
            this.Controls.Add(this.btn_milk);
            this.Controls.Add(this.btn_meat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "StaffPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "StaffPanel";
            this.Load += new System.EventHandler(this.StaffPanel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_meat;
        private System.Windows.Forms.ImageList ımageList1;
        private System.Windows.Forms.Button btn_milk;
        private System.Windows.Forms.Button btn_vegetable;
        private System.Windows.Forms.Button btn_legumes;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lbl_time;
        private System.Windows.Forms.Timer timer1;
    }
}