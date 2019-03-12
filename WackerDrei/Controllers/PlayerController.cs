using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WackerDrei.Models;
using WackerDrei.ViewModels;

namespace WackerDrei.Controllers
{
    [Authorize]
    public class PlayerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Players
        public ActionResult Index()
        {
            var players = db.Players.Include(x => x.Carriers).Include(x => x.Hobbies).Include(x => x.Injuries).Include(x => x.Functions).Include(x => x.Dioptre).ToList();
            return View(players);
        }

        public ActionResult Active()
        {
            var players = db.Players.Include(p => p.Carriers).Include(p => p.Dioptre).Include(p => p.Injury).Where(x => x.Active);
            return View(players.ToList());
        }

        public ActionResult Passiv()
        {
            var players = db.Players.Include(p => p.Carriers).Include(p => p.Dioptre).Include(p => p.Injury).Where(x => x.Active == false);
            return View(players.ToList());
        }

        // GET: Players/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // GET: Players/Create
        public ActionResult Create()
        {
            return View(new PlayerViewModel());
        }

        // POST: Players/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PlayerViewModel vm)
        {
            var hobbies = db.Hobbies.ToList();
            var functions = db.Functions.ToList();
            if (ModelState.IsValid)
            {
                var carriersList = new List<Carrier>();
                var injuriesList = new List<Injury>();
                var player = new Player
                {
                    Firstname = vm.Firstname,
                    Lastname = vm.Lastname,
                    EMail = vm.EMail,
                    Nickname = vm.Nickname,
                    Position = vm.Position,
                    Number = vm.Number,
                    Birthday = vm.Birthday,
                    Weight = vm.Weight,
                    Height = vm.Height,
                    DioptreDescription = vm.DioptreDescription,
                    Job = vm.Job,
                    MottoOfLife = vm.MottoOfLife,
                    Dream = vm.Dream,
                    OwnDescription = vm.OwnDescription,
                    TeamDescription = vm.TeamDescription,
                    DailyNicotine = vm.DailyNicotine,
                    BeerAfterTraining = vm.BeerAfterTraining,
                    Active = vm.Active,
                    Password = vm.Password
                };

                foreach (var item in vm.Carriers)
                {
                    var association = new Association { Name = item.Association, Team = item.Team };
                    carriersList.Add(new Carrier { Player = player, From = item.From, To = item.To, Association = association });
                }

                foreach (var item in vm.Injuries)
                {
                    var bodyPart = new Bodypart { Part = item.Bodypart.Part };
                    injuriesList.Add(new Injury { Description = item.Description, Bodypart = bodyPart });
                }

                player.Dioptre = new Dioptre { Left = vm.Dioptre.Left, Right = vm.Dioptre.Right };
                player.Dioptre.Players.Add(player);

                player.Carriers = carriersList;
                player.Injuries = injuriesList;

                var splitHobbies = SplitTags(vm.Hobbies);
                foreach (var item in splitHobbies)
                {
                    player.Hobbies.Add(hobbies.Any(x => x.Hobbyname == item)
                        ? hobbies.FirstOrDefault(x => x.Hobbyname == item)
                        : new Hobby { Hobbyname = item });
                }

                var splitFunctions = SplitTags(vm.Functions);
                foreach (var item in splitFunctions)
                {
                    player.Functions.Add(functions.Any(x => x.Description == item)
                        ? functions.FirstOrDefault(x => x.Description == item)
                        : new Function { Description = item });
                }

                db.Players.Add(player);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        // GET: Players/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: Players/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nickname,Position,Number,CarrierId,InjuryId,Birthday,Weight,Height,DioptreId,DioptreDescription,Job,HobbyId,MottoOfLife,Dream,OwnDescription,TeamDescription,DailyNicotine,BeerAfterTraining,Active,Password")] Player player)
        {
            if (ModelState.IsValid)
            {
                db.Entry(player).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(player);
        }

        // GET: Players/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var player = db.Players.Find(id);
            if (player == null)
            {
                return HttpNotFound();
            }
            return View(player);
        }

        // POST: Players/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var player = db.Players.Find(id);
            db.Players.Remove(player);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public List<string> SplitTags(string Tags)
        {
            if (!(Tags?.Split(',').ToList() is List<string> list)) return new List<string>();
            return list;
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
