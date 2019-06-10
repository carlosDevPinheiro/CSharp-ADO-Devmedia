using System;
using System.Data;
using System.Runtime.InteropServices;

namespace Estudo.ADOConsole
{
    public class Program04
    {
        static DataTable tabelaCarro1 = null;  // tabela 1
        static DataTable tabelaCarro2 = null;  // tabela 2
        static DataSet DataSetCarro = null;

        static void Main(string[] args)
        {
            DataTable tbl1 = CreateTabela(1);
            DataTable tbl2 = CreateTabela(2);

            DataSetCarro = new DataSet("Carros_Final");     // Nome final 
            DataSetCarro.Tables.Add(tabelaCarro1);          // add tabela no DataSet
            DataSetCarro.Tables.Add(tabelaCarro2);

            // criando relacionamento entre as tabela pelo campos de IDs
            DataRelation tabelaLink = new DataRelation("TabelaLink", tabelaCarro1.Columns["ID"], tabelaCarro2.Columns["ID"]);
            DataSetCarro.Relations.Add(tabelaLink);  // adcionando o relacionamento 

            DataTable TB_Resultado = new DataTable("TabelaResultado");

            TB_Resultado.Columns.Add("ID", typeof(int));
            TB_Resultado.Columns.Add("Automaker", typeof(string));
            TB_Resultado.Columns.Add("Model", typeof(string));
            TB_Resultado.Columns.Add("Color", typeof(string));
            TB_Resultado.Columns.Add("Date", typeof(DateTime));

            DataTable TB_Temporaria = DataSetCarro.Tables["Carro_1"];
            DataRelation objRelacionamento = TB_Temporaria.ChildRelations["TabelaLink"];

            foreach (DataRow row in TB_Temporaria.Rows)
            {

                foreach (DataRow childRow in row.GetChildRows(objRelacionamento))
                {
                    Console.WriteLine(childRow["Color"].ToString(),Console.ForegroundColor = ConsoleColor.DarkMagenta);
                }
            }

        }

        private static DataTable CreateTabela(int i)
        {
            if (i == 1)
            {

                tabelaCarro1 = new DataTable("Carro_1");

                tabelaCarro1.Columns.Add("ID", typeof(int));
                tabelaCarro1.Columns.Add("Automaker", typeof(string));
                tabelaCarro1.Columns.Add("Model", typeof(string));

                tabelaCarro1.PrimaryKey = new DataColumn[] { tabelaCarro1.Columns["CarroID"] };

                tabelaCarro1.Rows.Add(1, "Audi", "A4");
                tabelaCarro1.Rows.Add(2, "BMW", "540i");
                tabelaCarro1.Rows.Add(3, "Ferrari", "F-50");
                tabelaCarro1.Rows.Add(4, "Mercedez", "SLK-200");
                tabelaCarro1.Rows.Add(5, "Maclaren", "P1");
                tabelaCarro1.Rows.Add(6, "Porche", "911");

                tabelaCarro1.AcceptChanges();
                return tabelaCarro1;
            }
            else
            {
                tabelaCarro2 = new DataTable("Carro_2");

                tabelaCarro2.Columns.Add("ID", typeof(int));
                tabelaCarro2.Columns.Add("Color", typeof(string));
                tabelaCarro2.Columns.Add("Date", typeof(DateTime));

                //tabelaCarro2.PrimaryKey = new DataColumn[] { tabelaCarro2.Columns["ID"] };

                tabelaCarro2.Rows.Add(new object[] { 1, "White", DateTime.Parse("01/01/2012") });
                tabelaCarro2.Rows.Add(new object[] { 1, "Black", DateTime.Parse("01/01/2013") });
                tabelaCarro2.Rows.Add(new object[] { 3, "Red", DateTime.Parse("01/01/2002") });
                tabelaCarro2.Rows.Add(new object[] { 4, "Gray", DateTime.Parse("01/01/2010") });
                tabelaCarro2.Rows.Add(new object[] { 5, "White", DateTime.Parse("01/01/2012") });
                tabelaCarro2.Rows.Add(new object[] { 3, "Yellow", DateTime.Parse("01/01/2013") });

                tabelaCarro2.AcceptChanges();
                return tabelaCarro2;
            }
        }
    }
}