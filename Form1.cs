
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace interfaz2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string connection = "datasource=localhost;port=3306;username=root;password=;database=interfaz";
            string query = "select * from user";
            MySqlConnection databaseConnector = new MySqlConnection(connection);
            MySqlCommand commandoALanzar = new MySqlCommand(query, databaseConnector);
            commandoALanzar.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnector.Open();
                reader = commandoALanzar.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3) };
                        Console.WriteLine(reader.GetString(0) + " " + reader.GetString(1) + " " + reader.GetString(2) + " " + reader.GetString(3));

                    }
                }
                else
                {
                    Console.WriteLine("Datos inexistentes");
                }
                databaseConnector.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void GuardarUsuario()
        {
            string connection = "datasource=localhost;port=3306;username=root;password=;database=interfaz";
            string query = "INSERT INTO user(`ID`, `FIRST_NAME`, `LAST_NAME`, `ADDRESS`) VALUES (NULL, '" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "')";
            MySqlConnection databaseConnector = new MySqlConnection(connection);
            MySqlCommand databaseCommand = new MySqlCommand(query, databaseConnector);
            databaseCommand.CommandTimeout = 60;

            try
            {
                databaseConnector.Open();
                MySqlDataReader reader1 = databaseCommand.ExecuteReader();
                MessageBox.Show("Exito al guardar el dato");
                databaseConnector.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }
        private void MostrarUsuario()
        {
            string Connect = "datasource=localhost;port=3306;username=root;password=;database=interfaz;";
            string query = "select * from user";
            MySqlConnection databaseConnector = new MySqlConnection(Connect);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnector);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnector.Open();
                reader = commandDatabase.ExecuteReader();
                if (reader.HasRows)
                {
                    listView1.Items.Clear();
                    while (reader.Read())
                    {
                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3) };
                        var ListViewItems = new ListViewItem(row);
                        listView1.Items.Add(ListViewItems);
                    }

                }
                else
                {
                    Console.WriteLine("No se encontro nada");
                }
                databaseConnector.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Necesitas ingresar tu nombre");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Necesitas ingresar tu direccion");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Necesitas ingresar tu apellido");
            }
            else
            {

                GuardarUsuario();
                MostrarUsuario();
                Borrar();
                Modify();
                Buscar();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";

            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MostrarUsuario();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Borrar();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            Modify();
        }
        private void button5_Click(object sender, EventArgs e)
        {
            Buscar();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void Buscar()
        {
            string Connect = "datasource=localhost;port=3306;username=root;password=;database=interfaz;";
            string query = "select * from user where ID= '" + textBox4.Text + "' ";
            MySqlConnection databaseConnector = new MySqlConnection(Connect);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnector);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;


            try
            {
                databaseConnector.Open();
                reader = commandDatabase.ExecuteReader(); 
                if (reader.HasRows)
                {
                    listView1.Items.Clear();
                    while (reader.Read())
                    {
                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3) };
                        textBox1.Text = row[1];
                        textBox2.Text = row[2];
                        textBox3.Text = row[3];

                    }

                }
                else
                {
                    Console.WriteLine("No se encontro nada");
                }
                databaseConnector.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Actualizar()
        {
            string Connect = "datasource=localhost;port=3306;username=root;password=;database=interfaz;";
            string query = "UPDATE `user` SET `FIRST_NAME`='" + textBox1.Text + "',`LAST_NAME`='" + textBox2.Text + "',`ADDRESS`='" + textBox3.Text + "' WHERE ID = '" + textBox4.Text + "' ";//Modifica
            MySqlConnection databaseConnector = new MySqlConnection(Connect);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnector);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;


            try
            {
                databaseConnector.Open(); 
                reader = commandDatabase.ExecuteReader(); 
                if (reader.HasRows)
                {
                    listView1.Items.Clear();
                    while (reader.Read())
                    {
                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3) };
                        textBox1.Text = row[1];
                        textBox2.Text = row[2];
                        textBox3.Text = row[3];

                    }

                }
                else
                {
                    Console.WriteLine("Dato actualizado");
                }
                databaseConnector.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Borrar()
        {
            string Connect = "datasource=localhost;port=3306;username=root;password=;database=interfaz;";
            string query = "DELETE `user` SET `FIRST_NAME`='" + textBox1.Text + "',`LAST_NAME`='" + textBox2.Text + "',`ADDRESS`='" + textBox3.Text + "' WHERE ID = '" + textBox4.Text + "' ";
            MySqlConnection databaseConnector = new MySqlConnection(Connect);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnector);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;


            try
            {
                databaseConnector.Open(); 
                reader = commandDatabase.ExecuteReader(); 
                if (reader.HasRows)
                {
                    listView1.Items.Clear();
                    while (reader.Read())
                    {
                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3) };
                        textBox1.Text = row[1];
                        textBox2.Text = row[2];
                        textBox3.Text = row[3];

                    }

                }
                else
                {
                    Console.WriteLine("Dato eliminado");
                }
                databaseConnector.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Modify()
        {
            string Connect = "datasource=localhost;port=3306;username=root;password=;database=interfaz;";
            string query = "MODIFY `user` SET `FIRST_NAME`='" + textBox1.Text + "',`LAST_NAME`='" + textBox2.Text + "',`ADDRESS`='" + textBox3.Text + "' WHERE ID = '" + textBox4.Text + "' ";
            MySqlConnection databaseConnector = new MySqlConnection(Connect);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnector);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;


            try
            {
                databaseConnector.Open(); 
                reader = commandDatabase.ExecuteReader(); 
                if (reader.HasRows)
                {
                    listView1.Items.Clear();
                    while (reader.Read())
                    {
                        string[] row = { reader.GetString(0), reader.GetString(1), reader.GetString(2), reader.GetString(3) };
                        textBox1.Text = row[1];
                        textBox2.Text = row[2];
                        textBox3.Text = row[3];

                    }

                }
                else
                {
                    Console.WriteLine("Modificacion exitosa");
                }
                databaseConnector.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
          