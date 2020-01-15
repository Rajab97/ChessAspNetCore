using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChessWebAspNetCore.Models
{
    public partial class Figures
    {
        public Figures()
        {
            FigureToDirections = new HashSet<FigureToDirections>();
        }

        public byte Id { get; set; }
        [Required]
        [StringLength(20)]
        public string Name { get; set; }
        [StringLength(300)]
        public string Photo { get; set; }

        [InverseProperty("Figure")]
        public ICollection<FigureToDirections> FigureToDirections { get; set; }
    }
}
