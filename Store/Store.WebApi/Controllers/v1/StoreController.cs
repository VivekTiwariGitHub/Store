using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Store.Application.DTOs.Store;
using Store.Application.Enums;
using Store.Application.Exceptions;
using Store.Application.Interfaces;
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
        private readonly IStoreService _storeService;
        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            var role = HttpContext.User.FindFirst(ClaimTypes.Role).Value;
            return Ok(await _storeService.GetStoreDetails(role));
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Post(StoreRequest storeRequest)
        {
            var role = HttpContext.User.FindFirst(ClaimTypes.Role).Value;
            return Ok(await _storeService.CalculateTotal(storeRequest, role));
        }
    }
}
