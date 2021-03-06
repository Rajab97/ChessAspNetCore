﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChessWebAspNetCore.Helpers
{
    public class ChessGameInput
    {
        public int CurrentItemId { get; set; }
        public int CurrentFigureId { get; set; }
        public FigureIndex NewTableIndexForFigure { get; set; }
        public ChessFigure[] ChessFigures { get; set; }
    }
}
