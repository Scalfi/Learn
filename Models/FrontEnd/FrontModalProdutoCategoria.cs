using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learn.Models.FrontEnd
{
    public class FrontModalProdutoCategoria
    {
        public Produto Produto { get; set; }
        public List<Categoria> Categorias { get; set; }
        public Categoria Categoria { get; set; }
        public string Url { get; set; }
        public string Method { get; set; } = "post";

    }
}
