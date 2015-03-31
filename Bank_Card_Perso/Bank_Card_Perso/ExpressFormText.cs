using System;
using System;
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

namespace Bank_Card_Perso
{
    public partial class ExpressFormText : Form
    {
        public Image origImage;
        public Image prvImage;
        public Bitmap temp;
        public Bitmap bmap;
        public Image phaseFourImage;
        public bool textedImage = false;
        private Image tempPicBoxImage;
        private Image tempFrameImage;
        public ExpressFormText()
        {
            InitializeComponent();
            panelTextTwo.Visible = false;
            //lblComplete.Visible = false;
        }

        public void SetImagePreview(Image oriImage)
        {
            origImage = oriImage;
            prvImage = origImage.Clone() as Image;
            picBoxFour.Image = oriImage;
            picBoxFour.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btnNone_Click(object sender, EventArgs e)
        {
            picBoxFour.Image = origImage;
            //lblComplete.Visible = true;
        }

        private void InsertText(string displayText, string displayTextFont, float displayTextFontSize, string displayTextFontStyle, string displayTextForeColor, string displayTextLocation)
        {
            temp = (Bitmap)prvImage;
            bmap = (Bitmap)temp.Clone();
            Graphics gr = Graphics.FromImage(bmap);
            if (string.IsNullOrEmpty(displayTextFont))
                displayTextFont = "Times New Roman";
            if (displayTextFontSize.Equals(null))
                displayTextFontSize = 20.0F;
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
            gr.DrawString(displayText, font, LGBrush, 0, 0);
            picBoxFour.Image = (Bitmap)bmap.Clone();
            textedImage = true;
        }

        private void btnTextOne_Click(object sender, EventArgs e)
        {
            picBoxFour.Refresh();
            InsertText(btnTextOne.Text, "Arial Black", 15, "Italic", "Blue", "Bottom-Right");
            //lblComplete.Visible = true;
        }

        private void btnTextTwo_Click(object sender, EventArgs e)
        {
            picBoxFour.Refresh();
            InsertText(btnTextTwo.Text, "times new roman", 20, "Bold", "Blue", "Bottom-Left");
            //lblComplete.Visible = true;
        }

        private void btnTextThree_Click(object sender, EventArgs e)
        {
            picBoxFour.Refresh();
            InsertText(btnTextThree.Text, "times new roman", 20, "Bold", "Blue", "Bottom-Left");
            //lblComplete.Visible = true;
        }

        private void scrollBarText_Scroll(object sender, ScrollEventArgs e)
        {
            switch (scrollBarText.Value)
            {
                case 0:
                    panelTextOne.Visible = true;
                    panelTextTwo.Visible = false;
                    break;
                case 1:
                    panelTextOne.Visible = false;
                    panelTextTwo.Visible = true;
                    break;

            }
        }

        private void btnResetImage_Click(object sender, EventArgs e)
        {
            picBoxFour.Image = origImage;
        }
        public static Image resizeImage(Image imgToResize, Size size)
        {
            return (Image)(new Bitmap(imgToResize, size));
        }
        private void ApplyFrameAveragePhotoMerge(Image customizedImage, Image frameImage)
        {
            Bitmap ImageModified = (Bitmap)customizedImage;
            Bitmap ImageFrame = (Bitmap)frameImage;
            picBoxFour.Image = ImageModified.ArithmeticBlend(ImageFrame,
                                   (ColorCalculator.ColorCalculationType)ColorCalculator.ColorCalculationType.Average);
            //previewImgBox.Image = selectedSource;
        }
        private void btnNextThree_Click(object sender, EventArgs e)
        {
            tempPicBoxImage = picBoxFour.Image;
            tempPicBoxImage = resizeImage(tempPicBoxImage, new Size(531, 281));

            tempFrameImage = picBoxCardPreview.Image;
            tempFrameImage = resizeImage(tempFrameImage, new Size(531, 281));

            //selectedSource = (Bitmap)previewImgBox.Image;
            //frameImage = new Bitmap (picBoxTesting.Image);

            ApplyFrameAveragePhotoMerge(tempPicBoxImage, tempFrameImage);

            phaseFourImage = picBoxFour.Image;
            ExpressPreview epPreview = new ExpressPreview();
            epPreview.SetImagePreview(phaseFourImage.Clone() as Image);

            epPreview.Show();
            this.Hide();
        }
    }
}
