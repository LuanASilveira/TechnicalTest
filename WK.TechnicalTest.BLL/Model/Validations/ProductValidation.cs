using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WK.TechnicalTest.Model.Entities;

namespace WK.TechnicalTest.BLL.Model.Validations
{
    public class ProductValidation : AbstractValidator<Product>
    {
        public ProductValidation()
        {
            RuleFor(p => p.CategoryId).NotEmpty()
                                      .WithMessage("Categoria é obrigatória.");

            RuleFor(p => p.Name).NotEmpty()
                                .WithMessage("Nome é obrigatório.")
                                .MaximumLength(150)
                                .WithMessage("Nome deve conter no máximo 150 caracteres.");

            RuleFor(p => p.Price).NotEmpty()
                                 .WithMessage("Preço é obrigatório.")
                                 .GreaterThan(0)
                                 .WithMessage("Preço deve ser maior que 0.");
        }
    }
}
