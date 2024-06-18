using AdminEntryApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AdminEntryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryApiController : ControllerBase
    {
        private readonly MedicineContext context;

        public CountryApiController(MedicineContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Country>>> GetCountry()

        { 
           var data = await context.Countries.ToListAsync(); 
            return Ok(data);    
        }
        [HttpPost]
        public async Task<ActionResult<List<Country>>> CreateCountry(Country country)

        {
            await context.Countries.AddAsync(country);  
            await context.SaveChangesAsync();   
            return Ok(country); 
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Country>>> UpdateCountry(int id, Country country)

        {
            if(id !=country.Countryid) 
            {
                return BadRequest();
            }
            context.Entry(country).State = EntityState.Modified;    
            await context.SaveChangesAsync();   
            return Ok(country); 
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Country>>> DeleteCountry(int id)

        {
            var country = await context.Countries.FindAsync(id);    
            if (country == null)
            {
                return NotFound();
            }
            context.Countries.Remove(country);  
            await context.SaveChangesAsync();
            return Ok(country); 
        }

    }
}
