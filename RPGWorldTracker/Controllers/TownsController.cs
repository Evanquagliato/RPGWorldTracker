using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RPGWorldTracker.Data;
using RPGWorldTracker.Models;

namespace RPGWorldTracker.Controllers
{
    public class TownsController : Controller
    {
        private readonly RPGWorldTrackerContext _context;

        public TownsController(RPGWorldTrackerContext context)
        {
            _context = context;
        }

        // GET: Towns
        public async Task<IActionResult> Index()
        {
            var rPGWorldTrackerContext = _context.Town.Include(t => t.Campaign).Include(t => t.Kingdom);
            return View(await rPGWorldTrackerContext.ToListAsync());
        }

        // GET: Towns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var town = await _context.Town
                .Include(t => t.Campaign)
                .Include(t => t.Kingdom)
                .FirstOrDefaultAsync(m => m.TownId == id);
            if (town == null)
            {
                return NotFound();
            }

            return View(town);
        }

        // GET: Towns/Create
        public IActionResult Create()
        {
            ViewData["CampaignId"] = new SelectList(_context.Campaign, "CampaignId", "Name");
            ViewData["KingdomId"] = new SelectList(_context.Kingdom, "KingdomId", "Name");
            return View();
        }

        // POST: Towns/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TownId,Name,Geography,ResourcesEconomy,Culture,Government,HistoricalEvents,Threats,Defenses,Landmarks,OtherDetails,KingdomId,CampaignId")] Town town)
        {
            if (ModelState.IsValid)
            {
                _context.Add(town);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CampaignId"] = new SelectList(_context.Campaign, "CampaignId", "Name", town.CampaignId);
            ViewData["KingdomId"] = new SelectList(_context.Kingdom, "KingdomId", "Name", town.KingdomId);
            return View(town);
        }

        // GET: Towns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var town = await _context.Town.FindAsync(id);
            if (town == null)
            {
                return NotFound();
            }
            ViewData["CampaignId"] = new SelectList(_context.Campaign, "CampaignId", "Name", town.CampaignId);
            ViewData["KingdomId"] = new SelectList(_context.Kingdom, "KingdomId", "Name", town.KingdomId);
            return View(town);
        }

        // POST: Towns/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TownId,Name,Geography,ResourcesEconomy,Culture,Government,HistoricalEvents,Threats,Defenses,Landmarks,OtherDetails,KingdomId,CampaignId")] Town town)
        {
            if (id != town.TownId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(town);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TownExists(town.TownId))
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
            ViewData["CampaignId"] = new SelectList(_context.Campaign, "CampaignId", "Name", town.CampaignId);
            ViewData["KingdomId"] = new SelectList(_context.Kingdom, "KingdomId", "Name", town.KingdomId);
            return View(town);
        }

        // GET: Towns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var town = await _context.Town
                .Include(t => t.Campaign)
                .Include(t => t.Kingdom)
                .FirstOrDefaultAsync(m => m.TownId == id);
            if (town == null)
            {
                return NotFound();
            }

            return View(town);
        }

        // POST: Towns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var town = await _context.Town.FindAsync(id);
            _context.Town.Remove(town);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TownExists(int id)
        {
            return _context.Town.Any(e => e.TownId == id);
        }
    }
}
