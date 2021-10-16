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
    public class CharactersController : Controller
    {
        private readonly RPGWorldTrackerContext _context;

        public CharactersController(RPGWorldTrackerContext context)
        {
            _context = context;
        }

        // GET: Characters
        public async Task<IActionResult> Index()
        {
            var rPGWorldTrackerContext = _context.Character.Include(c => c.Campaign).Include(c => c.Home).Include(c => c.Job);
            return View(await rPGWorldTrackerContext.ToListAsync());
        }

        // GET: Characters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Character
                .Include(c => c.Campaign)
                .Include(c => c.Home)
                .Include(c => c.Job)
                .FirstOrDefaultAsync(m => m.CharacterId == id);
            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // GET: Characters/Create
        public IActionResult Create()
        {
            ViewData["CampaignId"] = new SelectList(_context.Campaign, "CampaignId", "CampaignId");
            ViewData["HomeId"] = new SelectList(_context.Set<Home>(), "HomeId", "HomeId");
            ViewData["JobId"] = new SelectList(_context.Set<Store>(), "StoreId", "StoreId");
            return View();
        }

        // POST: Characters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CharacterId,Name,Race,Profession,Appearance,Background,OtherDetails,CampaignId,JobId,HomeId")] Character character)
        {
            if (ModelState.IsValid)
            {
                _context.Add(character);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CampaignId"] = new SelectList(_context.Campaign, "CampaignId", "CampaignId", character.CampaignId);
            ViewData["HomeId"] = new SelectList(_context.Set<Home>(), "HomeId", "HomeId", character.HomeId);
            ViewData["JobId"] = new SelectList(_context.Set<Store>(), "StoreId", "StoreId", character.JobId);
            return View(character);
        }

        // GET: Characters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Character.FindAsync(id);
            if (character == null)
            {
                return NotFound();
            }
            ViewData["CampaignId"] = new SelectList(_context.Campaign, "CampaignId", "CampaignId", character.CampaignId);
            ViewData["HomeId"] = new SelectList(_context.Set<Home>(), "HomeId", "HomeId", character.HomeId);
            ViewData["JobId"] = new SelectList(_context.Set<Store>(), "StoreId", "StoreId", character.JobId);
            return View(character);
        }

        // POST: Characters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CharacterId,Name,Race,Profession,Appearance,Background,OtherDetails,CampaignId,JobId,HomeId")] Character character)
        {
            if (id != character.CharacterId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(character);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CharacterExists(character.CharacterId))
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
            ViewData["CampaignId"] = new SelectList(_context.Campaign, "CampaignId", "CampaignId", character.CampaignId);
            ViewData["HomeId"] = new SelectList(_context.Set<Home>(), "HomeId", "HomeId", character.HomeId);
            ViewData["JobId"] = new SelectList(_context.Set<Store>(), "StoreId", "StoreId", character.JobId);
            return View(character);
        }

        // GET: Characters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var character = await _context.Character
                .Include(c => c.Campaign)
                .Include(c => c.Home)
                .Include(c => c.Job)
                .FirstOrDefaultAsync(m => m.CharacterId == id);
            if (character == null)
            {
                return NotFound();
            }

            return View(character);
        }

        // POST: Characters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var character = await _context.Character.FindAsync(id);
            _context.Character.Remove(character);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CharacterExists(int id)
        {
            return _context.Character.Any(e => e.CharacterId == id);
        }
    }
}
