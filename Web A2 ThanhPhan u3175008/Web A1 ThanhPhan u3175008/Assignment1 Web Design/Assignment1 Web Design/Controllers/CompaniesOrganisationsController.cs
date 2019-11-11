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
    public class CompaniesOrganisationsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CompaniesOrganisationsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CompaniesOrganisations
        public async Task<IActionResult> Index()
        {
            return View(await _context.CompaniesOrganisations.ToListAsync());
        }

        // GET: CompaniesOrganisations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companiesOrganisations = await _context.CompaniesOrganisations
                .SingleOrDefaultAsync(m => m.Id == id);
            if (companiesOrganisations == null)
            {
                return NotFound();
            }

            return View(companiesOrganisations);
        }

        // GET: CompaniesOrganisations/Create
        public IActionResult Create()
        {
            CompaniesOrganisations companiesOrganisations = new CompaniesOrganisations();

            companiesOrganisations.Date = DateTime.Now;
            companiesOrganisations.Username = User.Identity.Name;
            return View(companiesOrganisations);
        }

        // POST: CompaniesOrganisations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Date,Username,Heading,StarRating,FeedBack,Agree,Disagree,EmergingTechnologyName,isAgreeAdded,isDisagreeAdded")] CompaniesOrganisations companiesOrganisations)
        {
            if (ModelState.IsValid)
            {
                _context.Add(companiesOrganisations);
                await _context.SaveChangesAsync();
                return RedirectToAction("Organisations", "Home");
            }
            return View(companiesOrganisations);
        }

        // GET: CompaniesOrganisations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companiesOrganisations = await _context.CompaniesOrganisations.SingleOrDefaultAsync(m => m.Id == id);
            if (companiesOrganisations == null)
            {
                return NotFound();
            }
            return View(companiesOrganisations);
        }



        // No View: UnitResults/IncreaseTotalMark/5
        public async Task<IActionResult> CountAgree(int? id, string username)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companiesOrganisations =
await _context.CompaniesOrganisations.SingleOrDefaultAsync(m => m.Id == id);

            if (companiesOrganisations == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    companiesOrganisations.Agree = companiesOrganisations.Agree + 1;

                    _context.Update(companiesOrganisations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompaniesOrganisationsExists(companiesOrganisations.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return RedirectToAction("Organisations", "Home");
        }

        public async Task<IActionResult> CountDisagree(int? id, string username)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companiesOrganisations =
await _context.CompaniesOrganisations.SingleOrDefaultAsync(m => m.Id == id);

            if (companiesOrganisations == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    companiesOrganisations.Disagree = companiesOrganisations.Disagree + 1;

                    _context.Update(companiesOrganisations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompaniesOrganisationsExists(companiesOrganisations.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }
            return RedirectToAction("Organisations", "Home");
        }

        // POST: CompaniesOrganisations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Date,Username,Heading,StarRating,FeedBack,Agree,Disagree,EmergingTechnologyName,isAgreeAdded,isDisagreeAdded")] CompaniesOrganisations companiesOrganisations)
        {
            if (id != companiesOrganisations.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(companiesOrganisations);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CompaniesOrganisationsExists(companiesOrganisations.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Organisations", "Home");
            }
            return View(companiesOrganisations);
        }

        // GET: CompaniesOrganisations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var companiesOrganisations = await _context.CompaniesOrganisations
                .SingleOrDefaultAsync(m => m.Id == id);
            if (companiesOrganisations == null)
            {
                return NotFound();
            }

            return View(companiesOrganisations);
        }

        // POST: CompaniesOrganisations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var companiesOrganisations = await _context.CompaniesOrganisations.SingleOrDefaultAsync(m => m.Id == id);
            _context.CompaniesOrganisations.Remove(companiesOrganisations);
            await _context.SaveChangesAsync();
            return RedirectToAction("Organisations", "Home");
        }

        private bool CompaniesOrganisationsExists(int id)
        {
            return _context.CompaniesOrganisations.Any(e => e.Id == id);
        }
    }
}
