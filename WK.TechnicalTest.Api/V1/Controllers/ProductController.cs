using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WK.TechnicalTest.Api.Controllers;
using WK.TechnicalTest.Api.ViewModel.Product;
using WK.TechnicalTest.BLL.Interfaces.Services;
using WK.TechnicalTest.Model.Entities;

namespace WK.TechnicalTest.Api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/product")]
    public class ProductController : MainController
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;

        public ProductController(IProductService productService,
                                  IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<ProductResponseViewModel> products =
            _mapper.Map<IEnumerable<ProductResponseViewModel>>(await _productService.GetAll());

            return Ok(products);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(long id)
        {
            ProductResponseViewModel product = _mapper.Map<ProductResponseViewModel>(await _productService.GetById(id));

            return Ok(product);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(ProductInputViewModel ProductInputViewModel)
        {
            if (!ModelState.IsValid)
                return InvalidModelResponse(ModelState);

            Product product = _mapper.Map<Product>(ProductInputViewModel);

            IEnumerable<string> validation = await _productService.Add(product);
            if (validation.Any())
                return BadRequest(validation);

            return Ok(product);
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromQuery] long id, ProductInputViewModel productInputViewModel)
        {
            if (!ModelState.IsValid)
                return InvalidModelResponse(ModelState);

            Product product = _mapper.Map<Product>(productInputViewModel, opt => opt.AfterMap((src, dest) => dest.Id = id));

            IEnumerable<string> validation = await _productService.Update(product);
            if (validation.Any())
                return BadRequest(validation);

            return Ok(product);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(long id)
        {
            await _productService.Delete(id);

            return Ok();
        }
    }
}
