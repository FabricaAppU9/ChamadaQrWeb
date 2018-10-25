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
            //Conexao de dados com MySql no host do uol
            string conStrMsql = 
                 "Server=chamadaqr.mysql.uhserver.com;" +
                 "Database=chamadaqr;" +
                 "Uid=ever1981;" +
                 "Pwd=@2018root;" +
                 "sslmode=none;";


            //Conexao de dados com SqlServer no host do azure
            string conStrSqlServer = 
                "Server = tcp:chamadaqr.database.windows.net,1433;" +
                "Initial Catalog=chamadaqr;" +
                "Persist Security Info=False;" +
                "User ID=u9adm;" +
                "Password=@2018root;" +
                "MultipleActiveResultSets=False;" +
                "Encrypt=True;" +
                "TrustServerCertificate=False;" +
                "Connection Timeout=30;";

            //Conexao de dados com MySql no host do azure mysql
            string conStrMsqlAzure =
                "Server=chamadaqr-mysqldbserver.mysql.database.azure.com; " +
                "Port=3306; " +
                "Database=chamadaqr; " +
                "Uid=u9adm@chamadaqr-mysqldbserver; " +
                "Pwd=@2018root; " +
                "SslMode=none;";

            //Variavel de ambiente - MYSQLCONNSTR_localdb
            //Armaznamento do mysql - d:\home\data\mysql
            //Localizacao do log - d:\home\logfiles\mysql


            MySqlConnection con1 = new MySqlConnection(conStrMsql);
            SqlConnection con2 = new SqlConnection(conStrSqlServer);
            MySqlConnection con3 = new MySqlConnection(conStrMsqlAzure);

            var mycon = con3;

            try
            {
                mycon.Open();
                MessageBox.Show("Connection Open! ");

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
                mycon.Close();
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
