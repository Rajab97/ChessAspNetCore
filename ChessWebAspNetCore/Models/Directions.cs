using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [ForeignKey("Id")]
        [InverseProperty("InverseIdNavigation")]
        public Directions IdNavigation { get; set; }
        [InverseProperty("IdNavigation")]
        public Directions InverseIdNavigation { get; set; }
        [InverseProperty("Direction")]
        public ICollection<DirectionToDescription> DirectionToDescription { get; set; }
        [InverseProperty("Direction")]
        public ICollection<FigureToDirections> FigureToDirections { get; set; }
    }
}
