using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Estudo.ADOConsole.Model
{
    
    public class Funcionario
    {
       // [JsonProperty("")]
        public Guid Customer_Id { get; set; }

        [JsonProperty("nome")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public string CPF { get; set; }
        
    }
}