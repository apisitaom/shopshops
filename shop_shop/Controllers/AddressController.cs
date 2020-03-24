using shop_shop.Models;
using shop_shop.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace shop_shop.Controllers
{
    [Route("address")]
    [ApiController]
    public class AddressController
    {
        private readonly AddressService _addressService;

        public AddressController(AddressService addressService) 
        {
            _addressService = addressService;
        }
        [HttpGet("lists")]
        public ActionResult<List<Address>> Get() =>
            _addressService.Alladdress();
        [HttpPost("add")]
        public ActionResult<Address> Create(Address address)
        {
            _addressService.Create(address);

            return address;
        }
    }
}
