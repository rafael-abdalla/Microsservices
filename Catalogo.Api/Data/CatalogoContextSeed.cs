using Catalogo.Api.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Catalogo.Api.Data
{
    public class CatalogoContextSeed
    {
        public static async void SeedData(IMongoCollection<Produto> produtos)
        {
            bool temProduto = produtos.Find(p => true).Any();
            if (!temProduto)
            {
                try
                {
                    await produtos.InsertManyAsync(ObterProdutos());
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }

        private static IEnumerable<Produto> ObterProdutos()
        {
            return new List<Produto>()
            {
                new Produto()
                {
                    Id = Guid.NewGuid().ToString(),
                    Nome = "Monitor LG Widescreen 24MP400-23.8\", Preto",
                    Descricao = @"
                        Monitor lg widescreen 24mp400-23.8 Descubra produtos úteis para você Os 
                        produtos foram projetados com o usuário em mente querendo cumprir os desejos
                    ",
                    Imagem = "https://m.media-amazon.com/images/I/414+bQflLoL._AC_SX425_.jpg",
                    Preco = 929.9M,
                    Categoria = "Computadores e Informática"
                },
                new Produto()
                {
                    Id = Guid.NewGuid().ToString(),
                    Nome = "Cadeira Gamer Cruiser Preta/Verde Fortrek",
                    Descricao = @"
                        A cadeira Cruiser tem sua cobertura em poliuretano com detalhes em fibra de 
                        carbono. Sua costura remete aos famoso bancos dos carros esportivos enquanto 
                        você desfruta do prazer de jogar seus games favoritos. - Conforto o Todo Um 
                        assento firme com um pequeno apoio para cabeça e almofada para as costas 
                        oferecem um conforto prolongado. - Apoie seu antebraço no apoio ajustável 
                        bi-direcional Perfeito para posicionar os cotovelos durante horas de 
                        jogabilidade. - Deslocamento facilitado Com uma roda de 60 mm de diâmetro 
                        construída em nylon garante liberdade para movimentar-se para todos os lados.
                    ",
                    Imagem = "https://m.media-amazon.com/images/I/51s1yFKdnHL._AC_SX522_.jpg",
                    Preco = 1376.86M,
                    Categoria = "Móveis"
                },
            };
        }
    }
}
