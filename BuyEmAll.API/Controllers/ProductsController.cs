using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BuyEmAll.API.Dtos;
using BuyEmAll.API.Errors;
using BuyEmAll.API.Helpers;
using BuyEmAll.Core.Entities;
using BuyEmAll.Core.Interfaces.Repositories;
using BuyEmAll.Core.Specifications;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BuyEmAll.API.Controllers
{
    // [Authorize]
    public class ProductsController : BaseController
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<Category> _categoryRepo;
        private readonly IGenericRepository<Brand> _brandRepo;
        // private readonly IMapper _mapper;

        public ProductsController(ILogger<ProductsController> logger, IGenericRepository<Product> productRepo,
            IGenericRepository<Category> categoryRepo, IGenericRepository<Brand> brandRepo, IMapper mapper) : base(mapper)
        {
            _productRepo = productRepo;
            _categoryRepo = categoryRepo;
            _brandRepo = brandRepo;
            // _mapper = mapper;
            _logger = logger;
        }

        [Cached(600)]
        [HttpGet("[action]")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IReadOnlyList<ProductReadDto>))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse))]
        public async Task<IActionResult> GetProducts([FromQuery] ProductSpecParams productSpecParams)
        {

            var result = await _productRepo.GetListWithSpecAsync(new ProductsWithCategoryAndBrandSpec(productSpecParams));
            return Ok(new Pagination<ProductReadDto> { 
                PageIndex = productSpecParams.PageIndex,
                PageSize = productSpecParams.PageSize,
                Data = _mapper.Map<IReadOnlyList<ProductReadDto>>(result) });
        }

        [Cached(600)]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ProductReadDto))]
        [ProducesResponseType(StatusCodes.Status404NotFound, Type = typeof(ApiResponse))]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(_mapper.Map<ProductReadDto>(await _productRepo.GetEntityWithSpecAsync(new ProductsWithCategoryAndBrandSpec(id))));
        }

        [Cached(600)]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetCategories()
        {
            return Ok(await _categoryRepo.GetAllAsync());
        }

        [Cached(600)]
        [HttpGet("[action]")]
        public async Task<IActionResult> GetBrands()
        {
            return Ok(await _brandRepo.GetAllAsync());
        }
    }
}
