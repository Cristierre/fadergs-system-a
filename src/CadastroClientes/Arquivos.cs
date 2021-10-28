using CadastroClientes.Aplicacao;
using CadastroClientes.Entidades;
using CsvHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroClientes
{
    public class Arquivos
    {
        public void ExportarListaParaCSV<T>(List<T> listaObj) {
            var dataHora = Util.ObterDataAtual();
            var dataHoraFormatoCSV = dataHora.ToString("yyyyMMddhhmmss");
            var nomeArquivo = $"ListaClientes{dataHoraFormatoCSV}.csv";
            var csvArquivoCaminho = Path.Combine(Environment.CurrentDirectory, nomeArquivo);

            using (FileStream fileStream = new FileStream(csvArquivoCaminho, FileMode.OpenOrCreate)) {
                using (var writer = new StreamWriter(fileStream, Encoding.GetEncoding("ISO-8859-1")))
                using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture)) {
                    csv.WriteHeader<Cliente>();
                    csv.NextRecord();

                    foreach (var item in listaObj) {
                        csv.WriteRecord(item);
                        csv.NextRecord();
                    }
                }
            }           
        }
    }
}
