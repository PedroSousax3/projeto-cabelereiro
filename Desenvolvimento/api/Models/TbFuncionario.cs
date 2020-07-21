using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("tb_funcionario")]
    public partial class TbFuncionario
    {
        public TbFuncionario()
        {
            TbAgenda = new HashSet<TbAgenda>();
            TbCorte = new HashSet<TbCorte>();
            TbVenda = new HashSet<TbVenda>();
        }

        [Key]
        [Column("id_funcionario")]
        public int IdFuncionario { get; set; }
        [Required]
        [Column("nm_funcionario", TypeName = "varchar(100)")]
        public string NmFuncionario { get; set; }
        [Required]
        [Column("tp_cargo", TypeName = "varchar(35)")]
        public string TpCargo { get; set; }
        [Column("dt_nascimento", TypeName = "datetime")]
        public DateTime DtNascimento { get; set; }
        [Required]
        [Column("ds_cpf", TypeName = "varchar(15)")]
        public string DsCpf { get; set; }
        [Required]
        [Column("ds_endereco", TypeName = "varchar(70)")]
        public string DsEndereco { get; set; }
        [Required]
        [Column("ds_cep", TypeName = "varchar(11)")]
        public string DsCep { get; set; }
        [Column("ds_complemento", TypeName = "varchar(20)")]
        public string DsComplemento { get; set; }
        [Required]
        [Column("ds_tel", TypeName = "varchar(20)")]
        public string DsTel { get; set; }
        [Required]
        [Column("ds_email", TypeName = "varchar(65)")]
        public string DsEmail { get; set; }
        [Column("dt_posse", TypeName = "date")]
        public DateTime DtPosse { get; set; }
        [Column("ds_foto", TypeName = "varchar(150)")]
        public string DsFoto { get; set; }
        [Required]
        [Column("ds_curriculo", TypeName = "varchar(150)")]
        public string DsCurriculo { get; set; }
        [Required]
        [Column("nm_usuario", TypeName = "varchar(35)")]
        public string NmUsuario { get; set; }
        [Required]
        [Column("ds_senha", TypeName = "varchar(12)")]
        public string DsSenha { get; set; }

        [InverseProperty("IdFuncionarioNavigation")]
        public virtual ICollection<TbAgenda> TbAgenda { get; set; }
        [InverseProperty("IdFuncionarioNavigation")]
        public virtual ICollection<TbCorte> TbCorte { get; set; }
        [InverseProperty("IdFuncionarioNavigation")]
        public virtual ICollection<TbVenda> TbVenda { get; set; }
    }
}
