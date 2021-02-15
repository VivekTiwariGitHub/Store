using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Ocsp;
using Store.Application.Constants;
using Store.Application.DTOs.Account;
using Store.Application.DTOs.Store;
using Store.Application.Enums;
using Store.Application.Exceptions;
using Store.Application.Interfaces;
using Store.Application.Wrappers;
using Store.Domain.Settings;
using Store.Infrastructure.Identity.Helpers;
using Store.Infrastructure.Identity.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.Cache;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastructure.Identity.Services
{
    public class StoreService : IStoreService
    {
        public async Task<Response<CalculateResponse>> CalculateTotal(StoreRequest storeRequest, string role)
        {
            if (string.IsNullOrEmpty(role))
            {
                throw new ApiException(ErrorMessages.RoleCanNotBeEmpty);
            }

            if (storeRequest.Weigth <= 0 || storeRequest.Price <= 0)
            {
                throw new ApiException(ErrorMessages.WeightCanNotBeZero);
            }

            if (storeRequest.Discount > 100)
            {
                throw new ApiException(ErrorMessages.DiscountCanNotBe100);
            }

            if (storeRequest.Discount > 0 && role != Roles.Privileged.ToString())
            {
                throw new ApiException(ErrorMessages.NotAPrivilegedCustomer);
            }

            CalculateResponse calculateResponse = new CalculateResponse();
            // use automapper to map the objects here.
            calculateResponse.Price = storeRequest.Price;
            calculateResponse.Weigth = storeRequest.Weigth;
            calculateResponse.Discount = storeRequest.Discount;
            int totalAmount = storeRequest.Price * storeRequest.Weigth;

            calculateResponse.Total = totalAmount - (double)(totalAmount * storeRequest.Discount) / 100;
            return new Response<CalculateResponse>(calculateResponse);
        }

        public async Task<Response<StoreResponse>> GetStoreDetails(string role)
        {
            if (string.IsNullOrEmpty(role))
            {
                throw new ApiException("Users role can not be empty");
            }

            StoreResponse storeResponse = new StoreResponse();
            if (role == Roles.Privileged.ToString())
            {
                storeResponse.Discount = 2;
            }

            return new Response<StoreResponse>(storeResponse);
        }
    }

}
