using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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

        //
        private void button1_Click(object sender, EventArgs e)
        {
            //bosta do hostinger
            //string conStr = "Data Source = sql169.main-hosting.eu; Network Library = DBMSSOCN;Initial Catalog = u788734955_chaqr; User ID = u788734955_root; Password = YEr6jv4hPd4U;";
            //"Server=sql169.main-hosting.eu;Port=3306;Database=u788734955_local;Uid=u788734955_ever;Pwd=root2018root;ConnectionLifeTime=3000;sslmode=none;";
            
            //uol
            string conStr = "Server=chamadaqr.mysql.uhserver.com;" +
                            "Database=chamadaqr;" +
                            "Uid=ever1981;" +
                            "Pwd=@2018root;" +
                            "sslmode=none;";

            MySqlConnection con = new MySqlConnection(conStr);
            try
            {
                con.Open();
                MessageBox.Show("Connection Open ! ");

                //DataTable table = new DataTable();
                //MySqlDataAdapter adapter = new MySqlDataAdapter("Select * from Aluno", con);
                //adapter.Fill(table);
                //dataGridView1.DataSource = table;

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
