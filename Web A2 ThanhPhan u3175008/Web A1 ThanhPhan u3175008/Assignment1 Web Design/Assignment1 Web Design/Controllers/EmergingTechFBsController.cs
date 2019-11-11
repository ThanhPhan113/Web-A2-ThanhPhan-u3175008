using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment1_Web_Design.Data;
using Assignment1_Web_Design.Models;

namespace Assignment1_Web_Design.Controllers
{
    public class EmergingTechFBsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmergingTechFBsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmergingTechFBs
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmergingTechFB.ToListAsync());
        }

        // GET: EmergingTechFBs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emergingTechFB = await _context.EmergingTechFB
                .SingleOrDefaultAsync(m => m.Id == id);
            if (emergingTechFB == null)
            {
                return NotFound();
            }

            return View(emergingTechFB);
        }

        // GET: EmergingTechFBs/Create
        public IActionResult Create()
        {
            EmergingTechFB emergingTechnologiesFeedback = new EmergingTechFB();

            emergingTechnologiesFeedback.Date = DateTime.Now;
            emergingTechnologiesFeedback.Username = User.Identity.Name;
            return View(emergingTechnologiesFeedback);
        }

        // POST: EmergingTechFBs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Username,Heading,StarRating,FeedBack,Agree,Disagree,EmergingTechnologyName,isAgreeAdded,isDisagreeAdded")] EmergingTechFB emergingTechFB)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emergingTechFB);
                await _context.SaveChangesAsync();
                return RedirectToAction("EmergingTechnologies", "Home");
            }
            return View(emergingTechFB);
        }

        // GET: EmergingTechFBs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emergingTechFB = await _context.EmergingTechFB.SingleOrDefaultAsync(m => m.Id == id);
            if (emergingTechFB == null)
            {
                return NotFound();
            }
            return View(emergingTechFB);
        }


        // No View: UnitResults/IncreaseTotalMark/5
        public async Task<IActionResult> CountAgree(int? id, string username)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emergingTechnologiesFeedback =
await _context.EmergingTechFB.SingleOrDefaultAsync(m => m.Id == id);

            if (emergingTechnologiesFeedback == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    emergingTechnologiesFeedback.Agree = emergingTechnologiesFeedback.Agree + 1;

                    _context.Update(emergingTechnologiesFeedback);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmergingTechFBExists(emergingTechnologiesFeedback.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return RedirectToAction("EmergingTechnologies", "Home");
        }


        // No View: UnitResults/IncreaseTotalMark/5
        public async Task<IActionResult> CountDisagree(int? id, string username)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emergingTechnologiesFeedback =
await _context.EmergingTechFB.SingleOrDefaultAsync(m => m.Id == id);

            if (emergingTechnologiesFeedback == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    emergingTechnologiesFeedback.Disagree = emergingTechnologiesFeedback.Disagree + 1;

                    _context.Update(emergingTechnologiesFeedback);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmergingTechFBExists(emergingTechnologiesFeedback.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return RedirectToAction("EmergingTechnologies", "Home");
        }



        // POST: EmergingTechFBs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Username,Heading,StarRating,FeedBack,Agree,Disagree,EmergingTechnologyName,isAgreeAdded,isDisagreeAdded")] EmergingTechFB emergingTechFB)
        {
            if (id != emergingTechFB.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emergingTechFB);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmergingTechFBExists(emergingTechFB.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("EmergingTechnologies", "Home");
            }
            return View(emergingTechFB);
        }

        // GET: EmergingTechFBs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emergingTechFB = await _context.EmergingTechFB
                .SingleOrDefaultAsync(m => m.Id == id);
            if (emergingTechFB == null)
            {
                return NotFound();
            }

            return View(emergingTechFB);
        }

        // POST: EmergingTechFBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var emergingTechFB = await _context.EmergingTechFB.SingleOrDefaultAsync(m => m.Id == id);
            _context.EmergingTechFB.Remove(emergingTechFB);
            await _context.SaveChangesAsync();
            return RedirectToAction("EmergingTechnologies", "Home");
        }

        private bool EmergingTechFBExists(int id)
        {
            return _context.EmergingTechFB.Any(e => e.Id == id);
        }
    }
}
