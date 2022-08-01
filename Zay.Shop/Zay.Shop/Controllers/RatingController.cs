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
    public class RatingController : ControllerBase
    {
        private readonly IGenericRepository<Rate> _ratingRepo;
        private readonly UserManager<ApplicationUser> _userManager;

        public RatingController(IGenericRepository<Rate> ratingRepo, UserManager<ApplicationUser> userManager)
        {
            _ratingRepo = ratingRepo;
            _userManager = userManager;
        }

        [HttpGet]

        public IActionResult Get()
        {
            try
            {
                var model = _ratingRepo.GetAll().Include(x => x.products).ToList().ToModelList();
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]

        public IActionResult Post(RateModel model)
        {
            try
            {
                var dept = _userManager.Users.Where(d => d.UserName == model.products.Username).FirstOrDefault();
                //var username = model.products.Username;
                var entity = _ratingRepo.Insert(model.ToEntity());
                return Ok(entity);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}
