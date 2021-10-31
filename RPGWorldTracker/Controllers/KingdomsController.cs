using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RPGWorldTracker.Data;
using RPGWorldTracker.Models;
using RPGWorldTracker.ViewModels;

namespace RPGWorldTracker.Controllers
{
	public class KingdomsController : Controller
	{
		private readonly RPGWorldTrackerContext _context;

		public KingdomsController(RPGWorldTrackerContext context)
		{
			_context = context;
		}

		// GET: Kingdoms
		public async Task<IActionResult> Index()
		{
			var rPGWorldTrackerContext = _context.Kingdom.Include(k => k.Campaign);
			return View(await rPGWorldTrackerContext.ToListAsync());
		}

		// GET: Kingdoms/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var kingdom = await _context.Kingdom
			    .Include(k => k.Campaign)
			    .FirstOrDefaultAsync(m => m.KingdomId == id);
			if (kingdom == null)
			{
				return NotFound();
			}

			return View(kingdom);
		}

		// GET: Kingdoms/Create
		public IActionResult Create()
		{
			ViewData["CampaignId"] = new SelectList(_context.Campaign, "CampaignId", "CampaignId");
			return View();
		}

		// POST: Kingdoms/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("KingdomId,Name,Geography,ResourcesEconomy,Culture,Government,HistoricalEvents,Threats,Landmarks,OtherDetails,CampaignId")] Kingdom kingdom)
		{
			if (ModelState.IsValid)
			{
				_context.Add(kingdom);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			ViewData["CampaignId"] = new SelectList(_context.Campaign, "CampaignId", "CampaignId", kingdom.CampaignId);
			return View(kingdom);
		}

		// GET: Kingdoms/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var kingdom = await _context.Kingdom.FindAsync(id);
			if (kingdom == null)
			{
				return NotFound();
			}
			ViewData["CampaignId"] = new SelectList(_context.Campaign, "CampaignId", "CampaignId", kingdom.CampaignId);
			return View(kingdom);
		}

		// POST: Kingdoms/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("KingdomId,Name,Geography,ResourcesEconomy,Culture,Government,HistoricalEvents,Threats,Landmarks,OtherDetails,CampaignId")] Kingdom kingdom)
		{
			if (id != kingdom.KingdomId)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(kingdom);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!KingdomExists(kingdom.KingdomId))
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
			ViewData["CampaignId"] = new SelectList(_context.Campaign, "CampaignId", "CampaignId", kingdom.CampaignId);
			return View(kingdom);
		}

		// GET: Kingdoms/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var kingdom = await _context.Kingdom
			    .Include(k => k.Campaign)
			    .FirstOrDefaultAsync(m => m.KingdomId == id);
			if (kingdom == null)
			{
				return NotFound();
			}

			return View(kingdom);
		}

		// POST: Kingdoms/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var kingdom = await _context.Kingdom.FindAsync(id);
			_context.Kingdom.Remove(kingdom);
			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool KingdomExists(int id)
		{
			return _context.Kingdom.Any(e => e.KingdomId == id);
		}


		// Kingdoms Reusable Widget 
		/*	public async Task<IActionResult> KingdomWidget()
			{
				var Kingdoms = _context.Kingdom.Include(k => k.Campaign);

				CampaignDetailsViewModel campaignDetailsViewModel = new CampaignDetailsViewModel()
				{
					Kingdoms = Kingdoms.ToList()
				};

				return View(campaignDetailsViewModel);
			}*/
	}
}
