﻿using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace WeatherInOhio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BDController : Controller
    {

        private readonly InternetShopContext db;
        public BDController(InternetShopContext db1)
        {
            db = db1;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(
                from T in db.Tovaris
                join S in db.Sklads on T.Id equals S.Idtovara
                select new { Id = T.Id, Title = T.Title, Price = T.Price, Amount = S.Amount }
                );
        }
        [HttpGet("{Title}")]
        public IActionResult GetName([Required] string Title)
        {
            return Ok(db.Tovaris.Where(p => p.Title.ToLower().Contains(Title.ToLower())).Select(p => p).ToList());
        }

        [HttpPost]
        public IActionResult Post([Required] int Id, [Required] string Title, [Required] decimal Price,
             string Desc = "")
        {
            try
            {
                Tovari NewGood = new Tovari();
                NewGood.Id = Id;
                NewGood.Title = Title;
                NewGood.Price = Price;
                NewGood.Descryption = Desc;
                db.Tovaris.Add(NewGood);
                db.SaveChanges();
                return Ok();
            }
            catch (Exception ex) { return BadRequest("Ошибка при добавлении"); }
        }

        [HttpPut]
        public IActionResult Put([Required] int Id, string Title = "", decimal Price = 0, string Desc = "")
        {
            try
            {
                Tovari? NewGood = db.Tovaris.Where(p => p.Id == Id).Select(p => p).FirstOrDefault();
                NewGood.Title = Title == "" ? NewGood.Title : Title;
                NewGood.Price = Price == 0 ? NewGood.Price : Price;
                NewGood.Descryption = Desc == "" ? NewGood.Descryption : Desc;
                db.Tovaris.Update(NewGood);
                db.SaveChanges();
                return Ok();
            }
            catch { return BadRequest("Ошибка при изменении"); }
        }
        [HttpDelete]
        public IActionResult Delete([Required] int Id)
        {
            try
            {
                db.Remove(db.Tovaris.Single(a => a.Id == Id));
                db.SaveChanges();
                return Ok();
            }
            catch { return BadRequest("Ошибка при удалении"); }
        }
    }
}
