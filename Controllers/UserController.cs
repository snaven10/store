using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using store.Data;
using store.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace store.Controllers
{
    [Authorize(Roles = "ADMIN")]
    public class UserController : Controller
    {
        readonly ApplicationDbContext ctx;

        public UserController(ApplicationDbContext _ctx)
        {
            ctx = _ctx;
        }
        // GET: User
        public IActionResult Index()
        {
            var result = new List<users>();
            result = (
                from au in ctx.Users
                select new users
                {
                    Id = au.Id,
                    FirsName = au.FirsName,
                    LastName = au.LastName,
                    Email = au.Email,
                }
            ).ToList();
            return View(result);
        }

        // GET: UserController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = ctx.Users
                            .Where(x => x.Id == id)
                            .SingleOrDefault();
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        // POST: UserController/Edit/5
        [BindProperty]
        public users Useres { get; set; }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, users users)
        {
            if (id != Useres.Id)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState.SelectMany(x => x.Value.Errors.Select(y => y.ErrorMessage)).ToList());
            }
            else
            {
                var user = ctx.Users.First(a => a.Id == Useres.Id);
                user.FirsName = Useres.FirsName;
                user.LastName = Useres.LastName;
                user.Email = Useres.Email;
                ctx.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: UserController/Delete/5
        public IActionResult Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var users = ctx.Users
                            .Where(x => x.Id == id)
                            .SingleOrDefault();
            if (users == null)
            {
                return NotFound();
            }

            return View(users);
        }

        // POST: UserController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var usuario = await ctx.Users.FindAsync(id);
            ctx.Users.Remove(usuario);
            await ctx.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
