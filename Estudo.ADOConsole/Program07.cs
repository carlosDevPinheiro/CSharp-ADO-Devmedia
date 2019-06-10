using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Estudo.ADOConsole.Model;
using Estudo.ADOConsole.Repositorio;
using Newtonsoft.Json;

namespace Estudo.ADOConsole
{
    public class Program07
    {
        private static readonly IFuncionarioDAO repositorio = new FuncionarioDAO();
        private static readonly List<Funcionario> funcionarios = repositorio.GetAllFuncionarios().ToList();
        private static string[] sobrenomes = new string[] { "Pinheiro", "Carvalho", "Gonçalves", "da Silva", "Magalhaes", "Mendonça", "Mouro", "Mourao" };

        static async Task Main(string[] argumentos)
        {




            await BuscarNomesApi();

            //repositorio.AddFuncionario(new Funcionario
            //{
            //    Customer_Id = Guid.NewGuid(),
            //    FirstName = "Antonio Carlos",
            //    LastName = "Pinheiro",
            //    BirthDay = new DateTime(1979, 09, 01),
            //    CPF = "28556811812"
            //});
        }

        private static async Task BuscarNomesApi()
        {
            var lista = await GetHttp();
            Random rdm = new Random();


            int count = 0;

            foreach (Requisicao re in lista)
            {
                re.ListPessoas.ForEach(x =>
                {
                    repositorio.AddFuncionario(new Funcionario
                    {
                        CPF = $"{rdm.Next(100, 999)}{rdm.Next(100, 999)}{rdm.Next(100, 999)}{rdm.Next(10, 99)}",
                        FirstName = x.Nome,
                        LastName = sobrenomes[count],
                        Customer_Id = Guid.NewGuid(),
                        BirthDay = DateTime.Today
                    });

                    if (count == 7)
                    {
                        count = 0;
                    }

                    count++;
                });
            }
        }

        public static async Task<List<Requisicao>> GetHttp()
        {

            try
            {
                using (var httpclient = new HttpClient())
                {
                    var _response =
                        await httpclient.GetAsync("https://servicodados.ibge.gov.br/api/v2/censos/nomes/ranking");

                    if (!_response.IsSuccessStatusCode)
                        throw new InvalidOperationException();

                    var _responseContent = await _response.Content.ReadAsStringAsync();
                    Console.WriteLine(_responseContent);

                    if (string.IsNullOrWhiteSpace(_responseContent))
                        throw new InvalidOperationException();
                   
                    return JsonConvert.DeserializeObject<List<Requisicao>>(_responseContent);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                throw;
            }




            //using (HttpClient client = new HttpClient())
            //{

            //    //try
            //    //{
            //    //    HttpResponseMessage response =
            //    //        await client.GetAsync("https://servicodados.ibge.gov.br/api/v2/censos/nomes/ranking");
            //    //    response.EnsureSuccessStatusCode();
            //    //    string responseBody = await response.Content.ReadAsStringAsync();

            //    //    return JsonConvert.DeserializeObject<List<Funcionario>>(responseBody);

            //    //    // Above three lines can be replaced with new helper method below
            //    //    // string responseBody = await client.GetStringAsync(uri);

            //    //    // Console.WriteLine(responseBody);
            //    //}
            //    //catch (HttpRequestException e)
            //    //{
            //    //    Console.WriteLine("\nException Caught!");
            //    //    Console.WriteLine("Message :{0} ", e.Message);
            //    //}
            //}

        }

        static void LerBanco()
        {
            int count = funcionarios.Count;
            Console.WriteLine(count);
            funcionarios.ForEach(x =>
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Id => {x.Customer_Id}");

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine($"Primeiro Nome => {x.FirstName}");

                Console.ForegroundColor = ConsoleColor.Magenta;
                //Console.WriteLine($"Data aniversario => {x.BirthDay}");

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"CPF=> {x.CPF}");

                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"Segundo Nome => {x.LastName}");
            });
        }
    }
}