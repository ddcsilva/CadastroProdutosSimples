using System.Collections.Generic;

namespace CadastroProdutos.Domain
{
    public sealed class Categoria : EntityBase
    {
        public string Nome { get; set; }

        public ICollection<Produto> Produtos { get; set; }

        public Categoria(string nome)
        {
            ValidarDominio(nome);
        }

        public Categoria(int id, string nome)
        {
            DomainExceptionValidation.When(id < 0, "Atributo 'Id' inválido.");
            Id = id;
            ValidarDominio(nome);
        }

        public void Atualizar(string nome)
        {
            ValidarDominio(nome);
        }

        private void ValidarDominio(string nome)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "Propriedade 'Nome' é obrigatório.");
            DomainExceptionValidation.When(nome.Length < 3, "Propriedade 'Nome' inválido. É obrigatório no mínimo 3 caracteres.");

            Nome = nome;
        }
    }
}
