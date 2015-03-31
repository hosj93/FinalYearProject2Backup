using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Text.RegularExpressions;

namespace BankCardPersonalization
{
    public partial class ExpressPreview : Form
    {
        private Image origImage;
        private Image prvImage;
        SqlConnection myConn = new SqlConnection("Data Source=LENOVO-PC\\BANKCARDPERSO;Initial Catalog=BankCardCredentials;Integrated Security=True");
        SqlCommand myCmd;
        private string strSQL;
        private Image customizedCard;
        public ExpressPreview()
        {
            InitializeComponent();
        }
        public void SetImagePreview(Image oriImage)
        {
            origImage = oriImage;
            prvImage = origImage.Clone() as Image;
            picBoxFive.Image = oriImage;
            picBoxFive.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            customizedCard = picBoxFive.Image;
            strSQL = "INSERT INTO ExpressMode (customerCustomizedCard) VALUES ('" + customizedCard + "')";

            try
            {
                myConn.Open();
                myCmd = new SqlCommand(strSQL, myConn);
                myCmd.ExecuteNonQuery();
                MessageBox.Show("Thank You For Your Registration.");
                myConn.Close();

            }
            catch
            {
                MessageBox.Show("Database Connection Error, Contact Customer Support For Immediate Assistance !");
            }
        }
    }
}