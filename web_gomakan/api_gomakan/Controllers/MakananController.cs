using System.Linq;
using api_gomakan.Data;
using libs_gomakan.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api_gomakan.Controllers
{
    [ApiController]
    [Route("makanan")]
    public class MakananController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<MakananController> _logger;

        public MakananController(ILogger<MakananController> logger, ApplicationDbContext db)
        {
            _logger = logger;
            _db = db;
        }

        [HttpGet]
        [Route("get/{id}")]
        public IActionResult Get(int id)
        {
            Makanan data = _db.Makanans.
                Where(p =>p.IsActive == true).
                Where(p => p.Id == id).
                FirstOrDefault();
            return Ok(data);
        }

        [HttpGet]
        [Route("list")]
        public IActionResult List(string keyword, int limit = 5, int offset = 0)
        {
            IQueryable<Makanan> query = _db.Makanans.Where(p => p.IsActive == true);

            if (!string.IsNullOrEmpty(keyword))
                query = query.Where(p =>
                    p.Name.ToLower().Contains(keyword.ToLower()) ||
                    p.Description.ToLower().Contains(keyword.ToLower()));
            
            query = query.Skip(offset).Take(limit);
            
            return Ok(query);
        }

    }
}