using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RotatePictureBox
{
    public partial class Form1 : Form
    {
        private Bitmap image = null;
        private float angle = 0.0f;

        public Form1()
        {
            InitializeComponent();
            angleNumericUpDown.Value = (Decimal)angle;
        }

        //Load image
        private void LoadImageBtn_Click(object sender, EventArgs e)
        {
            lfd.InitialDirectory = Application.StartupPath;
            lfd.ShowDialog();
        }

        private void lfd_FileOk(object sender, CancelEventArgs e)
        {
            try
            {
                image = new Bitmap(lfd.FileName);

                pictureBox1.Image = (Bitmap)image.Clone();
                ImagePathTxtBox.Text = lfd.FileName;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            RotateImage(pictureBox1, image, angle);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Up:
                    RotateImage(pictureBox1, image, angle++);
                    break;
                case Keys.Down:
                    RotateImage(pictureBox1, image, angle--);
                    break;
                case Keys.Right:
                    RotateImage(pictureBox1, image, angle++);
                    break;
                case Keys.Left:
                    RotateImage(pictureBox1, image, angle--);
                    break;
            }
        }

        private void angleNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            angle = (float)angleNumericUpDown.Value;
            RotateImage(pictureBox1, image, angle);
        }

        private void RotateImage(PictureBox pb, Image img, float angle)
        {
            if (img == null || pb.Image == null)
                return;

            Image oldImage = pb.Image;
            pb.Image = Utilities.RotateImage(img, angle);
            if (oldImage != null)
            {
                oldImage.Dispose();
            }
        }
    }
}