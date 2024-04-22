using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-G4IPB7M\\MYSQLSERVER2; Initial Catalog=Project; Integrated Security=True; Pooling=False");
            con.Open();


            SqlCommand manufacturerCmd = new SqlCommand("INSERT INTO Manufacturer VALUES (@ManufacturerID, @ManufacturerName)", con);
            manufacturerCmd.Parameters.AddWithValue("@ManufacturerID", int.Parse(textBox6.Text));
            manufacturerCmd.Parameters.AddWithValue("@ManufacturerName", textBox5.Text); // Change this to your desired manufacturer name
            manufacturerCmd.ExecuteNonQuery();

            // Insert into Product table
            SqlCommand productCmd = new SqlCommand("INSERT INTO Product VALUES (@ID, @Name, @Price, @Country, @ExpireDate, @Contact, @ManufacturerID)", con);
            productCmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            productCmd.Parameters.AddWithValue("@Name", textBox2.Text);
            productCmd.Parameters.AddWithValue("@Price", double.Parse(textBox3.Text));
            productCmd.Parameters.AddWithValue("@Country", comboBox1.Text);
            productCmd.Parameters.AddWithValue("@ExpireDate", dateTimePicker1.Text);
            productCmd.Parameters.AddWithValue("@Contact", textBox4.Text);
            productCmd.Parameters.AddWithValue("@ManufacturerID", int.Parse(textBox6.Text));
            productCmd.ExecuteNonQuery();

    
           

            con.Close();
            MessageBox.Show("Successfully Saved");
        }


        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-G4IPB7M\\MYSQLSERVER2; Initial Catalog=Project; Integrated Security=True; Pooling=False");
            con.Open();

            // Update Manufacturer table
            SqlCommand manufacturerCmd = new SqlCommand("UPDATE Manufacturer SET ManufacturerName = @ManufacturerName WHERE ManufacturerID = @ManufacturerID", con);
            manufacturerCmd.Parameters.AddWithValue("@ManufacturerID", int.Parse(textBox6.Text));
            manufacturerCmd.Parameters.AddWithValue("@ManufacturerName", textBox5.Text);
            manufacturerCmd.ExecuteNonQuery();

            // Update Product table
            SqlCommand productCmd = new SqlCommand("UPDATE Product SET Name = @Name, Price = @Price, Country = @Country, ExpireDate = @ExpireDate, Contact = @Contact, ManufacturerID = @ManufacturerID WHERE ID = @ID", con);
            productCmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            productCmd.Parameters.AddWithValue("@Name", textBox2.Text);
            productCmd.Parameters.AddWithValue("@Price", double.Parse(textBox3.Text));
            productCmd.Parameters.AddWithValue("@Country", comboBox1.Text);
            productCmd.Parameters.AddWithValue("@ExpireDate", dateTimePicker1.Value); // Use Value property for DateTimePicker
            productCmd.Parameters.AddWithValue("@Contact", textBox4.Text);
            productCmd.Parameters.AddWithValue("@ManufacturerID", int.Parse(textBox6.Text));
            productCmd.ExecuteNonQuery();

            con.Close();
            MessageBox.Show("Successfully Updated");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-G4IPB7M\\MYSQLSERVER2; Initial Catalog=Project; Integrated Security=True; Pooling=False");
            con.Open();

            int manufacturerID;
            if (int.TryParse(textBox6.Text, out manufacturerID))
            {
                // Delete associated products first
                SqlCommand productCmd = new SqlCommand("DELETE FROM Product WHERE ManufacturerID = @ManufacturerID", con);
                productCmd.Parameters.AddWithValue("@ManufacturerID", manufacturerID);
                productCmd.ExecuteNonQuery();

                // Then delete the manufacturer
                SqlCommand manufacturerCmd = new SqlCommand("DELETE FROM Manufacturer WHERE ManufacturerID = @ManufacturerID", con);
                manufacturerCmd.Parameters.AddWithValue("@ManufacturerID", manufacturerID);
                manufacturerCmd.ExecuteNonQuery();

                MessageBox.Show("Successfully deleted");
            }
            else
            {
                MessageBox.Show("Invalid manufacturer ID. Please enter a valid integer.");
            }

            con.Close();


        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Data Source=DESKTOP-G4IPB7M\\MYSQLSERVER2; Initial Catalog=Project; Integrated Security=True; Pooling=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT p.*, m.ManufacturerName FROM Product p JOIN Manufacturer m ON p.ManufacturerID = m.ManufacturerID WHERE p.ManufacturerID = @ManufacturerID", con);
            cmd.Parameters.AddWithValue("@ManufacturerID", int.Parse(textBox1.Text));
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

        }
    }
}
