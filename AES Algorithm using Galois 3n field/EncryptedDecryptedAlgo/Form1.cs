using PolyLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EncryptedDecryptedAlgo
{
    public partial class Form1 : Form
    {
        public string myString;
        public static int[] myAsCIIArray;
        public static string[] myTernaryArray;
        public Form1()
        {
            InitializeComponent();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            txtDecrypted.Text = myString;
        }
        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            myString = txtText.Text;
            if (txtText.Text != "")
            {
                myAsCIIArray = new int[myString.Length];
                int i = 0;
                foreach (char mychar in myString)
                {
                    int unicode = mychar;
                    txtASCII.Text += unicode;
                    myAsCIIArray[i] = unicode;
                    i++;
                }

                string ter = ToTrenary(myAsCIIArray);
                txtTernary.Text = ter;

                ChangeToPolynomial(myTernaryArray);
            }
        }


        public void ChangeToPolynomial(string[] myTerArray)
        {
            Polynomial[] polyArray = new Polynomial[myTerArray.Length];
            for (int i = 0; i < myTerArray.Length; i++)
            {
                double [] myDoubleArray=new double[myTerArray[i].Length];
                for (int j = 0; j < myTerArray[i].Length; j++)
                {
                    if (myTerArray[i][j].ToString() == "2")
                    {
                        myDoubleArray[j] = -1;
                    }
                    else
                    {
                        myDoubleArray[j] = double.Parse(myTerArray[i][j].ToString());
                    }
                    
                }
                polyArray[i] = new Polynomial(myDoubleArray);
            }

            Polynomial[] myFinalPolynomialParts = new Polynomial[myString.Length];
            for (int k = 0; k < myString.Length; k++)
            {
                
                if(k==0){
                    myFinalPolynomialParts[k]=polyArray[k];   
                }
                else{
                    
                double[] dZeroSequence=new double[(myString.Length*k)+1];
                dZeroSequence[(myString.Length*k)] = 1;
                myFinalPolynomialParts[k] = polyArray[k] * (new Polynomial(dZeroSequence));   
                }
            
            }
            Polynomial myFinalPolynomial=null;
            for (int l = 0; l < myFinalPolynomialParts.Length; l++)
            {
                if (myFinalPolynomial == null)
                {
                    myFinalPolynomial = myFinalPolynomialParts[l];
                }
                else
                {
                    myFinalPolynomial += myFinalPolynomialParts[l];
                }
            }
          
            txtPolyEncryptedFormat.Text = myFinalPolynomial.ToString();
        }
        public string ToTrenary(int[] myAsCIIArray)
        {


            StringBuilder Sb = new StringBuilder();

            myTernaryArray = new string[myAsCIIArray.Length];
            for (int i = 0; i < myAsCIIArray.Length; i++)
            {
                string myTerValues = "";
                while (myAsCIIArray[i] > 0)
                {
                    if (myAsCIIArray[i] % 3 == 2)
                    {
                        Sb.Insert(0, -1);
                    }
                    else
                    {
                        Sb.Insert(0, myAsCIIArray[i] % 3);
                    }
                    myTerValues += (myAsCIIArray[i] % 3).ToString();
                    myAsCIIArray[i] /= 3;
                }
                myTernaryArray[i] = myTerValues;


            }
            return Sb.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clear();
        }
        void clear()
        {
            txtText.Clear();
            txtASCII.Clear();
            txtTernary.Clear();
            txtPolyEncryptedFormat.Clear();
            txtDecrypted.Clear();
        }

    
          }
}
