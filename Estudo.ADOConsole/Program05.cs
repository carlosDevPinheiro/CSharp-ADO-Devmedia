using System;
using System.Data;

namespace Estudo.ADOConsole
{
    public class Program05
    {
        private static DataTable tabelaCarro1 = null;  // tabela 1
        private static DataTable tabelaCarro2 = null;  // tabela 2
        private static DataSet DataSetCarro = null;    // DataSet => e ele que vai conter as tabelas em Memoria para manipular em off

        public static void Main(string[] args)
        {
            var tbl1 = CreateTables(1);
            var tbl2 = CreateTables(2);


            DataSetCarro = new DataSet("Carros_Final");
            DataSetCarro.Tables.Add(tabelaCarro1);
            DataSetCarro.Tables.Add(tabelaCarro2);

            var FKeyContraint = new ForeignKeyConstraint(
                "FKEYConstraint",
                DataSetCarro.Tables["Carro_1"].Columns["ID"],
                DataSetCarro.Tables["Carro_2"].Columns["ID"]);

            FKeyContraint.DeleteRule = Rule.Cascade;                        // Regra ao deletar registro em Carro_1, tambem em Carro_2
            FKeyContraint.UpdateRule = Rule.Cascade;                        // Regra ao Atualizar registro em Carro_1, tambem em Carro_2
            FKeyContraint.AcceptRejectRule = AcceptRejectRule.Cascade;      // Aceitar alterações em cascata tambem

            DataSetCarro.Tables["Carro_2"].Constraints.Add(FKeyContraint);  // add a FKeyContraint na tabela Carro_2
            DataSetCarro.EnforceConstraints = true;                         // habiltar a constraint no DataSet

            DataRelation tabelaLink = new DataRelation("TabelaLink", tabelaCarro1.Columns["ID"], tabelaCarro2.Columns["ID"]);
            DataSetCarro.Relations.Add(tabelaLink);

            DataTable TB_Resultado = new DataTable("TabelaResultado");

            TB_Resultado.Columns.Add("ID", typeof(int));
            TB_Resultado.Columns.Add("Automaker", typeof(string));
            TB_Resultado.Columns.Add("Model", typeof(string));
            TB_Resultado.Columns.Add("Color", typeof(string));
            TB_Resultado.Columns.Add("Date", typeof(DateTime));

            // tabela temporaria

            DataTable TB_Temporaria = DataSetCarro.Tables["Carro_1"];
            DataRelation objRelacionamento = TB_Temporaria.ChildRelations["TabelaLink"];
            DataRow[] Linhasfilhas; // array de linhas 
            int contador = 0;

            foreach (DataRow item in TB_Temporaria.Rows)
            {
                Linhasfilhas = item.GetChildRows(objRelacionamento);

                if (Linhasfilhas.Length > 0)
                {
                    foreach (DataRow linha in Linhasfilhas)
                    {
                        TB_Resultado.ImportRow(linha);
                        TB_Resultado.Rows[contador][1] = item[1]; // Campo Automaker da tabela Pai
                        TB_Resultado.Rows[contador][2] = item[2]; // Campo Model da Tabela Pai

                        contador = contador + 1;
                    }
                }
            }

            Constraint MinhaUnique = new UniqueConstraint(TB_Resultado.Columns["ID"]); // Definindo que essa coluna não pode ter valores repetidos
            TB_Resultado.Constraints.Add(MinhaUnique);  // add a contraint na tabela de resultado

            foreach (DataRow row in TB_Temporaria.Rows)
            {
                Linhasfilhas = row.GetChildRows(objRelacionamento);

                if (Linhasfilhas.Length > 0)
                {
                    foreach (DataRow childRow in Linhasfilhas)
                    {
                        TB_Resultado.ImportRow(childRow);
                        TB_Resultado.Rows[contador][1] = row[1];
                        TB_Resultado.Rows[contador][2] = row[2];

                        contador += 1;

                        Console.WriteLine(row[1]);
                        Console.WriteLine(childRow[1]);
                    }
                }
            }
        }

        private static DataTable CreateTables(int i)
        {
            if (i == 1)
            {
                tabelaCarro1 = new DataTable("Carro_1");

                tabelaCarro1.Columns.Add("ID", typeof(int));
                tabelaCarro1.Columns.Add("Automaker", typeof(string));
                tabelaCarro1.Columns.Add("Model", typeof(string));

                tabelaCarro1.PrimaryKey = new DataColumn[] { tabelaCarro1.Columns["CarroID"] };

                tabelaCarro1.Rows.Add(new object[] { 1, "Audi", "A4" });
                tabelaCarro1.Rows.Add(new object[] { 2, "BMW", "540i" });
                tabelaCarro1.Rows.Add(new object[] { 3, "Ferrari", "F-50" });
                tabelaCarro1.Rows.Add(new object[] { 4, "Mercedez", "SLK-200" });
                tabelaCarro1.Rows.Add(new object[] { 5, "Maclaren", "P1" });
                tabelaCarro1.Rows.Add(new object[] { 6, "Porche", "911" });

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
                tabelaCarro2.Rows.Add(new object[] { 2, "Black", DateTime.Parse("01/01/2013") });
                tabelaCarro2.Rows.Add(new object[] { 3, "Red", DateTime.Parse("01/01/2002") });
                tabelaCarro2.Rows.Add(new object[] { 4, "Gray", DateTime.Parse("01/01/2010") });
                tabelaCarro2.Rows.Add(new object[] { 5, "White", DateTime.Parse("01/01/2012") });
                tabelaCarro2.Rows.Add(new object[] { 6, "Yellow", DateTime.Parse("01/01/2013") });

                tabelaCarro2.AcceptChanges();
                return tabelaCarro2;
            }
        }
    }
}