using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Learn.Models
{

    [Table("produto_categorias")]
    public class ProdutoCategoria
    {
        [ForeignKey("prod_id")]
        public int ProdutoId { get; set; }

        [ForeignKey("cat_id")]
        public int CategoriaId { get; set; }

        public Produto Produto { get; set; }
        public Categoria Categoria { get; set; }

    }
}
