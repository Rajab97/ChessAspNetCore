using System;
using System.Collections.Generic;

namespace ChessWebAspNetCore.Models
{
    public partial class DirectionToDescription
    {
        public int Id { get; set; }
        public int DirectionId { get; set; }
        public int DescriptionId { get; set; }

        public DirectionDescription Description { get; set; }
        public Directions Direction { get; set; }
    }
}
