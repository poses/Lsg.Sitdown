using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using Lsg.Sitdown.Models;

namespace Lsg.Sitdown.Controllers
{
    public class DailyEntryController : ApiController
    {
        private readonly SitdownContext _db = new SitdownContext();

        // GET api/DailyEntry
        public IEnumerable<DailyEntry> GetDailyEntries()
        {
            var entries = _db.DailyEntries.AsEnumerable();
            return entries;
        }

        // GET api/DailyEntry?limit=10
        public IEnumerable<DailyEntry> GetDailyEntries(int limit)
        {
            return _db.DailyEntries.Take(limit);
        }

        // GET api/DailyEntry/5
        public DailyEntry GetDailyEntry(int id)
        {
            DailyEntry dailyEntry = _db.DailyEntries.Find(id);
            if (dailyEntry == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }

            return dailyEntry;
        }

        // PUT api/DailyEntry/5
        public HttpResponseMessage PutDailyEntry(int id, DailyEntry dailyEntry)
        {
            if (ModelState.IsValid && id == dailyEntry.Id)
            {
                _db.Entry(dailyEntry).State = EntityState.Modified;

                try
                {
                    _db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }

                return Request.CreateResponse(HttpStatusCode.OK, dailyEntry);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // POST api/DailyEntry
        public HttpResponseMessage PostDailyEntry(DailyEntry dailyEntry)
        {
            if (ModelState.IsValid)
            {
                _db.DailyEntries.Add(dailyEntry);
                _db.SaveChanges();

                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, dailyEntry);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = dailyEntry.Id }));
                return response;
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        // DELETE api/DailyEntry/5
        public HttpResponseMessage DeleteDailyEntry(int id)
        {
            DailyEntry dailyentry = _db.DailyEntries.Find(id);
            if (dailyentry == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            _db.DailyEntries.Remove(dailyentry);

            try
            {
                _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }

            return Request.CreateResponse(HttpStatusCode.OK, dailyentry);
        }

        protected override void Dispose(bool disposing)
        {
            _db.Dispose();
            base.Dispose(disposing);
        }
    }
}