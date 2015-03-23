using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BankCardPersonalization
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            LoadingStateBox();
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

        }

       
    }
}
