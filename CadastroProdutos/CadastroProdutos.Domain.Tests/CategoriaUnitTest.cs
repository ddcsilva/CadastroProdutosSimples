using FluentAssertions;
using System;
using Xunit;

namespace CadastroProdutos.Domain.Tests
{
    public class CategoriaUnitTest
    {
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Categoria(1, "Nome da Categoria");
            action.Should()
                 .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateCategory_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Categoria(-1, "Nome da Categoria");
            action.Should()
                .Throw<DomainExceptionValidation>()
                 .WithMessage("Atributo 'Id' inv�lido.");
        }

        [Fact]
        public void CreateCategory_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Categoria(1, "Ca");
            action.Should()
                .Throw<DomainExceptionValidation>()
                   .WithMessage("Propriedade 'Nome' inv�lido. � obrigat�rio no m�nimo 3 caracteres.");
        }

        [Fact]
        public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Categoria(1, "");
            action.Should()
                .Throw<DomainExceptionValidation>()
                .WithMessage("Propriedade 'Nome' � obrigat�rio.");
        }

        [Fact]
        public void CreateCategory_WithNullNameValue_DomainExceptionInvalidName()
        {
            Action action = () => new Categoria(1, null);
            action.Should()
                .Throw<DomainExceptionValidation>();
        }
    }
}
