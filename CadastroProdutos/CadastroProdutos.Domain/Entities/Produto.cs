using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroProdutos.Domain
{
    public sealed class Produto : EntityBase
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public decimal Preco { get; private set; }
        public int QuantidadeEstoque { get; private set; }
        public string Imagem { get; private set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public Produto(string nome, string descricao, decimal preco, int quantidadeEstoque, string imagem)
        {
            ValidarDominio(nome, descricao, preco, quantidadeEstoque, imagem);
        }

        public Produto(int id, string nome, string descricao, decimal preco, int quantidadeEstoque, string imagem)
        {
            DomainExceptionValidation.When(id < 0, "Atributo 'Id' inválido.");
            Id = id;
            ValidarDominio(nome, descricao, preco, quantidadeEstoque, imagem);
        }

        public void Atualizar(string nome, string descricao, decimal preco, int quantidadeEstoque, string imagem, int categoriaId)
        {
            ValidarDominio(nome, descricao, preco, quantidadeEstoque, imagem);
            CategoriaId = categoriaId;
        }

        private void ValidarDominio(string nome, string descricao, decimal preco, int quantidadeEstoque, string imagem)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Propriedade 'Nome' é obrigatório.");
            DomainExceptionValidation.When(nome.Length < 3, "Atributo 'Nome' inválido. É obrigatório no mínimo 3 caracteres.");
            DomainExceptionValidation.When(string.IsNullOrEmpty(descricao), "Atributo 'Descricao' é obrigatório.");
            DomainExceptionValidation.When(descricao.Length < 5, "Propriedade 'Descricao' inválido. É obrigatório no mínimo 3 caracteres.");
            DomainExceptionValidation.When(preco < 0, "Propriedade 'Preco' inválido.");
            DomainExceptionValidation.When(quantidadeEstoque < 0, "Propriedade 'QuantidadeEstoque' inválido.");
            DomainExceptionValidation.When(imagem?.Length > 250, "Propriedade 'Imagem' inválido. Máximo de 250 caracteres excedido.");

            Nome = nome;
            Descricao = descricao;
            Preco = preco;
            QuantidadeEstoque = quantidadeEstoque;
            Imagem = imagem;
        }
    }
}
