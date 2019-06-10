using System;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Estudo.ADOConsole
{
    /*     
     *  Criando DataSet e adicionando tabelas nele
     */
    public static class Program03
    {
        private static DataTable tabelaCarro1 = null;
        private static DataTable tabelaCarro2 = null;

        public static void Main(string[] args)
        {


           tabelaCarro1 =  CreateTable01();
           tabelaCarro2 =  CreateTabela02();

            var DataSetCarro = new DataSet("Carros_Final");   
            DataSetCarro.Tables.Add(tabelaCarro1);          
            DataSetCarro.Tables.Add(tabelaCarro2);


            foreach (DataRow row in DataSetCarro.Tables[1].Rows)
                Console.WriteLine($"{row["Cor"]}",Console.ForegroundColor = ConsoleColor.Blue);
            
            Console.WriteLine($"unico: => " + DataSetCarro.Tables[1].Rows.Find(3)["Cor"], Console.ForegroundColor = ConsoleColor.DarkRed);

        }







        private static DataTable CreateTabela02()
        {
             tabelaCarro2 = new DataTable("Carro_2");

            tabelaCarro2.Columns.Add("ID", typeof(int));
            tabelaCarro2.Columns.Add("Cor", typeof(string));
            tabelaCarro2.Columns.Add("Data", typeof(DateTime));

            tabelaCarro2.PrimaryKey = new DataColumn[] {tabelaCarro2.Columns["ID"]};

            tabelaCarro2.Rows.Add(new object[] {1, "White", DateTime.Parse("01/01/2012")});
            tabelaCarro2.Rows.Add(new object[] {2, "Black", DateTime.Parse("01/01/2013")});
            tabelaCarro2.Rows.Add(new object[] {3, "Red", DateTime.Parse("01/01/2002")});
            tabelaCarro2.Rows.Add(new object[] {4, "Gray", DateTime.Parse("01/01/2010")});
            tabelaCarro2.Rows.Add(new object[] {5, "White", DateTime.Parse("01/01/2012")});
            tabelaCarro2.Rows.Add(new object[] {6, "Yellow", DateTime.Parse("01/01/2013")});

            tabelaCarro2.AcceptChanges();
            return tabelaCarro2;
        }

        private static DataTable CreateTable01()
        {
             tabelaCarro1 = new DataTable("Carro_1");

            tabelaCarro1.Columns.Add("CarroID", typeof(int));
            tabelaCarro1.Columns.Add("Marca", typeof(string));
            tabelaCarro1.Columns.Add("Modelo", typeof(string));

            tabelaCarro1.PrimaryKey = new DataColumn[] {tabelaCarro1.Columns["CarroID"]};

            tabelaCarro1.Rows.Add(new object[] {1, "Audi", "A4"});
            tabelaCarro1.Rows.Add(new object[] {2, "BMW", "540i"});
            tabelaCarro1.Rows.Add(new object[] {3, "Ferrari", "F-50"});
            tabelaCarro1.Rows.Add(new object[] {4, "Mercedez", "SLK-200"});
            tabelaCarro1.Rows.Add(new object[] {5, "Maclaren", "P1"});
            tabelaCarro1.Rows.Add(new object[] {6, "Porche", "911"});

            tabelaCarro1.AcceptChanges();
            return tabelaCarro1;
        }
    }
}