using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;                //allows me to read and write files

namespace Exam_Project_2
{
    public partial class Conversions : Form
    {
        public Conversions()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            //closes the form
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string strConversion;               //holds data coming from text file
            int X = 0;                          //Counter
            //reads text file for conversions

            try
            {
                StreamReader ConversionFile;
                //opens the file
                ConversionFile = File.OpenText("conversions.txt");
                //Read the data
                while (ConversionFile.EndOfStream == false)
                {
                    X = X + 1;
                    strConversion = ConversionFile.ReadLine();

                    //Where does the data go?
                    switch (X)
                    {
                        case 1:
                            lblUSDtoPounds.Text = strConversion;
                            break;
                        case 2:
                            lblUSDtoEuros.Text = strConversion;
                            break;
                        case 3:
                            lblEurostoUSD.Text = strConversion;
                            break;
                        default:
                            lblPoundstoUSD.Text = strConversion;
                            break;


                    }
                }
                //Closes the file
                ConversionFile.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                this.Close();
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //Variable for calculations
            decimal decUSDPounds;
            decimal decUSDEuros;
            decimal decEurosUSD;
            decimal decPoundsUSD;
            decimal decTotal;
            decimal decAmount;
  
            // Process inputs and add it to the list box
            if (radUSDtoPounds.Checked == true)
            {
                decUSDPounds = decimal.Parse(lblUSDtoPounds.Text);
                decAmount = decimal.Parse(txtboxAmount.Text);
                decTotal = decUSDPounds * decAmount;
                listboxOutput.Items.Add(txtboxCustomer.Text + " - " + txtboxDestination.Text + " - " + decTotal + " Pounds");
       
                txtboxCustomer.Focus();
                
            }
            else if (radUSDtoEuros.Checked == true)
            {
                decUSDEuros = decimal.Parse(lblUSDtoEuros.Text);
                decAmount = decimal.Parse(txtboxAmount.Text);
                decTotal = decUSDEuros * decAmount;
                listboxOutput.Items.Add(txtboxCustomer.Text + " - " + txtboxDestination.Text + " - " + decTotal + " Euros");
                txtboxCustomer.Focus();
            }
            else if (radEurostoUSD.Checked == true)
            {
                decEurosUSD = decimal.Parse(lblEurostoUSD.Text);
                decAmount = decimal.Parse(txtboxAmount.Text);
                decTotal = decEurosUSD * decAmount;
                listboxOutput.Items.Add(txtboxCustomer.Text + " - " + txtboxDestination.Text + " - " + decTotal + " USD");
                txtboxCustomer.Focus();
            }
            else if (radPoundstoUSD.Checked == true)
            {
                decPoundsUSD = decimal.Parse(lblPoundstoUSD.Text);
                decAmount = decimal.Parse(txtboxAmount.Text);
                decTotal = decPoundsUSD * decAmount;
                listboxOutput.Items.Add(txtboxCustomer.Text + " - " + txtboxDestination.Text + " - " + decTotal + " USD");
                txtboxCustomer.Focus();
            }
            else
            {
                MessageBox.Show("Invalide Conversion Selected");
            }

            TextWriter txt = new StreamWriter("History.txt");
            txt.Write(listboxOutput.Text);
            txt.Close();
        }
    }
}
