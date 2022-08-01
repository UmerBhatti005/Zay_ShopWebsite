using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    public class GeneralController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly IGenericRepository<Category> _categoryRepo;
        private readonly IGenericRepository<Status> _statusRepo;
        private readonly IGenericRepository<Gender> _genderRepo;
        private readonly IGenericRepository<ProductSize> _prodSizeRepo;


        //Here we use Dependency Injection to inject IMapper, IGenericRepository of Catgory,
        //IGenericRepository od Status, IGenericRepository od Gender and IGenericRepository of ProductSize
        public GeneralController(IMapper mapper, IGenericRepository<Category> categoryRepo, IGenericRepository<Status> statusRepo, IGenericRepository<Gender> genderRepo, IGenericRepository<ProductSize> prodSizeRepo)
        {
            _mapper = mapper;
            _categoryRepo = categoryRepo;
            _statusRepo = statusRepo;
            _genderRepo = genderRepo;
            _prodSizeRepo = prodSizeRepo;
        }

        //Here we get the values through QueryString
        [HttpGet]
        //[Authorize]
        public IActionResult Get()
        {
            try
            {
                //Use QueryString to get TopLevel Catgories
                //Sample Request Query https://localhost:44310/api/General?top=true
                bool Top = Convert.ToBoolean(Request.Query["top"]);
                if (Top)
                {
                    var topmodel = new ShopCatalogRepository().GetTopCategories();
                    List<CategoryModel> mappedItem = _mapper.Map<List<CategoryModel>>(topmodel);
                    if (mappedItem == null) { return BadRequest("Model Cant be null"); }
                    return Ok(mappedItem);
                }

                //Use QueryString to get SubCatgories
                //Sample Request Query https://localhost:44310/api/General?sub=true
                bool SubCat = Convert.ToBoolean(Request.Query["sub"]);
                if (SubCat)
                {
                    var subModel = _categoryRepo.GetAll().Include(x => x.Parent).Where(x => x.Parent != null).ToList().ToModelList();
                    List<CategoryModel> mappedItem = _mapper.Map<List<CategoryModel>>(subModel);
                    if (mappedItem == null) { return BadRequest("Model Cant be null"); }
                    return Ok(mappedItem);
                }

                int Sub = Convert.ToInt32(Request.Query["subCat"]);
                if (Sub > 0)
                {
                    var subModel = new ShopCatalogRepository().GetSubCategoriesByCategoryId(Sub);
                    List<CategoryModel> mappedItem = _mapper.Map<List<CategoryModel>>(subModel);
                    if (mappedItem == null) { return BadRequest("Model Cant be null"); }
                    return Ok(mappedItem);
                }

                //Use QueryString to get Statuses
                //Sample Request Query https://localhost:44310/api/General?statuses=true
                bool status = Convert.ToBoolean(Request.Query["statuses"]);
                if (status)
                {
                    //var statusesModel = new ShopCatalogRepository().GetAll();
                    var statusesModel = _statusRepo.GetAll();
                    List<StatusModel> mappedItem = _mapper.Map<List<StatusModel>>(statusesModel);
                    if (statusesModel == null) { return BadRequest("Model Cant be null"); }
                    return Ok(statusesModel);
                }

                //Use QueryString to get Status By Id
                //Sample Request Query https://localhost:44310/api/General?statusid=3            
                int statusid = Convert.ToInt32(Request.Query["statusId"]);
                if (statusid > 0)
                {
                    //var statusmodel = new ShopCatalogRepository().GetStatusbyId(statusid);
                    var statusmodel = _statusRepo.GetById(statusid);
                    StatusModel mappedItem = _mapper.Map<StatusModel>(statusmodel);
                    if (mappedItem == null) { return BadRequest("Model Cant be null"); }
                    return Ok(mappedItem);
                }

                //Use QueryString to get Genders
                //Sample Request Query https://localhost:44310/api/General?gender=true
                bool gender = Convert.ToBoolean(Request.Query["gender"]);
                if (gender)
                {
                    //var gendersModel = new ShopCatalogRepository().GetGenders();
                    var gendersModel = _genderRepo.GetAll();
                    List<GenderModel> mappedItem = _mapper.Map<List<GenderModel>>(gendersModel);
                    if (mappedItem == null) { return BadRequest("Model Cant be null"); }
                    return Ok(mappedItem);
                }

                //Use QueryString to get Gender By Id
                //Sample Request Query https://localhost:44310/api/General?genderid=3            
                int genderid = Convert.ToInt32(Request.Query["genderId"]);
                if (genderid > 0)
                {
                    //var gendermodel = new ShopCatalogRepository().GetGenderbyID(genderid);
                    var gendermodel = _genderRepo.GetById(genderid);
                    GenderModel mappedItem = _mapper.Map<GenderModel>(gendermodel);
                    if (mappedItem == null) { return BadRequest("Model cant be null"); }
                    return Ok(mappedItem);
                }

                //Use QueryString to get ProductSizes
                //Sample Request Query https://localhost:44310/api/General?productsize=true
                bool productsize = Convert.ToBoolean(Request.Query["productsize"]);
                if (productsize)
                {
                    //var prodsSizeModel = new ShopCatalogRepository().GetProductSizes();
                    var prodsSizeModel = _prodSizeRepo.GetAll();
                    List<ProductSizeModel> mappedItem = _mapper.Map<List<ProductSizeModel>>(prodsSizeModel);
                    if (mappedItem == null) { return BadRequest("Model Cant be null"); }
                    return Ok(mappedItem);
                }

                //Use QueryString to get ProductSize By Id
                //Sample Request Query https://localhost:44310/api/General?psizeid=3            
                int psizeid = Convert.ToInt32(Request.Query["psizeId"]);
                if (psizeid > 0)
                {
                    //var prodSizeModel = new ShopCatalogRepository().GetProductSize(psizeid);
                    var prodSizeModel = _prodSizeRepo.GetById(psizeid);
                    ProductSizeModel mappedItem = _mapper.Map<ProductSizeModel>(prodSizeModel);
                    if (mappedItem == null) { return BadRequest("Model Cant be null"); }
                    return Ok(mappedItem);
                }


                //Use QueryString to get All Categories
                var entity = _categoryRepo.GetAll().Include(x => x.Parent).AsNoTracking().ToList();
                var mapItem = _mapper.Map<List<CategoryModel>>(entity);
                if (mapItem == null) { return BadRequest("model cant be null"); }
                return Ok(mapItem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        //Program to get Category By Id
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var model = _categoryRepo.GetById(id).Include(x => x.Parent).Where(c => c.Id == id).FirstOrDefault();
                CategoryModel mappedItem = _mapper.Map<CategoryModel>(model);
                if (mappedItem == null) { return BadRequest("model cant be null"); }
                return Ok(mappedItem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        //Program to post Category
        [HttpPost]
        public IActionResult Post(CategoryModel model)
        {
            try
            {
                if (model == null) { return BadRequest("Model Cant be null"); }
                Category mappedItem = _mapper.Map<Category>(model);
                var entity = _categoryRepo.Insert(mappedItem);
                if (entity == null) { return BadRequest("Model Cant be null"); }
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        //Program to update Category
        [HttpPut]
        public IActionResult Put(int id, CategoryModel model)
        {
            try
            {
                if (id < 0) { return BadRequest("id cant be zero or negative"); }
                if (model == null) { return BadRequest("Model Can't be null"); }
                Category mappeditem = _mapper.Map<Category>(model);
                var entity = _categoryRepo.Update(mappeditem);
                //Category entity = new ShopCatalogRepository().UpdateCategory(id, mappeditem);
                if (entity == null) { return BadRequest("Model Can't be null"); }
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex);
            }
        }

        //Program to delete Category
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id < 1) { return BadRequest("id cant be 0 or negative"); }


                var res = _categoryRepo.GetById(id).FirstOrDefault();
                if (res != null)
                {
                    _categoryRepo.Delete(res);
                }
                else
                {
                    return NotFound();
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
