using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Learn.Models
{
    [Table("categorias")]
    public class Categoria
    {
        [Key]
        [Column("cat_id")]
        public int CategoriaId { get; set; }

        [MaxLength(60)]
        [Required(AllowEmptyStrings = true)]
        [Column("nome")]
        public string Nome { get; set; }

        [MinLength(300, ErrorMessage = "A descrição tem que ter no minimo 300 caracteres")]
        [MaxLength(4000, ErrorMessage = "A descrição pode ter no maximo 4000 caracteres")]
        [Required(AllowEmptyStrings = true)]
        [Column("descricao")]
        public string Descricao { get; set; }

        public ICollection<Produto> Produtos { get; set; }

    }
}
