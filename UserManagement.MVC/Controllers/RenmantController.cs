using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UserManagement.MVC.Data;
using UserManagement.MVC.Enums;
using UserManagement.MVC.Models;

namespace UserManagement.MVC.Controllers
{
    public class RenmantController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RenmantController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Renmant
        public async Task<IActionResult> Index()
        {
            return View(await _context.Renmant.ToListAsync());
        }

        // GET: Renmant/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var renmant = await _context.Renmant
                .FirstOrDefaultAsync(m => m.Id == id);
            if (renmant == null)
            {
                return NotFound();
            }

            return View(renmant);
        }

        // GET: Renmant/Create
        
        public IActionResult Create()
        {
            return View();
        }

        // POST: Renmant/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Moderator")]
        public async Task<IActionResult> Create([Bind("Id,Name,Quantity,Units")] Renmant renmant)
        {
            if (ModelState.IsValid)
            {
                _context.Add(renmant);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(renmant);
        }

        // GET: Renmant/Edit/5
        [Authorize(Roles = "Moderator")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var renmant = await _context.Renmant.FindAsync(id);
            if (renmant == null)
            {
                return NotFound();
            }
            return View(renmant);
        }

        // POST: Renmant/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Quantity,Units")] Renmant renmant)
        {
            if (id != renmant.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(renmant);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RenmantExists(renmant.Id))
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
            return View(renmant);
        }

       

        private bool RenmantExists(int id)
        {
            return _context.Renmant.Any(e => e.Id == id);
        }
    }
}
