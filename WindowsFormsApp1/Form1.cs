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

namespace WindowsFormsApp1
{   

    public partial class Form1 : Form
    {
        MySqlConnection conexion = new MySqlConnection("datasource=127.0.0.1;port=3306;username=root;password=;database=robot");
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// testear conexión con base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                MessageBox.Show("conectado");
                conexion.Close();


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Creación de backup de base de datos 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {

            String credenciales = "datasource=127.0.0.1;port=3306;username=root;password=;database=robot";
            String archivo = "C:\\Users\\56983\\Desktop\\trabajo practica\\bddbackup\\respaldo.sql";

            using (MySqlConnection conexion = new MySqlConnection(credenciales))
            {
                using (MySqlCommand comando = new MySqlCommand())
                {
                    using (MySqlBackup respaldo = new MySqlBackup(comando))
                    {
                        try
                        {
                            comando.Connection = conexion;
                            conexion.Open();
                            respaldo.ExportToFile(archivo);
                            conexion.Close();
                            MessageBox.Show("respaldo creado");
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);

                        }
                    }
                }
            }


    }
        /// <summary>
        /// crear base de datos nueva
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            String credenciales = "datasource=127.0.0.1;port=3306;username=root;password=";
           
            MySqlConnection conexion = new MySqlConnection(credenciales);
            MySqlCommand cmd;

            try
            {
                conexion.Open();
                string bd = "CREATE DATABASE magotteaux";

                cmd = new MySqlCommand(bd, conexion);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Base magotteaux creada");


            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
         

        }
        /// <summary>
        /// importar datos a nueva base de datos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button4_Click(object sender, EventArgs e)
        {
            String credenciales = "datasource=127.0.0.1;port=3306;username=root;password=;database=magotteaux";
            String archivo = "C:\\Users\\56983\\Desktop\\trabajo practica\\bddbackup\\respaldo.sql";

            using (MySqlConnection conexion = new MySqlConnection(credenciales))
            {
                using (MySqlCommand comando = new MySqlCommand())
                {
                    using (MySqlBackup respaldo = new MySqlBackup(comando))
                    {
                        try
                        {
                            comando.Connection = conexion;
                            conexion.Open();
                            respaldo.ImportFromFile(archivo);
                            conexion.Close();
                            MessageBox.Show("Restore de base hecho en una nueva base");


                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }

        }
    }
    }

