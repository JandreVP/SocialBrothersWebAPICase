using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SocialBrothersWebAPICase.Models;
using System.Collections.Generic;
using System.Linq;

namespace SocialBrothersWebAPICase.Controllers
{
    public class SearchByName : ControllerBase
    {
        private readonly AddressesContext _context;
        public SearchByName(AddressesContext Context)
        {
            _context = Context;
        }
        //This is where you can search for a name or just a part of the name to retrieve their information
        [HttpGet("name_")]
        public IActionResult GetItemsBySearch(string search)
        {
            var search_ = _context.Address.Where(i => i.Name_.Contains(search)).ToList();
            return Ok(search_);
        }
    }
}
