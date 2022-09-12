using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WK.TechnicalTest.BLL.Interfaces.Services;
using WK.TechnicalTest.Model.Entities;

namespace WK.TechnicalTest.BLL.Model.Validations
{
    public class CategoryValidation : AbstractValidator<Category>
    {
        public CategoryValidation(ICategoryService categoryService)
        {
            RuleFor(c => c.Name).NotEmpty()
                                .WithMessage("Nome é obrigatório.")
                                .MaximumLength(150)
                                .WithMessage("Nome deve conter no máximo 150 caracteres.")
                                .CustomAsync(async (field, context, cancellationToken) =>
                                {
                                    long? id = context.InstanceToValidate.Id > 0 ? context.InstanceToValidate.Id : null;
                                    if (await categoryService.CheckDuplicatedName(field, id))
                                        context.AddFailure("Já existe outra categoria com o mesmo nome.");
                                });
        }
    }
}
