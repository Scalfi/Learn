﻿using Learn.Models;
using Learn.Models.Database;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Learn.Repositories
{
    public class CategoriaRepository
    {

        private readonly MyDbContext _db;

        public CategoriaRepository(MyDbContext db)
        {
            _db = db;
        }
        public async Task<Categoria> PegaCategoriaAsync(int id)
        {
            return await _db.Categorias
                        .Where(c => c.CategoriaId.Equals(id))
                        .FirstOrDefaultAsync();
        }

        public async Task<Categoria> PegaCategoriaComProdutoAsync(int id)
        {
            return await _db.Categorias
                        .Include(c => c.Produtos)
                        .Where(p => p.CategoriaId.Equals(id))
                        .FirstOrDefaultAsync();
        }


        public async Task<List<Categoria>> PegaCategoriasAsync()
        {
            return await _db.Categorias
                        .ToListAsync();
        }


        public async Task<Categoria> CriaCategoriaAsync(Categoria Categoria)
        {
            var novoCategoria = new Categoria
            {
                Nome = Categoria.Nome,
                Descricao = Categoria.Descricao,
            };

            try
            {
                await _db.AddAsync(novoCategoria);
                await _db.SaveChangesAsync();
                return novoCategoria;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }


        public async Task<Categoria> AtualizaCategoriaAsync(Categoria atualizaCategoria, Categoria Categoria)
        {
            Categoria.Nome = atualizaCategoria.Nome;
            Categoria.Descricao = atualizaCategoria.Descricao;

            try
            {
                await _db.SaveChangesAsync();
                return Categoria;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }


        public async Task<bool> DeletaCategoriaAsync(Categoria Categoria)
        {

            try
            {
                _db.Remove(Categoria);
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
