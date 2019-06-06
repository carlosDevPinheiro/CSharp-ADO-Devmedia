using System;
using System.Data;

namespace Estudo.ADOConsole
{
    class Program
    {
        static void Main(string[] args)
        {
           DataTable TabelaExemplo = new DataTable("Exemplo");

           // adicionando coluna
           TabelaExemplo.Columns.Add("Id",typeof(long));
           TabelaExemplo.Columns.Add("PrimeiroNome",typeof(string));
           TabelaExemplo.Columns.Add("SegundoNome",typeof(string));
           TabelaExemplo.Columns.Add("DataNascimento",typeof(DateTime));
           
           // primary key
           TabelaExemplo.PrimaryKey= new DataColumn[]{ TabelaExemplo.Columns["Id"]};

           foreach (DataColumn column in TabelaExemplo.Columns)
           {
               Console.WriteLine($"{column.ColumnName} , {column.DataType}" );
           }

           // inserindo dados na tabela 
           TabelaExemplo.Rows.Add(new object[] { 1, "Carlos","Pinheiro", new DateTime(1979,09,01), });
           TabelaExemplo.Rows.Add(new object[] { 2, "Larissa", "Pinheiro", new DateTime(1987, 05, 27), });
           TabelaExemplo.Rows.Add(new object[] { 3, "Isabella", "Pinheiro", new DateTime(2015, 01, 16), });
           TabelaExemplo.Rows.Add(new object[] { 4, "Edusrada", "Oliveira", new DateTime(209, 07, 21), });

           foreach (DataRow registro in TabelaExemplo.Rows)
           {
               Console.WriteLine($"Nome: {registro["PrimeiroNome"]} {registro["SegundoNome"]} - {registro[3]}");
           }

           // estado adicionado na tabela em memoria "added"
           var resut = TabelaExemplo.Rows.Add(new object[] {5,"Joana","Pinheiro", new DateTime(1950,05,04) });
           Console.WriteLine($"estado: {resut.RowState} ");
           resut.AcceptChanges();

           // modificado "modifie"
           resut["SegundoNome"] = "Pinheiro da Silva";
           Console.WriteLine($"estado: {resut.RowState} ");
           resut.AcceptChanges();

           // modificado "removido"
           resut.Delete();
           Console.WriteLine($"estado: {resut.RowState} ");
           resut.AcceptChanges();


        }
    }
}
