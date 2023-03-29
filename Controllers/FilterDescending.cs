using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SocialBrothersWebAPICase.Models;
using System.Collections.Generic;
using System.Linq;

namespace SocialBrothersWebAPICase.Controllers
{

    [Route("api/[controller]")]
    public class FilterDescending : ControllerBase
    {
        private readonly AddressesContext _context;
        public FilterDescending(AddressesContext Context)
        {
            _context = Context;
        }
        //get the users in descending order (Alphabetically)
        [HttpGet("name_")]
        public IActionResult GetItemsDescending()
        {
            var items = _context.Address.OrderByDescending(i => i.Name_).ToList();
            return Ok(items);
        }
    }
}
