namespace Bank_Card_Perso
{
    partial class Photoupload
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Photoupload));
            this.buttonSelectImg = new EnhancedGlassButton.GlassButton();
            this.buttonImgGallery = new EnhancedGlassButton.GlassButton();
            this.btnImgRandom = new EnhancedGlassButton.GlassButton();
            this.btnHome = new EnhancedGlassButton.GlassButton();
            this.btnRotate = new EnhancedGlassButton.GlassButton();
            this.panelUploadPhoto = new System.Windows.Forms.Panel();
            this.panelPhoto = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.picBoxOne = new System.Windows.Forms.PictureBox();
            this.glassButton9 = new EnhancedGlassButton.GlassButton();
            this.glassButton8 = new EnhancedGlassButton.GlassButton();
            this.glassButton7 = new EnhancedGlassButton.GlassButton();
            this.glassButton6 = new EnhancedGlassButton.GlassButton();
            this.glassButton2 = new EnhancedGlassButton.GlassButton();
            this.btnExpressMode = new EnhancedGlassButton.GlassButton();
            this.ImgSelectPanel = new System.Windows.Forms.Panel();
            this.listViewGallery = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.label2 = new System.Windows.Forms.Label();
            this.panelUploadPhoto.SuspendLayout();
            this.panelPhoto.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxOne)).BeginInit();
            this.ImgSelectPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonSelectImg
            // 
            this.buttonSelectImg.BackColor = System.Drawing.Color.OrangeRed;
            this.buttonSelectImg.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSelectImg.BackgroundImage")));
            this.buttonSelectImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonSelectImg.GlowColor = System.Drawing.Color.Yellow;
            this.buttonSelectImg.Location = new System.Drawing.Point(352, 553);
            this.buttonSelectImg.Name = "buttonSelectImg";
            this.buttonSelectImg.Size = new System.Drawing.Size(163, 92);
            this.buttonSelectImg.TabIndex = 0;
            this.buttonSelectImg.ToolTipText = "Upload your photo";
            this.buttonSelectImg.Click += new System.EventHandler(this.buttonSelectImg_Click);
            // 
            // buttonImgGallery
            // 
            this.buttonImgGallery.BackColor = System.Drawing.Color.OrangeRed;
            this.buttonImgGallery.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonImgGallery.BackgroundImage")));
            this.buttonImgGallery.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonImgGallery.GlowColor = System.Drawing.Color.Yellow;
            this.buttonImgGallery.Location = new System.Drawing.Point(183, 553);
            this.buttonImgGallery.Name = "buttonImgGallery";
            this.buttonImgGallery.Size = new System.Drawing.Size(163, 92);
            this.buttonImgGallery.TabIndex = 1;
            this.buttonImgGallery.ToolTipText = "Browse our gallery";
            this.buttonImgGallery.Click += new System.EventHandler(this.buttonImgGallery_Click);
            // 
            // btnImgRandom
            // 
            this.btnImgRandom.BackColor = System.Drawing.Color.OrangeRed;
            this.btnImgRandom.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImgRandom.BackgroundImage")));
            this.btnImgRandom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImgRandom.GlowColor = System.Drawing.Color.Yellow;
            this.btnImgRandom.Location = new System.Drawing.Point(521, 553);
            this.btnImgRandom.Name = "btnImgRandom";
            this.btnImgRandom.Size = new System.Drawing.Size(163, 92);
            this.btnImgRandom.TabIndex = 2;
            this.btnImgRandom.ToolTipText = "Random a photo ";
            this.btnImgRandom.Click += new System.EventHandler(this.btnImgRandom_Click);
            // 
            // btnHome
            // 
            this.btnHome.BackColor = System.Drawing.Color.OrangeRed;
            this.btnHome.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnHome.BackgroundImage")));
            this.btnHome.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnHome.GlowColor = System.Drawing.Color.Yellow;
            this.btnHome.Location = new System.Drawing.Point(14, 553);
            this.btnHome.Name = "btnHome";
            this.btnHome.Size = new System.Drawing.Size(163, 90);
            this.btnHome.TabIndex = 3;
            this.btnHome.ToolTipText = "Home Page";
            this.btnHome.Click += new System.EventHandler(this.btnHome_Click);
            // 
            // btnRotate
            // 
            this.btnRotate.BackColor = System.Drawing.Color.OrangeRed;
            this.btnRotate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRotate.BackgroundImage")));
            this.btnRotate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRotate.GlowColor = System.Drawing.Color.Yellow;
            this.btnRotate.Location = new System.Drawing.Point(690, 553);
            this.btnRotate.Name = "btnRotate";
            this.btnRotate.Size = new System.Drawing.Size(163, 92);
            this.btnRotate.TabIndex = 4;
            this.btnRotate.ToolTipText = "Rotate the image";
            this.btnRotate.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnRotate_MouseClick);
            // 
            // panelUploadPhoto
            // 
            this.panelUploadPhoto.BackColor = System.Drawing.Color.Transparent;
            this.panelUploadPhoto.Controls.Add(this.panelPhoto);
            this.panelUploadPhoto.Controls.Add(this.glassButton9);
            this.panelUploadPhoto.Controls.Add(this.glassButton8);
            this.panelUploadPhoto.Controls.Add(this.glassButton7);
            this.panelUploadPhoto.Controls.Add(this.glassButton6);
            this.panelUploadPhoto.Controls.Add(this.glassButton2);
            this.panelUploadPhoto.Controls.Add(this.btnExpressMode);
            this.panelUploadPhoto.Controls.Add(this.btnHome);
            this.panelUploadPhoto.Controls.Add(this.btnRotate);
            this.panelUploadPhoto.Controls.Add(this.buttonImgGallery);
            this.panelUploadPhoto.Controls.Add(this.btnImgRandom);
            this.panelUploadPhoto.Controls.Add(this.buttonSelectImg);
            this.panelUploadPhoto.Controls.Add(this.ImgSelectPanel);
            this.panelUploadPhoto.Location = new System.Drawing.Point(-2, -1);
            this.panelUploadPhoto.Name = "panelUploadPhoto";
            this.panelUploadPhoto.Size = new System.Drawing.Size(860, 646);
            this.panelUploadPhoto.TabIndex = 5;
            // 
            // panelPhoto
            // 
            this.panelPhoto.Controls.Add(this.label1);
            this.panelPhoto.Controls.Add(this.picBoxOne);
            this.panelPhoto.Location = new System.Drawing.Point(14, 126);
            this.panelPhoto.Name = "panelPhoto";
            this.panelPhoto.Size = new System.Drawing.Size(701, 386);
            this.panelPhoto.TabIndex = 19;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 26);
            this.label1.TabIndex = 7;
            this.label1.Text = "Photo :";
            // 
            // picBoxOne
            // 
            this.picBoxOne.Location = new System.Drawing.Point(18, 44);
            this.picBoxOne.Name = "picBoxOne";
            this.picBoxOne.Size = new System.Drawing.Size(649, 315);
            this.picBoxOne.TabIndex = 5;
            this.picBoxOne.TabStop = false;
            this.picBoxOne.Paint += new System.Windows.Forms.PaintEventHandler(this.picBoxOne_Paint);
            // 
            // glassButton9
            // 
            this.glassButton9.BackColor = System.Drawing.Color.Blue;
            this.glassButton9.CornerRadius = 100;
            this.glassButton9.Enabled = false;
            this.glassButton9.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.glassButton9.InnerBorderColor = System.Drawing.Color.Blue;
            this.glassButton9.Location = new System.Drawing.Point(214, 3);
            this.glassButton9.Name = "glassButton9";
            this.glassButton9.OuterBorderColor = System.Drawing.Color.DarkBlue;
            this.glassButton9.Size = new System.Drawing.Size(132, 117);
            this.glassButton9.TabIndex = 18;
            this.glassButton9.Text = "Step 2 : Brightness && Contrast";
            // 
            // glassButton8
            // 
            this.glassButton8.BackColor = System.Drawing.Color.Blue;
            this.glassButton8.CornerRadius = 100;
            this.glassButton8.Enabled = false;
            this.glassButton8.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.glassButton8.InnerBorderColor = System.Drawing.Color.Blue;
            this.glassButton8.Location = new System.Drawing.Point(373, 3);
            this.glassButton8.Name = "glassButton8";
            this.glassButton8.OuterBorderColor = System.Drawing.Color.DarkBlue;
            this.glassButton8.Size = new System.Drawing.Size(132, 117);
            this.glassButton8.TabIndex = 17;
            this.glassButton8.Text = "Step 3 : Frame && Effect";
            // 
            // glassButton7
            // 
            this.glassButton7.BackColor = System.Drawing.Color.Blue;
            this.glassButton7.CornerRadius = 100;
            this.glassButton7.Enabled = false;
            this.glassButton7.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.glassButton7.InnerBorderColor = System.Drawing.Color.Blue;
            this.glassButton7.Location = new System.Drawing.Point(524, 3);
            this.glassButton7.Name = "glassButton7";
            this.glassButton7.OuterBorderColor = System.Drawing.Color.DarkBlue;
            this.glassButton7.Size = new System.Drawing.Size(132, 117);
            this.glassButton7.TabIndex = 16;
            this.glassButton7.Text = "Step 4 : Favourite Text";
            // 
            // glassButton6
            // 
            this.glassButton6.BackColor = System.Drawing.Color.Blue;
            this.glassButton6.CornerRadius = 100;
            this.glassButton6.Enabled = false;
            this.glassButton6.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.glassButton6.InnerBorderColor = System.Drawing.Color.Blue;
            this.glassButton6.Location = new System.Drawing.Point(677, 3);
            this.glassButton6.Name = "glassButton6";
            this.glassButton6.OuterBorderColor = System.Drawing.Color.DarkBlue;
            this.glassButton6.Size = new System.Drawing.Size(132, 117);
            this.glassButton6.TabIndex = 15;
            this.glassButton6.Text = "Step 5 : Completed";
            // 
            // glassButton2
            // 
            this.glassButton2.AlternativeFocusBorderColor = System.Drawing.Color.Yellow;
            this.glassButton2.BackColor = System.Drawing.Color.Lime;
            this.glassButton2.CornerRadius = 100;
            this.glassButton2.Enabled = false;
            this.glassButton2.Font = new System.Drawing.Font("Corbel", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.glassButton2.InnerBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.glassButton2.Location = new System.Drawing.Point(60, 3);
            this.glassButton2.Name = "glassButton2";
            this.glassButton2.OuterBorderColor = System.Drawing.Color.Lime;
            this.glassButton2.Size = new System.Drawing.Size(132, 117);
            this.glassButton2.TabIndex = 13;
            this.glassButton2.Text = "Step 1 : Choose Your Photo";
            // 
            // btnExpressMode
            // 
            this.btnExpressMode.CornerRadius = 100;
            this.btnExpressMode.InnerBorderColor = System.Drawing.Color.ForestGreen;
            this.btnExpressMode.Location = new System.Drawing.Point(733, 269);
            this.btnExpressMode.Name = "btnExpressMode";
            this.btnExpressMode.OuterBorderColor = System.Drawing.Color.Chartreuse;
            this.btnExpressMode.ShineColor = System.Drawing.Color.Aqua;
            this.btnExpressMode.ShowSpecialSymbol = true;
            this.btnExpressMode.Size = new System.Drawing.Size(104, 99);
            this.btnExpressMode.SpecialSymbol = EnhancedGlassButton.GlassButton.SpecialSymbols.ArrowRight;
            this.btnExpressMode.SpecialSymbolColor = System.Drawing.Color.Lime;
            this.btnExpressMode.TabIndex = 6;
            this.btnExpressMode.ToolTipText = "Next Step";
            this.btnExpressMode.Click += new System.EventHandler(this.btnExpressMode_Click);
            // 
            // ImgSelectPanel
            // 
            this.ImgSelectPanel.Controls.Add(this.listViewGallery);
            this.ImgSelectPanel.Controls.Add(this.label2);
            this.ImgSelectPanel.Location = new System.Drawing.Point(14, 126);
            this.ImgSelectPanel.Name = "ImgSelectPanel";
            this.ImgSelectPanel.Size = new System.Drawing.Size(701, 386);
            this.ImgSelectPanel.TabIndex = 20;
            // 
            // listViewGallery
            // 
            this.listViewGallery.BackColor = System.Drawing.SystemColors.HotTrack;
            this.listViewGallery.LargeImageList = this.imageList1;
            this.listViewGallery.Location = new System.Drawing.Point(21, 42);
            this.listViewGallery.Name = "listViewGallery";
            this.listViewGallery.Size = new System.Drawing.Size(649, 315);
            this.listViewGallery.TabIndex = 9;
            this.listViewGallery.UseCompatibleStateImageBehavior = false;
            this.listViewGallery.DoubleClick += new System.EventHandler(this.listViewGallery_DoubleClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "airplane.jpg");
            this.imageList1.Images.SetKeyName(1, "hardrock.jpg");
            this.imageList1.Images.SetKeyName(2, "linux.png");
            this.imageList1.Images.SetKeyName(3, "maybank.jpg");
            this.imageList1.Images.SetKeyName(4, "tiger.jpg");
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Showcard Gothic", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Transparent;
            this.label2.Location = new System.Drawing.Point(16, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 26);
            this.label2.TabIndex = 8;
            this.label2.Text = "Gallery :";
            // 
            // Photoupload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(860, 646);
            this.Controls.Add(this.panelUploadPhoto);
            this.Name = "Photoupload";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Upload Photo";
            this.panelUploadPhoto.ResumeLayout(false);
            this.panelPhoto.ResumeLayout(false);
            this.panelPhoto.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picBoxOne)).EndInit();
            this.ImgSelectPanel.ResumeLayout(false);
            this.ImgSelectPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private EnhancedGlassButton.GlassButton buttonSelectImg;
        private EnhancedGlassButton.GlassButton buttonImgGallery;
        private EnhancedGlassButton.GlassButton btnImgRandom;
        private EnhancedGlassButton.GlassButton btnHome;
        private EnhancedGlassButton.GlassButton btnRotate;
        private System.Windows.Forms.Panel panelUploadPhoto;
        private EnhancedGlassButton.GlassButton btnExpressMode;
        private System.Windows.Forms.PictureBox picBoxOne;
        private System.Windows.Forms.Label label1;
        private EnhancedGlassButton.GlassButton glassButton9;
        private EnhancedGlassButton.GlassButton glassButton8;
        private EnhancedGlassButton.GlassButton glassButton7;
        private EnhancedGlassButton.GlassButton glassButton6;
        private EnhancedGlassButton.GlassButton glassButton2;
        private System.Windows.Forms.Panel panelPhoto;
        private System.Windows.Forms.Panel ImgSelectPanel;
        private System.Windows.Forms.ListView listViewGallery;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ImageList imageList1;
    }
}