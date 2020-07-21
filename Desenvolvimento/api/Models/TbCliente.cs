using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Models
{
    [Table("tb_cliente")]
    public partial class TbCliente
    {
        public TbCliente()
        {
            TbAgenda = new HashSet<TbAgenda>();
            TbVenda = new HashSet<TbVenda>();
        }

        [Key]
        [Column("id_cliente")]
        public int IdCliente { get; set; }
        [Required]
        [Column("nm_cliente", TypeName = "varchar(75)")]
        public string NmCliente { get; set; }
        [Required]
        [Column("ds_cpf", TypeName = "varchar(15)")]
        public string DsCpf { get; set; }
        [Column("dt_nascimento", TypeName = "date")]
        public DateTime? DtNascimento { get; set; }
        [Required]
        [Column("ds_tel", TypeName = "varchar(20)")]
        public string DsTel { get; set; }
        [Required]
        [Column("ds_email", TypeName = "varchar(100)")]
        public string DsEmail { get; set; }

        [InverseProperty("IdClienteNavigation")]
        public virtual ICollection<TbAgenda> TbAgenda { get; set; }
        [InverseProperty("IdClienteNavigation")]
        public virtual ICollection<TbVenda> TbVenda { get; set; }
    }
}
