using Estudo.ADOConsole.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using System.Text;

namespace Estudo.ADOConsole.Repositorio
{
    public class FuncionarioDAO : IFuncionarioDAO
    {
        string connectionString = @"Data Source=192.168.99.100,1433;Initial Catalog=db_profile;User Id=SA;Password=isabella*15";

        public IEnumerable<Funcionario> GetAllFuncionarios() => 
                new List<Funcionario>(ExecuteQuery(new StringBuilder("SELECT * FROM tbl_customer")));

       
        public int AddFuncionario(Funcionario f)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                new SqlParameter() {ParameterName = "@customer_id", SqlDbType = SqlDbType.UniqueIdentifier, Value= f.Customer_Id},
                new SqlParameter() {ParameterName = "@fisrt_name", SqlDbType = SqlDbType.VarChar, Value = f.FirstName},
                new SqlParameter() {ParameterName = "@last_name", SqlDbType = SqlDbType.VarChar, Value = f.LastName},
                new SqlParameter() {ParameterName = "@birth_day", SqlDbType = SqlDbType.DateTime, Value =f.BirthDay },
                new SqlParameter() {ParameterName = "@doc_cpf", SqlDbType = SqlDbType.VarChar, Value =f.CPF }
            };
            return  Execute(new StringBuilder()
                .AppendLine("INSERT INTO [tbl_customer] ")
                .AppendLine("(customer_id, first_name, last_name, birth_day, doc_cpf) values ")
                .AppendLine($"(@customer_id, @fisrt_name, @last_name, @birth_day,@doc_cpf)"), parameters);
        }
        public void UpdateFuncionario(Funcionario funcionario)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //string comandoSQL = "Update Funcionarios set Nome = @Nome, Cidade = @Cidade, Departamento = 
                //                                              @Departamento, Sexo = @Sexo where FuncionarioId = @FuncionarioId";
                //SqlCommand cmd = new SqlCommand(comandoSQL, con);
                //cmd.CommandType = CommandType.Text;
                //cmd.Parameters.AddWithValue("@FuncionarioId", funcionario.FuncionarioId);
                //cmd.Parameters.AddWithValue("@Nome", funcionario.Nome);
                //cmd.Parameters.AddWithValue("@Cidade", funcionario.Cidade);
                //cmd.Parameters.AddWithValue("@Departamento", funcionario.Departamento);
                //cmd.Parameters.AddWithValue("@Sexo", funcionario.Sexo);
                //con.Open();
                //cmd.ExecuteNonQuery();
                //con.Close();
            }
        }
        public Funcionario GetFuncionario(int? id)
        {
            Funcionario funcionario = new Funcionario();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                //    string sqlQuery = "SELECT * FROM Funcionarios WHERE FuncionarioId= " + id;
                //    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                //    con.Open();
                //    SqlDataReader rdr = cmd.ExecuteReader();
                //    while (rdr.Read())
                //    {
                //        funcionario.FuncionarioId = Convert.ToInt32(rdr["FuncionarioId"]);
                //        funcionario.Nome = rdr["Nome"].ToString();
                //        funcionario.Cidade = rdr["Cidade"].ToString();
                //        funcionario.Departamento = rdr["Departamento"].ToString();
                //        funcionario.Sexo = rdr["Sexo"].ToString();
                //    }
            }
            return funcionario;
        }
        public void DeleteFuncionario(int? id)
        {

        }

        private SqlConnection CreateConnection() => new SqlConnection(connectionString);

        private IList<Funcionario> ExecuteQuery(StringBuilder cmd)
        {
            using (var conn = CreateConnection())
            {
                conn.Open();
                SqlCommand command = new SqlCommand(cmd.ToString(), conn);
                var results = command.ExecuteReader();


                try
                {
                    IList<Funcionario> funcionarios = new List<Funcionario>();
                    while (results.Read())
                    {
                       {
                           funcionarios.Add(new Funcionario
                           {
                               Customer_Id = Guid.Parse(results["customer_id"].ToString()),
                               FirstName = results["last_name"].ToString(),
                               LastName = results["last_name"].ToString(),
                               BirthDay = DateTime.Parse(results["birth_day"].ToString()),
                               CPF = results["doc_cpf"].ToString()
                           });
                       };
                    }

                    return funcionarios;
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
            }
        }

        private int Execute(StringBuilder cmd, List<SqlParameter> paramsList )
        {
            using (var conn = CreateConnection())
            {
                try
                {
                    Console.WriteLine(cmd);
                    conn.Open();
                    SqlCommand command = new SqlCommand(cmd.ToString(), conn);
                    command.Parameters.AddRange(paramsList.ToArray());
                    return command.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

    }
}