using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotasApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotasController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<Models.Nota> Get()
        {
            using (var db = new Models.notasDBContext())
            {
                IEnumerable<Models.Nota> notas = db.Notas.ToList();
                return notas;
            }
        }

        [HttpGet("{id}")]
        public IEnumerable<Models.Nota> Get(int id)
        {
            using (var db = new Models.notasDBContext())
            {
                IEnumerable<Models.Nota> notas = db.Notas.Where(s => s.Id == id).ToList();
                return notas;
            }
        }

        [HttpPost]
        public void Post(string titulo, DateTime fecha, string detalle)
        {            
            using (var db = new Models.notasDBContext())
            {
                var nota = new Models.Nota { Titulo = titulo, Fecha = fecha, Detalle = detalle };
                db.Notas.Add(nota);
                db.SaveChanges();
            }            
        }

        [HttpPut("{id}")]
        public void Put(int id, string titulo, DateTime fecha, string detalle)
        {
            using (var db = new Models.notasDBContext())
            {
                var notas = db.Notas.Find(id);
                notas.Titulo = titulo;                
                notas.Fecha = fecha;
                notas.Detalle = detalle;
                db.SaveChanges();
            }
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            using (var db = new Models.notasDBContext())
            {
                db.Notas.Remove(db.Notas.Find(id));                
                db.SaveChanges();
            }
        }
    }
}
