using ChessWebAspNetCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChessWebAspNetCore.Helpers;
using Microsoft.EntityFrameworkCore;

namespace ChessWebAspNetCore.Helpers
{
    public class PlayChess
    {
        public readonly Figures CurrentFigure;
        public readonly ChessFigure CurrentChessFigure;
        public readonly IEnumerable<FigureToDirections> AvailableDirections;
        private readonly ChessGameContext context;
        private readonly ChessGameInput chessGameInput;
        public PlayChess(ChessGameContext _context ,ChessGameInput chessGameInput)
        {
            CurrentFigure = _context.Figures.FirstOrDefault(m => m.Id == chessGameInput.CurrentFigureId);
            AvailableDirections = _context.FigureToDirections.Where(m => m.FigureId == chessGameInput.CurrentFigureId);
            CurrentChessFigure = chessGameInput.ChessFigures.FirstOrDefault(m => m.itemId == chessGameInput.CurrentItemId);
            this.chessGameInput = chessGameInput;
            context = _context;
        }

        public List<FigureIndex> GetPossibleIndexesInChessTable()
        {
            List<FigureIndex> result = new List<FigureIndex>();
            List<DirectionDescription> Descriptions = GetAvailableDescriptions();

            foreach (DirectionDescription item in Descriptions)
            {
                if (item.PerpendicularMovement == false && item.DiagonalMovement == false && (item.RowStep != 0 || item.ColumnStep != 0))
                    MoveWithOnlyColAndRowInputs(item.RowStep, item.ColumnStep, ref result);
                else
                {
                    if (item.DiagonalMovement == true && item.RowStep == 0 && item.ColumnStep == 0)
                        MoveDiagonally(CurrentChessFigure.Properties, ref result);
                    if (item.PerpendicularMovement == true && item.RowStep == 0 && item.ColumnStep == 0)
                        MovePerpendicularly(CurrentChessFigure.Properties, ref result);
                }
            }
            return result;
        }

        private void MoveWithOnlyColAndRowInputs(short? rowStep, short? colStep, ref List<FigureIndex> result)
        {
            //Check if next position in the chess table index
            if ((CurrentChessFigure.Properties.Row + rowStep <= 8 && CurrentChessFigure.Properties.Row + rowStep > 0) && (CurrentChessFigure.Properties.Col + colStep <= 8 && CurrentChessFigure.Properties.Col + colStep > 0))
            {
                FigureIndex figureIndex = FigureIndex.CreateInstance(CurrentChessFigure.Properties.Row + rowStep, CurrentChessFigure.Properties.Col + colStep);
                //var figuresAndIndex = context.FigureToIndex.Include(m => m.Figure).Join(
                //    context.TableIndexes,
                //        i => i.IndexId,
                //            ti => ti.Id,
                //                (index, tableIndex) => new {
                //                    Figure = index.Figure,
                //                    Row = tableIndex.RowIndex,
                //                    Col = tableIndex.ColumnIndex
                //                }).FirstOrDefault(m =>
                //                    m.Row == figureIndex.Row && m.Col == figureIndex.Col);

                var figuresAndIndex = chessGameInput.ChessFigures.FirstOrDefault(m => m.Properties.Row == figureIndex.Row && m.Properties.Col == figureIndex.Col);
                if (figuresAndIndex == null || (figuresAndIndex.WhiteOrBlack != CurrentChessFigure.WhiteOrBlack))
                {
                    result.Add(figureIndex);
                }
                
            }
           
        }

