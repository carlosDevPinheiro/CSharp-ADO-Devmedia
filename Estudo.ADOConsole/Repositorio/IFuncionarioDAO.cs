using System.Collections.Generic;
using Estudo.ADOConsole.Model;

namespace Estudo.ADOConsole.Repositorio
{
    public interface IFuncionarioDAO
    {
        IEnumerable<Funcionario> GetAllFuncionarios();
        int AddFuncionario(Funcionario funcionario);
        void UpdateFuncionario(Funcionario funcionario);
        Funcionario GetFuncionario(int? id);
        void DeleteFuncionario(int? id);
    }
}