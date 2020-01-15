using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessWebAspNetCore.Models.ViewModels
{
    public class FigureAndDirections
    {
        public Figures Figures { get; set; }
        public IEnumerable<FigureToDirections> DirectionsOfFigure { get; set; }
        public IEnumerable<Directions> Directions { get; set; } 
    }
}
