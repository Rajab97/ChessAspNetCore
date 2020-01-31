using System;
using System.Collections.Generic;

namespace ChessWebAspNetCore.Models
{
    public partial class DirectionDescription
    {
        public DirectionDescription()
        {
            DirectionToDescription = new HashSet<DirectionToDescription>();
        }

        public int Id { get; set; }
        public short? RowStep { get; set; }
        public short? ColumnStep { get; set; }
        public bool DiagonalMovement { get; set; }
        public bool PerpendicularMovement { get; set; }

        public ICollection<DirectionToDescription> DirectionToDescription { get; set; }
    }
}
