using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ChessWebAspNetCore.Models;
using ChessWebAspNetCore.Models.DTO;

namespace ChessWebAspNetCore.Controllers
{
    public class DirectionsController : Controller
    {
        private readonly ChessGameContext _context;

        public DirectionsController(ChessGameContext context)
        {
            _context = context;
        }

        // GET: Directions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Directions.ToListAsync());
        }

        // GET: Directions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directions = await _context.Directions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (directions == null)
            {
                return NotFound();
            }

            return View(directions);
        }

        // GET: Directions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Directions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Directions directions)
        {
            if (ModelState.IsValid)
            {
                _context.Add(directions);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(directions);
        }

        // GET: Directions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directions = await _context.Directions.FindAsync(id);
            if (directions == null)
            {
                return NotFound();
            }

            EditDirectionDTO editDirectionDTO = EditDirectionDTO.ConvertDirectionToDTO(directions);
            editDirectionDTO.FillNeedDatas(_context);
            return View(editDirectionDTO);
        }

        // POST: Directions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditDirectionDTO editDirectionDTO)
        {
            if (!_context.Directions.Any(m => m.Id == editDirectionDTO.Id))
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    Directions directions = EditDirectionDTO.GetDirectionFromDTO(editDirectionDTO);
                    if (editDirectionDTO.Descriptions != null)
                    {
                        IEnumerable<int> descriptions = editDirectionDTO.Descriptions.Distinct();
                        foreach (int item in descriptions)
                        {
                            DirectionToDescription directionToDescription = await _context.DirectionToDescription.FirstOrDefaultAsync(m => m.DirectionId == directions.Id && m.DescriptionId == Math.Abs(item));
                            if (item > 0)
                            {
                                if (directionToDescription == null)
                                {
                                    directionToDescription = new DirectionToDescription()
                                    {
                                        Direction = directions,
                                        DescriptionId = item
                                    };
                                    await _context.AddAsync(directionToDescription);
                                }
                            }
                            else
                            {
                                if (directionToDescription != null)
                                {
                                    _context.Remove(directionToDescription);
                                }
                            }
                        }
                    }

                    _context.Update(directions);

                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DirectionsExists(editDirectionDTO.Id))
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
            return View(editDirectionDTO);
        }

        // GET: Directions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var directions = await _context.Directions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (directions == null)
            {
                return NotFound();
            }

            return View(directions);
        }

        // POST: Directions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var directions = await _context.Directions.FindAsync(id);
            _context.Directions.Remove(directions);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DirectionsExists(int id)
        {
            return _context.Directions.Any(e => e.Id == id);
        }
    }
}
