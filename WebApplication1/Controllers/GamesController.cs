using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections;

namespace WebApplication1.Controllers
{
    public class GamesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Games
        public ActionResult Index()
        {
            var currentUser = HttpContext.User.Identity.GetUserId();
            var userGames = db.Games.Where(Game => Game.UserId == currentUser);
            return View(userGames);
        }

        // GET: Games/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GamePlayerViewModel gameViewModel = new GamePlayerViewModel();
            var listPlayers = db.Players.Where(Player => Player.PlayerGameID == id);
            gameViewModel.game = db.Games.Find(id);
            gameViewModel.players = listPlayers.ToList();
            if (gameViewModel == null)
            {
                return HttpNotFound();
            }
            return View(gameViewModel);
        }

        // GET: Games/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Games/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,GameName,GameStartDate,UserId,numOfPlayers")] Game game)
        {
            if (ModelState.IsValid)
            {
                db.Games.Add(game);
                db.SaveChanges();
                Session["GameName"] = game.GameName;
                Session["NumOfPlayers"] = game.numOfPlayers;
                Session["CurrentGame"] = game.Id;
                return RedirectToAction("GetPlayers","Players");
            }

            return View();
        }

        // GET: Games/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GamePlayerViewModel gameViewModel = new GamePlayerViewModel();
            var listPlayers = db.Players.Where(Player => Player.PlayerGameID == id);
            gameViewModel.game = db.Games.Find(id);
            gameViewModel.players = listPlayers.ToList();
            TempData["currentGame"] = gameViewModel.game.GameName;
            if (gameViewModel == null)
            {
                return HttpNotFound();
            }
            return View(gameViewModel);
        }

        // POST: Games/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GamePlayerViewModel gameView)

        {

            if (ModelState.IsValid)
            {
                gameView.game.GameName = Convert.ToString(TempData["currentGame"]);
                db.Entry(gameView.game.GameName).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","GamesController");
            }
            return RedirectToAction("Index","Games");
        }

        // GET: Games/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Game game = db.Games.Find(id);
            if (game == null)
            {
                return HttpNotFound();
            }
            return View(game);
        }

        // POST: Games/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Game game = db.Games.Find(id);
            db.Games.Remove(game);
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
