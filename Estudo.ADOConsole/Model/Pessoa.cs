using System.Collections.Generic;
using Newtonsoft.Json;

namespace Estudo.ADOConsole.Model
{
    public class Pessoa
    {
        [JsonProperty("nome")]
        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public override string ToString()
        {
            return $"({Nome})";
        }
    }

    public class Requisicao
    {
        public Requisicao()
        {
            ListPessoas = new List<Pessoa>();
        }

        [JsonProperty("localidade")]
        public string Localidade { get; set; }

        [JsonProperty("sexo")]
        public object Sexo { get; set; }

        [JsonProperty("res")]
        public List<Pessoa> ListPessoas { get; set; }
    }
}