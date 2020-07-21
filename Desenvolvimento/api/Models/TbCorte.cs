using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("tb_corte")]
    public partial class TbCorte
    {
        public TbCorte()
        {
            TbVenda = new HashSet<TbVenda>();
        }

        [Key]
        [Column("id_corte")]
        public int IdCorte { get; set; }
        [Column("id_funcionario")]
        public int IdFuncionario { get; set; }
        [Required]
        [Column("nm_corte", TypeName = "varchar(70)")]
        public string NmCorte { get; set; }
        [Required]
        [Column("tp_corte", TypeName = "varchar(50)")]
        public string TpCorte { get; set; }
        [Column("vl_corte", TypeName = "decimal(3,2)")]
        public decimal VlCorte { get; set; }
        [Column("id_produro")]
        public int IdProduro { get; set; }
        [Column("hr_preparo", TypeName = "time")]
        public TimeSpan? HrPreparo { get; set; }
        [Column("ds_foto", TypeName = "varchar(150)")]
        public string DsFoto { get; set; }
        [Column("ds_comentario", TypeName = "varchar(70)")]
        public string DsComentario { get; set; }
        [Column("ds_dicas", TypeName = "varchar(150)")]
        public string DsDicas { get; set; }
        [Column("dt_publicacao", TypeName = "datetime")]
        public DateTime? DtPublicacao { get; set; }
        [Column("vl_avaliacao", TypeName = "decimal(2,2)")]
        public decimal? VlAvaliacao { get; set; }

        [ForeignKey(nameof(IdFuncionario))]
        [InverseProperty(nameof(TbFuncionario.TbCorte))]
        public virtual TbFuncionario IdFuncionarioNavigation { get; set; }
        [InverseProperty("IdCorteNavigation")]
        public virtual ICollection<TbVenda> TbVenda { get; set; }
    }
}
