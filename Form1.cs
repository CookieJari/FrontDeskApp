using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ProgressBar;

namespace FrontDeskApp
{
    public partial class Form1 : Form
    {   
        // we declare the storage container
        Storage Storage = new Storage();

        // Declare list of Customers
        List<Customer>Customers = new List<Customer>() 
        {
            new Customer{FName="Jari",LName="Parial",MNumber="(995) 465-5276" }
        };

        //Create a List of transactions
        List<Transaction> TransactionList = new List<Transaction>();

        // the variables we get from the form
        string fName = "";
        string lName = "";
        string mNumber = "";

        int sBox = 0;
        int mBox = 0;
        int lBox = 0;

        DateTime transacTime;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //change transac time to right now
            transacTime = DateTime.Now;

            //Create user if non existent,
            //use User if existent
            Customer Customer = new Customer();
            Customer.FName = fName;
            Customer.LName = lName;
            Customer.MNumber = mNumber;
            //Get Index of current user in the list
            int containsItem = Customers.FindIndex(item => item.FName == Customer.FName && item.LName==Customer.LName);
            //If user does not exist, it returns -1
            if (containsItem<0)
            {
                Customers.Add(Customer);
            }
            else
            {
                Customer = Customers[containsItem];
            }

            // first we check if there is enough space to fill
            if (Storage.GetRemaining(1) <= sBox)
            {
                MessageBox.Show("Too many Small boxes");
            }
            else if (Storage.GetRemaining(2) <= mBox)
            {
                MessageBox.Show("Too many Medium boxes");
            }
            else if (Storage.GetRemaining(3) <= lBox)
            {
                MessageBox.Show("Too many Large boxes");
            }
            else 
            {
                // add box amount to owner
                Customer.SBoxes = sBox;
                Customer.MBoxes = mBox;
                Customer.LBoxes = lBox;

                // add box to storage
                Storage.SBoxes=sBox;
                Storage.MBoxes=mBox;
                Storage.LBoxes=lBox;

                MessageBox.Show("Storage was a Success!\n" +
                    "Customer Boxes:\n" +
                    "S: "+Customer.SBoxes+ "\tM: "+Customer.MBoxes+"\tL: "+Customer.LBoxes+
                    "\nStorage Boxes:\n"+
                    "S: " + Storage.SBoxes + "\tM: " + Storage.MBoxes + "\tL: " + Storage.LBoxes);

                // add to transaction History
                Transaction transaction = new Transaction();
                transaction.Owner = Customer;
                transaction.SBoxes = sBox;
                transaction.MBoxes = mBox;
                transaction.LBoxes = lBox;
                transaction.TransacTime = transacTime;
                transaction.TransacType= "Store";

                TransactionList.Add(transaction);

            }

        }

        //Retrieve Boxes
        private void button2_Click(object sender, EventArgs e)
        {
            //change transac time to right now
            transacTime = DateTime.Now;

            //Create user if non existent,
            //use User if existent
            Customer Customer = new Customer();
            Customer.FName = fName;
            Customer.LName = lName;
            Customer.MNumber = mNumber;
            //Get Index of current user in the list
            int containsItem = Customers.FindIndex(item => item.FName == Customer.FName && item.LName == Customer.LName);
            //If user does not exist, it returns -1
            if (containsItem < 0)
            {
                MessageBox.Show("User Does not Exist");
            }
            else
            {
                Customer = Customers[containsItem];

                // first we check if there is enough boxes to retrieve
                if (Customer.SBoxes<= sBox)
                {
                    MessageBox.Show("Not enough Small boxes");
                }
                else if (Customer.MBoxes <= mBox)
                {
                    MessageBox.Show("Not enough Medium boxes");
                }
                else if (Customer.LBoxes <= lBox)
                {
                    MessageBox.Show("Not enough Large boxes");
                }
                else
                {
                    // add box amount to owner
                    Customer.SBoxes = -sBox;
                    Customer.MBoxes = -mBox;
                    Customer.LBoxes = -lBox;

                    // add box to storage
                    Storage.SBoxes = -sBox;
                    Storage.MBoxes = -mBox;
                    Storage.LBoxes = -lBox;

                    MessageBox.Show("Retrieve was a Success!\n" +
                        "Customer Boxes:\n" +
                        "S: " + Customer.SBoxes + "\tM: " + Customer.MBoxes + "\tL: " + Customer.LBoxes +
                        "\nStorage Boxes:\n" +
                        "S: " + Storage.SBoxes + "\tM: " + Storage.MBoxes + "\tL: " + Storage.LBoxes);

                    // add to transaction History
                    Transaction transaction = new Transaction();
                    transaction.Owner = Customer;
                    transaction.SBoxes = sBox;
                    transaction.MBoxes = mBox;
                    transaction.LBoxes = lBox;
                    transaction.TransacTime = transacTime;
                    transaction.TransacType = "Retrieve";

                    TransactionList.Add(transaction);

                }
            }

        }

        //Check remaining boxes
        private void button4_Click(object sender, EventArgs e)
        {
            int s = Storage.GetRemaining(1);
            int m = Storage.GetRemaining(2);
            int l = Storage.GetRemaining(3);

            MessageBox.Show("These are the remaining slots\n" +
                "Small: " + s + "\t\tMedium: " + m + "\tLarge: " +l) ;

        }

        // Printing Transaction HIstory
        private void button3_Click(object sender, EventArgs e)
        {
            string output="";
            foreach (var transac in TransactionList)
            {
                string temp = transac.Owner.FName + " " + transac.Owner.LName + "\t\t" + transac.Owner.MNumber + "\t"
                    +"S: "+transac.SBoxes+"\t" + "M: " + transac.MBoxes + "\t" + "L: " + transac.LBoxes + "\n"+
                    "Type: " + transac.TransacType+"\t"+ "Date: " + transac.TransacTime + "\n\n";

                output +=temp;
            }

            MessageBox.Show(output);
        }

        

        // Functions for updating values

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            fName= textBox1.Text;
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            lName = textBox2.Text;
        }

        private void maskedTextBox1_MaskInputRejected_1(object sender, MaskInputRejectedEventArgs e)
        {
            mNumber = maskedTextBox1.Text;
        }
        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            sBox = Convert.ToInt32(numericUpDown2.Value);
        }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            mBox = Convert.ToInt32(numericUpDown1.Value);
        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            lBox = Convert.ToInt32(numericUpDown3.Value);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

    }
}
