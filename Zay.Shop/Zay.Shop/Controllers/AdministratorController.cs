using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Zay.Shop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AdministratorController : ControllerBase
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public AdministratorController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]

        public IActionResult GetAll()
        {
            try
            {
                var roles = _roleManager.Roles.Take(2);
                return Ok(roles);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            try
            {

                var result = await _roleManager.CreateAsync(new IdentityRole { Name = name });
                //if (string.IsNullOrEmpty(Convert.ToString(result)))
                return Ok(name);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
