using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using DiscotecaAlcatraz.Models;

namespace DiscotecaAlcatraz.Controllers
{
    public class HomeController : Controller
    {
        private AlcatrazContext db = new AlcatrazContext();

        public ActionResult Index()
        {
            InicioViewModel modelo = new InicioViewModel();

            modelo.Eventos = db.Eventos
                .OrderBy(e => e.Fecha)
                .ToList();

            modelo.Reservas = db.Reservas
                .Include(r => r.Evento)
                .OrderByDescending(r => r.Id)
                .ToList();

            return View(modelo);
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