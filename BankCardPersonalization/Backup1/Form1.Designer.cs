namespace RotatePictureBox
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LoadImageBtn = new System.Windows.Forms.Button();
            this.ImagePathTxtBox = new System.Windows.Forms.TextBox();
            this.lfd = new System.Windows.Forms.OpenFileDialog();
            this.angleNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.angleNumericUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(12, 66);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(309, 190);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // LoadImageBtn
            // 
            this.LoadImageBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LoadImageBtn.Location = new System.Drawing.Point(254, 10);
            this.LoadImageBtn.Name = "LoadImageBtn";
            this.LoadImageBtn.Size = new System.Drawing.Size(75, 23);
            this.LoadImageBtn.TabIndex = 1;
            this.LoadImageBtn.Text = "Load Image";
            this.LoadImageBtn.UseVisualStyleBackColor = true;
            this.LoadImageBtn.Click += new System.EventHandler(this.LoadImageBtn_Click);
            // 
            // ImagePathTxtBox
            // 
            this.ImagePathTxtBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.ImagePathTxtBox.Enabled = false;
            this.ImagePathTxtBox.Location = new System.Drawing.Point(12, 13);
            this.ImagePathTxtBox.MinimumSize = new System.Drawing.Size(236, 20);
            this.ImagePathTxtBox.Name = "ImagePathTxtBox";
            this.ImagePathTxtBox.ReadOnly = true;
            this.ImagePathTxtBox.ShortcutsEnabled = false;
            this.ImagePathTxtBox.Size = new System.Drawing.Size(236, 20);
            this.ImagePathTxtBox.TabIndex = 2;
            // 
            // lfd
            // 
            this.lfd.DefaultExt = "png";
            this.lfd.Filter = "PNG files (*.png)|*.png|JPEG Image Files (*.jpg)|*.jpg|All files (*.*)|*.*";
            this.lfd.FileOk += new System.ComponentModel.CancelEventHandler(this.lfd_FileOk);
            // 
            // angleNumericUpDown
            // 
            this.angleNumericUpDown.Location = new System.Drawing.Point(13, 40);
            this.angleNumericUpDown.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.angleNumericUpDown.Minimum = new decimal(new int[] {
            360,
            0,
            0,
            -2147483648});
            this.angleNumericUpDown.Name = "angleNumericUpDown";
            this.angleNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.angleNumericUpDown.TabIndex = 3;
            this.angleNumericUpDown.ValueChanged += new System.EventHandler(this.angleNumericUpDown_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(139, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Angle";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.ClientSize = new System.Drawing.Size(341, 288);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.angleNumericUpDown);
            this.Controls.Add(this.ImagePathTxtBox);
            this.Controls.Add(this.LoadImageBtn);
            this.Controls.Add(this.pictureBox1);
            this.MinimumSize = new System.Drawing.Size(357, 326);
            this.Name = "Form1";
            this.Text = "RotatePictureBox";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.angleNumericUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button LoadImageBtn;
        private System.Windows.Forms.TextBox ImagePathTxtBox;
        private System.Windows.Forms.OpenFileDialog lfd;
        private System.Windows.Forms.NumericUpDown angleNumericUpDown;
        private System.Windows.Forms.Label label1;
    }
}

