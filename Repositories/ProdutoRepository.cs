using Learn.Models;
using Learn.Models.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learn.Repositories
{

    public class ProdutoRepository
    {
        private readonly MyDbContext _db;

        public ProdutoRepository(MyDbContext db)
        {
            _db = db;
        }
        public async Task<Produto> PegaProdutoAsync(int id)
        {
            return await _db.Produtos
                        .Where(p => p.ProdutoId.Equals(id))
                        .FirstOrDefaultAsync();
        }

        public async Task<List<Produto>> PegaProdutosAsync()
        {
            return await _db.Produtos
                        .ToListAsync();
        }


        public async Task<Produto> CriaProdutoAsync(Produto produto) 
        {
            var novoProduto = new Produto
            {
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Valor = produto.Valor,
                Marca = produto.Marca,
                CategoriaId = produto.CategoriaId
            };

            try
            {
                await _db.AddAsync(novoProduto);
                await _db.SaveChangesAsync();
                return novoProduto;
            } catch( Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }


        public async Task<Produto> AtualizaProdutoAsync(Produto atualizaProduto, Produto produto)
        {
            produto.Nome = atualizaProduto.Nome;
            produto.Descricao = atualizaProduto.Descricao;
            produto.Valor = atualizaProduto.Valor;
            produto.Marca = atualizaProduto.Marca;
            produto.CategoriaId = atualizaProduto.CategoriaId;

            try
            {
                await _db.AddAsync(produto);
                await _db.SaveChangesAsync();
                return produto;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }


        public async Task<bool> DeletaProdutoAsync(Produto produto)
        {
 
            try
            {
                 _db.Remove(produto);
                await _db.SaveChangesAsync();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }

        }

    }
}
