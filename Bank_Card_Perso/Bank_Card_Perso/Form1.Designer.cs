namespace Bank_Card_Perso
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonPersonalize = new System.Windows.Forms.Button();
            this.btnCustomerService = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Gabriola", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(78, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(445, 74);
            this.label1.TabIndex = 0;
            this.label1.Text = "One Click Card Personalization";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Yellow;
            this.label2.Location = new System.Drawing.Point(86, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(382, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Touch an item below to explore :";
            // 
            // buttonPersonalize
            // 
            this.buttonPersonalize.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("buttonPersonalize.BackgroundImage")));
            this.buttonPersonalize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonPersonalize.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonPersonalize.Location = new System.Drawing.Point(144, 175);
            this.buttonPersonalize.Name = "buttonPersonalize";
            this.buttonPersonalize.Size = new System.Drawing.Size(233, 155);
            this.buttonPersonalize.TabIndex = 2;
            this.buttonPersonalize.UseVisualStyleBackColor = true;
            this.buttonPersonalize.Click += new System.EventHandler(this.buttonPersonalize_Click);
            this.buttonPersonalize.MouseEnter += new System.EventHandler(this.buttonPersonalize_MouseEnter);
            this.buttonPersonalize.MouseLeave += new System.EventHandler(this.buttonPersonalize_MouseLeave);
            // 
            // btnCustomerService
            // 
            this.btnCustomerService.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCustomerService.BackgroundImage")));
            this.btnCustomerService.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnCustomerService.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCustomerService.Location = new System.Drawing.Point(511, 292);
            this.btnCustomerService.Name = "btnCustomerService";
            this.btnCustomerService.Size = new System.Drawing.Size(233, 155);
            this.btnCustomerService.TabIndex = 3;
            this.btnCustomerService.UseVisualStyleBackColor = true;
            this.btnCustomerService.MouseEnter += new System.EventHandler(this.btnCustomerService_MouseEnter);
            this.btnCustomerService.MouseLeave += new System.EventHandler(this.btnCustomerService_MouseLeave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(139, 333);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(271, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "Start personalize your card";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(506, 450);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(294, 25);
            this.label4.TabIndex = 5;
            this.label4.Text = "Request for customer support";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-1, 602);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(254, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(862, 646);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnCustomerService);
            this.Controls.Add(this.buttonPersonalize);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bank Card Personalization";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonPersonalize;
        private System.Windows.Forms.Button btnCustomerService;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.PictureBox pictureBox1;





    }
}

