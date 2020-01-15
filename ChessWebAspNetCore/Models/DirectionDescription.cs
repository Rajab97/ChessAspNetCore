using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Display(Name ="Diagonal")]
        public bool DiagonalMovement { get; set; }
        [Display(Name = "Perpendicular")]
        public bool PerpendicularMovement { get; set; }

        [InverseProperty("Description")]
        public ICollection<DirectionToDescription> DirectionToDescription { get; set; }
    }
}
