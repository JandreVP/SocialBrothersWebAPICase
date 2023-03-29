using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SocialBrothersWebAPICase.Models;
using System.Collections.Generic;
using System.Linq;

namespace SocialBrothersWebAPICase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilterAscending : ControllerBase
    {
        private readonly AddressesContext _context;
        public FilterAscending(AddressesContext Context)
        {
            _context = Context;
        }

        //Get the users in Ascending order(Alphabetically)
        [HttpGet("name_")]
        public IActionResult GetItemsDescending()
        {
            var items = _context.Address.OrderBy(i => i.Name_).ToList();
            return Ok(items);
        }
    }
}
