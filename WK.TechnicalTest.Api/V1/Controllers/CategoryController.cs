using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WK.TechnicalTest.Api.Controllers;
using WK.TechnicalTest.Api.ViewModel.Category;
using WK.TechnicalTest.BLL.Interfaces.Services;
using WK.TechnicalTest.Model.Entities;

namespace WK.TechnicalTest.Api.V1.Controllers
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/category")]
    public class CategoryController : MainController
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService,
                                  IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<CategoryResponseViewModel> categories =
            _mapper.Map<IEnumerable<CategoryResponseViewModel>>(await _categoryService.GetAll());

            return Ok(categories);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetById(long id)
        {
            CategoryResponseViewModel category = _mapper.Map<CategoryResponseViewModel>(await _categoryService.GetById(id));

            return Ok(category);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CategoryInputViewModel categoryInputViewModel)
        {
            if (!ModelState.IsValid)
                return InvalidModelResponse(ModelState);

            Category category = _mapper.Map<Category>(categoryInputViewModel);

            IEnumerable<string> validation = await _categoryService.Add(category);
            if (validation.Any())
                return BadRequest(validation);

            return Ok(category);
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(long id)
        {
            await _categoryService.Delete(id);

            return Ok();
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update([FromQuery] long id, CategoryInputViewModel categoryInputViewModel)
        {
            if (!ModelState.IsValid)
                return InvalidModelResponse(ModelState);

            Category category = _mapper.Map<Category>(categoryInputViewModel, opt => opt.AfterMap((src, dest) => dest.Id = id));

            IEnumerable<string> validation = await _categoryService.Update(category);
            if (validation.Any())
                return BadRequest(validation);

            return Ok(category);
        }
    }
}
