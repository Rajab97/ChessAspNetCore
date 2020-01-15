using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChessWebAspNetCore.Models;

namespace ChessWebAspNetCore.Controllers
{
    public class DirectionDescriptionsController : Controller
    {
        private readonly ChessGameContext _context;

        public DirectionDescriptionsController(ChessGameContext context)
        {
            _context = context;
        }

        // GET: DirectionDescriptions
        public async Task<IActionResult> Index()
        {
            var chessGameContext = _context.DirectionDescription;
            return View(await chessGameContext.ToListAsync());
        }

      

        // GET: DirectionDescriptions/Create
        public IActionResult Create()
        {
            ViewData["DirectionId"] = new SelectList(_context.Directions, "Id", "Name");
            return View();
        }

        // POST: DirectionDescriptions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RowStep,ColumnStep,DiagonalMovement,PerpendicularMovement,DirectionId")] DirectionDescription directionDescription,short? RightOrLeft,short? UpOrDown)
        {
            if (ModelState.IsValid)
            {
                try
                {
                   
                    directionDescription.ColumnStep = (short)(directionDescription.ColumnStep.GetValueOrDefault() * RightOrLeft);
                    directionDescription.RowStep = (short)(directionDescription.RowStep.GetValueOrDefault() * UpOrDown);
                    _context.Add(directionDescription);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception e)
                {

                    throw e ;
                }
            }
            ViewData["DirectionId"] = new SelectList(_context.Directions, "Id", "Name");
            return View(directionDescription);
        }

        // GET: DirectionDescriptions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var directionDescription = await _context.DirectionDescription.FindAsync(id);
            if (directionDescription == null)
            {
                return NotFound();
            }
            ViewData["DirectionId"] = new SelectList(_context.Directions, "Id", "Name");
            return View(directionDescription);
        }

        // POST: DirectionDescriptions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RowStep,ColumnStep,DiagonalMovement,PerpendicularMovement,DirectionId")] DirectionDescription directionDescription)
        {
            if (id != directionDescription.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(directionDescription);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DirectionDescriptionExists(directionDescription.Id))
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
            ViewData["DirectionId"] = new SelectList(_context.Directions, "Id", "Name");
            return View(directionDescription);
        }

        // GET: DirectionDescriptions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directionDescription = await _context.DirectionDescription
                .FirstOrDefaultAsync(m => m.Id == id);
            if (directionDescription == null)
            {
                return NotFound();
            }

            return View(directionDescription);
        }

        // POST: DirectionDescriptions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var directionDescription = await _context.DirectionDescription.FindAsync(id);
            _context.DirectionDescription.Remove(directionDescription);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DirectionDescriptionExists(int id)
        {
            return _context.DirectionDescription.Any(e => e.Id == id);
        }
    }
}
