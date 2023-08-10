namespace Market_otomasyon
{
    partial class AdminPanel
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
            this.btn_userPanel = new System.Windows.Forms.Button();
            this.imageList_admin = new System.Windows.Forms.ImageList(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_userPanel
            // 
            this.btn_userPanel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_userPanel.ImageKey = "user.ico";
            this.btn_userPanel.ImageList = this.imageList_admin;
            this.btn_userPanel.Location = new System.Drawing.Point(12, 21);
            this.btn_userPanel.Name = "btn_userPanel";
            this.btn_userPanel.Size = new System.Drawing.Size(105, 106);
            this.btn_userPanel.TabIndex = 0;
            this.btn_userPanel.UseVisualStyleBackColor = true;
            this.btn_userPanel.Click += new System.EventHandler(this.btn_userPanel_Click);
            // 
            // imageList_admin
            // 
            this.imageList_admin.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList_admin.ImageSize = new System.Drawing.Size(85, 85);
            this.imageList_admin.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.ImageKey = "product.ico";
            this.button1.ImageList = this.imageList_admin;
            this.button1.Location = new System.Drawing.Point(150, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 106);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.ImageKey = "cikis.ico";
            this.button2.ImageList = this.imageList_admin;
            this.button2.Location = new System.Drawing.Point(78, 158);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(105, 106);
            this.button2.TabIndex = 0;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // AdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 279);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btn_userPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "AdminPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminPanel";
            this.Load += new System.EventHandler(this.AdminPanel_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_userPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ImageList imageList_admin;
    }
}