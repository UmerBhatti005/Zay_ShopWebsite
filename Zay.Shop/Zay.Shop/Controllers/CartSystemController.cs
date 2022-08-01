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
    public class CartSystemController : ControllerBase
    {
        private readonly IGenericRepository<CartSystem> _cartRepo;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IGenericRepository<Colors> _colorRepo;
        private readonly IGenericRepository<ProductSize> _productSizeRpo;
        private readonly IShopCatalogRepository _shopCatalogRepository;
        private readonly IGenericRepository<Report> _reportRepo;

        public CartSystemController(IGenericRepository<CartSystem> cartRepo, UserManager<ApplicationUser> userManager, IGenericRepository<Colors> colorRepo,
            IGenericRepository<ProductSize> productSizeRpo, IShopCatalogRepository shopCatalogRepository, IGenericRepository<Report> reportRepo)
        {
            _cartRepo = cartRepo;
            _userManager = userManager;
            _colorRepo = colorRepo;
            _productSizeRpo = productSizeRpo;
            _shopCatalogRepository = shopCatalogRepository;
            _reportRepo = reportRepo;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var models = _cartRepo.GetAll().Include(x => x.productSize).Include(x => x.colors).Include(x => x.report).Include(x => x.applicationUser).ToList().ToModelList();
                if (models == null) { return BadRequest("model cant be null"); }
                return Ok(models);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                if (id < 1) { return BadRequest("Id cant be negative or zero or null"); }
                var model = _cartRepo.GetById(id).Include(x => x.productSize).Include(x => x.colors).Include(x => x.report).Where(x => x.Id == id).ToList().ToModelList();
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("/FromUser/{username}")]
        public IActionResult GetByUsername(string username)
        {
            try
            {
                //bool active = Convert.ToBoolean(Request.Query["active"]);
                //if (active)
                //{
                //    var models = _shopCatalogRepository.GetCartSystemC(3).ToModelList();
                //    return Ok(models);
                //}
                var model = _cartRepo.GetByUsername(username).Include(x => x.productSize).Include(x => x.colors).Include(x => x.report).Include(x => x.applicationUser).Where(x => x.applicationUser.UserName == username).Where(x => x.report.Id != 3).ToList().ToModelList();
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public IActionResult Post(CartSystemModel model)
        {
            try
            {
                var dept = _userManager.Users.Where(d => d.UserName == model.Username).FirstOrDefault();
                var color = _colorRepo.GetByUsername(model.colors.Name).Where(d => d.Name == model.colors.Name).FirstOrDefault();
                var size = _productSizeRpo.GetByUsername(model.productSize.Name).Where(d => d.Name == model.productSize.Name).FirstOrDefault();
                var report =  _reportRepo.GetById(model.report.Id).Where(d => d.Id == model.report.Id).FirstOrDefault();
                var entity = _cartRepo.Insert(model.ToEntity(dept, color, size, report));
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public IActionResult Put(CartSystemModel model)
        {
            try
            {
                var dept = _userManager.Users.Where(d => d.Id == model.Username).FirstOrDefault();
                var color = _colorRepo.GetByUsername(model.colors.Name).Where(d => d.Name == model.colors.Name).FirstOrDefault();
                var size = _productSizeRpo.GetByUsername(model.productSize.Name).Where(d => d.Name == model.productSize.Name).FirstOrDefault();
                var report = _reportRepo.GetById(model.report.Id).Where(d => d.Id == model.report.Id).FirstOrDefault();
                var entity = _cartRepo.Update(model.ToEntity(dept, color, size, report));
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id < 1) { return BadRequest("id cant be null or zero or negative"); }
                var obj = _cartRepo.GetById(id).Include(x => x.productSize).Include(x => x.colors).Where(x => x.Id == id).FirstOrDefault();
                if (obj != null)
                {
                    _cartRepo.Delete(obj);
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
