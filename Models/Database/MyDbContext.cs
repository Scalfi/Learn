using Microsoft.EntityFrameworkCore;



namespace Learn.Models.Database
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<ProdutoCategoria> ProdutoCategorias{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<ProdutoCategoria>()
                .HasOne(pC => pC.Produto)
                .WithMany(p => p.ProdutoCategorias);

            modelBuilder.Entity<ProdutoCategoria>()
                .HasOne(pC => pC.Categoria)
                .WithMany(c => c.ProdutoCategorias);

            modelBuilder.Entity<ProdutoCategoria>()
                .HasKey(x => new { x.ProdutoId, x.CategoriaId });

        }
    }
}
