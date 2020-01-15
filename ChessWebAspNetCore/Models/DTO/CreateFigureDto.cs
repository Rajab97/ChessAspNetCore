using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ChessWebAspNetCore.Helpers.ImageUpload;
using Microsoft.AspNetCore.Http;
namespace ChessWebAspNetCore.Models.DTO
{
    public class CreateFigureDto
    {
        [Required(ErrorMessage = "You must enter name")]
        [Display(Name ="Name of figure")]
        public string Name { get; set; }


        [Required(ErrorMessage = "You must enter image")]
        [Display(Name = "Image")]
        public IFormFile Photo { get; set; } 

        public static async Task<Figures> GetFigureFromDtoAsync(CreateFigureDto dto)
        {
            return new Figures()
            {
                Name = dto.Name,
                Photo = await new ImageWriter().UploadImage(dto.Photo)
            };
        }
    }
}
