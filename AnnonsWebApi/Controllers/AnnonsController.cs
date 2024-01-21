using AnnonsWebApi.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AnnonsWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnonsController : ControllerBase
    {
        private readonly DataContext _context;

        public AnnonsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Annons>>> Get()
        {
            return Ok(await _context.Annonser.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Annons>> Get(int id)
        {
            var hero = await _context.Annonser.FindAsync(id);
            if (hero == null)
                return BadRequest("Hero not found.");
            return Ok(hero);
        }

        [HttpPost]
        public async Task<ActionResult<List<Annons>>> AddHero(Annons annons)
        {
            _context.Annonser.Add(annons);
            await _context.SaveChangesAsync();

            return Ok(await _context.Annonser.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Annons>>> UpdateHero(Annons request)
        {
            var dbHero = await _context.Annonser.FindAsync(request.Id);
            if (dbHero == null)
                return BadRequest("Hero not found.");

            dbHero.Id = request.Id;
            dbHero.CompanyName = request.CompanyName;
            dbHero.Title = request.Title;
            dbHero.Description = request.Description;

            await _context.SaveChangesAsync();

            return Ok(await _context.Annonser.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Annons>>> Delete(int id)
        {
            var dbHero = await _context.Annonser.FindAsync(id);
            if (dbHero == null)
                return BadRequest("Hero not found.");

            _context.Annonser.Remove(dbHero);
            await _context.SaveChangesAsync();

            return Ok(await _context.Annonser.ToListAsync());
        }




    }
}
