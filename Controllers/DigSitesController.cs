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
using WebApiHarjoitusTyo.Models;

namespace WebApiHarjoitusTyo.Controllers
{
    public class DigSitesController : ApiController
    {
        private WebApiHarjoitusTyoContext db = new WebApiHarjoitusTyoContext();

        // GET: api/DigSites
        public IQueryable<DigSite> GetDigSites()
        {
            return db.DigSites;
        }

        // GET: api/DigSites/5
        [ResponseType(typeof(DigSite))]
        public async Task<IHttpActionResult> GetDigSite(int id)
        {
            DigSite digSite = await db.DigSites.FindAsync(id);
            if (digSite == null)
            {
                return NotFound();
            }

            return Ok(digSite);
        }

        // PUT: api/DigSites/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutDigSite(int id, DigSite digSite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != digSite.Id)
            {
                return BadRequest();
            }

            db.Entry(digSite).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DigSiteExists(id))
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

        // POST: api/DigSites
        [ResponseType(typeof(DigSite))]
        public async Task<IHttpActionResult> PostDigSite(DigSite digSite)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DigSites.Add(digSite);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = digSite.Id }, digSite);
        }

        // DELETE: api/DigSites/5
        [ResponseType(typeof(DigSite))]
        public async Task<IHttpActionResult> DeleteDigSite(int id)
        {
            DigSite digSite = await db.DigSites.FindAsync(id);
            if (digSite == null)
            {
                return NotFound();
            }

            db.DigSites.Remove(digSite);
            await db.SaveChangesAsync();

            return Ok(digSite);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DigSiteExists(int id)
        {
            return db.DigSites.Count(e => e.Id == id) > 0;
        }
    }
}