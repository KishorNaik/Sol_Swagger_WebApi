using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Sol_Demo.Models;

namespace Sol_Demo.Controllers
{
    [Produces("application/json")]
    [Route("api/customer")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        #region Private Methods

        private Task<IEnumerable<CustomerModel>> GetCustomerAsync()
        {
            return Task.Run<IEnumerable<CustomerModel>>(() =>
            {
                var customerList = new List<CustomerModel>();
                customerList.Add(new CustomerModel()
                {
                    FullName = "Kishor Naik",
                    EmailId = "kishor.naik011.net@gmail.com",
                    MobileNo = "9111111111"
                });
                customerList.Add(new CustomerModel()
                {
                    FullName = "Eshaan Naik",
                    EmailId = "eshaan@gmail.com",
                    MobileNo = "9222222222"
                });

                return customerList;
            });
        }

        #endregion Private Methods

        #region End Point (Demo)

        /// <summary>
        ///  Get list of Customer
        /// </summary>
        /// <returns>Array</returns>
        [HttpGet("getcustomer")]
        public async Task<IActionResult> GetCustomerData()
        {
            return base.Ok(await this.GetCustomerAsync());
        }

        /// <summary>
        /// Add new Customer
        /// </summary>
        /// <param name="customerModel">Define model of customer</param>
        /// <returns>bool</returns>
        [HttpPost("add")]
        public IActionResult AddCustomer([FromBody] CustomerModel customerModel)
        {
            return base.Ok(true);
        }

        #endregion End Point (Demo)
    }
}