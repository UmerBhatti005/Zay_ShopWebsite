using AutoMapper;
using IdentityProjectPractise.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopLibrary;
using ShopLibrary.Helper;
using ShopLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Zay.Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductsController : ControllerBase
    {

        private readonly IShopCatalogRepository _shopRepository;
        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<Colors> _colorRepository;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;

        //Here we use Dependency Injection to inject IShopCatalogRepository and IGenericRepository of Product
        public ProductsController(IShopCatalogRepository shopRepository, IGenericRepository<Product> productRepository, IGenericRepository<Colors> colorRepository,
            IMapper mapper, UserManager<ApplicationUser> userManager )
        {
            _shopRepository = shopRepository;
            _productRepository = productRepository;
            _colorRepository = colorRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        //Here we get the values through QueryString
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                //Use QueryString to get colorById
                //Sample Request Query https://localhost:44310/api/Products?color=1
                int color = Convert.ToInt32(Request.Query["color"]);
                if (color > 0)
                {
                    var colorsModel = _colorRepository.GetById(color).FirstOrDefault();
                    var mappedColor = _mapper.Map<ColorsModel>(colorsModel);
                    return Ok(mappedColor);
                }
                //Use QueryString to get colors
                //Sample Request Query https://localhost:44310/api/Products?color=true
                bool allColor = Convert.ToBoolean(Request.Query["colors"]);
                if (allColor)
                {
                    var colorsModel = _colorRepository.GetAll().ToList();
                    var mappedColor = _mapper.Map<List<ColorsModel>>(colorsModel);
                    return Ok(mappedColor);
                }
                //Use QueryString to get Newest Products
                bool newest = Convert.ToBoolean(Request.Query["newest"]);
                if (newest)
                {
                    List<ProductModel> newmodels = _shopRepository.GetNewestProducts().ToModelList();
                    if (newmodels == null) { return BadRequest("model cant be null"); }
                    return Ok(newmodels);
                }
                //Use QueryString to get Best Seller Products
                bool bestseller = Convert.ToBoolean(Request.Query["bestseller"]);
                if (bestseller)
                {
                    List<ProductModel> bestmodels = _shopRepository.GetBestSellers().ToModelList();
                    if (bestmodels == null) { return BadRequest("model cant be null"); }
                    return Ok(bestmodels);
                }
                //Use QueryString to get Featured Products
                bool featured = Convert.ToBoolean(Request.Query["featured"]);
                if (featured)
                {
                    List<ProductModel> featuredmodel = _shopRepository.GetFeaturedProducts().ToModelList();
                    if (featuredmodel == null) { return BadRequest("model cant be null"); }
                    return Ok(featuredmodel);
                }

                bool active = Convert.ToBoolean(Request.Query["Active"]);
                if (active)
                {
                    var model = _shopRepository.GetActiveProducts(2).ToList().ToModelList();
                    if(model == null) { return BadRequest("model cant be null"); }
                    return Ok(model);
                }

                //Code to get All Products
                //var models = _productRepository.GetAll().Include(x => x.categories).ThenInclude(x => x.Parent).Include(x => x.statuses).Include(x => x.genders).Include(x => x.ProductImages).AsNoTracking().ToList();
                var models = _shopRepository.GetProducts().ToList().ToModelList();
                if (models == null) { return BadRequest("model cant be null"); }
                return Ok(models);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        //Program to get Product by Id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                if (id < 1) { return BadRequest("Id cant be negative or zero or null"); }
                var model = _productRepository.GetById(id).Include(x => x.categories).ThenInclude(x => x.Parent).Include(x => x.statuses).Include(x => x.productSizes).Include(x => x.colors).Include(x => x.genders).Include(x => x.ProductImages).Include(x => x.applicationUser).Where(x => x.Id == id).FirstOrDefault().ToModel();
                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        //Program to get Product by CatgoryId
        [HttpGet]
        [Route("ProductByCategory/{id}")]
        public IActionResult GetByCid(int id)
        {
            try
            {
                if (id < 1) { return BadRequest("CategoryId cant be negative or zero or null"); }
                List<ProductModel> model = _shopRepository.GetProductsByCategoryId(id).ToModelList();
                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        //Program to get Product by GenderId
        [HttpGet("/ProductByGender/{id}")]
        public IActionResult GetByGender(int id)
        {
            try
            {
                bool news = Convert.ToBoolean(Request.Query["newest"]);
                if (news)
                {
                    if (id < 1) { return BadRequest("GenderId cant be negative or zero or null"); }
                    List<ProductModel> nmodel = _shopRepository.GetNewestProductsForGender(id).ToModelList();
                    return Ok(nmodel);
                }

                if (id < 1) { return BadRequest("GenderId cant be negative or zero or null"); }
                List<ProductModel> model = _shopRepository.GetProductsForGender(id).ToModelList();
                return Ok(model);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        [HttpGet("/SpecAdv/{Username}")]
        //[Route("SpecAdv")]
        public IActionResult GetSpecificAdvFromUser(string Username)
        {
            try
            {
                if (Username == null) { return BadRequest("Username can't be null"); }
                var model = _shopRepository.GetSpecificAdvFromUser(Username).ToModelList();
                if (model != null)
                {
                    return Ok(model);
                }
                return BadRequest();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        //Program to post Product
        [HttpPost]
        public IActionResult Post(ProductModel model)
        {
            try
            {
                var dept = _userManager.Users.Where(d => d.UserName == model.Username).FirstOrDefault();
                //return dept;
                if (model == null) { return BadRequest("Model Cant be null"); }
                Product entity = _shopRepository.AddProduct(model.ToEntity(dept));
                if (entity == null) { return BadRequest("Model Cant be null"); }
                return Ok(entity);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
        //program to update product
        [HttpPut]
        public IActionResult put(ProductModel model)
        {
            try
            {
                if (model == null) { return BadRequest("model cant be null"); }
                var dept = _userManager.Users.Where(d => d.Id == model.Username).FirstOrDefault();
                var entity = _productRepository.Update(model.ToEntity(dept));
                if (entity == null) { return BadRequest("model cant be null"); }
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        //Program to Delete Product
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id < 1) { return BadRequest("id cant be null or zero or negative"); }
                //Product entity = new ShopCatalogRepository().DeleteProduct(id);
                //Product entity = _productRepository.Delete(id);
                var res = _productRepository.GetById(id).FirstOrDefault();
                if (res != null)
                {
                    _productRepository.Delete(res);
                }
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }
    }
}
