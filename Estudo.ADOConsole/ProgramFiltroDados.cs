using System;
using System.Data;

namespace Estudo.ADOConsole
{
    public static class ProgramFiltroDados
    {
        public static void Main(string[] args)
        {
            DataTable TabelaExemplo = new DataTable("Exemplo");

            // adicionando coluna
            TabelaExemplo.Columns.Add("Id", typeof(long));
            TabelaExemplo.Columns.Add("PrimeiroNome", typeof(string));
            TabelaExemplo.Columns.Add("SegundoNome", typeof(string));
            TabelaExemplo.Columns.Add("DataNascimento", typeof(DateTime));

            // primary key
            TabelaExemplo.PrimaryKey = new[] { TabelaExemplo.Columns["Id"] };

            // inserindo dados na tabela 
            TabelaExemplo.Rows.Add(new object[] { 1, "Carlos", "Pinheiro", new DateTime(1979, 09, 01), });
            TabelaExemplo.Rows.Add(new object[] { 2, "Larissa", "Pinheiro", new DateTime(1987, 05, 27), });
            TabelaExemplo.Rows.Add(new object[] { 3, "Isabella", "Pinheiro", new DateTime(2015, 01, 16), });
            TabelaExemplo.Rows.Add(new object[] { 4, "Edusrada", "Oliveira", new DateTime(209, 07, 21), });
            TabelaExemplo.AcceptChanges();


            // selecionando um item da tabela pelo primeiro nome igual a Carlos
            var resultado = TabelaExemplo.Select("PrimeiroNome = 'Carlos'");

            foreach (DataRow dataRow in resultado)
            {
                Console.WriteLine("resultado: "+ dataRow["PrimeiroNome"]);
            }

            var ordenado = TabelaExemplo.Select("DataNascimento >= '1950-01-01'","DataNascimento asc");

            foreach (DataRow row in ordenado)
            {
                Console.WriteLine(row["DataNascimento"]);
            }

            DataColumn nomeNormalizado = new DataColumn("NomeNormalizado")
            {
                DataType = typeof(string),
                Expression = "PrimeiroNome + SegundoNome"
            };

            TabelaExemplo.Columns.Add(nomeNormalizado);

            foreach (DataRow row in TabelaExemplo.Rows)
            {
                Console.WriteLine($"coluna: {row[4]}");
            }

        }
    }
}