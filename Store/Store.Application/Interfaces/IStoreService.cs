using Store.Application.DTOs.Store;
using Store.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Store.Application.Interfaces
{
    public interface IStoreService
    {
        Task<Response<StoreResponse>> GetStoreDetails(string role);
        Task<Response<CalculateResponse>> CalculateTotal(StoreRequest storeRequest, string role);
    }
}
