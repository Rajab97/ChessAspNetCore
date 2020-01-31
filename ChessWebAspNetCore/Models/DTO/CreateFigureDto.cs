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

        public IEnumerable<string> Indexes { get; set; }

        public static async Task<Figures> GetFigureFromDtoAsync(CreateFigureDto dto)
        {
            return new Figures()
            {
                Name = dto.Name,
                Photo = await new ImageWriter().UploadImage(dto.Photo),
            };
        }

        public static List<FigureToIndex> GetFigureToIndexes(CreateFigureDto figureDto,ChessGameContext chessGameContext,Figures figure)
        {
            List<FigureToIndex> figureToIndixes = new List<FigureToIndex>(); 
            foreach (string item in figureDto.Indexes)
            {
                Index index = CheckThisRowAndColumnStringValid(item);
                if (index != null)
                {
                    TableIndexes tableIndexes = chessGameContext.TableIndexes.FirstOrDefault(m => m.RowIndex == index.Row && m.ColumnIndex == index.Column);
                    if (tableIndexes != null)
                    {
                        figureToIndixes.Add(new FigureToIndex()
                        {
                            IndexId = tableIndexes.Id,
                            Figure = figure
                        });
                    }
                }
            }
            return figureToIndixes;
        }
        private static Index CheckThisRowAndColumnStringValid(string text)
        {
            try
            {
                int Row = Convert.ToInt32(text.Split('-')[0]);
                int Column = Convert.ToInt32(text.Split('-')[1]);
                if ((Row > 0 && Row <= 8) && (Column > 0 && Column <= 8))
                    return new Index() {
                        Row = Row,
                        Column = Column
                    };
                return null;
            }
            catch (Exception)
            {

                return null;
            }

        }
        private class Index
        {
            public int Row { get; set; }
            public int Column { get; set; }
        }
    }
}
