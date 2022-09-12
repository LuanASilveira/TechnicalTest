using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WK.TechnicalTest.Model;

namespace WK.TechnicalTest.BLL.Services
{
    public class BaseService
    {
        protected async Task<IEnumerable<string>> ExecuteValidation<TV, TE>(TV validation, TE entity) where TV : AbstractValidator<TE> where TE : Entity
        {
            var validator = await validation.ValidateAsync(entity);

            if (validator.IsValid)
                return Array.Empty<string>();

            return validator.Errors.Select(e => e.ErrorMessage).ToArray();
        }
    }
}
