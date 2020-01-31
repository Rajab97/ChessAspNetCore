using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ChessWebAspNetCore.BLL;
namespace ChessWebAspNetCore.Models.DTO
{
    public class EditDirectionDTO
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
       
        public IEnumerable<int> Descriptions { get; set; }
        public IEnumerable<DirectionDescription> AvailableDescriptions { get; set; }
        public IEnumerable<DirectionToDescription> DirectionToDescriptions { get; set; }
        public static EditDirectionDTO ConvertDirectionToDTO(Directions directions)
        {
            return new EditDirectionDTO
            {
                Id = directions.Id,
                Name = directions.Name,
            };
        }
        public static Directions GetDirectionFromDTO(EditDirectionDTO editDirectionDTO)
        {
            return new Directions
            {
                Id = editDirectionDTO.Id,
                Name = editDirectionDTO.Name
            };
        }
        public void FillNeedDatas(ChessGameContext dbContext)
        {
            if(dbContext == null)
                throw new NullReferenceException(message: "DbContext must not be null");

            if (dbContext.Directions.Any(m => m.Id == Id))
            {
                this.AvailableDescriptions = DirectionAndDescriptionHelper.GetDescriptionsWhichNotAvailableForCurrentDirection(Id,dbContext);
                this.DirectionToDescriptions = dbContext.DirectionToDescription.Include(m => m.Description).Where(m => m.DirectionId == this.Id);
            }
            else
            {
                throw new Exception(message: "Figure is not valid");
            }

        }
    }
}
