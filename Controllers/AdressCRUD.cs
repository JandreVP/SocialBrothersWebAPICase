
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SocialBrothersWebAPICase.Models;
using System.Collections.Generic;
using System.Linq;

namespace SocialBrothersWebAPICase.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AdressCRUD : ControllerBase
    {

        private readonly AddressesContext _context;

        public AdressCRUD(AddressesContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<address>>> GetAddresses()
        {
            if (_context.Address == null)
            {
                return NotFound();

            }
            return await _context.Address.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<address>> GetAddress(int id)
        {
            if (_context.Address == null)
            {
                return NotFound();

            }
            var address = await _context.Address.FindAsync(id);
            if (address == null)
            {
                return NotFound();

            }
            return address;

        }


        [HttpPost]

        public async Task<ActionResult<address>> PostAddress(address Address)
        {
            _context.Address.Add(Address);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAddress), new { id = Address.ID }, Address);
        }

        //Edit data
        [HttpPut]
        public async Task<IActionResult> PutAddress(int id, address Address)
        {
            if (id != Address.ID)
            {
                return BadRequest();
            }
            _context.Entry(Address).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!addressAvailable(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }
            return Ok();


        }

        private bool addressAvailable(int id)
        {
            return (_context.Address?.Any(a => a.ID == id)).GetValueOrDefault();
        }


        //Delete data by ID
        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteAddress(int id)
        {
            if (_context.Address == null)
            {
                return NotFound();

            }

            var address = _context.Address.FindAsync(id);
            if (address == null)
            {
                return NotFound();

            }

            _context.Address.Remove(await address);
            await _context.SaveChangesAsync();

            return Ok();
        }

    }
}
