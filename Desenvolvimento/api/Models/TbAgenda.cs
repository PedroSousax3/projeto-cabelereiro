using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("tb_agenda")]
    public partial class TbAgenda
    {
        [Key]
        [Column("id_agenda")]
        public int IdAgenda { get; set; }
        [Column("id_funcionario")]
        public int IdFuncionario { get; set; }
        [Column("id_cliente")]
        public int IdCliente { get; set; }
        [Column("dt_corte", TypeName = "datetime")]
        public DateTime DtCorte { get; set; }

        [ForeignKey(nameof(IdCliente))]
        [InverseProperty(nameof(TbCliente.TbAgenda))]
        public virtual TbCliente IdClienteNavigation { get; set; }
        [ForeignKey(nameof(IdFuncionario))]
        [InverseProperty(nameof(TbFuncionario.TbAgenda))]
        public virtual TbFuncionario IdFuncionarioNavigation { get; set; }
    }
}
