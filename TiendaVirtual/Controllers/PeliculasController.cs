using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TiendaVirtual;
using TiendaVirtual.Models;

namespace TiendaVirtual.Controllers
{
    public class PeliculasController : Controller
    {
        private TiendaVirtualDBE db = new TiendaVirtualDBE();

        [Authorize]
        public ActionResult AddToCart(CarritoPedidos pedido, int id)
        {
            int numProds = 0;
            pedido.ForEach(prod =>
            {
                if (prod.Id == id)
                {
                    numProds++;
                }
            });
            Peliculas peliculaEncontrada = db.Peliculas.Find(id);

            if(numProds < peliculaEncontrada.Stock)
            {
                pedido.Add(db.Peliculas.Find(id));
            }
            
            return RedirectToAction("Index");
        }

        [Authorize]
        // GET: Peliculas
        public ActionResult Index()
        {
            return View(db.Peliculas.ToList());
        }

        [Authorize]
        // GET: Peliculas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Peliculas peliculas = db.Peliculas.Find(id);
            if (peliculas == null)
            {
                return HttpNotFound();
            }
            return View(peliculas);
        }

        [Authorize(Users = "admin@admin.es")]
        // GET: Peliculas/Create
        public ActionResult Create()
        {
            return View();
        }

        [Authorize(Users = "admin@admin.es")]
        // POST: Peliculas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Sinopsis,Precio,Stock,Caratula")] Peliculas peliculas)
        {
            if (ModelState.IsValid)
            {
                db.Peliculas.Add(peliculas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(peliculas);
        }

        [Authorize(Users = "admin@admin.es")]
        // password -> SoyAdmin1-
        // GET: Peliculas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Peliculas peliculas = db.Peliculas.Find(id);
            if (peliculas == null)
            {
                return HttpNotFound();
            }
            return View(peliculas);
        }

        [Authorize(Users = "admin@admin.es")]
        // POST: Peliculas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Sinopsis,Precio,Stock,Caratula")] Peliculas peliculas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(peliculas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(peliculas);
        }

        [Authorize(Users = "admin@admin.es")]
        // GET: Peliculas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Peliculas peliculas = db.Peliculas.Find(id);
            if (peliculas == null)
            {
                return HttpNotFound();
            }
            return View(peliculas);
        }

        [Authorize(Users = "admin@admin.es")]
        // POST: Peliculas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Peliculas peliculas = db.Peliculas.Find(id);
            db.Peliculas.Remove(peliculas);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
