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
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using Formula1ServiceSample.Models;

namespace Formula1ServiceSample.Controllers
{
    /*
    To add a route for this controller, merge these statements into the Register method of the WebApiConfig class. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using Formula1ServiceSample.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Racer>("Racer");
    builder.EntitySet<RaceResult>("RaceResult"); 
    config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
    */
    public class RacerController : ODataController
    {
        private Formula1Entities db = new Formula1Entities();

        // GET odata/Racer
        [Queryable]
        public IQueryable<Racer> GetRacer()
        {
            return db.Racers;
        }

        // GET odata/Racer(5)
        [Queryable]
        public SingleResult<Racer> GetRacer([FromODataUri] int key)
        {
            return SingleResult.Create(db.Racers.Where(racer => racer.Id == key));
        }

        // PUT odata/Racer(5)
        public async Task<IHttpActionResult> Put([FromODataUri] int key, Racer racer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != racer.Id)
            {
                return BadRequest();
            }

            db.Entry(racer).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RacerExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(racer);
        }

        // POST odata/Racer
        public async Task<IHttpActionResult> Post(Racer racer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Racers.Add(racer);
            await db.SaveChangesAsync();

            return Created(racer);
        }

        // PATCH odata/Racer(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public async Task<IHttpActionResult> Patch([FromODataUri] int key, Delta<Racer> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Racer racer = await db.Racers.FindAsync(key);
            if (racer == null)
            {
                return NotFound();
            }

            patch.Patch(racer);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RacerExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(racer);
        }

        // DELETE odata/Racer(5)
        public async Task<IHttpActionResult> Delete([FromODataUri] int key)
        {
            Racer racer = await db.Racers.FindAsync(key);
            if (racer == null)
            {
                return NotFound();
            }

            db.Racers.Remove(racer);
            await db.SaveChangesAsync();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET odata/Racer(5)/RaceResults
        [Queryable]
        public IQueryable<RaceResult> GetRaceResults([FromODataUri] int key)
        {
            return db.Racers.Where(m => m.Id == key).SelectMany(m => m.RaceResults);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RacerExists(int key)
        {
            return db.Racers.Count(e => e.Id == key) > 0;
        }
    }
}
