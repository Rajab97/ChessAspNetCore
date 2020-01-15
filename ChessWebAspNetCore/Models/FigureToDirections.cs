using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChessWebAspNetCore.Models
{
    public partial class FigureToDirections
    {
        public int Id { get; set; }
        public byte? FigureId { get; set; }
        public int? DirectionId { get; set; }

        [ForeignKey("DirectionId")]
        [InverseProperty("FigureToDirections")]
        public Directions Direction { get; set; }
        [ForeignKey("FigureId")]
        [InverseProperty("FigureToDirections")]
        public Figures Figure { get; set; }
    }
}
