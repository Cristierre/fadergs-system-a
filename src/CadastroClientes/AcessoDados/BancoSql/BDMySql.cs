using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroClientes.AcessoDados.BancoSql
{
    public class BDMySql
    {
        private readonly string _connectionString = "SERVER=ec2-54-207-22-211.sa-east-1.compute.amazonaws.com; PORT=3306; DATABASE=fadergs; UID=fadergs; PWD=fadergs;";
        
        public void Executar(string ComandoSql) {
            MySqlConnection Conexao = Conectar();
            MySqlCommand Comando = new MySqlCommand();

            try {
                Comando.Connection = Conexao;

                Comando.CommandText = ComandoSql;
                Comando.ExecuteNonQuery();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            } finally {
                Conexao.Close();
            }
        }

        public MySqlConnection Conectar() {
            MySqlConnection Conexao = null;
            MySqlCommand Comando = new MySqlCommand();

            try {
                Conexao = new MySqlConnection(_connectionString);
                Comando.Connection = Conexao;
                if (Conexao.State == ConnectionState.Closed)
                    Conexao.Open();
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            } finally {
            }

            return Conexao;
        }

        public DataTable ObterDataTable(string ComandoSql) {
            MySqlConnection Conexao = null;
            MySqlCommand Comando = new MySqlCommand();
            MySqlDataAdapter DataAdapter = new MySqlDataAdapter();
            DataTable DataTable = null;
            DataSet DataSet;

            try {
                Conexao = new MySqlConnection(_connectionString);
                Comando = new MySqlCommand(ComandoSql, Conexao);
                
                DataAdapter = new MySqlDataAdapter(Comando);
                DataSet = new DataSet();
                DataTable = new DataTable();
                DataAdapter.Fill(DataTable);
            } catch (Exception ex) {
                MessageBox.Show(ex.Message);
            } finally {
                Conexao.Close();
            }

            return DataTable;
        }
    }
}