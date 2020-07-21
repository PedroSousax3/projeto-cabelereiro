using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("tb_produto")]
    public partial class TbProduto
    {
        public TbProduto()
        {
            TbEstoque = new HashSet<TbEstoque>();
        }

        [Key]
        [Column("id_produto")]
        public int IdProduto { get; set; }
        [Required]
        [Column("nm_produto", TypeName = "varchar(70)")]
        public string NmProduto { get; set; }
        [Column("nm_marca", TypeName = "varchar(50)")]
        public string NmMarca { get; set; }
        [Column("vl_compra", TypeName = "decimal(10,0)")]
        public decimal VlCompra { get; set; }
        [Column("vl_total", TypeName = "decimal(10,0)")]
        public decimal VlTotal { get; set; }
        [Column("dt_cadastro", TypeName = "date")]
        public DateTime DtCadastro { get; set; }
        [Column("dt_fabricacao", TypeName = "date")]
        public DateTime? DtFabricacao { get; set; }
        [Required]
        [Column("ds_unidade_medida", TypeName = "varchar(45)")]
        public string DsUnidadeMedida { get; set; }
        [Column("dt_vencimento", TypeName = "date")]
        public DateTime DtVencimento { get; set; }
        [Required]
        [Column("ds_nota_fical", TypeName = "varchar(100)")]
        public string DsNotaFical { get; set; }

        [InverseProperty("IdProdutoNavigation")]
        public virtual ICollection<TbEstoque> TbEstoque { get; set; }
    }
}
