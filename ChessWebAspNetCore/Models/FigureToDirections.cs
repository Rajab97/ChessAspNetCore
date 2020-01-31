using System;
using System.Collections.Generic;

namespace ChessWebAspNetCore.Models
{
    public partial class FigureToDirections
    {
        public int Id { get; set; }
        public byte? FigureId { get; set; }
        public int? DirectionId { get; set; }

        public Directions Direction { get; set; }
        public Figures Figure { get; set; }
    }
}
