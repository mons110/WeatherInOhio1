using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WeatherInOhio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComContr : Controller
    {
        InternetShopContext db = new InternetShopContext();
        private readonly ILogger<BDController> _logger;

        public ComContr(ILogger<BDController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{id}")]
        public IActionResult GetName([Required] int Id)
        {
            return Ok(db.Comments.Where(p => p.GoodId== Id).ToList());
        }

        [HttpPost]
        public IActionResult Post([Required] int UserId, [Required] int GId, [Required] int Rate, int Sod
             )
        {
            try
            {
                Comment NewGood = new Comment();
                NewGood.UserId = UserId;
                NewGood.GoodId = GId;
                NewGood.Rate = Rate;
                NewGood.Comment1 = Sod;
                db.Comments.Add(NewGood);
                db.SaveChanges();
                return Ok();
            }
            catch (Exception ex) { return BadRequest("Ошибка при добавлении"); }
        }

        [HttpPut]
        public IActionResult Put([Required] int UsID, [Required] int Id, int Rate = 0, int Desc = 0)
        {
            try
            {
                Comment? NewGood = db.Comments.Where(p => p.UserId == UsID).Select(p => p).FirstOrDefault();
                NewGood.GoodId = Id == 0 ? NewGood.GoodId : Id;
                NewGood.Rate = Rate == 0 ? NewGood.Rate : Rate;
                NewGood.Comment1 = Desc == 0 ? NewGood.Comment1 : Desc;
                db.Comments.Update(NewGood);
                db.SaveChanges();
                return Ok();
            }
            catch { return BadRequest("Ошибка при изменении"); }
        }
        [HttpDelete]
        public IActionResult Delete([Required] int Id, [Required] int Gid)
        {
            try
            {
                db.Remove(db.Comments.Where(p => p.GoodId == Gid).Single(a => a.UserId == Id));
                db.SaveChanges();
                return Ok();
            }
            catch { return BadRequest("Ошибка при удалении"); }
        }
    }
}
