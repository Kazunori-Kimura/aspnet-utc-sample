using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using UtcSample.Models;

namespace UtcSample.Controllers
{
    public class SoliloquiesController : Controller
    {
        private Models.AppContext db = new Models.AppContext();

        // GET: Soliloquies
        public ActionResult Index()
        {
            return View(db.Soliluies.ToList());
        }

        // GET: Soliloquies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Soliloquy soliloquy = db.Soliluies.Find(id);
            if (soliloquy == null)
            {
                return HttpNotFound();
            }
            return View(soliloquy);
        }

        // GET: Soliloquies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Soliloquies/Create
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Message")] Soliloquy soliloquy)
        {
            if (ModelState.IsValid)
            {
                soliloquy.Created = DateTime.UtcNow;
                db.Soliluies.Add(soliloquy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(soliloquy);
        }

        // GET: Soliloquies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Soliloquy soliloquy = db.Soliluies.Find(id);
            if (soliloquy == null)
            {
                return HttpNotFound();
            }
            return View(soliloquy);
        }

        // POST: Soliloquies/Edit/5
        // 過多ポスティング攻撃を防止するには、バインド先とする特定のプロパティを有効にしてください。
        // 詳細については、https://go.microsoft.com/fwlink/?LinkId=317598 を参照してください。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Message,Created")] Soliloquy soliloquy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(soliloquy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(soliloquy);
        }

        // GET: Soliloquies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Soliloquy soliloquy = db.Soliluies.Find(id);
            if (soliloquy == null)
            {
                return HttpNotFound();
            }
            return View(soliloquy);
        }

        // POST: Soliloquies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Soliloquy soliloquy = db.Soliluies.Find(id);
            db.Soliluies.Remove(soliloquy);
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
