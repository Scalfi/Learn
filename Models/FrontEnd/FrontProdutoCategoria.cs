using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learn.Models.FrontEnd
{
    public class FrontProdutoCategoria
    {
        public Produto Produto { get; set; }
        public List<Categoria> Categorias { get; set; }
    }
}
