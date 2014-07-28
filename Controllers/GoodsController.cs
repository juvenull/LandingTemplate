using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using LandingTemplate.Models;

namespace LandingTemplate.Controllers
{
    public class GoodsController : ApiController
    {
        private LandingTemplateContext db = new LandingTemplateContext();

        // GET api/Goods
        public IQueryable<GoodDTO> GetGoods()
        {
            var goods = from g in db.Goods
                        select new GoodDTO
                        {
                            Id = g.Id,
                            Title = g.Title,
                            Price = g.Price,
                            Amount = g.Amount,
                            UrlImage = g.UrlImage,
                            PriceOld = g.PriceOld,
                            IsHit = g.IsHit
                        };
            return goods;
        }

        // GET api/Goods/5
        [ResponseType(typeof(GoodDTO))]
        public async Task<IHttpActionResult> GetGood(int id)
        {
            var good = await db.Goods.Select(g => new GoodDTO
            {
                Id = g.Id,
                Title = g.Title,
                Price = g.Price,
                Amount = g.Amount,
                UrlImage = g.UrlImage,
                PriceOld = g.PriceOld,
                IsHit = g.IsHit

            }).SingleOrDefaultAsync(g => g.Id == id);
            if (good == null)
            {
                return NotFound();
            }

            return Ok(good);
        }

        // PUT api/Goods/5
        public async Task<IHttpActionResult> PutGood(int id, Good good)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != good.Id)
            {
                return BadRequest();
            }

            db.Entry(good).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GoodExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Goods
        [ResponseType(typeof(Good))]
        public async Task<IHttpActionResult> PostGood(Good good)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Goods.Add(good);
            await db.SaveChangesAsync();

            // New code:
            // Load author name
            //db.Entry(good).Reference(x => x.).Load();

            var dto = new GoodDTO()
            {
                Id = good.Id,
                Title = good.Title,
                Price = good.Price,
                Amount = good.Amount,
                UrlImage = good.UrlImage,
                PriceOld = good.PriceOld,
                IsHit = good.IsHit
            };

            return CreatedAtRoute("DefaultApi", new { id = good.Id }, good);
        }

        // DELETE api/Goods/5
        [ResponseType(typeof(Good))]
        public async Task<IHttpActionResult> DeleteGood(int id)
        {
            Good good = await db.Goods.FindAsync(id);
            if (good == null)
            {
                return NotFound();
            }

            db.Goods.Remove(good);
            await db.SaveChangesAsync();

            return Ok(good);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GoodExists(int id)
        {
            return db.Goods.Count(e => e.Id == id) > 0;
        }
    }
}