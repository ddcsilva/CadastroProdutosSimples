using FluentAssertions;
using System;
using Xunit;

namespace CadastroProdutos.Domain.Tests
{
    public class ProductUnitTest
    {
        [Fact]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Produto(1, "Product Name", "Product Description", 9.99m,
                99, "product image");
            action.Should()
                .NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Produto(-1, "Product Name", "Product Description", 9.99m,
                99, "product image");

            action.Should().Throw<DomainExceptionValidation>()
                .WithMessage("Atributo 'Id' inválido.");
        }

        [Fact]
        public void CreateProduct_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Produto(1, "Pr", "Product Description", 9.99m, 99,
                "product image");
            action.Should().Throw<DomainExceptionValidation>()
                 .WithMessage("Atributo 'Nome' inválido. É obrigatório no mínimo 3 caracteres.");
        }

        [Fact]
        public void CreateProduct_LongImageName_DomainExceptionLongImageName()
        {
            Action action = () => new Produto(1, "Product Name", "Product Description", 9.99m,
                99, "product image toooooooooooooooooooooooooooooooooooooooooooo loooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooogggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggggg");

            action.Should()
                .Throw<DomainExceptionValidation>()
                 .WithMessage("Propriedade 'Imagem' inválido. Máximo de 250 caracteres excedido.");
        }

        [Fact]
        public void CreateProduct_WithNullImageName_NoDomainException()
        {
            Action action = () => new Produto(1, "Product Name", "Product Description", 9.99m, 99, null);
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_WithEmptyImageName_NoDomainException()
        {
            Action action = () => new Produto(1, "Product Name", "Product Description", 9.99m, 99, "");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact]
        public void CreateProduct_InvalidPriceValue_DomainException()
        {
            Action action = () => new Produto(1, "Product Name", "Product Description", -9.99m,
                99, "");
            action.Should().Throw<DomainExceptionValidation>()
                 .WithMessage("Propriedade 'Preco' inválido.");
        }

        [Theory]
        [InlineData(-5)]
        public void CreateProduct_InvalidStockValue_ExceptionDomainNegativeValue(int value)
        {
            Action action = () => new Produto(1, "Pro", "Product Description", 9.99m, value,
                "product image");
            action.Should().Throw<DomainExceptionValidation>()
                   .WithMessage("Propriedade 'QuantidadeEstoque' inválido.");
        }

    }
}
