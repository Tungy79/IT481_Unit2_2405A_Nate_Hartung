using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT481_Unit2_2405A_Nate_Hartung
{
    internal class DB
    {
        string connectionString;
        SqlConnection cnn;
        public DB()
        {
            connectionString = "Server = SCHOOLLAPTOP\\SQLEXPRESS; " +
                                        "Trusted_Connections=true;" +
                                        "Database=northwind;" +
                                        "User Instance=false;" +
                                        "Connection timeout=30";


        }


        public DB(string conn)
        {
            connectionString = conn;
        }


        public string getCustomerCount()
        {
            Int32 count = 0;

            cnn = new SqlConnection(connectionString);
            cnn.Open();
            string countQuery = "select count(*) from dbo.Customers;";
            SqlCommand cmd = new SqlCommand(countQuery, cnn);

            try
            {
                count = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Error connecting to database: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error: " + ex.Message);
            }
            finally
            {
                cnn.Close();
            }

            return count.ToString();
        }

        public string getCompanyNames()
        {
            string names = "None";
            SqlDataReader dataReader;

            cnn = new SqlConnection(connectionString);
            cnn.Open();
            string countQuery = "select companyname from customers;";
            SqlCommand cmd = new SqlCommand(countQuery, cnn);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                try
                {
                    names = names + dataReader.GetValue(0) + "\n";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return names;
        }


        public string getOrderCount()
        {
            Int32 count = 0;

            cnn = new SqlConnection(connectionString);
            cnn.Open();
            string countQuery = "select count(*) from dbo.Orders;";
            SqlCommand cmd = new SqlCommand(countQuery, cnn);

            try
            {
                count = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return count.ToString();
        }


        public string getCustomerID()
        {
            string names = "None";
            SqlDataReader dataReader;

            cnn = new SqlConnection(connectionString);
            cnn.Open();
            string countQuery = "select distinct CustomerID from orders;";
            SqlCommand cmd = new SqlCommand(countQuery, cnn);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                try
                {
                    names = names + dataReader.GetValue(0) + "\n";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return names;

        }

        public string getEmployeeCount()
        {
            Int32 count = 0;

            cnn = new SqlConnection(connectionString);
            cnn.Open();
            string countQuery = "select count(*) from dbo.Employees;";
            SqlCommand cmd = new SqlCommand(countQuery, cnn);

            try
            {
                count = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return count.ToString();
        }



        public string getEmployeeLastName()
        {
            string names = "None";
            SqlDataReader dataReader;

            cnn = new SqlConnection(connectionString);
            cnn.Open();
            string countQuery = "select lastname from employees;";
            SqlCommand cmd = new SqlCommand(countQuery, cnn);
            dataReader = cmd.ExecuteReader();
            while (dataReader.Read())
            {
                try
                {
                    names = names + dataReader.GetValue(0) + "\n";
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return names;
        }
    }
}
