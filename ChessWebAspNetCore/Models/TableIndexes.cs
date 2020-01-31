using System;
using System.Collections.Generic;

namespace ChessWebAspNetCore.Models
{
    public partial class TableIndexes
    {
        public short Id { get; set; }
        public short RowIndex { get; set; }
        public short ColumnIndex { get; set; }

        public FigureToIndex FigureToIndex { get; set; }
    }
}
