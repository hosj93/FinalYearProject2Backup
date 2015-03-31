using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_Card_Perso
{
    public partial class Brightness : Form
    {
        public static Bitmap image;
        public Image prvImage;
        public Image origImage;
        public int brightnessVal;
        public Bitmap oriBrightnessImage;
        public Bitmap cloneBrightnessImage;
        public Bitmap oriContrastImage;
        public Bitmap cloneConstrastImage;
        public Image finalImage;
        public int finalBrightnessVal;
        public int contrastValue;
        public int finalContastVal;

        public Brightness()
        {
            InitializeComponent();
        }
        public void SetImagePreview(Image oriImage, Image previewImg)
        {
            picBoxTwo.Image = previewImg;
            prvImage = previewImg;
            origImage = oriImage;
            picBoxTwo.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btnNextOne_Click(object sender, EventArgs e)
        {
            ExpressFraming epFraming = new ExpressFraming();
            if (trcBrightness.Value != 0 && trcContrast.Value != 0)
            {
                epFraming.SetImagePreview(finalImage.Clone() as Image);
            }
            else if (trcBrightness.Value == 0 && trcContrast.Value == 0)
            {
                epFraming.SetImagePreview(prvImage.Clone() as Image);
            }
            else if (trcBrightness.Value != 0 && trcContrast.Value == 0)
            {
                epFraming.SetImagePreview(prvImage.Clone() as Image);
            }
            else if (trcBrightness.Value == 0 && trcContrast.Value != 0)
            {
                epFraming.SetImagePreview(finalImage.Clone() as Image);
            }
            epFraming.Show();
            this.Hide();

        }

        private void trcBrightness_Scroll(object sender, ScrollEventArgs e)
        {
            oriBrightnessImage = new Bitmap(prvImage);
            cloneBrightnessImage = (Bitmap)oriBrightnessImage.Clone();
            brightnessVal = trcBrightness.Value;
            if (brightnessVal < -255) brightnessVal = -255;
            if (brightnessVal > 255) brightnessVal = 255;
            Color c;
            for (int i = 0; i < cloneBrightnessImage.Width; i++)
            {
                for (int j = 0; j < cloneBrightnessImage.Height; j++)
                {
                    c = cloneBrightnessImage.GetPixel(i, j);
                    int cR = c.R + brightnessVal;
                    int cG = c.G + brightnessVal;
                    int cB = c.B + brightnessVal;

                    if (cR < 0) cR = 1;
                    if (cR > 255) cR = 255;

                    if (cG < 0) cG = 1;
                    if (cG > 255) cG = 255;

                    if (cB < 0) cB = 1;
                    if (cB > 255) cB = 255;

                    cloneBrightnessImage.SetPixel(i, j,
                    Color.FromArgb((byte)cR, (byte)cG, (byte)cB));
                }
            }
            oriBrightnessImage = (Bitmap)cloneBrightnessImage.Clone();
            picBoxTwo.Image = oriBrightnessImage;
            picBoxTwo.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void trcContrast_Scroll(object sender, ScrollEventArgs e)
        {
            if (trcContrast.Value != 0)
            {
                trcBrightness.Enabled = false;
            }
            oriContrastImage = (Bitmap)oriBrightnessImage;
            cloneConstrastImage = (Bitmap)oriContrastImage.Clone();
            contrastValue = trcContrast.Value;
            if (contrastValue < -100) contrastValue = -100;
            if (contrastValue > 100) contrastValue = 100;
            contrastValue = Convert.ToInt32((100.0 + contrastValue) / 100.0);
            contrastValue *= contrastValue;
            Color c;
            for (int i = 0; i < cloneConstrastImage.Width; i++)
            {
                for (int j = 0; j < cloneConstrastImage.Height; j++)
                {
                    c = cloneConstrastImage.GetPixel(i, j);
                    double pR = c.R / 255.0;
                    pR -= 0.5;
                    pR *= contrastValue;
                    pR += 0.5;
                    pR *= 255;
                    if (pR < 0) pR = 0;
                    if (pR > 255) pR = 255;

                    double pG = c.G / 255.0;
                    pG -= 0.5;
                    pG *= contrastValue;
                    pG += 0.5;
                    pG *= 255;
                    if (pG < 0) pG = 0;
                    if (pG > 255) pG = 255;

                    double pB = c.B / 255.0;
                    pB -= 0.5;
                    pB *= contrastValue;
                    pB += 0.5;
                    pB *= 255;
                    if (pB < 0) pB = 0;
                    if (pB > 255) pB = 255;

                    cloneConstrastImage.SetPixel(i, j, Color.FromArgb((byte)pR, (byte)pG, (byte)pB));
                }
            }
            picBoxTwo.Image = (Bitmap)cloneConstrastImage.Clone();
            finalImage = picBoxTwo.Image;
        }
    }
}
