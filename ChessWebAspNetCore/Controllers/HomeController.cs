using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChessWebAspNetCore.Models;
using ChessWebAspNetCore.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using ChessWebAspNetCore.Helpers.ImageUpload;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using ChessWebAspNetCore.Models.DTO;
using ChessWebAspNetCore.BLL;

namespace ChessWebAspNetCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ChessGameContext _context;
        public HomeController(ChessGameContext chessGameContext)
        {
            _context = chessGameContext;
        }
        [HttpGet]
        public IActionResult Index()
        {
            HomeIndexViewModel homeIndexViewModel = new HomeIndexViewModel();
           
            
                homeIndexViewModel.Figures = _context.Figures.ToList();
            

            return View(homeIndexViewModel);
        }


       
        [HttpGet]
        [AutoValidateAntiforgeryToken]
        public  IActionResult CreateFigure()
        {
            return View();
        }
        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> CreateFigure(CreateFigureDto figureDto)
        {
            if (!ModelState.IsValid)
            {
                return View(figureDto);
            }

            try
            {
                    Figures figure = await CreateFigureDto.GetFigureFromDtoAsync(figureDto);
                    _context.Add(figure);
                    await _context.SaveChangesAsync();
                

            }
            catch(FormatException)
            {
                ModelState.AddModelError("Photo", $"Image format must be {WriterHelper.GetValidImageFormatsForErrorMessages()}");
                return View(figureDto);
            }
            catch (Exception)
            {
                
                return View(figureDto);
            }


            return RedirectToAction(nameof(Index));
        }


        [HttpGet]
        public IActionResult EditFigure(int? Id)
        {

                Figures figures = _context.Figures.FirstOrDefault(m => m.Id == Id);
                if (figures == null)
                {
                    return RedirectToAction(nameof(Index));
                }

           
                EditFigureDto editFigureDto = EditFigureDto.GetDtoFromFigure(figures);
                editFigureDto.FillNeedDatas(_context);
                return View(editFigureDto);
            
           
        }


        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> EditFigure(EditFigureDto figureDto)
        {

            

              
                try
                {

                figureDto.FillNeedDatas(_context);
                if (!ModelState.IsValid)
                    return View(figureDto);

               
                
                Figures figures = await EditFigureDto.GetFigureFromDtoAsync(figureDto);
                if (figureDto.Directions != null)
                {
                    IEnumerable<int> directions = figureDto.Directions.Distinct();
                    foreach (int item in directions)
                    {
                        FigureToDirections figureToDirections = await _context.FigureToDirections.FirstOrDefaultAsync(m => m.FigureId == figures.Id && m.DirectionId == Math.Abs(item));
                        if (item > 0)
                        {
                            if (figureToDirections == null)
                            {
                                figureToDirections = new FigureToDirections()
                                {
                                    FigureId = figures.Id,
                                    DirectionId = item
                                };
                                await _context.AddAsync(figureToDirections);
                            }
                        }
                        else
                        {
                            if (figureToDirections != null)
                            {
                                _context.Remove(figureToDirections);
                            }
                        }
                    }
                }
          
                _context.Update(figures);
                await _context.SaveChangesAsync();

                if (figureDto.Photo != null)
                {
                    ImageDeleter.RemoveImageWithPath(figureDto.PreviousPhoto);
                }
                return RedirectToAction(nameof(Index));
                    

                }
                catch (FormatException)
                {
                    ModelState.AddModelError("Photo", $"Image format must be {WriterHelper.GetValidImageFormatsForErrorMessages()}");
              
                    return View(figureDto);
                }
                catch (DbUpdateException)
                {
                    ModelState.AddModelError("exception", $"Your request is not confirmed");
                    return View(figureDto);
                }
                catch(Exception)
                {
                    return View(figureDto);
                }
        }

        [HttpGet]
        public IActionResult DeleteFigure(int? Id)
        {
            Figures figures = _context.Figures.FirstOrDefault(m => m.Id == Id);
            if (figures != null)
            {
                return View(figures);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> DeleteFigure(Figures figures)
        {
            if (!_context.Figures.Any(m => m.Id == figures.Id))
            {
                //PageNotFound
                return NotFound();
            }
            _context.Figures.Remove(figures);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult AddDirectionToCurrentFigure(int? Id)
        {
            try
            {
                FigureAndDirections model = new FigureAndDirections();

                Figures figure = _context.Figures.FirstOrDefault(m => m.Id == Id);

                if (figure == null)
                    //Page Not Found
                    return NotFound();
                model.Figures = figure;
                model.DirectionsOfFigure = _context.FigureToDirections.Include(m => m.Direction).Where(f => f.Id == Id);
                model.Directions = _context.Directions;
                return View(model);
            }
            catch (Exception)
            {

                return RedirectToAction(nameof(Index));
            }
            
        }

    





        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
