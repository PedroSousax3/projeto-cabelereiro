using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("tb_venda")]
    public partial class TbVenda
    {
        public TbVenda()
        {
            TbEstoque = new HashSet<TbEstoque>();
        }

        [Key]
        [Column("id_venda")]
        public int IdVenda { get; set; }
        [Column("id_funcionario")]
        public int IdFuncionario { get; set; }
        [Column("id_cliente")]
        public int IdCliente { get; set; }
        [Column("id_corte")]
        public int IdCorte { get; set; }
        [Column("dt_venda", TypeName = "datetime")]
        public DateTime DtVenda { get; set; }
        [Column("nm_cupom")]
        public int? NmCupom { get; set; }
        [Column("dt_validade_cupom", TypeName = "date")]
        public DateTime? DtValidadeCupom { get; set; }
        [Column("vl_desconto_cupom", TypeName = "decimal(5,0)")]
        public decimal? VlDescontoCupom { get; set; }

        [ForeignKey(nameof(IdCliente))]
        [InverseProperty(nameof(TbCliente.TbVenda))]
        public virtual TbCliente IdClienteNavigation { get; set; }
        [ForeignKey(nameof(IdCorte))]
        [InverseProperty(nameof(TbCorte.TbVenda))]
        public virtual TbCorte IdCorteNavigation { get; set; }
        [ForeignKey(nameof(IdFuncionario))]
        [InverseProperty(nameof(TbFuncionario.TbVenda))]
        public virtual TbFuncionario IdFuncionarioNavigation { get; set; }
        [InverseProperty("IdVendaNavigation")]
        public virtual ICollection<TbEstoque> TbEstoque { get; set; }
    }
}
