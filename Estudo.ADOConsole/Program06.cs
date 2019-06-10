using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Estudo.ADOConsole
{
    public class Program06
    {
        public static void Main(string[] argumntos)
        {
            const string connString = "Data Source=192.168.99.100,1433;Initial Catalog=db_profile;User Id=SA;Password=isabella*15";
            // @"Provider=SQLOLEDB;Data Source=(local); integrated Security=SSPI; Initial Catalog=db_profile; Encrypt=true;"


            using (var conn = CreateConnections(connString))
            {
                try
                {
                    conn.Open();
                    var command = new SqlCommand("", conn);

                    command.CommandText = new StringBuilder()
                        .AppendLine("SELECT * FROM tbl_customer")
                        .AppendLine("Where customer_id = '7C97710B-62C4-4846-8467-352C4B9445A1'")
                        .ToString();
                    // command.CommandType = CommandType.StoredProcedure;

                    // command.ExecuteNonQuery();                  // executa o comando e retorna linhas afetadas
                    // var result = (Funcionario) command.ExecuteScalar(); // retorna o objeto do banco
                    SqlDataReader result = command.ExecuteReader();

                    if (result.HasRows)
                    {
                        int nome = result.GetOrdinal("firt_name");

                        while (result.Read())
                        {
                            Console.WriteLine(result.GetString(nome));
                        }
                    }

                    // dois selects "select * from tbl_customer, select * from tbl_customer"
                }
                catch (SqlException ex)
                {
                    Console.WriteLine(ex.Message);

                }
                catch (InvalidOperationException opex)
                {
                    Console.WriteLine(opex.Message);
                }
                catch (Exception exx)
                {
                    Console.WriteLine(exx.Message);
                }
            }





#if false
            var conn = CreateConnections(connString);
            try
            {
                conn.Open();


            }
            catch (SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                conn?.Close();
            }
           
            
#endif

        }

        private static SqlConnection CreateConnections(string connString) =>  new SqlConnection(connString);
        
    }
}