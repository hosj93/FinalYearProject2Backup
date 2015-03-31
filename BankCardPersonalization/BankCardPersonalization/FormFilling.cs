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
    public partial class FormFilling : Form
    {
        SqlConnection myConn = new SqlConnection("Data Source=LENOVO-PC\\BANKCARDPERSO;Initial Catalog=BankCardCredentials;Integrated Security=True");
        SqlCommand myCmd;
        private string nricName;
        private string nricNumber;
        private string addressOne;
        private string addressTwo;
        private string city;
        private string state;
        private string poskod;
        private string emailAddress;
        private string mobileNumber;
        private Image customizedCard;
        private string strSQL;
        private bool dataChecking = false;
        private bool fieldChecking = false;
        Exception IcNumberException = new Exception();
        public FormFilling()
        {
            InitializeComponent();
            LoadingStateBox();
        }

        public void SetCardPreview(Image cardImage)
        {
            picCardPreview.Image = cardImage;
            picCardPreview.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private void LoadingStateBox()
        {
            cBoxState.Items.Add("Kuala Lumpur");
            cBoxState.Items.Add("Perlis");
            cBoxState.Items.Add("Kedah");
            cBoxState.Items.Add("Pahang");
            cBoxState.Items.Add("Kelantan");
            cBoxState.Items.Add("Terengganu");
            cBoxState.Items.Add("Perak");
            cBoxState.Items.Add("Penang");
            cBoxState.Items.Add("Selangor");
            cBoxState.Items.Add("Negeri Sembilan");
            cBoxState.Items.Add("Melaka");
            cBoxState.Items.Add("Johor");
            cBoxState.Items.Add("Sabah");
            cBoxState.Items.Add("Sarawak");
            cBoxState.SelectedIndex = 0;

        }

        private void btnProceedCard_Click(object sender, EventArgs e)
        {
            try
            {
                nricName = textName.Text;
                nricNumber = textNRIC.Text;
                addressOne = textAddOne.Text;
                addressTwo = textAddTwo.Text;
                city = textCity.Text;
                state = cBoxState.SelectedItem.ToString();
                poskod = textPoskod.Text;
                emailAddress = textEmail.Text;
                mobileNumber = textMobile.Text;
                customizedCard = picCardPreview.Image;
                strSQL = "INSERT INTO CustomerDetails (nricName, nricNumber, addressOne, addressTwo," +
                "city, state, poskod, emailAddress, mobileNumber, photoCard) VALUES ('" + nricName + "','" +
                nricNumber + "','" + addressOne + "','" + addressTwo + "','" + city + "','" + state +
                "','" + poskod + "','" + emailAddress + "','" + mobileNumber + "','" + customizedCard + "')";
                dataChecking = CheckEmptyData(nricName, nricNumber, addressOne, city, poskod, mobileNumber);
                fieldChecking = CheckData(nricName, nricNumber, addressOne, city, poskod, mobileNumber);
                if (dataChecking == true || fieldChecking == true)
                {
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
            catch (ArgumentNullException)
            {
                MessageBox.Show("Required Field Shouldn't Be Blank !!!");
            }
            catch (FormatException ex) 
            {
                MessageBox.Show(ex.Message);
            }
            catch (IcNumberException exMessage)
            {
                MessageBox.Show(exMessage.Message);
            }
            catch (PoskodException pExMessage)
            {
                MessageBox.Show(pExMessage.Message);
            }
            catch (CityException cityExMessage)
            {
                MessageBox.Show(cityExMessage.Message);
            }
            catch (MobileException mobileExMessage)
            {
                MessageBox.Show(mobileExMessage.Message);
            }
        }

        private bool CheckEmptyData(string nricName, string nricNumber, string addressOne, string city, string poskod, string mobileNumber)
        {
            if (nricName == "" || nricNumber == "" || addressOne == ""
                        || city == "" || poskod == "" || mobileNumber == "")
            {
                throw new ArgumentNullException();
            }
            return true;
        }

        private bool CheckData(string nricName, string nricNumber, string addressOne, string city, string poskod, string mobileNumber)
        {
            if (Regex.IsMatch(nricName, @"\d"))
            {
                throw new FormatException("Invalid name, name shouldn't contained digit !!");   
            }
            if (!Regex.IsMatch(nricNumber, "^\\d{6}\\-\\d{2}\\-\\d{4}$"))
            {
                throw new IcNumberException("Incorrect IC Number Format !! IC number should look like this : 123456-78-9012");
                
            }
            if (poskod.Length != 5)
            {
                throw new PoskodException("Poskod should contained 5 digits");
            }
            if (Regex.IsMatch(city, @"\d")) ;
            {
                throw new CityException("City name shouldn't contained digits");
            }
            if(!Regex.IsMatch(mobileNumber,"^([0])([1])([1,2,3,4,6,7,8,9])([0-9][0-9][0-9][0-9][0-9][0-9][0-9])"))
            {
                throw new MobileException("Please provide a valid mobile phone number");
            }
            return true;
        }
    }
}
public class MobileException : Exception
{
    public MobileException()
    {
    }

    public MobileException(string message)
        : base(message)
    {
    }
}
public class CityException : Exception
{
    public CityException()
    {
    }

    public CityException(string message)
        : base(message)
    {
    }
}
public class PoskodException : Exception
{
    public PoskodException()
    {
    }

    public PoskodException(string message)
        : base(message)
    {
    }
}
public class IcNumberException: Exception
{
    public IcNumberException()
    {
    }

    public IcNumberException(string message)
        : base(message)
    {
    }
}