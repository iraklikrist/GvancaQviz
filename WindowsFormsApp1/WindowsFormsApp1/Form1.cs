using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            SqlConnection con = new SqlConnection("Data Source = DESKTOP-G4IPB7M\\MYSQLSERVER2; Initial Catalog = Project; Integrated Security = True; Pooling= False ");
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into Product values (@ID, @Name, @Price, @Country, @ExpireDate,@Contact, @ManufacturerID)", con);
            cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Price", double.Parse(textBox3.Text));
            cmd.Parameters.AddWithValue("@Country", comboBox1.Text);
            cmd.Parameters.AddWithValue("@ExpireDate", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@Contact", textBox4.Text);
            cmd.Parameters.AddWithValue("@Manufacturer", textBox5.Text);
            cmd.Parameters.AddWithValue("@ManufacturerID", int.Parse(textBox6.Text));
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Saved");

          
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }
    }
}
