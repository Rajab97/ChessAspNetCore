using System;
using System.Collections.Generic;

namespace ChessWebAspNetCore.Models
{
    public partial class Directions
    {
        public Directions()
        {
            DirectionToDescription = new HashSet<DirectionToDescription>();
            FigureToDirections = new HashSet<FigureToDirections>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public Directions IdNavigation { get; set; }
        public Directions InverseIdNavigation { get; set; }
        public ICollection<DirectionToDescription> DirectionToDescription { get; set; }
        public ICollection<FigureToDirections> FigureToDirections { get; set; }
    }
}
