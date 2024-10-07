using MySql.Data.MySqlClient;
using System.Windows.Forms;
using System;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void buttonInsert_Click(object sender, EventArgs e)
        {
            // Retrieve the values from the text boxes
            string firstname = textBoxName.Text;
            string lastname = textBoxLastName.Text;

            // Check if name and age are valid
            if (string.IsNullOrEmpty(firstname) || string.IsNullOrEmpty(lastname))
            {
                MessageBox.Show("Please enter both Name and Age.");
                return;
            }

            // Connection string to the MySQL database (replace with your own values)
            string connectionString = "Server=localhost;Database=testdb;User ID=root;Password=root;";

            // Create a connection to MySQL
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    conn.Open();
                    Console.WriteLine("Connection opened successfully.");

                    // SQL Insert query
                    string insertQuery = "INSERT INTO testtable (firstname, lastname) VALUES (@firstname, @lastname)";

                    // Create a command
                    MySqlCommand cmd = new MySqlCommand(insertQuery, conn);

                    // Add parameters to prevent SQL injection
                    cmd.Parameters.AddWithValue("@firstname", firstname);
                    cmd.Parameters.AddWithValue("@lastname", lastname);

                    // Execute the insert query
                    int rowsAffected = cmd.ExecuteNonQuery();
                    MessageBox.Show($"{rowsAffected} row(s) inserted successfully!");

                }
                catch (MySqlException ex)
                {
                    // Show error if something went wrong
                    MessageBox.Show("Error: " + ex.Message);
                }
                finally
                {
                    // Close the connection
                    conn.Close();
                }
            }
        }

        private void textBoxLastNameall_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
