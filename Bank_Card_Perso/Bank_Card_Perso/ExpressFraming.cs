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
    public partial class ExpressFraming : Form
    {
        public Image prvImage;
        public Image origImage;
        public Image tempFrameImage = null;
        public Image tempPicBoxImage = null;
        public Image phaseThreeImage;
        public bool imageWithFrame = false;
        public bool imageWithEffect = false;
        public Image finalImage;
        public ExpressFraming()
        {
            InitializeComponent();
            panelFrameOne.Visible = true;
            panelFrameTwo.Visible = false;
            panelFrameThree.Visible = false;
            panelEffectOne.Visible = true;
            panelEffectTwo.Visible = false;
            panelEffectThree.Visible = false;
            panelEffectFour.Visible = false;
        }
        public void SetImagePreview(Image oriImage)
        {
            picBoxThree.Image = oriImage;
            origImage = oriImage;
            prvImage = origImage.Clone() as Image;

            picBoxThree.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void frameScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            switch (frameScrollBar.Value)
            {
                case 0:
                    panelFrameOne.Visible = true;
                    panelFrameTwo.Visible = false;
                    panelFrameThree.Visible = false;
                    break;
                case 1:
                    panelFrameOne.Visible = false;
                    panelFrameTwo.Visible = true;
                    panelFrameThree.Visible = false;
                    break;
                case 2:
                    panelFrameOne.Visible = false;
                    panelFrameTwo.Visible = false;
                    panelFrameThree.Visible = true;
                    break;
            }
        }
        private void effectScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            switch (effectScrollBar.Value)
            {
                case 0:
                    panelEffectOne.Visible = true;
                    panelEffectTwo.Visible = false;
                    panelEffectThree.Visible = false;
                    panelEffectFour.Visible = false;
                    break;
                case 1:
                    panelEffectOne.Visible = false;
                    panelEffectTwo.Visible = true;
                    panelEffectThree.Visible = false;
                    panelEffectFour.Visible = false;
                    break;
                case 2:
                    panelEffectOne.Visible = false;
                    panelEffectTwo.Visible = false;
                    panelEffectThree.Visible = true;
                    panelEffectFour.Visible = false;
                    break;
                case 3:
                    panelEffectOne.Visible = false;
                    panelEffectTwo.Visible = false;
                    panelEffectThree.Visible = false;
                    panelEffectFour.Visible = true;
                    break;
            }
        }
        private void ApplyFrameMinPhotoMerge(Image customizedImage, Image frameImage)
        {
            Bitmap ImageModified = (Bitmap)customizedImage;
            Bitmap ImageFrame = (Bitmap)frameImage;
            picBoxThree.Image = ImageModified.ArithmeticBlend(ImageFrame,
                                   (ColorCalculator.ColorCalculationType)ColorCalculator.ColorCalculationType.Min);
            //previewImgBox.Image = selectedSource;
        }
        private void ApplyFrameAmplitudePhotoMerge(Image customizedImage, Image frameImage)
        {
            Bitmap ImageModified = (Bitmap)customizedImage;
            Bitmap ImageFrame = (Bitmap)frameImage;
            picBoxThree.Image = ImageModified.ArithmeticBlend(ImageFrame,
                                   (ColorCalculator.ColorCalculationType)ColorCalculator.ColorCalculationType.Amplitude);
            //previewImgBox.Image = selectedSource;
        }

        private void ApplyFrameAveragePhotoMerge(Image customizedImage, Image frameImage)
        {
            Bitmap ImageModified = (Bitmap)customizedImage;
            Bitmap ImageFrame = (Bitmap)frameImage;
            picBoxThree.Image = ImageModified.ArithmeticBlend(ImageFrame,
                                   (ColorCalculator.ColorCalculationType)ColorCalculator.ColorCalculationType.Average);
            //previewImgBox.Image = selectedSource;
        }

        private void ApplyFrameMultiplyPhotoMerge(Image customizedImage, Image frameImage)
        {
            Bitmap ImageModified = (Bitmap)customizedImage;
            Bitmap ImageFrame = (Bitmap)frameImage;
            picBoxThree.Image = ImageModified.ArithmeticBlend(ImageFrame,
                                   (ColorCalculator.ColorCalculationType)ColorCalculator.ColorCalculationType.Multiply);
            //previewImgBox.Image = selectedSource;
        }
        private void ApplyFrameMaxPhotoMerge(Image customizedImage, Image frameImage)
        {
            Bitmap ImageModified = (Bitmap)customizedImage;
            Bitmap ImageFrame = (Bitmap)frameImage;
            picBoxThree.Image = ImageModified.ArithmeticBlend(ImageFrame,
                                   (ColorCalculator.ColorCalculationType)ColorCalculator.ColorCalculationType.Max);
            //previewImgBox.Image = selectedSource;
        }
        private void ApplyFrameAddPhotoMerge(Image customizedImage, Image frameImage)
        {
            Bitmap ImageModified = (Bitmap)customizedImage;
            Bitmap ImageFrame = (Bitmap)frameImage;
            picBoxThree.Image = ImageModified.ArithmeticBlend(ImageFrame,
                                   (ColorCalculator.ColorCalculationType)ColorCalculator.ColorCalculationType.Add);
            //previewImgBox.Image = selectedSource;
        }
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
        private void btnFrameOne_Click(object sender, EventArgs e)
        {
            imageWithFrame = true;
            tempPicBoxImage = prvImage;
            tempPicBoxImage = resizeImage(tempPicBoxImage, new Size(469, 241));

            tempFrameImage = btnFrameOne.BackgroundImage;
            tempFrameImage = resizeImage(tempFrameImage, new Size(469, 241));

            ApplyFrameMultiplyPhotoMerge(tempPicBoxImage, tempFrameImage);
            finalImage = picBoxThree.Image;
        }
        private void btnFrameTwo_Click(object sender, EventArgs e)
        {
            imageWithFrame = true;
            prvImage = origImage;
            tempPicBoxImage = prvImage;
            tempPicBoxImage = resizeImage(tempPicBoxImage, new Size(469, 241));

            tempFrameImage = btnFrameTwo.BackgroundImage;
            tempFrameImage = resizeImage(tempFrameImage, new Size(469, 241));

            ApplyFrameMultiplyPhotoMerge(tempPicBoxImage, tempFrameImage);
            finalImage = picBoxThree.Image;
        }

        private void btnFrameThree_Click(object sender, EventArgs e)
        {
            imageWithFrame = true;
            prvImage = origImage;
            tempPicBoxImage = prvImage;
            tempPicBoxImage = resizeImage(tempPicBoxImage, new Size(469, 241));

            tempFrameImage = btnFrameThree.BackgroundImage;
            tempFrameImage = resizeImage(tempFrameImage, new Size(469, 241));

            ApplyFrameMultiplyPhotoMerge(tempPicBoxImage, tempFrameImage);
            finalImage = picBoxThree.Image;
        }

        private void btnFrameFour_Click(object sender, EventArgs e)
        {
            imageWithFrame = true;
            prvImage = origImage;
            tempPicBoxImage = prvImage;
            tempPicBoxImage = resizeImage(tempPicBoxImage, new Size(469, 241));

            tempFrameImage = btnFrameFour.BackgroundImage;
            tempFrameImage = resizeImage(tempFrameImage, new Size(469, 241));

            ApplyFrameMultiplyPhotoMerge(tempPicBoxImage, tempFrameImage);
            finalImage = picBoxThree.Image;
        }

        private void btnFrameFive_Click(object sender, EventArgs e)
        {
            imageWithFrame = true;
            prvImage = origImage;
            tempPicBoxImage = prvImage;
            tempPicBoxImage = resizeImage(tempPicBoxImage, new Size(469, 241));

            tempFrameImage = btnFrameFive.BackgroundImage;
            tempFrameImage = resizeImage(tempFrameImage, new Size(469, 241));

            ApplyFrameMultiplyPhotoMerge(tempPicBoxImage, tempFrameImage);
            finalImage = picBoxThree.Image;
        }

        private void btnFrameSix_Click(object sender, EventArgs e)
        {
            imageWithFrame = true;
            prvImage = origImage;
            tempPicBoxImage = prvImage;
            tempPicBoxImage = resizeImage(tempPicBoxImage, new Size(469, 241));

            tempFrameImage = btnFrameSix.BackgroundImage;
            tempFrameImage = resizeImage(tempFrameImage, new Size(469, 241));

            ApplyFrameMultiplyPhotoMerge(tempPicBoxImage, tempFrameImage);
            finalImage = picBoxThree.Image;
        }

        private void btnFrameSeven_Click(object sender, EventArgs e)
        {
            imageWithFrame = true;
            prvImage = origImage;
            tempPicBoxImage = prvImage;
            tempPicBoxImage = resizeImage(tempPicBoxImage, new Size(469, 241));

            tempFrameImage = btnFrameSeven.BackgroundImage;
            tempFrameImage = resizeImage(tempFrameImage, new Size(469, 241));

            ApplyFrameMultiplyPhotoMerge(tempPicBoxImage, tempFrameImage);
            finalImage = picBoxThree.Image;
        }

        private void btnFrameEight_Click(object sender, EventArgs e)
        {
            imageWithFrame = true;
            prvImage = origImage;
            tempPicBoxImage = prvImage;
            tempPicBoxImage = resizeImage(tempPicBoxImage, new Size(469, 241));

            tempFrameImage = btnFrameEight.BackgroundImage;
            tempFrameImage = resizeImage(tempFrameImage, new Size(469, 241));

            ApplyFrameMultiplyPhotoMerge(tempPicBoxImage, tempFrameImage);
            finalImage = picBoxThree.Image;
        }

        private void btnResetImage_Click(object sender, EventArgs e)
        {
            picBoxThree.Image = origImage;
        }

        private void btnOverlayOne_Click(object sender, EventArgs e)
        {
            if (imageWithFrame == true)
            {
                prvImage = finalImage;
            }
            else
            {
                prvImage = origImage;
            }
            imageWithEffect = true;
            tempPicBoxImage = prvImage;
            tempPicBoxImage = resizeImage(tempPicBoxImage, new Size(469, 241));

            tempFrameImage = btnOverlayOne.BackgroundImage;
            tempFrameImage = resizeImage(tempFrameImage, new Size(469, 241));

            ApplyFrameMultiplyPhotoMerge(tempPicBoxImage, tempFrameImage);
        }

        private void btnOverlayTwo_Click(object sender, EventArgs e)
        {
            if (imageWithFrame == true)
            {
                prvImage = finalImage;
            }
            else
            {
                prvImage = origImage;
            }
            imageWithEffect = true;
            tempPicBoxImage = prvImage;
            tempPicBoxImage = resizeImage(tempPicBoxImage, new Size(469, 241));

            tempFrameImage = btnOverlayTwo.BackgroundImage;
            tempFrameImage = resizeImage(tempFrameImage, new Size(469, 241));

            ApplyFrameMaxPhotoMerge(tempPicBoxImage, tempFrameImage);
        }
        private void btnOverlayFour_Click(object sender, EventArgs e)
        {
            if (imageWithFrame == true)
            {
                prvImage = finalImage;
            }
            else
            {
                prvImage = origImage;
            }
            imageWithEffect = true;
            tempPicBoxImage = prvImage;
            tempPicBoxImage = resizeImage(tempPicBoxImage, new Size(469, 241));

            tempFrameImage = btnOverlayFour.BackgroundImage;
            tempFrameImage = resizeImage(tempFrameImage, new Size(469, 241));

            ApplyFrameAddPhotoMerge(tempPicBoxImage, tempFrameImage);
        }

        private void btnOverlaySix_Click(object sender, EventArgs e)
        {
            if (imageWithFrame == true)
            {
                prvImage = finalImage;
            }
            else
            {
                prvImage = origImage;
            }
            imageWithEffect = true;
            tempPicBoxImage = prvImage;
            tempPicBoxImage = resizeImage(tempPicBoxImage, new Size(469, 241));

            tempFrameImage = btnOverlaySix.BackgroundImage;
            tempFrameImage = resizeImage(tempFrameImage, new Size(469, 241));

            ApplyFrameAveragePhotoMerge(tempPicBoxImage, tempFrameImage);
        }

        private void btnOverlayThree_Click(object sender, EventArgs e)
        {
            if (imageWithFrame == true)
            {
                prvImage = finalImage;
            }
            else
            {
                prvImage = origImage;
            }
            imageWithEffect = true;
            tempPicBoxImage = prvImage;
            tempPicBoxImage = resizeImage(tempPicBoxImage, new Size(469, 241));

            tempFrameImage = btnOverlayThree.BackgroundImage;
            tempFrameImage = resizeImage(tempFrameImage, new Size(469, 241));

            ApplyFrameMinPhotoMerge(tempPicBoxImage, tempFrameImage);
        }

        private void btnOverlayFive_Click(object sender, EventArgs e)
        {
            if (imageWithFrame == true)
            {
                prvImage = finalImage;
            }
            else
            {
                prvImage = origImage;
            }
            imageWithEffect = true;
            tempPicBoxImage = prvImage;
            tempPicBoxImage = resizeImage(tempPicBoxImage, new Size(469, 241));

            tempFrameImage = btnOverlayFive.BackgroundImage;
            tempFrameImage = resizeImage(tempFrameImage, new Size(469, 241));

            ApplyFrameAddPhotoMerge(tempPicBoxImage, tempFrameImage);
        }

        private void btnOverlayBasOne_Click(object sender, EventArgs e)
        {
            if (imageWithFrame == true)
            {
                prvImage = finalImage;
            }
            else
            {
                prvImage = origImage;
            }
            imageWithEffect = true;
            tempPicBoxImage = prvImage;
            tempPicBoxImage = resizeImage(tempPicBoxImage, new Size(469, 241));

            tempFrameImage = btnOverlayBasOne.BackgroundImage;
            tempFrameImage = resizeImage(tempFrameImage, new Size(469, 241));

            ApplyFrameAddPhotoMerge(tempPicBoxImage, tempFrameImage);
        }

        private void btnOverlayBasTwo_Click(object sender, EventArgs e)
        {
            if (imageWithFrame == true)
            {
                prvImage = finalImage;
            }
            else
            {
                prvImage = origImage;
            }
            imageWithEffect = true;
            tempPicBoxImage = prvImage;
            tempPicBoxImage = resizeImage(tempPicBoxImage, new Size(469, 241));

            tempFrameImage = btnOverlayBasTwo.BackgroundImage;
            tempFrameImage = resizeImage(tempFrameImage, new Size(469, 241));

            ApplyFrameMaxPhotoMerge(tempPicBoxImage, tempFrameImage);

        }

        private void btnOverlayBasThree_Click(object sender, EventArgs e)
        {
            if (imageWithFrame == true)
            {
                prvImage = finalImage;
            }
            else
            {
                prvImage = origImage;
            }
            imageWithEffect = true;
            tempPicBoxImage = prvImage;
            tempPicBoxImage = resizeImage(tempPicBoxImage, new Size(469, 241));

            tempFrameImage = btnOverlayBasThree.BackgroundImage;
            tempFrameImage = resizeImage(tempFrameImage, new Size(469, 241));

            ApplyFrameAddPhotoMerge(tempPicBoxImage, tempFrameImage);
        }

        private void btnOverlayBasFour_Click(object sender, EventArgs e)
        {
            if (imageWithFrame == true)
            {
                prvImage = finalImage;
            }
            else
            {
                prvImage = origImage;
            }
            imageWithEffect = true;
            tempPicBoxImage = prvImage;
            tempPicBoxImage = resizeImage(tempPicBoxImage, new Size(469, 241));

            tempFrameImage = btnOverlayBasFour.BackgroundImage;
            tempFrameImage = resizeImage(tempFrameImage, new Size(469, 241));

            ApplyFrameAveragePhotoMerge(tempPicBoxImage, tempFrameImage);
        }

        private void btnOverlayBasFive_Click(object sender, EventArgs e)
        {
            if (imageWithFrame == true)
            {
                prvImage = finalImage;
            }
            else
            {
                prvImage = origImage;
            }
            imageWithEffect = true;
            tempPicBoxImage = prvImage;
            tempPicBoxImage = resizeImage(tempPicBoxImage, new Size(469, 241));

            tempFrameImage = btnOverlayBasFive.BackgroundImage;
            tempFrameImage = resizeImage(tempFrameImage, new Size(469, 241));

            ApplyFrameAddPhotoMerge(tempPicBoxImage, tempFrameImage);
        }

        private void btnOverlayBasSix_Click(object sender, EventArgs e)
        {
            if (imageWithFrame == true)
            {
                prvImage = finalImage;
            }
            else
            {
                prvImage = origImage;
            }
            imageWithEffect = true;
            tempPicBoxImage = prvImage;
            tempPicBoxImage = resizeImage(tempPicBoxImage, new Size(469, 241));

            tempFrameImage = btnOverlayBasSix.BackgroundImage;
            tempFrameImage = resizeImage(tempFrameImage, new Size(469, 241));

            ApplyFrameAveragePhotoMerge(tempPicBoxImage, tempFrameImage);
        }

        private void btnNextTwo_Click(object sender, EventArgs e)
        {
            phaseThreeImage = picBoxThree.Image;
            ExpressFormText epFormText = new ExpressFormText();
            epFormText.SetImagePreview(phaseThreeImage.Clone() as Image);

            epFormText.Show();
            this.Hide();
        }


    }
}
