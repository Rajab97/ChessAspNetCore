using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChessWebAspNetCore.Models
{
    public partial class DirectionToDescription
    {
        public int Id { get; set; }
        public int DirectionId { get; set; }
        public int DescriptionId { get; set; }

        [ForeignKey("DescriptionId")]
        [InverseProperty("DirectionToDescription")]
        public DirectionDescription Description { get; set; }
        [ForeignKey("DirectionId")]
        [InverseProperty("DirectionToDescription")]
        public Directions Direction { get; set; }
    }
}
