using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Learn.Models
{
    [Table("produtos")]
    public class Produto
    {
        [Key]
        [Column("prod_id")]

        public int ProdutoId { get; set; }

        [MaxLength(60)]
        [Required(AllowEmptyStrings = true)]
        [Column("nome")]
        public string Nome { get; set; }

        [MinLength(300, ErrorMessage = "A descrição tem que ter no minimo 300 caracteres")]
        [MaxLength(4000, ErrorMessage = "A descrição pode ter no maximo 4000 caracteres")]
        [Required(AllowEmptyStrings = true)]
        [Column("descricao")]

        public string Descricao { get; set; }

        [Required]
        [Range(0, 999.99)]
        [Column("Valor")]
        public decimal Valor { get; set; }
        
        [MaxLength(50)]
        [DefaultValue("")]
        [Required(AllowEmptyStrings = true)]
        [Column("marca")]
        public decimal Marca { get; set; }

        [Column("cat_id")]
        public int CategoriaId { get; set; }
        
        [ForeignKey("CategoriaId")]
        public Categoria Categoria { get; set; }
    }
}
