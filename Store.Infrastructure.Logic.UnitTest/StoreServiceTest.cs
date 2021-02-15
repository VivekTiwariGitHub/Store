using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Identity;
using Moq;
using Store.Application.Constants;
using Store.Application.DTOs.Store;
using Store.Application.Enums;
using Store.Application.Exceptions;
using Store.Infrastructure.Identity.Models;
using Store.Infrastructure.Identity.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Store.Infrastructure.Logic.UnitTest
{
    public class StoreServiceTest
    {
        private readonly StoreService _storeService;
        //private readonly Mock<UserManager<ApplicationUser>> _userManagerMock = new Mock<UserManager<ApplicationUser>>();



        public StoreServiceTest()
        {
            _storeService = new StoreService();
        }

        [Theory]
        [ClassData(typeof(CalculateData))]
        public async Task CalculateTotal_ShouldEqualTotal_Theory(double expectedTotal,
                            StoreRequest storeRequest, string role)
        {
            var output = await _storeService.CalculateTotal(storeRequest, role);
            Assert.Equal(expectedTotal, output.Data.Total);
        }

        [Theory]
        [ClassData(typeof(CalculateExceptionData))]
        public async Task CalculateTotal_Error_Theory(string Expected,
                    StoreRequest storeRequest, string role)
        {
            try
            {
                var output = await _storeService.CalculateTotal(storeRequest, role);
            }
            catch (ApiException ex)
            {
                Assert.Equal(Expected, ex.Message);
            }
            
        }

        [Theory]
        [InlineData(0, "Normal")]
        [InlineData(2, "Privileged")]
        public async Task GetStore_ShouldEqualDiscount_Theory(int expected, string role)
        {
            var output = await _storeService.GetStoreDetails(role);
            Assert.Equal(expected, output.Data.Discount);
        }


        public class CalculateData : IEnumerable<object[]>
        {
            private readonly List<object[]> _data = new List<object[]>
            {
                new object[] {
                    190,
                    new StoreRequest
                    {
                        Price = 100,
                        Weigth = 2,
                        Discount = 5
                    },
                    Roles.Privileged.ToString()
                },
                new object[] {
                    237.5,
                    new StoreRequest
                    {
                        Price = 25,
                        Weigth = 10,
                        Discount = 5
                    },
                    Roles.Privileged.ToString()
                }
            };

            public IEnumerator<object[]> GetEnumerator()
            {
                return _data.GetEnumerator();
            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        public class CalculateExceptionData : IEnumerable<object[]>
        {
            private readonly List<object[]> _data = new List<object[]>
            {
                new object[] {
                    ErrorMessages.RoleCanNotBeEmpty,
                    new StoreRequest
                    {
                        Price = 100,
                        Weigth = 2,
                        Discount = 5
                    },
                    ""
                },
                new object[] {
                    ErrorMessages.NotAPrivilegedCustomer,
                    new StoreRequest
                    {
                        Price = 25,
                        Weigth = 10,
                        Discount = 5
                    },
                    Roles.Normal.ToString()
                },
                new object[] {
                    ErrorMessages.WeightCanNotBeZero,
                    new StoreRequest
                    {
                        Price = 0,
                        Weigth = 0,
                        Discount = 5
                    },
                    Roles.Privileged.ToString()
                }
                ,
                new object[] {
                    ErrorMessages.DiscountCanNotBe100,
                    new StoreRequest
                    {
                        Price = 22,
                        Weigth = 21,
                        Discount = 100
                    },
                    Roles.Privileged.ToString()
                }
            };

            public IEnumerator<object[]> GetEnumerator()
            {
                return _data.GetEnumerator();
            }
            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }
    }
}
