﻿using ChessWebAspNetCore.BLL;
using ChessWebAspNetCore.Helpers.ImageUpload;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ChessWebAspNetCore.Models.DTO
{
    public class EditFigureDto
    {
        public byte Id { get; set; }
        [Required()]
        [MaxLength(15)]
        public string Name { get; set; }
        [Required]
        public string PreviousPhoto { get; set; }

        public IFormFile Photo { get; set; }

        public IEnumerable<int> Directions { get; set; }
        public IEnumerable<string> Indexes { get; set; }

        public EditFigureDto()
        {
            Directions = new List<int>();
        }
       
        public IEnumerable<Directions> AvailableDirection { get; set; }
        public IQueryable<FigureToDirections> FigureToDirections { get; set; }
        public IEnumerable<TableIndexes> AvailableTableIndexes { get; set; }


        public void FillNeedDatas(ChessGameContext _context)
        {
            if (_context == null)
                throw new NullReferenceException(message: "DbContext must not be null");

            if (_context.Figures.Any(m => m.Id == Id))
            {
                AvailableDirection = FigureAndDirectionHelper.GetDirectionWhichNotAvailableForFigure(Id, _context);
                FigureToDirections = _context.FigureToDirections.Include(f => f.Direction).Where(m => m.FigureId == Id);
                AvailableTableIndexes = _context.TableIndexes
                    .Join(_context.FigureToIndex, index => index.Id, figureToIndex => figureToIndex.IndexId, (index, figureToIndex) => new
                    {
                        IndexId = index.Id,
                        FigureId = figureToIndex.FigureId,
                        RowIndex = index.RowIndex,
                        ColumnIndex = index.ColumnIndex
                    })
                    .Where(m => m.FigureId == Id).ToList()
                    .Select((item, index) => new TableIndexes
                        {
                            RowIndex = item.RowIndex,
                            ColumnIndex = item.ColumnIndex,
                            Id = item.IndexId
                        });
            }
            else
            {
                throw new Exception(message:"Figure is not valid");
            }
        }
        public static async Task<Figures> GetFigureFromDtoAsync(EditFigureDto editFigureDto)
        {
            Figures figure = new Figures()
            {
                Id = editFigureDto.Id,
                Name = editFigureDto.Name,
            };
            if (editFigureDto.Photo == null)
            {
                figure.Photo = editFigureDto.PreviousPhoto;
            }
            else
            {
                figure.Photo = await new ImageWriter().UploadImage(editFigureDto.Photo);
            }
            return figure;
        }
        public static EditFigureDto GetDtoFromFigure(Figures editFigure)
        {
            return new EditFigureDto()
            {
                Id = editFigure.Id,
                Name = editFigure.Name,
                PreviousPhoto = editFigure.Photo,
            };
        }
    }
}
