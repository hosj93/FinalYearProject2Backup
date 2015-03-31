using MetroFramework.Forms;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonPersonalize_MouseEnter(object sender, EventArgs e)
        {
            this.buttonPersonalize.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.customizeCardTwo));
        }

        private void buttonPersonalize_MouseLeave(object sender, EventArgs e)
        {
            this.buttonPersonalize.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.customizeCardOne));
        }

        private void btnCustomerService_MouseEnter(object sender, EventArgs e)
        {
            this.btnCustomerService.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.customerserviceOne));
        }

        private void btnCustomerService_MouseLeave(object sender, EventArgs e)
        {
            this.btnCustomerService.BackgroundImage = ((System.Drawing.Image)(Properties.Resources.social_customer_support));
        }

        private void buttonPersonalize_Click(object sender, EventArgs e)
        {
            Photoupload photoUpload = new Photoupload();
            photoUpload.Show();
            this.Hide();
        }
        
    }
}
