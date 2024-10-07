using Store.Repository.Basket.Models;
using Store.Services.Services.BasketService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Services.Services.BasketService
{
    public interface IBasketService
    {
        Task<CustomerBasketDto> GetBasketAsync(string basketId);
        Task<CustomerBasketDto> UpdateBasketAsync(CustomerBasketDto basket);
        Task<bool> DeleteBasketAsync(string basketId);
    }
}
