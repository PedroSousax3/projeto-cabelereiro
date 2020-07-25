using System;

namespace api.Utils
{
    public class FuncionarioConvert
    {
        public Models.TbFuncionario ConvertFuncionarioRequest(Models.Request.FuncionarioRequest novo)
        {
            Models.TbFuncionario funci = new Models.TbFuncionario();

            funci.NmFuncionario = novo.funcionario;
            funci.TpCargo = novo.cargo;
            funci.DtNascimento = novo.nascimento;
            funci.DsCpf = novo.cpf;
            funci.DsEndereco = novo.endereco;
            funci.DsCep = novo.cep;
            funci.DsComplemento = novo.complemento;
            funci.DsTel = novo.telefone;
            funci.DsEmail =  novo.email;
            funci.DtPosse = DateTime.Now;
            funci.DsFoto = novo.foto;
            funci.DsCurriculo = novo.curriculo;
            funci.NmUsuario = novo.usuario;
            funci.DsSenha = novo.senha;

            return funci;
        }

        public Models.Response.FuncionarioResponse ConvertFuncionarioResponse(Models.TbFuncionario funci)
        {
            Models.Response.FuncionarioResponse novo = new Models.Response.FuncionarioResponse();

            novo.id = funci.IdFuncionario;
            novo.funcionario = funci.NmFuncionario;
            novo.cargo = funci.TpCargo;
            novo.nascimento = funci.DtNascimento;
            novo.cpf = funci.DsCpf;
            novo.endereco = funci.DsEndereco;
            novo.cep = funci.DsCep;
            novo.complemento = funci.DsComplemento;
            novo.telefone = funci.DsTel;
            novo.email = funci.DsEmail;
            novo.data_posse = funci.DtPosse;
            novo.foto = funci.DsFoto;
            novo.curriculo = funci.DsCurriculo;

            return novo;
        }
    }
}