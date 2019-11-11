using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Assignment1WebDesign.Models;
using Assignment1_Web_Design.Data;
using Microsoft.AspNetCore.Authorization;

namespace Assignment1_Web_Design.Controllers
{
    public class EmergingTechnologiesFeedbacksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmergingTechnologiesFeedbacksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmergingTechnologiesFeedbacks
        public async Task<IActionResult> Index()
        {
            return View(await _context.EmergingTechnologiesFeedback.ToListAsync());
        }

        // GET: EmergingTechnologiesFeedbacks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emergingTechnologiesFeedback = await _context.EmergingTechnologiesFeedback
                .SingleOrDefaultAsync(m => m.Id == id);
            if (emergingTechnologiesFeedback == null)
            {
                return NotFound();
            }

            return View(emergingTechnologiesFeedback);
        }

        // GET: EmergingTechnologiesFeedbacks/Create
        public IActionResult Create()
        {
            EmergingTechnologiesFeedback emergingTechnologiesFeedback = new EmergingTechnologiesFeedback();

            emergingTechnologiesFeedback.Date = DateTime.Now;
            emergingTechnologiesFeedback.Username = User.Identity.Name;
            return View(emergingTechnologiesFeedback);
        }

        // POST: EmergingTechnologiesFeedbacks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Username,Heading,StarRating,FeedBack,Agree,Disagree,EmergingTechnologyName")] EmergingTechnologiesFeedback emergingTechnologiesFeedback)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emergingTechnologiesFeedback);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emergingTechnologiesFeedback);
        }

        // GET: EmergingTechnologiesFeedbacks/Edit/5
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emergingTechnologiesFeedback = await _context.EmergingTechnologiesFeedback.SingleOrDefaultAsync(m => m.Id == id);
            if (emergingTechnologiesFeedback == null)
            {
                return NotFound();
            }
            return View(emergingTechnologiesFeedback);
        }

        // POST: EmergingTechnologiesFeedbacks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Username,Heading,StarRating,FeedBack,Agree,Disagree,EmergingTechnologyName")] EmergingTechnologiesFeedback emergingTechnologiesFeedback)
        {
            if (id != emergingTechnologiesFeedback.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emergingTechnologiesFeedback);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmergingTechnologiesFeedbackExists(emergingTechnologiesFeedback.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(emergingTechnologiesFeedback);
        }

        // GET: EmergingTechnologiesFeedbacks/Delete/5
        [Authorize(Roles = "Manager")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emergingTechnologiesFeedback = await _context.EmergingTechnologiesFeedback
                .SingleOrDefaultAsync(m => m.Id == id);
            if (emergingTechnologiesFeedback == null)
            {
                return NotFound();
            }

            return View(emergingTechnologiesFeedback);
        }

        // POST: EmergingTechnologiesFeedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var emergingTechnologiesFeedback = await _context.EmergingTechnologiesFeedback.SingleOrDefaultAsync(m => m.Id == id);
            _context.EmergingTechnologiesFeedback.Remove(emergingTechnologiesFeedback);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmergingTechnologiesFeedbackExists(int id)
        {
            return _context.EmergingTechnologiesFeedback.Any(e => e.Id == id);
        }

        // No View: UnitResults/IncreaseTotalMark/5
        public async Task<IActionResult> CountAgree(int? id, string username)
        {
            if (id == null)
            {
                return NotFound();
            }

            var emergingTechnologiesFeedback =
await _context.EmergingTechnologiesFeedback.SingleOrDefaultAsync(m => m.Id == id);

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
                    if (!EmergingTechnologiesFeedbackExists(emergingTechnologiesFeedback.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return RedirectToAction("Index");
        }


    }
}

