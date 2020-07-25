using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Business
{
    public class FuncionarioBusiness
    {
        Database.FuncionarioDatabase funcaobd = new Database.FuncionarioDatabase();
        public Models.TbFuncionario InserirFuncionario(Models.TbFuncionario funci)
        {
            if(string.IsNullOrEmpty(funci.NmFuncionario))
                throw new ArgumentException("Nome do funcionario não foi encontrado.");
            if(funci.DsSenha.Length >= 8)
                throw new ArgumentException("Senha deve possuir 8 ou mais caracteres.");
                
            return funcaobd.InserirFuncionario(funci);
        }

        public List<Models.TbFuncionario> ConsultarFuncionarios()
        {
            return funcaobd.ConsultarFuncionarios();
        }

        public Models.TbFuncionario ConsultarFuncionarioPorCpf(string cpf)
        {
            return funcaobd.ConsultarFuncionarioPorCpf(cpf);
        }

        public Models.TbFuncionario RemoverFuncionarioPorId(int id)
        {
            if(id <= 0)
                new ArgumentException ("Id do funcionario é menor que 1, logo não pode ser encontrado.");
            if(funcaobd.ConsultarFuncionarioPorId(id).IdFuncionario <= 0)
                new ArgumentException("Id não cadastrado no sistema.");

            return funcaobd.RemoverDuncinarioPorId(id);
        }
    }
}