﻿using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ChamadaTE
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {                   
            string comStr = "Database=localdb;Data Source=127.0.0.1;User Id=azure;Password=6#vWHD_$;Port=56550";
            MySqlConnection con = new MySqlConnection(comStr);
            try
            {
                con.Open();
                MessageBox.Show("Connection Open ! ");

                DataTable table = new DataTable();
                MySqlDataAdapter adapter = new MySqlDataAdapter("Select * from Aluno", con);
                adapter.Fill(table);
                dataGridView1.DataSource = table;

                /*esta metodo retorna somente a quantidade de linhas do banco
                MySqlCommand cmd = new MySqlCommand("Select * from Aluno", cnn);
                MySqlDataReader leitor = cmd.ExecuteReader();
                while (leitor.Read())
                MessageBox.Show(leitor[0].ToString());
               */

                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can not open connection ! " + ex.Message.ToString());
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
