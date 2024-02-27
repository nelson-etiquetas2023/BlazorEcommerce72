using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Orders.Backend.Data;
using Orders.Shared;
using Orders.Shared.Entities;

namespace Orders.Backend.Controllers
{
    [ApiController]
    [Route("api/[Controller]")]

    public class CountriesController : ControllerBase
    {
        private readonly DataContext _context;
        public CountriesController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<IActionResult> GetAsync() 
        {
            return Ok(await _context.Countries.ToListAsync());
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetAsync(int id) 
        {
            var country = await _context.Countries.FindAsync(id);
            if ( country == null) 
            {
                return NotFound();
            }
            return Ok(country);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(Country country) 
        {
            _context.Countries.Add(country);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> PutAsync(Country country) 
        { 
            _context.Update(country);
            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> DeleteAsync(int id) 
        {
            var countryDelete = await _context.Countries.FindAsync(id);
            if (countryDelete == null) 
            {
                return NotFound();
            }
            _context.Countries.Remove(countryDelete);
            await _context.SaveChangesAsync();
            return NoContent();
        }


    }
}
