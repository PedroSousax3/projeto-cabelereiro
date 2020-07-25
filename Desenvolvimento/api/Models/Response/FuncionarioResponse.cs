using System;

namespace api.Models.Response
{
    public class FuncionarioResponse
    {
        public int id { get; set; }
        public string funcionario { get; set; }
        public string cargo { get; set; }
        public DateTime nascimento { get; set; }
        public string cpf { get; set; }
        public string endereco { get; set; }
        public string cep { get; set; }
        public string complemento { get; set; }
        public string telefone { get; set; }
        public string email { get; set; }
        public DateTime data_posse { get; set; }
        public string foto { get; set; }
        public string curriculo { get; set; }
    }
}