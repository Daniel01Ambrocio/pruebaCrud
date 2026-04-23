using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using apiEmpresa.Models;

namespace apiEmpresa.Controllers
{
    public class EmpleadosRolesController : ApiController
    {
        private ModelEmpresa db = new ModelEmpresa();

        // GET: api/EmpleadosRoles
        public IQueryable<EmpleadosRoles> GetEmpleadosRoles()
        {
            return db.EmpleadosRoles;
        }

        // GET: api/EmpleadosRoles/5
        [ResponseType(typeof(EmpleadosRoles))]
        public IHttpActionResult GetEmpleadosRoles(int id)
        {
            EmpleadosRoles empleadosRoles = db.EmpleadosRoles.Find(id);
            if (empleadosRoles == null)
            {
                return NotFound();
            }

            return Ok(empleadosRoles);
        }

        // PUT: api/EmpleadosRoles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutEmpleadosRoles(int id, EmpleadosRoles empleadosRoles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != empleadosRoles.IDEmpleadoRol)
            {
                return BadRequest();
            }

            db.Entry(empleadosRoles).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpleadosRolesExists(id))
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

        // POST: api/EmpleadosRoles
        [ResponseType(typeof(EmpleadosRoles))]
        public IHttpActionResult PostEmpleadosRoles(EmpleadosRoles empleadosRoles)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.EmpleadosRoles.Add(empleadosRoles);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = empleadosRoles.IDEmpleadoRol }, empleadosRoles);
        }

        // DELETE: api/EmpleadosRoles/5
        [ResponseType(typeof(EmpleadosRoles))]
        public IHttpActionResult DeleteEmpleadosRoles(int id)
        {
            EmpleadosRoles empleadosRoles = db.EmpleadosRoles.Find(id);
            if (empleadosRoles == null)
            {
                return NotFound();
            }

            db.EmpleadosRoles.Remove(empleadosRoles);
            db.SaveChanges();

            return Ok(empleadosRoles);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmpleadosRolesExists(int id)
        {
            return db.EmpleadosRoles.Count(e => e.IDEmpleadoRol == id) > 0;
        }
    }
}