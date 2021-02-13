using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.Application.Enums;
using Store.Application.Exceptions;
using Store.Domain.Entities;
using Store.Infrastructure.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Store.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class StoreController : BaseApiController
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public StoreController(UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            var role = HttpContext.User.FindFirst(ClaimTypes.Role).Value;
            return Ok(role == Roles.Privileged.ToString() ? new PrivilegedProduct() : new Product());
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(PrivilegedProduct product)
        {
            if (product.Discount > 0)
            {
                var role = HttpContext.User.FindFirst(ClaimTypes.Role).Value;
               if(role != Roles.Privileged.ToString())
                {
                    throw new ApiException("Not a privileged customer to get discount");
                }
            }

            return Ok();
        }


    }
}
