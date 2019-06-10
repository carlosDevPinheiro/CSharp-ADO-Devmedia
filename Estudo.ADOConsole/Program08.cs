using Estudo.ADOConsole.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Estudo.ADOConsole
{
    public class Program08
    {
        static void Main(string[] args)
        {

            
            StreamReader leitor = File.OpenText(@"C:\Users\proga\Downloads\NomesJson.txt");
            List<string> nomes = new List<string>();


            var nomeArray = leitor.ReadToEnd().Split(',');
            string nome = string.Empty;
            string sobreNome = string.Empty;

            foreach (string palavra in nomeArray)
            {
                foreach (char ch in palavra)
                {
                    if (char.IsLetter(ch))
                    {
                        nome += ch;
                        

                    } else if (char.IsWhiteSpace(ch))
                    {
                        nomes.Add(nome + ",");
                    }
                }

               
            }

            nomes.ForEach(x => Console.WriteLine(x));

            


          //  FileStream criador = File.Create($@"C:\Users\proga\Downloads\NomesJson{DateTime.Now.Year}.txt");
           
            


          //  //Byte[] arquivo = new UTF8Encoding(true).GetBytes(JsonConvert.SerializeObject(nomes));

          ////  criador.Write(arquivo);
          //  criador.Close();

          //  StreamReader leitor2 = File.OpenText($@"C:\Users\proga\Downloads\NomesJson{DateTime.Now.Year}.txt");
          //  var ListaPessoas = JsonConvert.DeserializeObject<List<Pessoa>>(leitor2.ReadToEnd());

          //  foreach (Pessoa pessoa in ListaPessoas)
          //  {
          //      Console.WriteLine(pessoa.ToString());
          //  }
        }
    }
}