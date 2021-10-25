using CadastroClientes.AcessoDados.BancoSql;
using CadastroClientes.Entidades;
using CadastroClientes.AcessoDados;
using System.Collections.Generic;
using System.Data;
using System;

namespace CadastroClientes.AcessoDados.Repositorio
{
    public class RepositorioClientes
    {
        private BDMySql _mySql = new BDMySql();
        private string _comandoSql;

        public void Salvar(Cliente cliente) {
            var campos = "INSERT INTO Clientes (NomeCompleto, DataNascimento, EstadoCivil, Sexo, RG, CPF, Pais, Estado, Cidade, Bairro, CEP, Logradouro, Complemento, Numero, TelefoneFixo1, TelefoneFixo2, Celular1, Celular2, DataRegistro) ";
            var valores = $"VALUES ('{cliente.NomeCompleto}','{cliente.DataNascimento.ToString("yyyy-MM-dd")}','{cliente.EstadoCivil}','{cliente.Sexo.Substring(0, 1)}','{cliente.RG}','{cliente.CPF}','{cliente.Pais}','{cliente.Estado}','{cliente.Cidade}','{cliente.Bairro}','{cliente.CEP}','{cliente.Logradouro}','{cliente.Complemento}','{cliente.Numero}','{cliente.TelefoneFixo1}','{cliente.TelefoneFixo2}','{cliente.Celular1}','{cliente.Celular2}','{cliente.DataRegistro.ToString("yyyy-MM-dd")}')";

            _comandoSql = campos + valores;
            _mySql.Executar(_comandoSql);
        }

        public void Atualizar(Cliente cliente) {
            _comandoSql = "UPDATE Clientes " +
                        "SET NomeCompleto = '" + cliente.NomeCompleto + "'," +
                        "DataNascimento = '" + cliente.DataNascimento.ToString("yyyy-MM-dd") + "'," +
                        "EstadoCivil = '" + cliente.EstadoCivil + "'," +
                        "Sexo = '" + cliente.Sexo.Substring(0, 1) + "'," +
                        "RG = '" + cliente.RG + "'," +
                        "CPF = '" + cliente.CPF + "'," +
                        "Pais = '" + cliente.Pais + "'," +
                        "Estado = '" + cliente.Estado + "'," +
                        "Cidade = '" + cliente.Cidade + "'," +
                        "Bairro = '" + cliente.Bairro + "'," +
                        "CEP = '" + cliente.CEP + "'," +
                        "Logradouro = '" + cliente.Logradouro + "'," +
                        "Complemento = '" + cliente.Complemento + "'," +
                        "Numero = '" + cliente.Numero + "'," +
                        "TelefoneFixo1 = '" + cliente.TelefoneFixo1 + "'," +
                        "TelefoneFixo2 = '" + cliente.TelefoneFixo2 + "'," +
                        "Celular1 = '" + cliente.Celular1 + "'," +
                        "Celular2 = '" + cliente.Celular2 + "'" +
                       " WHERE Id = " + cliente.Id;           
            _mySql.Executar(_comandoSql);
        }

        public void Excluir(int id) {
            _comandoSql = $"DELETE FROM Clientes WHERE Id = {id}";
            _mySql.Executar(_comandoSql);
        }

        public List<Cliente> CarregarTodos() {
            List<Cliente> listaClientes = new List<Cliente>();
            DataTable dataTable;

            _comandoSql = "SELECT * FROM Clientes";
            dataTable = _mySql.ObterDataTable(_comandoSql);

            foreach (DataRow row in dataTable.Rows) {
                Cliente cliente = new Cliente();

                cliente.Id = int.Parse(GetValueRow(row, "Id"));
                cliente.NomeCompleto = GetValueRow(row, "NomeCompleto");
                cliente.DataNascimento = DateTime.Parse(GetValueRow(row, "DataNascimento"));
                cliente.EstadoCivil = int.Parse(GetValueRow(row, "EstadoCivil"));
                cliente.Sexo = GetValueRow(row, "Sexo");
                cliente.RG = long.Parse(GetValueRow(row, "RG"));
                cliente.CPF = long.Parse(GetValueRow(row, "CPF"));
                cliente.Pais = GetValueRow(row, "Pais");
                cliente.Estado = GetValueRow(row, "Estado");
                cliente.Cidade = GetValueRow(row, "Cidade");
                cliente.Bairro = GetValueRow(row, "Bairro");
                cliente.CEP = GetValueRow(row, "CEP");
                cliente.Logradouro = GetValueRow(row, "Logradouro");
                cliente.Complemento = GetValueRow(row, "Complemento");
                cliente.Numero = int.Parse(GetValueRow(row, "Numero"));
                cliente.TelefoneFixo1 = long.Parse(GetValueRow(row, "TelefoneFixo1"));
                cliente.TelefoneFixo2 = long.Parse(GetValueRow(row, "TelefoneFixo2"));
                cliente.Celular1 = long.Parse(GetValueRow(row, "Celular1"));
                cliente.Celular2 = long.Parse(GetValueRow(row, "Celular2"));
                cliente.DataRegistro = DateTime.Parse(GetValueRow(row, "DataRegistro"));

                listaClientes.Add(cliente);
            }

            return listaClientes;
        }

        private string GetValueRow(DataRow row, string nomeCampo) {
            return row[nomeCampo].ToString();
        }
    }
}