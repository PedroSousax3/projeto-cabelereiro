//Modificar Business e nomeação dos erros
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class FuncionarioController : ControllerBase
    {
        Utils.FuncionarioConvert convert = new Utils.FuncionarioConvert();
        Business.FuncionarioBusiness funcaorn = new Business.FuncionarioBusiness();
        Database.FuncionarioDatabase funcaobd = new Database.FuncionarioDatabase();

        [HttpPost]
        public ActionResult<Models.Response.FuncionarioResponse> InserirFuncionario(Models.Request.FuncionarioRequest funci)
        {
            try
            {
                Models.TbFuncionario funciconvertido = convert.ConvertFuncionarioRequest(funci);

                Models.TbFuncionario inserido = funcaorn.InserirFuncionario(funciconvertido);

                return convert.ConvertFuncionarioResponse(inserido);
            }
            catch(System.Exception ex)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(404, ex.Message)
                );
            }
        }

        [HttpGet]
        public List<Models.Response.FuncionarioResponse> ConsultarFuncionarios()
        {
            List<Models.TbFuncionario> funcionarios = funcaorn.ConsultarFuncionarios();

            List<Models.Response.FuncionarioResponse> result = 
                                                funcionarios.Select(x => 
                                                        convert.ConvertFuncionarioResponse(x))
                                                            .ToList();
            return result;
        }

        [HttpGet("ConsultaPorCpf/cpf")]
        public Models.Response.FuncionarioResponse ConsultarFuncionarioPorCpf(string cpf)
        {
            Models.TbFuncionario funcionario = funcaorn.ConsultarFuncionarioPorCpf(cpf);

            Models.Response.FuncionarioResponse result = convert.ConvertFuncionarioResponse(funcionario);
            return result;
        }

        [HttpPut("{id}")]
        public ActionResult<Models.Response.FuncionarioResponse> AlterarFuncionarioPorId(int id, Models.Request.FuncionarioRequest novo)
        {
            try
            {
                Models.TbFuncionario dados = convert.ConvertFuncionarioRequest(novo);

                Models.TbFuncionario result = funcaobd.AlterarFuncionarioPorId(id, dados);

                return convert.ConvertFuncionarioResponse(result);
            }
            catch(System.Exception ex)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(400, ex.Message)
                );
            }
        }

        [HttpDelete]
        public ActionResult<Models.Response.FuncionarioResponse> RemoverFuncionarioPorId(int id)
        {
            try
            {
                Models.TbFuncionario removido = funcaorn.RemoverFuncionarioPorId(id);

                return convert.ConvertFuncionarioResponse(removido);
            }
            catch (System.Exception ex)
            {
                return BadRequest(
                    new Models.Response.ErroResponse(404, ex.Message)
                );
            }
        }
    }
}