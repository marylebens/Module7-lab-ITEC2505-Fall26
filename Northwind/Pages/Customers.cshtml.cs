using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;
using System.Runtime.Serialization;

public class CustomersModel : PageModel
{
    //Attribute of the customers model class
    //This attribute holds the list of customers (from the database)
    public List<Customer> Customers { get; set; }

    //OnGet method - onget method is a special method because it is
    // automatically called when the web page is loaded
    public void OnGet()
    {
        //Initialize a list of customers
        Customers = new List<Customer>();

        //Connect to the database and populate the list of customers
        // set up a connection string - this string holds
        //the values that are needed to establish a database connection
        string connectionString = "Data Source=../northwind.db;Mode=ReadOnly";

        //Use the connection string to make a new connection to the database
        using (SqliteConnection connection = new SqliteConnection(connectionString))
        {
            connection.Open();  //opens the connection

            // Set up a string to hold the SQL command that we will execute against the database
            string sql = "SELECT CustomerID, CompanyName, ContactName, Country FROM Customers";

            //Execute the SQL statement against the database
            using (SqliteCommand command = new SqliteCommand(sql, connection))
            {
                // Create a reader object - this reads the resultset from the database
                // that is returned when we execute our SQL command
                using (SqliteDataReader reader = command.ExecuteReader())
                {
                    //Loop through the result set from executing the SQL SELECT statement command
                    while (reader.Read())
                    {
                        // Add the columns, the values from the current record in the
                        //resultset to my list of customers
                        Customers.Add(new Customer
                        {
                            // Populate the new customer object with the data from the
                            // resultset from our database table
                            CustomerID = reader.GetString(0),
                            CompanyName = reader.GetString(1),
                            ContactName = reader.GetString(2),
                            Country = reader.GetString(3)
                        });
                    }
                }
            }
        }
    }
}

//Class that is a blueprint for creating a new Customer object
public class Customer
{
    //Attributes for the customer class
    public string CustomerID { get; set; }
    public string CompanyName { get; set; }
    public string ContactName { get; set; }
    public string Country { get; set; }
}