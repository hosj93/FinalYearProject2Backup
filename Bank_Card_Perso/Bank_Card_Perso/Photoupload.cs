using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bank_Card_Perso
{
    public partial class Photoupload : Form
    {
        public bool imageLoaded = false;
        private Bitmap bmpSelectedImg;
        private Bitmap previewSelectedImg;
        private string imageName;
        private string pathName;

        public Photoupload()
        {
            InitializeComponent();
            panelPhoto.Visible = true;
            ImgSelectPanel.Visible = false;
        }

        private void buttonSelectImg_Click(object sender, EventArgs e)
        {
            imageLoaded = false;
            panelPhoto.Visible = true;
            picBoxOne.Image = null;
            ImgSelectPanel.Visible = false;
            OpenFileDialog imageDirectory = new OpenFileDialog();
            imageDirectory.Filter = "All Files (*.*)|*.*";
            imageDirectory.Title = "Select an Image File";

            if (imageDirectory.ShowDialog() == DialogResult.OK)
            {
                StreamReader picStreamReader = new StreamReader(imageDirectory.FileName);
                bmpSelectedImg = (Bitmap)Bitmap.FromStream(picStreamReader.BaseStream);
                picStreamReader.Close();

                previewSelectedImg = bmpSelectedImg.CopyToSquareCanvas(picBoxOne.Width);
                picBoxOne.Image = previewSelectedImg;
                picBoxOne.SizeMode = PictureBoxSizeMode.StretchImage;
                imageLoaded = true;

            }
        }

        private void picBoxOne_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (imageLoaded == false)
            {
                g.DrawString("Your Photo",
                new Font("Arial", 15), System.Drawing.Brushes.Blue, new Point(150, 120));
            }
        }

        private void buttonImgGallery_Click(object sender, EventArgs e)
        {
            ImgSelectPanel.Visible = true;
            panelPhoto.Visible = false;
            int i = 0;
            string[] extensions = new[] { ".jpg", ".png", ".bmp", ".jpeg" };
            string[] directory = Directory.GetFiles(@"C:\Users\Jack\Pictures", "*.*")
                .Where(f => extensions.Contains(System.IO.Path.GetExtension(f).ToLower())).ToArray();
            this.listViewGallery.Items.Clear();
            foreach (string dir in directory)
            {
                listViewGallery.Items.Add(Path.GetFileNameWithoutExtension(dir), i);
                i++;
                if (i == imageList1.Images.Count)
                    i = 0;

            }
        }
        private void listViewGallery_DoubleClick(object sender, EventArgs e)
        {
            Image galleryImg;
            foreach (ListViewItem imgGallery in listViewGallery.SelectedItems)
            {
                int imgIndex = imgGallery.ImageIndex;
                if (imgIndex >= 0 && imgIndex < this.imageList1.Images.Count)
                {
                    ImgSelectPanel.Visible = false;
                    imageLoaded = true;
                    galleryImg = this.imageList1.Images[imgIndex];
                    imageName = this.imageList1.Images.Keys[imgIndex].ToString();
                    pathName = "C:\\Users\\Jack\\Pictures\\" + imageName;

                    StreamReader picStreamReader = new StreamReader(pathName);
                    bmpSelectedImg = (Bitmap)Bitmap.FromStream(picStreamReader.BaseStream);
                    picStreamReader.Close();

                    previewSelectedImg = bmpSelectedImg.CopyToSquareCanvas(picBoxOne.Width);
                    picBoxOne.Image = previewSelectedImg;
                    picBoxOne.SizeMode = PictureBoxSizeMode.StretchImage;
                    panelPhoto.Visible = true;

                }
            }

        }

        private void btnImgRandom_Click(object sender, EventArgs e)
        {
            Random rndImg = new Random();
            int iniImgIndex = 0;
            int maxImgIndex = imageList1.Images.Count;
            Image galleryImg;
            int imgIndex = rndImg.Next(iniImgIndex, maxImgIndex);
            if (imgIndex >= iniImgIndex && imgIndex < this.imageList1.Images.Count)
            {
                ImgSelectPanel.Visible = false;
                imageLoaded = true;
                galleryImg = this.imageList1.Images[imgIndex];
                imageName = this.imageList1.Images.Keys[imgIndex].ToString();
                pathName = "C:\\Users\\Jack\\Pictures\\" + imageName;

                StreamReader picStreamReader = new StreamReader(pathName);
                bmpSelectedImg = (Bitmap)Bitmap.FromStream(picStreamReader.BaseStream);
                picStreamReader.Close();

                previewSelectedImg = bmpSelectedImg.CopyToSquareCanvas(picBoxOne.Width);
                picBoxOne.Image = previewSelectedImg;
                picBoxOne.SizeMode = PictureBoxSizeMode.StretchImage;
                imageLoaded = true;
                panelPhoto.Visible = true;

            }

        }
        private void btnRotate_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Clicks == 1)
            {
                RotateImage rotateImage90 = new RotateImage();
                picBoxOne.Image = rotateImage90.RotateImage90Degree(previewSelectedImg);
                bmpSelectedImg = new Bitmap(picBoxOne.Image);
                previewSelectedImg = new Bitmap(picBoxOne.Image);
                imageLoaded = true;
            }
        }

        private void btnExpressMode_Click(object sender, EventArgs e)
        {
            string argRndImg = "Please Select a Photo";
            string noImgFound = "Opsssss.... No Photo Found !!" + Environment.NewLine + argRndImg;

            if (picBoxOne.Image == null)
            {
                DialogResult noImgResult = MessageBox.Show(noImgFound, "No Photo Found",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

            }
            else
            {
                Brightness formBright = new Brightness();
                formBright.SetImagePreview(bmpSelectedImg.Clone() as Image, previewSelectedImg.Clone() as Image);
                formBright.Show();
                //f2.ShowDialog();
                this.Hide();
            }
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Hide();
        }
    }
}