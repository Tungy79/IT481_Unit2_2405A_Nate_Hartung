using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IT481_Unit2_2405A_Nate_Hartung
{
    public partial class Form1 : Form
    {
        private DB db;


        public Form1()
        {
            InitializeComponent();
            button1.Click += new System.EventHandler(button1_Click);
            button2.Click += new System.EventHandler(button2_Click);
            button3.Click += new System.EventHandler(button3_Click);
            button4.Click += new System.EventHandler(button4_Click);
            button5.Click += new System.EventHandler(button5_Click);
            button6.Click += new System.EventHandler(button6_Click);
            button7.Click += new System.EventHandler(button7_Click);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*database = new DB("Server = SCHOOLLAPTOP\\SQLEXPRESS; " +
                                        "Trusted_Connection=true;" +
                                        "Database=northwind;" +
                                        "User Instance=false;" +
                                        "Connection timeout=30");

            MessageBox.Show("Connection information sent");*/

            bool isValid = true;
            string user = textBox1.Text;
            string password = textBox2.Text;
            string server = textBox4.Text;
            string database = textBox3.Text;

            if (user.Length == 0 || password.Length == 0 || server.Length == 0 || database.Length == 0)
            {
                isValid = false;
                MessageBox.Show("You must enter user name, password, server, and database values");

            }

            if (isValid)
            { 
                db = new DB("Server = " + server + "\\SQLEXPRESS;" +
                            "Trusted_Connection=true;" +
                            "Database = " + database + ";" +
                            "User Id = " + user + ";" +
                            "Password = " + password + ";"
                            );


                MessageBox.Show("Connection information sent");
            }    
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string count = db.getCustomerCount();
            MessageBox.Show(count, "Customer count");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string names = db.getCompanyNames();
            MessageBox.Show(names, "Company names");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string count = db.getOrderCount();
            MessageBox.Show(count, "Order count");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string names = db.getCustomerID();
            MessageBox.Show(names, "CustomerID");
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string count = db.getEmployeeCount();
            MessageBox.Show(count, "Employee count");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string names = db.getEmployeeLastName();
            MessageBox.Show(names, "Emloyee Last Name");
        }


    }
}
