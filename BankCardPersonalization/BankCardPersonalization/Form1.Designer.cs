namespace BankCardPersonalization
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ImgSelectPanel = new System.Windows.Forms.Panel();
            this.btnExpressMode = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnRotate = new System.Windows.Forms.Button();
            this.btnImgRandom = new System.Windows.Forms.Button();
            this.buttonSelectImg = new System.Windows.Forms.Button();
            this.gBoxStepOne = new System.Windows.Forms.GroupBox();
            this.labelInstructOne = new System.Windows.Forms.Label();
            this.grpSelectedImg = new System.Windows.Forms.GroupBox();
            this.selectedImageBox = new System.Windows.Forms.PictureBox();
            this.panelImgGallery = new System.Windows.Forms.Panel();
            this.listViewGallery = new System.Windows.Forms.ListView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.labelImgGallery = new System.Windows.Forms.Label();
            this.lblTimerSec = new System.Windows.Forms.Label();
            this.lblDotTwo = new System.Windows.Forms.Label();
            this.lblTimerMin = new System.Windows.Forms.Label();
            this.lblDotOne = new System.Windows.Forms.Label();
            this.lblTimerHour = new System.Windows.Forms.Label();
            this.btnImgProNext = new System.Windows.Forms.Button();
            this.buttonImgGallery = new System.Windows.Forms.Button();
            this.timerLoad = new System.Windows.Forms.Timer(this.components);
            this.ImgSelectPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gBoxStepOne.SuspendLayout();
            this.grpSelectedImg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.selectedImageBox)).BeginInit();
            this.panelImgGallery.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImgSelectPanel
            // 
            this.ImgSelectPanel.BackColor = System.Drawing.Color.Silver;
            this.ImgSelectPanel.Controls.Add(this.btnExpressMode);
            this.ImgSelectPanel.Controls.Add(this.pictureBox2);
            this.ImgSelectPanel.Controls.Add(this.pictureBox1);
            this.ImgSelectPanel.Controls.Add(this.label1);
            this.ImgSelectPanel.Controls.Add(this.btnRotate);
            this.ImgSelectPanel.Controls.Add(this.btnImgRandom);
            this.ImgSelectPanel.Controls.Add(this.buttonSelectImg);
            this.ImgSelectPanel.Controls.Add(this.gBoxStepOne);
            this.ImgSelectPanel.Controls.Add(this.panelImgGallery);
            this.ImgSelectPanel.Controls.Add(this.lblTimerSec);
            this.ImgSelectPanel.Controls.Add(this.lblDotTwo);
            this.ImgSelectPanel.Controls.Add(this.lblTimerMin);
            this.ImgSelectPanel.Controls.Add(this.lblDotOne);
            this.ImgSelectPanel.Controls.Add(this.lblTimerHour);
            this.ImgSelectPanel.Controls.Add(this.btnImgProNext);
            this.ImgSelectPanel.Controls.Add(this.buttonImgGallery);
            this.ImgSelectPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImgSelectPanel.Location = new System.Drawing.Point(0, 0);
            this.ImgSelectPanel.Name = "ImgSelectPanel";
            this.ImgSelectPanel.Size = new System.Drawing.Size(1122, 835);
            this.ImgSelectPanel.TabIndex = 0;
            // 
            // btnExpressMode
            // 
            this.btnExpressMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExpressMode.Location = new System.Drawing.Point(819, 725);
            this.btnExpressMode.Name = "btnExpressMode";
            this.btnExpressMode.Size = new System.Drawing.Size(125, 72);
            this.btnExpressMode.TabIndex = 18;
            this.btnExpressMode.Text = "Express Mode";
            this.btnExpressMode.UseVisualStyleBackColor = true;
            this.btnExpressMode.Click += new System.EventHandler(this.btnExpressMode_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(882, 49);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(34, 31);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 17;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(945, 128);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(66, 83);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(922, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 32);
            this.label1.TabIndex = 15;
            this.label1.Text = "Time Left";
            // 
            // btnRotate
            // 
            this.btnRotate.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRotate.BackgroundImage")));
            this.btnRotate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRotate.Location = new System.Drawing.Point(693, 717);
            this.btnRotate.Name = "btnRotate";
            this.btnRotate.Size = new System.Drawing.Size(66, 51);
            this.btnRotate.TabIndex = 14;
            this.btnRotate.UseVisualStyleBackColor = true;
            this.btnRotate.MouseClick += new System.Windows.Forms.MouseEventHandler(this.btnRotate_MouseClick);
            // 
            // btnImgRandom
            // 
            this.btnImgRandom.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnImgRandom.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnImgRandom.BackgroundImage")));
            this.btnImgRandom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnImgRandom.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImgRandom.ForeColor = System.Drawing.Color.Chartreuse;
            this.btnImgRandom.Location = new System.Drawing.Point(69, 269);
            this.btnImgRandom.Name = "btnImgRandom";
            this.btnImgRandom.Size = new System.Drawing.Size(239, 104);
            this.btnImgRandom.TabIndex = 13;
            this.btnImgRandom.Text = "Random Photo";
            this.btnImgRandom.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnImgRandom.UseVisualStyleBackColor = false;
            this.btnImgRandom.Click += new System.EventHandler(this.btnImgRandom_Click);
            // 
            // buttonSelectImg
            // 
            this.buttonSelectImg.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonSelectImg.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonSelectImg.BackgroundImage")));
            this.buttonSelectImg.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonSelectImg.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSelectImg.ForeColor = System.Drawing.Color.Crimson;
            this.buttonSelectImg.Location = new System.Drawing.Point(69, 607);
            this.buttonSelectImg.Name = "buttonSelectImg";
            this.buttonSelectImg.Size = new System.Drawing.Size(239, 104);
            this.buttonSelectImg.TabIndex = 0;
            this.buttonSelectImg.Text = "Upload Your Image";
            this.buttonSelectImg.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonSelectImg.UseVisualStyleBackColor = false;
            this.buttonSelectImg.Click += new System.EventHandler(this.buttonSelectImg_Click);
            // 
            // gBoxStepOne
            // 
            this.gBoxStepOne.Controls.Add(this.labelInstructOne);
            this.gBoxStepOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gBoxStepOne.Location = new System.Drawing.Point(69, 31);
            this.gBoxStepOne.Name = "gBoxStepOne";
            this.gBoxStepOne.Size = new System.Drawing.Size(777, 195);
            this.gBoxStepOne.TabIndex = 12;
            this.gBoxStepOne.TabStop = false;
            this.gBoxStepOne.Text = "Step 1 :";
            // 
            // labelInstructOne
            // 
            this.labelInstructOne.AutoSize = true;
            this.labelInstructOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelInstructOne.Location = new System.Drawing.Point(6, 30);
            this.labelInstructOne.Name = "labelInstructOne";
            this.labelInstructOne.Size = new System.Drawing.Size(87, 20);
            this.labelInstructOne.TabIndex = 0;
            this.labelInstructOne.Text = "Instruction";
            // 
            // grpSelectedImg
            // 
            this.grpSelectedImg.Controls.Add(this.selectedImageBox);
            this.grpSelectedImg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpSelectedImg.Location = new System.Drawing.Point(3, 17);
            this.grpSelectedImg.Name = "grpSelectedImg";
            this.grpSelectedImg.Size = new System.Drawing.Size(663, 447);
            this.grpSelectedImg.TabIndex = 11;
            this.grpSelectedImg.TabStop = false;
            this.grpSelectedImg.Text = "Selected Image :";
            // 
            // selectedImageBox
            // 
            this.selectedImageBox.Location = new System.Drawing.Point(20, 56);
            this.selectedImageBox.Name = "selectedImageBox";
            this.selectedImageBox.Size = new System.Drawing.Size(637, 373);
            this.selectedImageBox.TabIndex = 2;
            this.selectedImageBox.TabStop = false;
            this.selectedImageBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxPaint);
            // 
            // panelImgGallery
            // 
            this.panelImgGallery.Controls.Add(this.listViewGallery);
            this.panelImgGallery.Controls.Add(this.labelImgGallery);
            this.panelImgGallery.Controls.Add(this.grpSelectedImg);
            this.panelImgGallery.Location = new System.Drawing.Point(421, 269);
            this.panelImgGallery.Name = "panelImgGallery";
            this.panelImgGallery.Size = new System.Drawing.Size(663, 447);
            this.panelImgGallery.TabIndex = 4;
            // 
            // listViewGallery
            // 
            this.listViewGallery.FullRowSelect = true;
            this.listViewGallery.LargeImageList = this.imageList1;
            this.listViewGallery.Location = new System.Drawing.Point(23, 69);
            this.listViewGallery.Name = "listViewGallery";
            this.listViewGallery.Size = new System.Drawing.Size(620, 395);
            this.listViewGallery.TabIndex = 1;
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
            // labelImgGallery
            // 
            this.labelImgGallery.AutoSize = true;
            this.labelImgGallery.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelImgGallery.ForeColor = System.Drawing.Color.Blue;
            this.labelImgGallery.Location = new System.Drawing.Point(19, 14);
            this.labelImgGallery.Name = "labelImgGallery";
            this.labelImgGallery.Size = new System.Drawing.Size(144, 24);
            this.labelImgGallery.TabIndex = 0;
            this.labelImgGallery.Text = "Image Gallery ";
            // 
            // lblTimerSec
            // 
            this.lblTimerSec.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTimerSec.AutoSize = true;
            this.lblTimerSec.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimerSec.ForeColor = System.Drawing.Color.Blue;
            this.lblTimerSec.Location = new System.Drawing.Point(1035, 94);
            this.lblTimerSec.Name = "lblTimerSec";
            this.lblTimerSec.Size = new System.Drawing.Size(49, 32);
            this.lblTimerSec.TabIndex = 9;
            this.lblTimerSec.Text = "00";
            // 
            // lblDotTwo
            // 
            this.lblDotTwo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDotTwo.AutoSize = true;
            this.lblDotTwo.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDotTwo.ForeColor = System.Drawing.Color.Blue;
            this.lblDotTwo.Location = new System.Drawing.Point(1005, 90);
            this.lblDotTwo.Name = "lblDotTwo";
            this.lblDotTwo.Size = new System.Drawing.Size(24, 36);
            this.lblDotTwo.TabIndex = 8;
            this.lblDotTwo.Text = ":";
            // 
            // lblTimerMin
            // 
            this.lblTimerMin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTimerMin.AutoSize = true;
            this.lblTimerMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimerMin.ForeColor = System.Drawing.Color.Blue;
            this.lblTimerMin.Location = new System.Drawing.Point(950, 93);
            this.lblTimerMin.Name = "lblTimerMin";
            this.lblTimerMin.Size = new System.Drawing.Size(49, 32);
            this.lblTimerMin.TabIndex = 7;
            this.lblTimerMin.Text = "00";
            // 
            // lblDotOne
            // 
            this.lblDotOne.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDotOne.AutoSize = true;
            this.lblDotOne.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDotOne.ForeColor = System.Drawing.Color.Blue;
            this.lblDotOne.Location = new System.Drawing.Point(920, 91);
            this.lblDotOne.Name = "lblDotOne";
            this.lblDotOne.Size = new System.Drawing.Size(24, 36);
            this.lblDotOne.TabIndex = 6;
            this.lblDotOne.Text = ":";
            // 
            // lblTimerHour
            // 
            this.lblTimerHour.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTimerHour.AutoSize = true;
            this.lblTimerHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimerHour.ForeColor = System.Drawing.Color.Blue;
            this.lblTimerHour.Location = new System.Drawing.Point(865, 93);
            this.lblTimerHour.Name = "lblTimerHour";
            this.lblTimerHour.Size = new System.Drawing.Size(49, 32);
            this.lblTimerHour.TabIndex = 5;
            this.lblTimerHour.Text = "00";
            // 
            // btnImgProNext
            // 
            this.btnImgProNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImgProNext.Location = new System.Drawing.Point(966, 725);
            this.btnImgProNext.Name = "btnImgProNext";
            this.btnImgProNext.Size = new System.Drawing.Size(118, 72);
            this.btnImgProNext.TabIndex = 2;
            this.btnImgProNext.Text = "Full Mode";
            this.btnImgProNext.UseVisualStyleBackColor = true;
            this.btnImgProNext.Click += new System.EventHandler(this.btnImgProNext_Click);
            // 
            // buttonImgGallery
            // 
            this.buttonImgGallery.BackColor = System.Drawing.SystemColors.Highlight;
            this.buttonImgGallery.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonImgGallery.BackgroundImage")));
            this.buttonImgGallery.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.buttonImgGallery.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonImgGallery.ForeColor = System.Drawing.Color.Purple;
            this.buttonImgGallery.Location = new System.Drawing.Point(69, 440);
            this.buttonImgGallery.Name = "buttonImgGallery";
            this.buttonImgGallery.Size = new System.Drawing.Size(239, 104);
            this.buttonImgGallery.TabIndex = 1;
            this.buttonImgGallery.Text = "Browse Gallery";
            this.buttonImgGallery.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.buttonImgGallery.UseVisualStyleBackColor = false;
            this.buttonImgGallery.Click += new System.EventHandler(this.buttonImgGallery_Click);
            // 
            // timerLoad
            // 
            this.timerLoad.Interval = 1000;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1122, 835);
            this.Controls.Add(this.ImgSelectPanel);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bank Card Personalization";
            this.ImgSelectPanel.ResumeLayout(false);
            this.ImgSelectPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gBoxStepOne.ResumeLayout(false);
            this.gBoxStepOne.PerformLayout();
            this.grpSelectedImg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.selectedImageBox)).EndInit();
            this.panelImgGallery.ResumeLayout(false);
            this.panelImgGallery.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel ImgSelectPanel;
        private System.Windows.Forms.Button buttonImgGallery;
        private System.Windows.Forms.Button buttonSelectImg;
        private System.Windows.Forms.Panel panelImgGallery;
        private System.Windows.Forms.Label labelImgGallery;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView listViewGallery;
        private System.Windows.Forms.Button btnImgProNext;
        private System.Windows.Forms.Label lblDotTwo;
        private System.Windows.Forms.Label lblTimerMin;
        private System.Windows.Forms.Label lblDotOne;
        private System.Windows.Forms.Label lblTimerHour;
        private System.Windows.Forms.Timer timerLoad;
        private System.Windows.Forms.Label lblTimerSec;
        private System.Windows.Forms.GroupBox gBoxStepOne;
        private System.Windows.Forms.Label labelInstructOne;
        private System.Windows.Forms.Button btnImgRandom;
        private System.Windows.Forms.GroupBox grpSelectedImg;
        private System.Windows.Forms.PictureBox selectedImageBox;
        private System.Windows.Forms.Button btnRotate;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnExpressMode;
    }
}

