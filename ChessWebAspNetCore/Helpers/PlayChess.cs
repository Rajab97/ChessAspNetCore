using ChessWebAspNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChessWebAspNetCore.Helpers;
namespace ChessWebAspNetCore.Helpers
{
    public class PlayChess
    {
        public readonly Figures CurrentFigure;
        public readonly FigureIndex CurrentFigureIndex;
        public readonly IEnumerable<FigureToDirections> AvailableDirections;
        private readonly ChessGameContext context; 
        public PlayChess(ChessGameContext _context , int figureId,FigureIndex figureIndex)
        {
            CurrentFigure = _context.Figures.FirstOrDefault(m => m.Id == figureId);
            AvailableDirections = _context.FigureToDirections.Where(m => m.FigureId == figureId);
            CurrentFigureIndex = figureIndex;
            context = _context;
        }

        public List<FigureIndex> GetPossibleIndexesInChessTable()
        {
            List<FigureIndex> result = new List<FigureIndex>();
            List<DirectionDescription> Descriptions = GetAvailableDescriptions();

            foreach (DirectionDescription item in Descriptions)
            {
                if (item.PerpendicularMovement == false && item.DiagonalMovement == false && (item.RowStep != 0 || item.ColumnStep != 0))
                    MoveWithOnlyColAndRowInputs(CurrentFigureIndex, item.RowStep, item.ColumnStep, ref result);
                else
                {
                    if (item.DiagonalMovement == true && item.RowStep == 0 && item.ColumnStep == 0)
                        MoveDiagonally(CurrentFigureIndex, ref result);
                    if (item.PerpendicularMovement == true && item.RowStep == 0 && item.ColumnStep == 0)
                        MovePerpendicularly(CurrentFigureIndex, ref result);
                }
            }
            return result;
        }

        private void MoveWithOnlyColAndRowInputs(FigureIndex currentFigureIndex, short? rowStep, short? colStep, ref List<FigureIndex> result)
        {
            //Check if next position in the chess table index
            if ((currentFigureIndex.Row + rowStep <= 8 && currentFigureIndex.Row + rowStep > 0) && (currentFigureIndex.Col + colStep <= 8 && currentFigureIndex.Col + colStep > 0))
            {
                result.Add(FigureIndex.CreateInstance(currentFigureIndex.Row + rowStep,currentFigureIndex.Col + colStep));
            }
           
        }

        private void MovePerpendicularly(FigureIndex currentFigureIndex, ref List<FigureIndex> result)
        {
            byte counterForPossibility = 1;
            byte counterForStepUp = 1;
            while (counterForPossibility > 0)
            {
                counterForPossibility = 0;
                if (currentFigureIndex.Row + counterForStepUp <= 8)
                {
                    AddFigureIndexInIteration(currentFigureIndex.Row + counterForStepUp, currentFigureIndex.Col, ref counterForPossibility, ref result);
                }
                if (currentFigureIndex.Row - counterForStepUp > 0)
                {
                    AddFigureIndexInIteration(currentFigureIndex.Row - counterForStepUp, currentFigureIndex.Col, ref counterForPossibility, ref result);
                }
                if (currentFigureIndex.Col - counterForStepUp > 0)
                {
                    AddFigureIndexInIteration(currentFigureIndex.Row, currentFigureIndex.Col - counterForStepUp, ref counterForPossibility, ref result);
                }
                if (currentFigureIndex.Col + counterForStepUp <= 8)
                {
                    AddFigureIndexInIteration(currentFigureIndex.Row, currentFigureIndex.Col + counterForStepUp, ref counterForPossibility, ref result);
                }
                counterForStepUp++;
            }
        }
        private void MoveDiagonally(FigureIndex currentFigureIndex, ref List<FigureIndex> result)
        {
            //bu deyishen vasitesi ile yoxlayiramki helede istiqametler uzre hereket elemek mumkundur
            byte counterForPossibility = 1;
            byte counterForStepUp = 1;
            while (counterForPossibility > 0)
            {
                counterForPossibility = 0;
                if (currentFigureIndex.Row + counterForStepUp <= 8 && currentFigureIndex.Col + counterForStepUp <= 8)
                {
                    AddFigureIndexInIteration(currentFigureIndex.Row + counterForStepUp, currentFigureIndex.Col + counterForStepUp,ref counterForPossibility, ref result);
                }
                if (currentFigureIndex.Row - counterForStepUp > 0 && currentFigureIndex.Col - counterForStepUp > 0)
                {
                    AddFigureIndexInIteration(currentFigureIndex.Row - counterForStepUp, currentFigureIndex.Col - counterForStepUp, ref counterForPossibility, ref result);
                }
                if (currentFigureIndex.Row + counterForStepUp <= 8 && currentFigureIndex.Col - counterForStepUp > 0)
                {
                    AddFigureIndexInIteration(currentFigureIndex.Row + counterForStepUp, currentFigureIndex.Col - counterForStepUp, ref counterForPossibility, ref result);
                }
                if (currentFigureIndex.Row - counterForStepUp > 0 && currentFigureIndex.Col + counterForStepUp <= 8)
                {
                    AddFigureIndexInIteration(currentFigureIndex.Row - counterForStepUp, currentFigureIndex.Col + counterForStepUp, ref counterForPossibility, ref result);
                }
                counterForStepUp++;
            }



           
        }

        private List<DirectionDescription> GetAvailableDescriptions()
        {
            List<DirectionDescription> descriptions = new List<DirectionDescription>();
            foreach (FigureToDirections item in AvailableDirections)
            {
                List<DirectionToDescription> directionToDescriptions = context.DirectionToDescription.Where(m => m.DirectionId == item.DirectionId).ToList();
                if (directionToDescriptions != null && directionToDescriptions.Count > 0)
                {
                    foreach (DirectionToDescription direction in directionToDescriptions)
                    {
                        IEnumerable<DirectionDescription> currentDescriptions = context.DirectionDescription.Where(m => m.Id == direction.DescriptionId);
                        descriptions.AddRange(currentDescriptions);
                    }
                    
                }
               
            }
            return descriptions;
        }
        private void AddFigureIndexInIteration(int? row, int? col,ref byte counter, ref List<FigureIndex> resultList)
        {
            resultList.Add(FigureIndex.CreateInstance(row, col));
            counter++;
        }
    }
}