        private void MovePerpendicularly(FigureIndex currentFigureIndex, ref List<FigureIndex> result)
        {
            byte counterForPossibility = 1;
            byte counterForStepUp = 1;
            List<bool> fourDirectionPermission = new List<bool>()
            {
                true, //Up
                true, //Right
                true, //Down
                true //Left
            };
            while (counterForPossibility > 0)
            {
                counterForPossibility = 0;

                if (fourDirectionPermission[0] == true && currentFigureIndex.Row + counterForStepUp <= 8)
                {
                    var figuresAndIndex = chessGameInput.ChessFigures.FirstOrDefault(m => m.Properties.Row == currentFigureIndex.Row + counterForStepUp && m.Properties.Col == currentFigureIndex.Col);
                    if (figuresAndIndex == null)
                    {
                        AddFigureIndexInIteration(currentFigureIndex.Row + counterForStepUp, currentFigureIndex.Col, ref counterForPossibility, ref result);
                    }
                    else if(figuresAndIndex.WhiteOrBlack != CurrentChessFigure.WhiteOrBlack)
                    {
                        fourDirectionPermission[0] = false;
                        AddFigureIndexInIteration(currentFigureIndex.Row + counterForStepUp, currentFigureIndex.Col, ref counterForPossibility, ref result);
                    }
                    else
                    {
                        fourDirectionPermission[0] = false;
                    }
                }
                if (fourDirectionPermission[2] == true && currentFigureIndex.Row - counterForStepUp > 0)
                {
                    var figuresAndIndex = chessGameInput.ChessFigures.FirstOrDefault(m => m.Properties.Row == currentFigureIndex.Row - counterForStepUp && m.Properties.Col == currentFigureIndex.Col);
                    if (figuresAndIndex == null)
                    {
                        AddFigureIndexInIteration(currentFigureIndex.Row - counterForStepUp, currentFigureIndex.Col, ref counterForPossibility, ref result);
                    }
                    else if (figuresAndIndex.WhiteOrBlack != CurrentChessFigure.WhiteOrBlack)
                    {
                        fourDirectionPermission[2] = false;
                        AddFigureIndexInIteration(currentFigureIndex.Row - counterForStepUp, currentFigureIndex.Col, ref counterForPossibility, ref result);
                    }
                    else
                    {
                        fourDirectionPermission[2] = false;
                    }
                }
                if (fourDirectionPermission[3] == true && currentFigureIndex.Col - counterForStepUp > 0)
                {
                    var figuresAndIndex = chessGameInput.ChessFigures.FirstOrDefault(m => m.Properties.Row == currentFigureIndex.Row && m.Properties.Col == currentFigureIndex.Col - counterForStepUp);
                    if (figuresAndIndex == null)
                    {
                        AddFigureIndexInIteration(currentFigureIndex.Row, currentFigureIndex.Col - counterForStepUp, ref counterForPossibility, ref result);
                    }
                    else if (figuresAndIndex.WhiteOrBlack != CurrentChessFigure.WhiteOrBlack)
                    {
                        fourDirectionPermission[3] = false;
                        AddFigureIndexInIteration(currentFigureIndex.Row, currentFigureIndex.Col - counterForStepUp, ref counterForPossibility, ref result);
                    }
                    else
                    {
                        fourDirectionPermission[3] = false;
                    }
                }
                if (fourDirectionPermission[1] == true && currentFigureIndex.Col + counterForStepUp <= 8)
                {
                    var figuresAndIndex = chessGameInput.ChessFigures.FirstOrDefault(m => m.Properties.Row == currentFigureIndex.Row && m.Properties.Col == currentFigureIndex.Col + counterForStepUp);
                    if (figuresAndIndex == null)
                    {
                        AddFigureIndexInIteration(currentFigureIndex.Row, currentFigureIndex.Col + counterForStepUp, ref counterForPossibility, ref result);
                    }
                    else if (figuresAndIndex.WhiteOrBlack != CurrentChessFigure.WhiteOrBlack)
                    {
                        fourDirectionPermission[1] = false;
                        AddFigureIndexInIteration(currentFigureIndex.Row, currentFigureIndex.Col + counterForStepUp, ref counterForPossibility, ref result);
                    }
                    else
                    {
                        fourDirectionPermission[1] = false;
                    }
                }
                counterForStepUp++;
            }
        }
        private void MoveDiagonally(FigureIndex currentFigureIndex, ref List<FigureIndex> result)
        {
            //bu deyishen vasitesi ile yoxlayiramki helede istiqametler uzre hereket elemek mumkundur
            byte counterForPossibility = 1;
            byte counterForStepUp = 1;
            List<bool> fourDirectionPermission = new List<bool>()
            {
                true, //UpRight
                true, //DownRight
                true, //DownLeft
                true //UpLeft
            };

            while (counterForPossibility > 0)
            {
                counterForPossibility = 0;
                if (fourDirectionPermission[0]==true && currentFigureIndex.Row + counterForStepUp <= 8 && currentFigureIndex.Col + counterForStepUp <= 8)
                {
                    var figuresAndIndex = chessGameInput.ChessFigures.FirstOrDefault(m => m.Properties.Row == currentFigureIndex.Row + counterForStepUp && m.Properties.Col == currentFigureIndex.Col + counterForStepUp);
                    if (figuresAndIndex == null)
                    {
                        AddFigureIndexInIteration(currentFigureIndex.Row + counterForStepUp, currentFigureIndex.Col + counterForStepUp, ref counterForPossibility, ref result);
                    }
                    else if (figuresAndIndex.WhiteOrBlack != CurrentChessFigure.WhiteOrBlack)
                    {
                        fourDirectionPermission[0] = false;
                        AddFigureIndexInIteration(currentFigureIndex.Row + counterForStepUp, currentFigureIndex.Col + counterForStepUp, ref counterForPossibility, ref result);
                    }
                    else
                    {
                        fourDirectionPermission[0] = false;
                    }
                }
                if (fourDirectionPermission[2] == true && currentFigureIndex.Row - counterForStepUp > 0 && currentFigureIndex.Col - counterForStepUp > 0)
                {
                    var figuresAndIndex = chessGameInput.ChessFigures.FirstOrDefault(m => m.Properties.Row == currentFigureIndex.Row - counterForStepUp && m.Properties.Col == currentFigureIndex.Col - counterForStepUp);
                    if (figuresAndIndex == null)
                    {
                        AddFigureIndexInIteration(currentFigureIndex.Row - counterForStepUp, currentFigureIndex.Col - counterForStepUp, ref counterForPossibility, ref result);
                    }
                    else if (figuresAndIndex.WhiteOrBlack != CurrentChessFigure.WhiteOrBlack)
                    {
                        fourDirectionPermission[2] = false;
                        AddFigureIndexInIteration(currentFigureIndex.Row - counterForStepUp, currentFigureIndex.Col - counterForStepUp, ref counterForPossibility, ref result);
                    }
                    else
                    {
                        fourDirectionPermission[2] = false;
                    }
                }
                if (fourDirectionPermission[3] == true && currentFigureIndex.Row + counterForStepUp <= 8 && currentFigureIndex.Col - counterForStepUp > 0)
                {
                    var figuresAndIndex = chessGameInput.ChessFigures.FirstOrDefault(m => m.Properties.Row == currentFigureIndex.Row + counterForStepUp && m.Properties.Col == currentFigureIndex.Col - counterForStepUp);
                    if (figuresAndIndex == null)
                    {
                        AddFigureIndexInIteration(currentFigureIndex.Row + counterForStepUp, currentFigureIndex.Col - counterForStepUp, ref counterForPossibility, ref result);
                    }
                    else if (figuresAndIndex.WhiteOrBlack != CurrentChessFigure.WhiteOrBlack)
                    {
                        fourDirectionPermission[3] = false;
                        AddFigureIndexInIteration(currentFigureIndex.Row + counterForStepUp, currentFigureIndex.Col - counterForStepUp, ref counterForPossibility, ref result);
                    }
                    else
                    {
                        fourDirectionPermission[3] = false;
                    }
                }
                if (fourDirectionPermission[1] == true && currentFigureIndex.Row - counterForStepUp > 0 && currentFigureIndex.Col + counterForStepUp <= 8)
                {
                    var figuresAndIndex = chessGameInput.ChessFigures.FirstOrDefault(m => m.Properties.Row == currentFigureIndex.Row - counterForStepUp && m.Properties.Col == currentFigureIndex.Col + counterForStepUp);
                    if (figuresAndIndex == null)
                    {
                        AddFigureIndexInIteration(currentFigureIndex.Row - counterForStepUp, currentFigureIndex.Col + counterForStepUp, ref counterForPossibility, ref result);
                    }
                    else if (figuresAndIndex.WhiteOrBlack != CurrentChessFigure.WhiteOrBlack)
                    {
                        fourDirectionPermission[1] = false;
                        AddFigureIndexInIteration(currentFigureIndex.Row - counterForStepUp, currentFigureIndex.Col + counterForStepUp, ref counterForPossibility, ref result);
                    }
                    else
                    {
                        fourDirectionPermission[1] = false;
                    }
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
