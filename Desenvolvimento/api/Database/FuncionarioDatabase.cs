using System;
using System.Collections.Generic;
using System.Linq;

namespace api.Database
{
    public class FuncionarioDatabase
    {
        Models.bd_cabelereiroContext bd = new Models.bd_cabelereiroContext();
        public Models.TbFuncionario InserirFuncionario (Models.TbFuncionario funci)
        {
            bd.TbFuncionario.Add(funci);
            bd.SaveChanges();

            return funci;
        }

        public List<Models.TbFuncionario> ConsultarFuncionarios()
        {
            return bd.TbFuncionario.ToList();
        }

        public Models.TbFuncionario ConsultarFuncionarioPorCpf(string cpf)
        {
            return bd.TbFuncionario.FirstOrDefault(x => 
                                        x.DsCpf == cpf);
        }

        public Models.TbFuncionario ConsultarFuncionarioPorId(int id)
        {
            return bd.TbFuncionario.FirstOrDefault(x => 
                                        x.IdFuncionario == id);
        }

        public Models.TbFuncionario AlterarFuncionarioPorId(int id, Models.TbFuncionario novo)
        {
            Models.TbFuncionario funci = this.ConsultarFuncionarioPorId(id);
            
            funci.NmFuncionario = novo.NmFuncionario;
            funci.TpCargo = novo.TpCargo;
            funci.DtNascimento = novo.DtNascimento;
            funci.DsCpf = novo.DsCpf;
            funci.DsEndereco = novo.DsEndereco;
            funci.DsCep = novo.DsCep;
            funci.DsComplemento = novo.DsComplemento;
            funci.DsTel = novo.DsTel;
            funci.DsEmail = novo.DsEmail;
            funci.DtPosse = novo.DtPosse;
            funci.DsFoto = novo.DsFoto;
            funci.DsCurriculo = novo.DsCurriculo;
            funci.NmUsuario = novo.NmUsuario;
            funci.DsSenha = novo.DsSenha;

            bd.SaveChanges();

            return funci; 
        }

        public Models.TbFuncionario RemoverDuncinarioPorId(int id)
        {
            Models.TbFuncionario funcionario = bd.TbFuncionario.FirstOrDefault(x => 
                                                                    x.IdFuncionario == id);

            bd.TbFuncionario.Remove(funcionario);
            bd.SaveChanges();

            return funcionario;
        }
    }
}