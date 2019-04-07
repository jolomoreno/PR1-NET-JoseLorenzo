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
using Microsoft.AspNet.Identity;

namespace TiendaVirtual.Controllers
{
    public class CarritoController : Controller
    {
        private TiendaVirtualDBE db = new TiendaVirtualDBE();
        // GET: Carrito
        [Authorize]
        public ActionResult Index(CarritoPedidos cart)
        {
            return View(cart);
        }

        [Authorize]
        public ActionResult Delete(CarritoPedidos pedido, int id)
        {
            pedido.Remove(pedido.Find(item => item.Id == id));
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpPost]
        public ActionResult Buy(string dir, CarritoPedidos carrito)
        {
            string userEmail = User.Identity.GetUserName();
            Pedidos pedido = new Pedidos();
            double? total = 0.0;
            carrito.ForEach(product =>
           {
               Peliculas productDb = db.Peliculas.Find(product.Id);
               pedido.Peliculas.Add(productDb);
               productDb.Stock -= 1;
               total += productDb.Precio;
               db.Entry(productDb).State = EntityState.Modified;
           });
            pedido.Cliente = userEmail;
            pedido.Total = total;
            pedido.Direccion = dir;
            pedido.Fecha = DateTime.Now;

            db.Pedidos.Add(pedido);
            db.SaveChanges();
            carrito.Clear();

            return RedirectToAction("Index", "Pedidos");
        }
    }
}