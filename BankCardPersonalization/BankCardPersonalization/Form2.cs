﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace BankCardPersonalization
{
    public partial class Form2 : Form
    {
        Form1 f1 = new Form1();

        public string initPlacement = "0";
        public int hours = 00;
        public int minutes = 03;
        public int sec = 00;

        public static Bitmap image;
        public Image prvImage;
        public Image origImage;

        public Image tempFrameImage = null;
        public Image tempPicBoxImage = null;

        public Bitmap selectedSource = null;
        public Bitmap bitmapResult = null;
        public Bitmap oriImageEffect = null;
        public Bitmap tempImageEffect = null;
        public Bitmap oriBrightnessEffect = null;
        public Bitmap tempBrightnessEffect = null;
        public Bitmap frameImage = null;
        public Bitmap frameImageTwo = null;
        public bool cartoonEffectChecker = false;
        public bool imageEffect;
        public bool brightnessEffect;
        public int gammaRedVal;
        public int gammaGreenVal;
        public int gammaBlueVal;

        public Form2()
        {
            InitializeComponent();
            LoadingTextProperties();
            f1.timerFunction(false);
            DisplayInstructTwo();
            ImgGradientPrompt();
            //cmbCarEffectImplement();
            //cmbColorSwappingImplement();
            //cmbArtEffectImplement();
            panelFrameTwo.Visible = false;
            panelFrameOne.Visible = true;
            timerExecute(true);
        }

        private void timerExecute(bool timerExecuter)
        {
            timerLoading.Enabled = timerExecuter;
        }

        public void LoadingTextProperties()
        {
            foreach (FontFamily fontFamily in FontFamily.Families)
            {
                cBoxFont.Items.Add(fontFamily.Name);
            }
            for (int i = 15; i <= 45; i += 5)
            {
                cBoxFontSize.Items.Add(i.ToString() + " pt");
            }
            // Load Font Styles.
            cBoxFontStyle.Items.Add("Bold");
            cBoxFontStyle.Items.Add("Italic");
            cBoxFontStyle.Items.Add("Regular");
            cBoxFontStyle.Items.Add("Strikeout");
            cBoxFontStyle.Items.Add("Underline");
            // Load Colors.
            Type type = typeof(System.Drawing.Color);
            System.Reflection.PropertyInfo[] propertyInfo = type.GetProperties();
            for (int i = 0; i < propertyInfo.Length; i++)
            {
                if (propertyInfo[i].Name != "Transparent"
                    && propertyInfo[i].Name != "R"
                    && propertyInfo[i].Name != "G"
                    && propertyInfo[i].Name != "B"
                    && propertyInfo[i].Name != "A"
                    && propertyInfo[i].Name != "IsKnownColor"
                    && propertyInfo[i].Name != "IsEmpty"
                    && propertyInfo[i].Name != "IsNamedColor"
                    && propertyInfo[i].Name != "IsSystemColor"
                    && propertyInfo[i].Name != "Name")
                {
                    cBoxTextColor.Items.Add(propertyInfo[i].Name);
                }
            }
            cBoxTextLocation.Items.Add("Top-Left");
            cBoxTextLocation.Items.Add("Top-Right");
            cBoxTextLocation.Items.Add("Bottom-Left");
            cBoxTextLocation.Items.Add("Bottom-Right");
            cBoxTextLocation.Items.Add("Middle");
        }

        //public void cmbArtEffectImplement()
        //{
        //    cmbFilterSize.SelectedIndex = 0;
        //}

        /**public void cmbColorSwappingImplement()
        {
            cmbColorSwapping.Items.Add(ColorSwapFilter.ColorSwapType.ShiftLeft);
            cmbColorSwapping.Items.Add(ColorSwapFilter.ColorSwapType.ShiftRight);
            cmbColorSwapping.Items.Add(ColorSwapFilter.ColorSwapType.SwapBlueAndGreen);
            cmbColorSwapping.Items.Add(ColorSwapFilter.ColorSwapType.SwapBlueAndRed);
            cmbColorSwapping.Items.Add(ColorSwapFilter.ColorSwapType.SwapRedAndGreen);

            cmbColorSwapping.SelectedIndex = 0;
        } **/
        /**public void cmbCarEffectImplement()
        {
            cmbCartoonEffect.Items.Add(CartoonEffect.SmoothingFilterType.Default);
            cmbCartoonEffect.Items.Add(CartoonEffect.SmoothingFilterType.Gaussian3x3);
            cmbCartoonEffect.Items.Add(CartoonEffect.SmoothingFilterType.Gaussian5x5);
            cmbCartoonEffect.Items.Add(CartoonEffect.SmoothingFilterType.Gaussian7x7);
            cmbCartoonEffect.Items.Add(CartoonEffect.SmoothingFilterType.Median3x3);
            cmbCartoonEffect.Items.Add(CartoonEffect.SmoothingFilterType.Median5x5);
            cmbCartoonEffect.Items.Add(CartoonEffect.SmoothingFilterType.Median7x7);
            cmbCartoonEffect.Items.Add(CartoonEffect.SmoothingFilterType.Median9x9);
            cmbCartoonEffect.Items.Add(CartoonEffect.SmoothingFilterType.Mean3x3);
            cmbCartoonEffect.Items.Add(CartoonEffect.SmoothingFilterType.Mean5x5);
            cmbCartoonEffect.Items.Add(CartoonEffect.SmoothingFilterType.LowPass3x3);
            cmbCartoonEffect.Items.Add(CartoonEffect.SmoothingFilterType.LowPass5x5);
            cmbCartoonEffect.Items.Add(CartoonEffect.SmoothingFilterType.Sharpen3x3);

            cmbCartoonEffect.SelectedIndex = 0;
        }**/

        public void SetImagePreview(Image oriImage, Image previewImg)
        {
            previewImgBox.Image = previewImg;
            prvImage = previewImg;
            origImage = oriImage;
            previewImgBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        /**private void ApplyImageFilter(bool preview, Image prvImage, Image origImage)
        {
            if (prvImage == null || cmbCartoonEffect.SelectedIndex == -1)
            {
                return;
            }

            if (preview == true)
            {
                selectedSource = new Bitmap(prvImage);
            }
            else
            {
                //selectedSource = new Bitmap (oriImage);
            }

            if (selectedSource != null)
            {
                if ((CartoonEffect.SmoothingFilterType)cmbCartoonEffect.SelectedItem == CartoonEffect.SmoothingFilterType.Default)
                {
                    imageEffect = false;
                    bitmapResult = new Bitmap(origImage);
                }
                else
                {
                    CartoonEffect.SmoothingFilterType filterType =
                        ((CartoonEffect.SmoothingFilterType)cmbCartoonEffect.SelectedItem);

                    bitmapResult = selectedSource.CartoonEffectFilter(
                                       (byte)60, filterType);
                    //trcThreshold.Value
                }
            }

            if (bitmapResult != null)
            {
                if (preview == true)
                {
                    previewImgBox.Image = bitmapResult;
                    cartoonEffectChecker = true;   
                }
                else
                {
                    //resultBitmap = bitmapResult;
                }
            }
        } **/

        private void ImgGradientPrompt()
        {
            //label1.Visible = false;
            int i = 0;
            string[] extensions = new[] { ".jpg", ".png", ".bmp", ".jpeg" };
            string[] directory = Directory.GetFiles(@"C:\Users\Jack\Pictures\imgGradient", "*.*")
                .Where(f => extensions.Contains(System.IO.Path.GetExtension(f).ToLower())).ToArray();
            this.listViewImgEffect.Items.Clear();

            foreach (string dir in directory)
            {
                listViewImgEffect.Items.Add(Path.GetFileNameWithoutExtension(dir), i);
                i++;
                if (i == imgGradient.Images.Count)
                    i = 0;

            }
        }

        private void DisplayInstructTwo()
        {
            StringBuilder instructTwo = new StringBuilder();
            instructTwo.AppendLine("Customize your photo using features");
            instructTwo.AppendLine("provided");
            instructTwo.AppendLine("Press 'Next' if you have done everything");
            //instructTwo.AppendLine("Once you have done it, please proceed to next step by simply clicking ");
            //instructTwo.AppendLine("on the 'Next' button.");
            lblInstructTwo.Text = instructTwo.ToString();
        }

        /**private void FilterLevelChanged(object sender, EventArgs e)
        {
            if (imageEffect == true)
            {
                prvImage = oriImageEffect;
                ApplyImageFilter(true, prvImage, origImage);
            }
            else
            {
                prvImage = origImage;
                ApplyImageFilter(true, prvImage, origImage);
            }
            
        } **/
        private void listViewImgEffect_Click(object sender, EventArgs e)
        {
            int imgEffectIndex;
            foreach (ListViewItem imgGradient in listViewImgEffect.SelectedItems)
            {
                imgEffectIndex = imgGradient.ImageIndex;
                if (imgEffectIndex >= 0 && imgEffectIndex < this.imgGradient.Images.Count)
                {
                    switch (imgEffectIndex)
                    {
                        case 0:
                            {
                                ApplyFlipping();
                            } break;
                        case 1:
                            {
                                ApplyGrayScale();

                            } break;
                        case 2:
                            {
                                ApplyInvertEffect();
                            } break;
                    }
                }

            }
        }

        private void ApplyFlipping()
        {
            Bitmap rotateImage = null;
            rotateImage = new Bitmap(previewImgBox.Image);
            previewImgBox.Image = rotateImage.FlipPixels();
        }

        private void BrightnessLabel()
        {
            StringBuilder ImgBrightnessText = new StringBuilder();
            ImgBrightnessText.AppendLine("Adjust the brightness of your Image ");
            lblImgBrightness.Text = ImgBrightnessText.ToString();
        }

        private void ApplyInvertEffect()
        {
            if (cartoonEffectChecker == true)
            {
                oriImageEffect = new Bitmap(bitmapResult);
                tempImageEffect = (Bitmap)oriImageEffect.Clone();
            }
            else
            {
                oriImageEffect = new Bitmap(prvImage);
                tempImageEffect = (Bitmap)oriImageEffect.Clone();
            }

            Color c;
            for (int i = 0; i < tempImageEffect.Width; i++)
            {
                for (int j = 0; j < tempImageEffect.Height; j++)
                {
                    c = tempImageEffect.GetPixel(i, j);
                    tempImageEffect.SetPixel(i, j,
                    Color.FromArgb(255 - c.R, 255 - c.G, 255 - c.B));
                }
            }
            oriImageEffect = (Bitmap)tempImageEffect.Clone();
            previewImgBox.Image = oriImageEffect;
            previewImgBox.SizeMode = PictureBoxSizeMode.StretchImage;
            imageEffect = true;
            GrabLatestImage(imageEffect);
        }

        private void ApplyGrayScale()
        {
            if (cartoonEffectChecker == true)
            {
                oriImageEffect = new Bitmap(bitmapResult);
                tempImageEffect = (Bitmap)oriImageEffect.Clone();
            }
            else
            {
                oriImageEffect = new Bitmap(origImage);
                tempImageEffect = (Bitmap)oriImageEffect.Clone();
            }

            Color c;
            for (int i = 0; i < tempImageEffect.Width; i++)
            {
                for (int j = 0; j < tempImageEffect.Height; j++)
                {
                    c = tempImageEffect.GetPixel(i, j);
                    byte gray = (byte)(.299 * c.R + .587 * c.G + .114 * c.B);
                    tempImageEffect.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                }
            }
            oriImageEffect = (Bitmap)tempImageEffect.Clone();
            previewImgBox.Image = oriImageEffect;
            previewImgBox.SizeMode = PictureBoxSizeMode.StretchImage;
            imageEffect = true;
            GrabLatestImage(imageEffect);
        }

        private void GrabLatestImage(bool imageEffect)
        {
            if (imageEffect == true)
            {
                oriBrightnessEffect = oriImageEffect;

            }
            else
            {
                oriBrightnessEffect = new Bitmap(prvImage);
            }
        }

        private void tabBrightness_Click(object sender, EventArgs e)
        {
            BrightnessLabel();
        }

        private void trcBrightness_Scroll(object sender, EventArgs e)
        {
            int brightnessVal = trcBrightness.Value;
            oriImageEffect = new Bitmap(oriBrightnessEffect);
            tempImageEffect = (Bitmap)oriImageEffect.Clone();
            //if (imageEffect == true)
            //{
            //    oriImageEffect = new Bitmap(oriBrightnessEffect);
            //    tempImageEffect = (Bitmap)oriImageEffect.Clone();
            //}
            //else
            //{
            //   oriImageEffect = new Bitmap(prvImage);
            //   tempImageEffect = (Bitmap)oriImageEffect.Clone();
            //}
            if (brightnessVal < -255) brightnessVal = -255;
            if (brightnessVal > 255) brightnessVal = 255;
            Color c;
            for (int i = 0; i < tempImageEffect.Width; i++)
            {
                for (int j = 0; j < tempImageEffect.Height; j++)
                {
                    c = tempImageEffect.GetPixel(i, j);
                    int cR = c.R + brightnessVal;
                    int cG = c.G + brightnessVal;
                    int cB = c.B + brightnessVal;

                    if (cR < 0) cR = 1;
                    if (cR > 255) cR = 255;

                    if (cG < 0) cG = 1;
                    if (cG > 255) cG = 255;

                    if (cB < 0) cB = 1;
                    if (cB > 255) cB = 255;

                    tempImageEffect.SetPixel(i, j,
                    Color.FromArgb((byte)cR, (byte)cG, (byte)cB));
                }
            }
            if (brightnessVal < 100)
            {
                lblBrightnessValue.ForeColor = System.Drawing.Color.Green;
            }
            else if (brightnessVal > 100 && brightnessVal < 180)
            {
                lblBrightnessValue.ForeColor = System.Drawing.Color.Blue;
            }
            else
                lblBrightnessValue.ForeColor = System.Drawing.Color.Red;

            lblBrightnessValue.Text = brightnessVal.ToString();
            oriImageEffect = (Bitmap)tempImageEffect.Clone();
            previewImgBox.Image = oriImageEffect;
            previewImgBox.SizeMode = PictureBoxSizeMode.StretchImage;
            // imageEffect = true;
            //GrabLatestImage(imageEffect);

        }

        /**private void ColorEffectChanged(object sender, EventArgs e)
        {
            ApplyColorFilter();
        }**/

        private void ColorPanelClickEvent(object sender, EventArgs e)
        {
            if (sender is Panel)
            {
                Panel tmp = (Panel)sender;

                ColorDialog cld = new ColorDialog();
                cld.AllowFullOpen = true;
                cld.Color = tmp.BackColor;
                cld.FullOpen = true;

                if (cld.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    tmp.BackColor = cld.Color;
                    ApplyBitonal(true);
                }
            }
        }

        private void ApplyBitonal(bool preview)
        {
            Bitmap bitonalImage = null;
            bitonalImage = new Bitmap(previewImgBox.Image);
            if (prvImage == null)
            {
                return;
            }

            if (preview == true)
            {
                previewImgBox.Image = bitonalImage.Bitonal(pnlDarkColor.BackColor, pnlLightColor.BackColor, trcBitonal.Value);
            }
            else
            {
                //resultBitmap = originalBitmap.Bitonal(pnlDarkColor.BackColor, pnlLightColor.BackColor, trcBitonal.Value);
            }
        }

        private void ColorComponentEffectChanged(object sender, EventArgs e)
        {
            lblThresholdValue.Text = trcBitonal.Value.ToString();

            ApplyBitonal(true);
        }
        private void defaultPicture(Bitmap oriImage)
        {
            previewImgBox.Image = oriImage;
        }

        private void ApplyFizzyFilter(Bitmap cloneImage, int filterSize, double numEdgeOne, double numEdgeTwo)
        {
            previewImgBox.Image = cloneImage.FuzzyEdgeBlurFilter(filterSize, (float)numEdgeOne, (float)numEdgeTwo);

        }
        private void cBoxFizzyBlur_CheckedChanged(object sender, EventArgs e)
        {
            Bitmap oriImage = new Bitmap(previewImgBox.Image);
            Bitmap cloneImage = (Bitmap)oriImage.Clone();
            int filterSize = 3;
            double numEdgeOne = 0.500;
            double numEdgeTwo = 2.000;
            if (cBoxFizzyBlur.Checked == true)
            {
                ApplyFizzyFilter(cloneImage, filterSize, numEdgeOne, numEdgeTwo);
            }
            else if (cBoxFizzyBlur.Checked == false)
            {
                previewImgBox.Image = prvImage;
            }
        }

        /**private void cmbFilterSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Bitmap oriImage = null;
            //oriImage = new Bitmap(previewImgBox.Image);
            //Bitmap oriImage = new Bitmap(previewImgBox.Image);
            //Bitmap cloneImage = (Bitmap)oriImage.Clone();
            int edgeThreshold = 50;
            if (prvImage != null)
            {
                if (cmbFilterSize.SelectedItem.ToString() == "None")
                {
                    previewImgBox.Image = prvImage;
                }
                else
                {
                    int filterSize = 0;

                    //ExtBitmap.ColorShiftType shiftType = (ExtBitmap.ColorShiftType)cmbColorShiftType.SelectedItem;
                    //ExtBitmap.EdgeTracingType edgeType = (ExtBitmap.EdgeTracingType)cmbEdgeTracing.SelectedItem;

                    if (Int32.TryParse(cmbFilterSize.SelectedItem.ToString(), out filterSize))
                    {
                        previewImgBox.Image = ((Bitmap)(prvImage)).AbstractColorsFilter(filterSize, (byte)edgeThreshold, true, true, true, ExtBitmap.EdgeTracingType.Black, ExtBitmap.ColorShiftType.None);
                    }
                }
            } 
        }**/

        private void trcContrast_Scroll(object sender, EventArgs e)
        {
            int contrastValue = trcContrast.Value;
            lblContrastValue.Text = contrastValue.ToString();

            Bitmap oriImage = new Bitmap(previewImgBox.Image);
            Bitmap cloneImage = (Bitmap)oriImage.Clone();

            if (contrastValue < -100) contrastValue = -100;
            if (contrastValue > 100) contrastValue = 100;
            contrastValue = Convert.ToInt32((100.0 + contrastValue) / 100.0);
            contrastValue *= contrastValue;
            Color c;
            for (int i = 0; i < cloneImage.Width; i++)
            {
                for (int j = 0; j < cloneImage.Height; j++)
                {
                    c = cloneImage.GetPixel(i, j);
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

                    cloneImage.SetPixel(i, j, Color.FromArgb((byte)pR, (byte)pG, (byte)pB));
                }
            }
            previewImgBox.Image = (Bitmap)cloneImage.Clone();
        }

        public void trcGammaRed_Scroll(object sender, EventArgs e)
        {
            lblTrcGammaRed.Text = trcGammaRed.Value.ToString();
            gammaRedVal = Convert.ToInt32(trcGammaRed.Value.ToString());
        }

        public void trcGammaGreen_Scroll(object sender, EventArgs e)
        {
            lblTrcGammaGreen.Text = trcGammaGreen.Value.ToString();
            gammaGreenVal = Convert.ToInt32(trcGammaGreen.Value.ToString());
        }

        public void trcGammaBlue_Scroll(object sender, EventArgs e)
        {
            lblTrcGammaBlue.Text = trcGammaBlue.Value.ToString();
            gammaBlueVal = Convert.ToInt32(trcGammaBlue.Value.ToString());
        }

        private void performGamma_Click(object sender, EventArgs e)
        {
            GammaSetting(gammaRedVal, gammaGreenVal, gammaBlueVal);
        }

        private void GammaSetting(int gammaRedVal, int gammaGreenVal, int gammaBlueVal)
        {
            Bitmap oriImage = new Bitmap(previewImgBox.Image);
            Bitmap cloneImage = (Bitmap)oriImage.Clone();
            Color c;
            byte[] redGamma = CreateGammaArray(gammaRedVal);
            byte[] greenGamma = CreateGammaArray(gammaGreenVal);
            byte[] blueGamma = CreateGammaArray(gammaBlueVal);
            for (int i = 0; i < cloneImage.Width; i++)
            {
                for (int j = 0; j < cloneImage.Height; j++)
                {
                    c = cloneImage.GetPixel(i, j);
                    cloneImage.SetPixel(i, j, Color.FromArgb(redGamma[c.R], greenGamma[c.G], blueGamma[c.B]));
                }
            }
            previewImgBox.Image = (Bitmap)cloneImage.Clone();
        }

        private byte[] CreateGammaArray(double color)
        {
            byte[] gammaArray = new byte[256];
            for (int i = 0; i < 256; ++i)
            {
                gammaArray[i] = (byte)Math.Min(255, (int)((255.0 * Math.Pow(i / 255.0, 1.0 / color)) + 0.5));
            }
            return gammaArray;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            panelFrameOne.Visible = false;
            panelFrameTwo.Visible = true;
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            panelFrameOne.Visible = true;
            panelFrameTwo.Visible = false;
        }

        private void btnCEffectOne_Click(object sender, EventArgs e)
        {
            selectedSource = new Bitmap(prvImage);
            CartoonEffect.SmoothingFilterType filterType =
                        ((CartoonEffect.SmoothingFilterType)CartoonEffect.SmoothingFilterType.Gaussian7x7);
            ApplyImageFilterNew(selectedSource, filterType);
        }

        private void btnCEffectTwo_Click(object sender, EventArgs e)
        {
            selectedSource = new Bitmap(prvImage);
            CartoonEffect.SmoothingFilterType filterType =
                        ((CartoonEffect.SmoothingFilterType)CartoonEffect.SmoothingFilterType.Median5x5);
            ApplyImageFilterNew(selectedSource, filterType);
        }

        private void btnCEffectThree_Click(object sender, EventArgs e)
        {
            selectedSource = new Bitmap(prvImage);
            CartoonEffect.SmoothingFilterType filterType =
                        ((CartoonEffect.SmoothingFilterType)CartoonEffect.SmoothingFilterType.Median7x7);
            ApplyImageFilterNew(selectedSource, filterType);
        }

        private void btnCEffectFour_Click(object sender, EventArgs e)
        {
            selectedSource = new Bitmap(prvImage);
            CartoonEffect.SmoothingFilterType filterType =
                        ((CartoonEffect.SmoothingFilterType)CartoonEffect.SmoothingFilterType.Median9x9);
            ApplyImageFilterNew(selectedSource, filterType);
        }

        private void ApplyImageFilterNew(Bitmap selectedSource, CartoonEffect.SmoothingFilterType filterType)
        {
            bitmapResult = selectedSource.CartoonEffectFilter(
                                          (byte)60, filterType);
            previewImgBox.Image = bitmapResult;
            cartoonEffectChecker = true;
        }

        private void btnCSwapOne_Click(object sender, EventArgs e)
        {
            ColorSwapFilter swapFilter = new ColorSwapFilter();
            swapFilter.SwapType = (ColorSwapFilter.ColorSwapType)ColorSwapFilter.ColorSwapType.SwapRedAndGreen;
            ApplyColorFilter(swapFilter);
        }

        private void btnCSwapTwo_Click(object sender, EventArgs e)
        {
            ColorSwapFilter swapFilter = new ColorSwapFilter();
            swapFilter.SwapType = (ColorSwapFilter.ColorSwapType)ColorSwapFilter.ColorSwapType.ShiftRight;
            ApplyColorFilter(swapFilter);
        }

        private void btnCSwapThree_Click(object sender, EventArgs e)
        {
            ColorSwapFilter swapFilter = new ColorSwapFilter();
            swapFilter.SwapType = (ColorSwapFilter.ColorSwapType)ColorSwapFilter.ColorSwapType.SwapBlueAndGreen;
            ApplyColorFilter(swapFilter);
        }

        private void btnCSwapFour_Click(object sender, EventArgs e)
        {
            ColorSwapFilter swapFilter = new ColorSwapFilter();
            swapFilter.SwapType = (ColorSwapFilter.ColorSwapType)ColorSwapFilter.ColorSwapType.SwapBlueAndRed;
            ApplyColorFilter(swapFilter);
        }

        private void btnCSwapFive_Click(object sender, EventArgs e)
        {
            ColorSwapFilter swapFilter = new ColorSwapFilter();
            swapFilter.SwapType = (ColorSwapFilter.ColorSwapType)ColorSwapFilter.ColorSwapType.ShiftLeft;
            ApplyColorFilter(swapFilter);
        }

        private void ApplyColorFilter(ColorSwapFilter swapFilter)
        {
            if (prvImage != null)
            {

                //swapFilter.InvertColorsWhenSwapping = chkInvertColours.Checked;
                //swapFilter.SwapHalfColorValues = chkHalfColours.Checked;

                previewImgBox.Image = ((Bitmap)(prvImage)).SwapColorsCopy(swapFilter);
            }
        }

        private void btnArtEffectOne_Click(object sender, EventArgs e)
        {
            int filterSize = 3;
            ApplyArtEffect(filterSize);
        }

        private void btnArtEffectTwo_Click(object sender, EventArgs e)
        {
            int filterSize = 7;
            ApplyArtEffect(filterSize);
        }

        private void btnArtEffectThree_Click(object sender, EventArgs e)
        {
            int filterSize = 5;
            ApplyArtEffect(filterSize);
        }

        private void ApplyArtEffect(int filterSize)
        {
            int edgeThreshold = 50;
            previewImgBox.Image = ((Bitmap)(prvImage)).AbstractColorsFilter(filterSize, (byte)edgeThreshold, true, true, true, ExtBitmap.EdgeTracingType.Black, ExtBitmap.ColorShiftType.None);

        }

        private void buttonResetDefault_Click(object sender, EventArgs e)
        {
            previewImgBox.Image = origImage;
        }

        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }

        private void btnFrameOne_Click(object sender, EventArgs e)
        {
            tempPicBoxImage = previewImgBox.Image;
            tempPicBoxImage = resizeImage(tempPicBoxImage, new Size(531, 281));

            tempFrameImage = btnFrameOne.BackgroundImage;
            tempFrameImage = resizeImage(tempFrameImage, new Size(531, 281));

            //selectedSource = (Bitmap)previewImgBox.Image;
            //frameImage = new Bitmap (picBoxTesting.Image);

            ApplyFrameMultiplyPhotoMerge(tempPicBoxImage, tempFrameImage);
        }

        private void ApplyFrameMinPhotoMerge(Image customizedImage, Image frameImage)
        {
            Bitmap ImageModified = (Bitmap)customizedImage;
            Bitmap ImageFrame = (Bitmap)frameImage;
            previewImgBox.Image = ImageModified.ArithmeticBlend(ImageFrame,
                                   (ColorCalculator.ColorCalculationType)ColorCalculator.ColorCalculationType.Min);
            //previewImgBox.Image = selectedSource;
        }
        private void ApplyFrameAmplitudePhotoMerge(Image customizedImage, Image frameImage)
        {
            Bitmap ImageModified = (Bitmap)customizedImage;
            Bitmap ImageFrame = (Bitmap)frameImage;
            previewImgBox.Image = ImageModified.ArithmeticBlend(ImageFrame,
                                   (ColorCalculator.ColorCalculationType)ColorCalculator.ColorCalculationType.Amplitude);
            //previewImgBox.Image = selectedSource;
        }

        private void ApplyFrameAveragePhotoMerge(Image customizedImage, Image frameImage)
        {
            Bitmap ImageModified = (Bitmap)customizedImage;
            Bitmap ImageFrame = (Bitmap)frameImage;
            previewImgBox.Image = ImageModified.ArithmeticBlend(ImageFrame,
                                   (ColorCalculator.ColorCalculationType)ColorCalculator.ColorCalculationType.Average);
            //previewImgBox.Image = selectedSource;
        }

        private void ApplyFrameMultiplyPhotoMerge(Image customizedImage, Image frameImage)
        {
            Bitmap ImageModified = (Bitmap)customizedImage;
            Bitmap ImageFrame = (Bitmap)frameImage;
            previewImgBox.Image = ImageModified.ArithmeticBlend(ImageFrame,
                                   (ColorCalculator.ColorCalculationType)ColorCalculator.ColorCalculationType.Multiply);
            //previewImgBox.Image = selectedSource;
        }
        private void ApplyFrameMaxPhotoMerge(Image customizedImage, Image frameImage)
        {
            Bitmap ImageModified = (Bitmap)customizedImage;
            Bitmap ImageFrame = (Bitmap)frameImage;
            previewImgBox.Image = ImageModified.ArithmeticBlend(ImageFrame,
                                   (ColorCalculator.ColorCalculationType)ColorCalculator.ColorCalculationType.Max);
            //previewImgBox.Image = selectedSource;
        }
        private void ApplyFrameAddPhotoMerge(Image customizedImage, Image frameImage)
        {
            Bitmap ImageModified = (Bitmap)customizedImage;
            Bitmap ImageFrame = (Bitmap)frameImage;
            previewImgBox.Image = ImageModified.ArithmeticBlend(ImageFrame,
                                   (ColorCalculator.ColorCalculationType)ColorCalculator.ColorCalculationType.Add);
            //previewImgBox.Image = selectedSource;
        }

        private void btnFrameTwo_Click(object sender, EventArgs e)
        {
            tempPicBoxImage = previewImgBox.Image;
            tempPicBoxImage = resizeImage(tempPicBoxImage, new Size(531, 281));

            tempFrameImage = btnFrameTwo.BackgroundImage;
            tempFrameImage = resizeImage(tempFrameImage, new Size(531, 281));

            //selectedSource = (Bitmap)previewImgBox.Image;
            //frameImage = new Bitmap (picBoxTesting.Image);

            ApplyFrameMultiplyPhotoMerge(tempPicBoxImage, tempFrameImage);
        }

        private void btnFrameThree_Click(object sender, EventArgs e)
        {
            tempPicBoxImage = previewImgBox.Image;
            tempPicBoxImage = resizeImage(tempPicBoxImage, new Size(531, 281));

            tempFrameImage = btnFrameThree.BackgroundImage;
            tempFrameImage = resizeImage(tempFrameImage, new Size(531, 281));

            //selectedSource = (Bitmap)previewImgBox.Image;
            //frameImage = new Bitmap (picBoxTesting.Image);

            ApplyFrameMultiplyPhotoMerge(tempPicBoxImage, tempFrameImage);
        }

        private void btnFrameFour_Click(object sender, EventArgs e)
        {
            tempPicBoxImage = previewImgBox.Image;
            tempPicBoxImage = resizeImage(tempPicBoxImage, new Size(531, 281));

            tempFrameImage = btnFrameFour.BackgroundImage;
            tempFrameImage = resizeImage(tempFrameImage, new Size(531, 281));

            //selectedSource = (Bitmap)previewImgBox.Image;
            //frameImage = new Bitmap (picBoxTesting.Image);

            ApplyFrameMultiplyPhotoMerge(tempPicBoxImage, tempFrameImage);
        }

        private void btnFrameFive_Click(object sender, EventArgs e)
        {
            tempPicBoxImage = previewImgBox.Image;
            tempPicBoxImage = resizeImage(tempPicBoxImage, new Size(531, 281));

            tempFrameImage = btnFrameFive.BackgroundImage;
            tempFrameImage = resizeImage(tempFrameImage, new Size(531, 281));

            //selectedSource = (Bitmap)previewImgBox.Image;
            //frameImage = new Bitmap (picBoxTesting.Image);

            ApplyFrameMultiplyPhotoMerge(tempPicBoxImage, tempFrameImage);
        }

        private void btnFrameSix_Click(object sender, EventArgs e)
        {
            tempPicBoxImage = previewImgBox.Image;
            tempPicBoxImage = resizeImage(tempPicBoxImage, new Size(531, 281));

            tempFrameImage = btnFrameSix.BackgroundImage;
            tempFrameImage = resizeImage(tempFrameImage, new Size(531, 281));

            //selectedSource = (Bitmap)previewImgBox.Image;
            //frameImage = new Bitmap (picBoxTesting.Image);

            ApplyFrameMultiplyPhotoMerge(tempPicBoxImage, tempFrameImage);
        }

        private void btnFrameSeven_Click(object sender, EventArgs e)
        {
            tempPicBoxImage = previewImgBox.Image;
            tempPicBoxImage = resizeImage(tempPicBoxImage, new Size(531, 281));

            tempFrameImage = btnFrameSeven.BackgroundImage;
            tempFrameImage = resizeImage(tempFrameImage, new Size(531, 281));

            //selectedSource = (Bitmap)previewImgBox.Image;
            //frameImage = new Bitmap (picBoxTesting.Image);

            ApplyFrameMultiplyPhotoMerge(tempPicBoxImage, tempFrameImage);
        }

        private void btnFrameEight_Click(object sender, EventArgs e)
        {
            tempPicBoxImage = previewImgBox.Image;
            tempPicBoxImage = resizeImage(tempPicBoxImage, new Size(531, 281));

            tempFrameImage = btnFrameEight.BackgroundImage;
            tempFrameImage = resizeImage(tempFrameImage, new Size(531, 281));

            //selectedSource = (Bitmap)previewImgBox.Image;
            //frameImage = new Bitmap (picBoxTesting.Image);

            ApplyFrameMultiplyPhotoMerge(tempPicBoxImage, tempFrameImage);
        }

        private void cBoxRemoveFrame_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rBtnFilters_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtnFilters.Checked == true)
            {
                panelFilters.Visible = true;
                panelTextInsert.Visible = false;
            }
        }

        private void rBtnText_CheckedChanged(object sender, EventArgs e)
        {
            if (rBtnText.Checked == true)
            {
                panelTextInsert.Visible = true;
                panelFilters.Visible = false;
            }
        }

        public string DisplayText
        {
            get { return textInserting.Text; }
            set { textInserting.Text = value.ToString(); }
        }

        public string DisplayTextFont
        {
            get { return cBoxFont.Text; }
            set { cBoxFont.Text = value.ToString(); }
        }

        public float DisplayTextFontSize
        {
            get
            {
                float fs = 10.0F;
                if (!string.IsNullOrEmpty(cBoxFontSize.Text))
                    fs = Convert.ToSingle(cBoxFontSize.Text.Replace("pt", ""));
                return fs;
            }
            set { cBoxFontSize.Text = value.ToString() + "pt"; }
        }

        public string DisplayTextFontStyle
        {
            get { return cBoxFontStyle.Text; }
            set { cBoxFontStyle.Text = value.ToString(); }
        }

        public string DisplayTextForeColor
        {
            get { return cBoxTextColor.Text; }
            set { cBoxTextColor.Text = value.ToString(); }
        }

        public string DisplayTextLocation
        {
            get { return cBoxTextLocation.Text; }
            set { cBoxTextLocation.Text = value.ToString(); }
        }
        private void btnApplyText_Click(object sender, EventArgs e)
        {
            InsertText(DisplayText, DisplayTextFont, DisplayTextFontSize, DisplayTextFontStyle, DisplayTextForeColor, DisplayTextLocation);
        }

        private void InsertText(string displayText, string displayTextFont, float displayTextFontSize, string displayTextFontStyle, string displayTextForeColor, string displayTextLocation)
        {
            Bitmap temp = (Bitmap)previewImgBox.Image;
            Bitmap bmap = (Bitmap)temp.Clone();
            Graphics gr = Graphics.FromImage(bmap);
            //double posValue =
            //int intPosValue = Convert.ToInt32(posValue);
            if (string.IsNullOrEmpty(displayTextFont))
                displayTextFont = "Times New Roman";
            if (displayTextFontSize.Equals(null))
                displayTextFontSize = 10.0F;
            //SizeF textSize =
            //gr.MeasureString(displayTextFontSize, Font);
            Font font = new Font(displayTextFont, displayTextFontSize);
           
            if (!string.IsNullOrEmpty(displayTextFontStyle))
            {
                FontStyle fStyle = FontStyle.Regular;
                switch (displayTextFontStyle.ToLower())
                {
                    case "bold":
                        fStyle = FontStyle.Bold;
                        break;
                    case "italic":
                        fStyle = FontStyle.Italic;
                        break;
                    case "underline":
                        fStyle = FontStyle.Underline;
                        break;
                    case "strikeout":
                        fStyle = FontStyle.Strikeout;
                        break;

                }
                font = new Font(displayTextFont, displayTextFontSize, fStyle);
            }
            if (string.IsNullOrEmpty(displayTextForeColor))
                displayTextForeColor = "Black";

            Color color1 = Color.FromName(displayTextForeColor);
            Color color2 = Color.FromName(displayTextForeColor);
            int gW = (int)(displayText.Length * displayTextFontSize);
            gW = gW == 0 ? 10 : gW;
            LinearGradientBrush LGBrush = new LinearGradientBrush(new Rectangle(0, 0, gW, (int)displayTextFontSize), color1, color2, LinearGradientMode.Vertical);
            //gr.DrawString(displayText, font, LGBrush, xPos, yPos);
            if (!string.IsNullOrEmpty(displayTextLocation))
            {
                switch (displayTextLocation)
                {
                    case "Top-Left":
                        previewImgBox.Paint += new PaintEventHandler((sender, e) =>
                        {
                            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                            SizeF textPattern = e.Graphics.MeasureString(displayText, font);
                            PointF locationToDraw = new PointF();
                            locationToDraw.X = 0;
                            locationToDraw.Y = 0;

                            e.Graphics.DrawString(displayText, font, LGBrush, locationToDraw);
                        });
                        break;
                    case "Top-Right":
                        previewImgBox.Paint += new PaintEventHandler((sender, e) =>
                        {
                            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                            SizeF textPattern = e.Graphics.MeasureString(displayText, font);
                            PointF locationToDraw = new PointF();
                            locationToDraw.X = previewImgBox.Width - textPattern.Width;
                            locationToDraw.Y = 0;

                            e.Graphics.DrawString(displayText, font, LGBrush, locationToDraw);
                        });
                        break;
                    case "Bottom-Left":
                        previewImgBox.Paint += new PaintEventHandler((sender, e) =>
                        {
                            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                            SizeF textPattern = e.Graphics.MeasureString(displayText, font);
                            PointF locationToDraw = new PointF();
                            locationToDraw.X = 0;
                            locationToDraw.Y = previewImgBox.Height - textPattern.Height;

                            e.Graphics.DrawString(displayText, font, LGBrush, locationToDraw);
                        });
                        break;
                    case "Bottom-Right":
                        previewImgBox.Paint += new PaintEventHandler((sender, e) =>
                        {
                            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                            SizeF textPattern = e.Graphics.MeasureString(displayText, font);
                            PointF locationToDraw = new PointF();
                            locationToDraw.X = previewImgBox.Width - textPattern.Width;
                            locationToDraw.Y = previewImgBox.Height - textPattern.Height;

                            e.Graphics.DrawString(displayText, font, LGBrush, locationToDraw);
                        });
                        break;
                    case "Middle":
                        previewImgBox.Paint += new PaintEventHandler((sender, e) =>
                        {
                            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                            SizeF textPattern= e.Graphics.MeasureString(displayText, font);
                            PointF locationToDraw = new PointF();
                            locationToDraw.X = (previewImgBox.Width / 2) - (textPattern.Width / 2);
                            locationToDraw.Y = (previewImgBox.Height / 2) - (textPattern.Height / 2);

                            e.Graphics.DrawString(displayText, font, LGBrush, locationToDraw);
                        });
                        break;
                }
            }
            previewImgBox.Image = (Bitmap)bmap.Clone();
        }


        private void btnOverlayOne_Click(object sender, EventArgs e)
        {
            tempPicBoxImage = previewImgBox.Image;
            tempPicBoxImage = resizeImage(tempPicBoxImage, new Size(531, 281));

            tempFrameImage = btnOverlayOne.BackgroundImage;
            tempFrameImage = resizeImage(tempFrameImage, new Size(531, 281));

            //selectedSource = (Bitmap)previewImgBox.Image;
            //frameImage = new Bitmap (picBoxTesting.Image);

            ApplyFrameMultiplyPhotoMerge(tempPicBoxImage, tempFrameImage);
        }

        private void btnOverlayTwo_Click(object sender, EventArgs e)
        {
            tempPicBoxImage = previewImgBox.Image;
            tempPicBoxImage = resizeImage(tempPicBoxImage, new Size(531, 281));

            tempFrameImage = btnOverlayTwo.BackgroundImage;
            tempFrameImage = resizeImage(tempFrameImage, new Size(531, 281));

            //selectedSource = (Bitmap)previewImgBox.Image;
            //frameImage = new Bitmap (picBoxTesting.Image);

            ApplyFrameMaxPhotoMerge(tempPicBoxImage, tempFrameImage);
        }
        private void btnOverlayFour_Click(object sender, EventArgs e)
        {
            tempPicBoxImage = previewImgBox.Image;
            tempPicBoxImage = resizeImage(tempPicBoxImage, new Size(531, 281));

            tempFrameImage = btnOverlayFour.BackgroundImage;
            tempFrameImage = resizeImage(tempFrameImage, new Size(531, 281));

            //selectedSource = (Bitmap)previewImgBox.Image;
            //frameImage = new Bitmap (picBoxTesting.Image);

            ApplyFrameAddPhotoMerge(tempPicBoxImage, tempFrameImage);
        }

        private void btnOverlaySix_Click(object sender, EventArgs e)
        {
            tempPicBoxImage = previewImgBox.Image;
            tempPicBoxImage = resizeImage(tempPicBoxImage, new Size(531, 281));

            tempFrameImage = btnOverlaySix.BackgroundImage;
            tempFrameImage = resizeImage(tempFrameImage, new Size(531, 281));

            //selectedSource = (Bitmap)previewImgBox.Image;
            //frameImage = new Bitmap (picBoxTesting.Image);

            ApplyFrameAveragePhotoMerge(tempPicBoxImage, tempFrameImage);
        }

        private void btnOverlayThree_Click(object sender, EventArgs e)
        {
            tempPicBoxImage = previewImgBox.Image;
            tempPicBoxImage = resizeImage(tempPicBoxImage, new Size(531, 281));

            tempFrameImage = btnOverlayThree.BackgroundImage;
            tempFrameImage = resizeImage(tempFrameImage, new Size(531, 281));

            //selectedSource = (Bitmap)previewImgBox.Image;
            //frameImage = new Bitmap (picBoxTesting.Image);

            ApplyFrameMinPhotoMerge(tempPicBoxImage, tempFrameImage);
        }

        private void btnOverlayFive_Click(object sender, EventArgs e)
        {
            tempPicBoxImage = previewImgBox.Image;
            tempPicBoxImage = resizeImage(tempPicBoxImage, new Size(531, 281));

            tempFrameImage = btnOverlayFive.BackgroundImage;
            tempFrameImage = resizeImage(tempFrameImage, new Size(531, 281));

            //selectedSource = (Bitmap)previewImgBox.Image;
            //frameImage = new Bitmap (picBoxTesting.Image);

            ApplyFrameAddPhotoMerge(tempPicBoxImage, tempFrameImage);
        }

        private void btnOverlayBasOne_Click(object sender, EventArgs e)
        {
            tempPicBoxImage = previewImgBox.Image;
            tempPicBoxImage = resizeImage(tempPicBoxImage, new Size(531, 281));

            tempFrameImage = btnOverlayBasOne.BackgroundImage;
            tempFrameImage = resizeImage(tempFrameImage, new Size(531, 281));

            //selectedSource = (Bitmap)previewImgBox.Image;
            //frameImage = new Bitmap (picBoxTesting.Image);

            ApplyFrameAddPhotoMerge(tempPicBoxImage, tempFrameImage);
        }

        private void btnOverlayBasTwo_Click(object sender, EventArgs e)
        {
            tempPicBoxImage = previewImgBox.Image;
            tempPicBoxImage = resizeImage(tempPicBoxImage, new Size(531, 281));

            tempFrameImage = btnOverlayBasTwo.BackgroundImage;
            tempFrameImage = resizeImage(tempFrameImage, new Size(531, 281));

            //selectedSource = (Bitmap)previewImgBox.Image;
            //frameImage = new Bitmap (picBoxTesting.Image);

            ApplyFrameMaxPhotoMerge(tempPicBoxImage, tempFrameImage);

        }

        private void btnOverlayBasThree_Click(object sender, EventArgs e)
        {
            tempPicBoxImage = previewImgBox.Image;
            tempPicBoxImage = resizeImage(tempPicBoxImage, new Size(531, 281));

            tempFrameImage = btnOverlayBasThree.BackgroundImage;
            tempFrameImage = resizeImage(tempFrameImage, new Size(531, 281));

            //selectedSource = (Bitmap)previewImgBox.Image;
            //frameImage = new Bitmap (picBoxTesting.Image);

            ApplyFrameAddPhotoMerge(tempPicBoxImage, tempFrameImage);
        }

        private void btnOverlayBasFour_Click(object sender, EventArgs e)
        {
            tempPicBoxImage = previewImgBox.Image;
            tempPicBoxImage = resizeImage(tempPicBoxImage, new Size(531, 281));

            tempFrameImage = btnOverlayBasFour.BackgroundImage;
            tempFrameImage = resizeImage(tempFrameImage, new Size(531, 281));

            //selectedSource = (Bitmap)previewImgBox.Image;
            //frameImage = new Bitmap (picBoxTesting.Image);

            ApplyFrameAveragePhotoMerge(tempPicBoxImage, tempFrameImage);
        }

        private void btnOverlayBasFive_Click(object sender, EventArgs e)
        {
            tempPicBoxImage = previewImgBox.Image;
            tempPicBoxImage = resizeImage(tempPicBoxImage, new Size(531, 281));

            tempFrameImage = btnOverlayBasFive.BackgroundImage;
            tempFrameImage = resizeImage(tempFrameImage, new Size(531, 281));

            //selectedSource = (Bitmap)previewImgBox.Image;
            //frameImage = new Bitmap (picBoxTesting.Image);

            ApplyFrameAddPhotoMerge(tempPicBoxImage, tempFrameImage);
        }

        private void btnOverlayBasSix_Click(object sender, EventArgs e)
        {
            tempPicBoxImage = previewImgBox.Image;
            tempPicBoxImage = resizeImage(tempPicBoxImage, new Size(531, 281));

            tempFrameImage = btnOverlayBasSix.BackgroundImage;
            tempFrameImage = resizeImage(tempFrameImage, new Size(531, 281));

            //selectedSource = (Bitmap)previewImgBox.Image;
            //frameImage = new Bitmap (picBoxTesting.Image);

            ApplyFrameAveragePhotoMerge(tempPicBoxImage, tempFrameImage);
        }

        private void timerLoading_Tick(object sender, EventArgs e)
        {
            {
                if (minutes != 0 && sec < 1)
                {
                    sec = 59;
                    if (minutes == 0)
                    {
                        //minutes = 59;
                        //MessageBox.Show("FASTER");
                        if (hours != 0) hours -= 1;
                    }
                    else
                    {
                        minutes -= 1;
                    }
                }
                else if (minutes == 0 && sec == 0)
                {
                    imageConfirmation();
                }
                else
                {
                    sec -= 1;
                }
            }
            if (minutes == 0 && sec != 0)
            {
                if (minutes == 0 && sec < 10)
                {
                    if ((sec % 2) != 0)
                    {
                        lblTimerSec.ForeColor = System.Drawing.Color.Red;
                        lblTimerHour.ForeColor = System.Drawing.Color.Red;
                        lblTimerMin.ForeColor = System.Drawing.Color.Red;
                    }
                    else
                    {
                        lblTimerSec.ForeColor = System.Drawing.Color.Blue;
                        lblTimerHour.ForeColor = System.Drawing.Color.Blue;
                        lblTimerMin.ForeColor = System.Drawing.Color.Blue;
                    }
                }
            }
            lblTimerHour.Text = initPlacement + hours.ToString();
            lblTimerMin.Text = initPlacement + minutes.ToString();
            if (sec < 10)
            {
                lblTimerSec.Text = initPlacement + sec.ToString();
            }
            else
            {
                lblTimerSec.Text = sec.ToString();
            }
        }
        private void imageConfirmation()
        {
            string imgConfirm = "So, this will be your finalized image. "+ Environment.NewLine + "Press OK to move on to next page.";
            timerExecute(false);
            DialogResult imgConfirmation = MessageBox.Show(imgConfirm, "Final Image Confirmation",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

            if (imgConfirmation == DialogResult.Yes)
            {
                /**Form2 f2 = new Form2();
                f2.SetImagePreview(bmpSelectedImg.Clone() as Image, previewSelectedImg.Clone() as Image);
                f2.Show();
                //f2.ShowDialog();
                this.Hide();
                timerFunction(false);**/
            }
        }

        private void btnCardPhoto_Click(object sender, EventArgs e)
        {
            tempPicBoxImage = previewImgBox.Image;
            tempPicBoxImage = resizeImage(tempPicBoxImage, new Size(531,281));

            tempFrameImage = picBoxCard.Image;
            tempFrameImage = resizeImage(tempFrameImage, new Size(531, 281));

            //selectedSource = (Bitmap)previewImgBox.Image;
            //frameImage = new Bitmap (picBoxTesting.Image);

            ApplyFrameAveragePhotoMerge(tempPicBoxImage, tempFrameImage);
        }

        private void btnProceed_Click(object sender, EventArgs e)
        {
            Image lastImage;
            lastImage = previewImgBox.Image;
            FormFilling formFilling = new FormFilling();
            formFilling.SetCardPreview(lastImage.Clone() as Image);
            formFilling.Show();
            this.Hide();
            timerExecute(false);
        }
    } 
  }   
   



