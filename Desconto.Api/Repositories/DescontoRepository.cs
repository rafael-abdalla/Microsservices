using Dapper;
using Desconto.Api.Entities;
using Microsoft.Extensions.Configuration;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desconto.Api.Repositories
{
    public class DescontoRepository : IDescontoRepository
    {
        private readonly IConfiguration _configuration;

        public DescontoRepository(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new
                ArgumentNullException(nameof(configuration));
        }

        private NpgsqlConnection ObterConexaoPostgreSQL()
        {
            return new NpgsqlConnection
                (_configuration.GetValue<string>("DatabaseSettings:ConnectionString"));
        }

        public async Task<bool> Atualizar(Cupom cupom)
        {
            NpgsqlConnection conexao = ObterConexaoPostgreSQL();

            var resultado = await conexao.ExecuteAsync(
                @"UPDATE Cupom SET ProdutoNome=@ProdutoNome,
                Descricao=@Descricao, Valor=@Valor WHERE Id=@Id",
                new { Id = cupom.Id, ProdutoNome = cupom.ProdutoNome,
                    Descricao = cupom.Descricao, Valor = cupom.Valor });

            return resultado != 0;
        }

        public async Task<bool> Eliminar(string nome)
        {
            NpgsqlConnection conexao = ObterConexaoPostgreSQL();

            var resultado = await conexao.ExecuteAsync(
                "DELETE FROM Cupom WHERE ProdutoNome=@ProdutoNome",
                new { ProdutoNome = nome });

            return resultado != 0;
        }

        public async Task<bool> Inserir(Cupom cupom)
        {
            NpgsqlConnection conexao = ObterConexaoPostgreSQL();

            var resultado = await conexao.ExecuteAsync(
                @"INSERT INTO Cupom (Id, ProdutoNome, Descricao, Valor)
                VALUES (@Id, @ProdutoNome, @Descricao, @Valor)",
                new { Id = cupom.Id, ProdutoNome = cupom.ProdutoNome,
                    Descricao = cupom.Descricao, Valor = cupom.Valor });

            return resultado != 0;
        }

        public async Task<Cupom> ObterPorProdutoNome(string nome)
        {
            NpgsqlConnection conexao = ObterConexaoPostgreSQL();

            var cupom = await conexao.QueryFirstOrDefaultAsync<Cupom>(
                "SELECT * FROM Cupom WHERE ProdutoNome=@ProdutoNome",
                new { ProdutoNome = nome });

            if (cupom == null)
            {
                return new Cupom { ProdutoNome = "Sem desconto", Descricao = "Sem descrição de desconto", Valor = 0 };
            }

            return cupom;
        }
    }
}
