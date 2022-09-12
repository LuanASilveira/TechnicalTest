using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text;

namespace WK.TechnicalTest.Api.Controllers
{
    [ApiController]
    public class MainController : Controller
    {
        protected ActionResult InvalidModelResponse(ModelStateDictionary modelState)
        {
            IEnumerable<string> errors = NotifierErrorInvalidModel(modelState);
            return BadRequest(errors);
        }

        protected List<string> NotifierErrorInvalidModel(ModelStateDictionary modelState)
        {
            var errors = new List<string>();

            var modelErrors = modelState.Values.SelectMany(e => e.Errors);
            foreach (var error in modelErrors)
            {
                var errorMsg = error.Exception == null ? error.ErrorMessage : error.Exception.Message;
                errors.Add(errorMsg);
            }

            return errors;
        }
    }
}
