using System;
using System.Collections.Generic;

namespace ChessWebAspNetCore.Models
{
    public partial class FigureToIndex
    {
        public int Id { get; set; }
        public byte? FigureId { get; set; }
        public short? IndexId { get; set; }

        public Figures Figure { get; set; }
        public TableIndexes Index { get; set; }
    }
}
