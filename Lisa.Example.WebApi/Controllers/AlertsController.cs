using System.Collections.Generic;
using System.Data.Entity;
using System.Net;
using System.Web.Http;
using Lisa.Example.WebApi.Models;

namespace Lisa.Example.WebApi.Controllers
{
    public class AlertsController : ApiController
    {
        private readonly AlertContext _db = new AlertContext();

        public IEnumerable<Alert> Get()
        {
            return _db.Alerts;
        }

        public IHttpActionResult Get(int id)
        {
            var alert = _db.Alerts.Find(id);
            if (alert == null)
            {
                return NotFound();
            }

            return Ok(alert);
        }

        public IHttpActionResult Put(int id, Alert alert)
        {
            if (id != alert.Id)
            {
                return BadRequest();
            }

            _db.Entry(alert).State = EntityState.Modified;
            _db.SaveChanges();


            return StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult Post(Alert alert)
        {
            _db.Alerts.Add(alert);
            _db.SaveChanges();

            return CreatedAtRoute("Api", new {id = alert.Id}, alert);
        }

        public IHttpActionResult Delete(int id)
        {
            var alert = _db.Alerts.Find(id);
            if (alert == null)
            {
                return NotFound();
            }

            _db.Alerts.Remove(alert);
            _db.SaveChanges();

            return Ok(alert);
        }
    }
}