using System;
using System.Collections.Generic;

namespace ChessWebAspNetCore.Models
{
    public partial class Figures
    {
        public Figures()
        {
            FigureToDirections = new HashSet<FigureToDirections>();
            FigureToIndex = new HashSet<FigureToIndex>();
        }

        public byte Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public bool? WhiteOrBlack { get; set; }

        public ICollection<FigureToDirections> FigureToDirections { get; set; }
        public ICollection<FigureToIndex> FigureToIndex { get; set; }
    }
}
