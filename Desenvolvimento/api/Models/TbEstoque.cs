using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("tb_estoque")]
    public partial class TbEstoque
    {
        [Key]
        [Column("id_estoque")]
        public int IdEstoque { get; set; }
        [Column("id_venda")]
        public int IdVenda { get; set; }
        [Column("id_produto")]
        public int IdProduto { get; set; }
        [Required]
        [Column("ds_motivo", TypeName = "varchar(65)")]
        public string DsMotivo { get; set; }
        [Column("qt_disponivel")]
        public int QtDisponivel { get; set; }
        [Column("dt_atualizacao", TypeName = "datetime")]
        public DateTime DtAtualizacao { get; set; }

        [ForeignKey(nameof(IdProduto))]
        [InverseProperty(nameof(TbProduto.TbEstoque))]
        public virtual TbProduto IdProdutoNavigation { get; set; }
        [ForeignKey(nameof(IdVenda))]
        [InverseProperty(nameof(TbVenda.TbEstoque))]
        public virtual TbVenda IdVendaNavigation { get; set; }
    }
}
