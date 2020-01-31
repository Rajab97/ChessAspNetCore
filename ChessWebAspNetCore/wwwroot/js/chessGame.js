
var ChessFigures = [];
var ChessFigure = function (itemId, figureId, properties,whiteOrBlack) {
    this.itemId = parseInt(itemId);
    this.Id = parseInt(figureId);
    this.Properties = properties;
    this.WhiteOrBlack = whiteOrBlack;
    ChessFigures.push(this);
    return this;
}




var PreviousPositionOfFigure = null;
var DraggedFigure = null;
var ChessFigureDetails = null;
var countOfDamagedFiguresOfPlayerFirst = 0;
var countOfDamagedFiguresOfPlayerSecond = 0;
var WhichPlayersTurn = true;
$(document).ready(function () {
    var gameZoneWidth = $(".gameContainer").width();
    var squareWidthAndHeight = $(".gameSquare").width();
    $(".gameContainer").height(gameZoneWidth);

    var allFigures = $(".chessFigures");
    var whiteTeamCounter = 0;
    var blackTeamCounter = 0;
    for (var i = 0; i < allFigures.length; i++) {
        $(allFigures[i]).css({
            width: squareWidthAndHeight,
            height: squareWidthAndHeight,
        }).removeClass("displayNone")
        if ($(allFigures[i]).hasClass("whiteTeam")) {
            FillPlayerSidesWithFiguresWhenGameStart($(".playerOneSide"), allFigures[i], whiteTeamCounter + 1 ,false)
            whiteTeamCounter++;
        }
        else if ($(allFigures[i]).hasClass("blackTeam")) {
            FillPlayerSidesWithFiguresWhenGameStart($(".playerSecondSide"), allFigures[i], blackTeamCounter + 1, false)
            blackTeamCounter++;
        }
       
        

    }
    //Table daki fiqurlari oz xanalarina doldurur
 

    //var chessFiguresContainerWidth = $('.chessFiguresContainer').width();
    //$('.chessFiguresContainer').height(chessFiguresContainerWidth);
    //$('.figureOnTheDesk').on('dblclick', function (e) {
    //    var figureId = e.delegateTarget.attributes['figure-id'].value;
    //    var data = {
    //        CurrentFigureId: parseInt(figureId),
    //        ChessFigures: ChessFigures
    //    };
    //    var jsonData = JSON.stringify(data);


    //    $.ajax({
    //        url: "/API/ChessGame/",
    //        method: "POST",
    //        contentType: "application/json; charset=utf-8",
    //        dataType: "json",
    //        data: jsonData,
    //        success: function (e) {
    //            ShowPossibleIndexesForCurrentFigure(e.possibleIndexes)
    //        },
    //        failure: function (response) {
    //            console.log(response);
    //        },
    //        error: function (response) {
    //            console.log(response);
    //        }

    //    })
    //});


    $(".draggable").draggable({
        revert: 'invalid',
        start: function (event, ui) {
            $(this).addClass('figureOnDrag');

            PreviousPositionOfFigure = { top: $(ui.helper[0]).offset().top, left: $(ui.helper[0]).offset().left };
            DraggedFigure = ui.helper[0];
            ClearAllDots();

            $(this).css(
                {
                    "transition": "box-shadow .3s linear ,width .3s ease,height .3s ease"
                });

            if ($(ui.helper[0]).hasClass("activePlayer")) {
                
                var itemId = parseInt($(ui.helper[0]).attr("currentItemId"));
                var figureId = parseInt($(ui.helper[0]).attr("figure-id"));
                ShowPossibleIndexes(itemId, figureId);
            }
        },
        stop: function (event, ui) {
            $(this).removeClass('figureOnDrag');
        },
    });

    $(".droppable").droppable({
        drop: function (event, ui) {

            if ($(ui.draggable[0]).hasClass("activePlayer")) {
                var figureId = ui.draggable[0].attributes['figure-id'].value;
                var itemId = ui.draggable[0].attributes['currentItemId'].value;
                CheckIndexForCurrentFigure(figureId, itemId, ChessFigures, event.target.attributes['row'].value, event.target.attributes['col'].value);

                //else {
                //    var newFigure = new ChessFigure(itemId,figureId, { Row: parseInt(event.target.attributes['row'].value), Col: parseInt(event.target.attributes['col'].value) });
                //}
                fillContainerWithCurrentFigure({ top: $(event.target).offset().top, left: $(event.target).offset().left }, ui.draggable[0]);
            }
            else {
                fillContainerWithCurrentFigure(PreviousPositionOfFigure, DraggedFigure)
            }
        },
        accept: '.draggable' 
    });

    $(".StartGame").click(function (e) {
        e.preventDefault();
        FillTableWithFiguresWhenGameStart();
        $(this).fadeOut();
        $(".chessFigures.blackTeam").removeClass("activePlayer");
    })
});


function CheckIndexForCurrentFigure(figureId, itemId, allChessFiguresWithTableIndexes, newRowIndex , newColumnIndex) {

    var data = {
        CurrentItemId: parseInt(itemId),
        CurrentFigureId: parseInt(figureId),
        NewTableIndexForFigure: { Row: parseInt(newRowIndex), Col: parseInt(newColumnIndex) },
        ChessFigures: allChessFiguresWithTableIndexes
    };
    var jsonData = JSON.stringify(data);

    var result = false;
    $.ajax({
        url: "/API/CheckStateOfFigure/",
        method: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: jsonData,
        success: function (e) {
            if (e.result == true) {
                if (IsFigureCoordinatesExist(itemId)) {
                    var existedFigure = GetChessElementById(itemId);
                    existedFigure.Properties.Row = parseInt(newRowIndex);
                    existedFigure.Properties.Col = parseInt(newColumnIndex);
                    var ElementInNewIndex = $('.chessFigures[rowId="' + newRowIndex + '"][columnId="' + newColumnIndex + '"]')
                    if (ElementInNewIndex.length != 0 && $(ElementInNewIndex[0]).hasClass("opponentFigure")) {
                        var indexOfDeletedFigureInGlobalArray = null
                        ChessFigures.forEach(function (item, index) {
                            var currentItemId = $(ElementInNewIndex[0]).attr("currentItemId")
                            if (item.itemId == parseInt(currentItemId)) {
                                indexOfDeletedFigureInGlobalArray = index;
                            }
                        })
                        if (Number.isInteger(indexOfDeletedFigureInGlobalArray)) {
                            if (ChessFigures[indexOfDeletedFigureInGlobalArray].WhiteOrBlack == true) {
                                FillPlayerSidesWithFiguresWhenGameStart($(".playerOneSide"), $(ElementInNewIndex[0]),  countOfDamagedFiguresOfPlayerFirst + 1,true)
                                countOfDamagedFiguresOfPlayerFirst++;
                            }
                            else {
                                FillPlayerSidesWithFiguresWhenGameStart($(".playerSecondSide"), $(ElementInNewIndex[0]), countOfDamagedFiguresOfPlayerSecond + 1,true)
                                countOfDamagedFiguresOfPlayerSecond++;
                            }
                            $(ElementInNewIndex[0]).removeAttr("rowId").removeAttr("columnId").removeAttr("columnId").removeAttr("figure-id").removeAttr("currentItemId");
                            ChessFigures.splice(indexOfDeletedFigureInGlobalArray, 1);

                        }
                    }

                    var currentFigure = $('.chessFigures[currentItemId="' + itemId + '"]');
                    currentFigure.attr("rowId", parseInt(newRowIndex))
                    currentFigure.attr("columnId", parseInt(newColumnIndex))
                   
                    $('.chessFigures').removeClass("activePlayer");
                    if (WhichPlayersTurn) {
                        WhichPlayersTurn = false;
                        $('.chessFigures.blackTeam').addClass("activePlayer");
                    }
                    else {
                        WhichPlayersTurn = true;
                        $('.chessFigures.whiteTeam').addClass("activePlayer");
                    }
                }
            }
            else {
                fillContainerWithCurrentFigure(PreviousPositionOfFigure, DraggedFigure);
            }
            ClearAllDots();
        },
        failure: function (response) {
            console.log(response);
        },
        error: function (response) {
            console.log(response);
        }

    })

    console.log("Result is " + result);
}  

function FillPlayerSidesWithFiguresWhenGameStart(container, element, positionIndex, animate) {
    var containerWidth = $(container).width();
    var numberOfElementsForOneRow = Math.floor(containerWidth / $(element).width());
    var top = Math.floor(positionIndex / (numberOfElementsForOneRow + 0.1)) * $(element).height();
    var left = ((positionIndex - 1) % numberOfElementsForOneRow) * $(element).width();
    if (animate) {
        $(element).css({ "position": "absolute", "transition": "all 0s ease 0s"}).animate({
            top: top,
            left: left,
        }, 2000);
    }
    else {
        $(element).css({
            position: "absolute",
            top: top,
            left: left
        })
    }
   
}

function FillTableWithFiguresWhenGameStart() {
    var allFigures = $(".chessFigures");

   
    var squareWidthAndHeight = $(".gameSquare").width();


    for (var i = 0; i < allFigures.length; i++) {
        var columnId = $(allFigures[i]).attr("columnId");
        var rowId = $(allFigures[i]).attr("rowId");
        $(allFigures[i]).css({
            width: squareWidthAndHeight,
            height: squareWidthAndHeight,
        })
        $(allFigures[i]).removeClass("displayNone");

        //Move figure to table
        fillContainerWithCurrentFigureWhenGameStart($('.gameSquare[row="' + rowId + '"][col="' + columnId + '"]'), allFigures[i]);

        //Add each figure to array of indexes of current figures
        var figureId = $(allFigures[i]).attr("figure-id");
        var itemId = $(allFigures[i]).attr("currentItemId");
        new ChessFigure(itemId, figureId, { Row: parseInt($(allFigures[i]).attr("rowId")), Col: parseInt($(allFigures[i]).attr("columnId")) }, $(allFigures[i]).hasClass("whiteTeam"));

        //Add double click to figures
        $(allFigures[i]).on('dblclick', function (e) {
            if ($(this).hasClass("activePlayer")) {
                var figureId = e.delegateTarget.attributes['figure-id'].value;
                var itemId = e.delegateTarget.attributes['currentItemId'].value;

                //GlobalVariables
                PreviousPositionOfFigure = { top: $(this).offset().top, left: $(this).offset().left };
                DraggedFigure = this;
                ChessFigureDetails = ChessFigures.find(m => m.itemId == parseInt(itemId))

                ShowPossibleIndexes(itemId, figureId);
            }
            
        });

    }
   
}
function ShowPossibleIndexes(itemId, figureId) {
    var data = {
        CurrentItemId: parseInt(itemId),
        CurrentFigureId: parseInt(figureId),
        ChessFigures: ChessFigures
    };
    var jsonData = JSON.stringify(data);


    $.ajax({
        url: "/API/ChessGame/",
        method: "POST",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        data: jsonData,
        success: function (e) {
            if (e != null || e != undefined) {
                ShowPossibleIndexesForCurrentFigure(e.possibleIndexes)
            }
        },
        failure: function (response) {
            console.log(response);
        },
        error: function (response) {
            console.log(response);
        }

    })
}

function FigureAbout() {
    this["Name"] = 'Receb';

}

function ClearAllDots() {
    $('.gameSquare').removeClass("filledWithOtherFigure").removeClass("active").html("");
    $('.chessFigures').removeClass("opponentFigure");
}

function CheckLocation(row, col) {
    var result = false;
    ChessFigures.forEach(function (item, index) {
        if (item.Properties.Row == row && item.Properties.Col == col) {
            result = true;
        }
    });
    return result;
}

function ShowPossibleIndexesForCurrentFigure(possibleIndexesArray) {
    ClearAllDots();

    var greenChircleElementForIndexes = '<div class="centeredElement greenChircleElement"></div>'
    possibleIndexesArray.forEach(function (item, index) {
        if (CheckLocation(item.row, item.col)) {
            $('.chessFigures[rowId="' + item.row + '"][columnId="' + item.col + '"]').addClass("opponentFigure");
            $('.gameSquare[row="' + item.row + '"][col="' + item.col + '"]').addClass("filledWithOtherFigure");
        }
        else {
            
            $('.gameSquare[row="' + item.row + '"][col="' + item.col + '"]').append(greenChircleElementForIndexes);
        }
        $('.gameSquare[row="' + item.row + '"][col="' + item.col + '"]').addClass("active");
    });
}

function fillContainerWithCurrentFigureWhenGameStart(container, figure) {
        var left = $(container).offset().left - $(figure).parent().offset().left
        var top = $(container).offset().top - $(figure).parent().offset().top
    
        $(figure).css({ "position": "absolute" }).animate({
            top: top,
            left: left,
        }, 2000);
}

function fillContainerWithCurrentFigure(position, figure) {

    $(figure).css(
        {
            "transition":"all .3s linear"


        });
    $(figure).offset({ top: position.top, left: position.left })
   
}

function IsFigureCoordinatesExist(itemId) {
    var result = false;
    ChessFigures.forEach(function (item, index) {
        if (item.itemId == itemId) {
            result = true;
        }
    })
    return result;
}

function GetChessElementById(itemId) {
    var result = undefined;
    ChessFigures.forEach(function (item, index) {
        if (item.itemId == itemId) {
            result = item;
        }
    })
    return result;
}

$(window).resize(function () {
    var gameZoneWidth = $(".gameContainer").width();
    $(".gameContainer").height(gameZoneWidth);


});

$(".gameContainer ").on("click", ".active", function (e) {
    ClearAllDots();
    var newRowIndex = parseInt($(e.currentTarget).attr('row'));
    var newColumnIndex = parseInt($(e.currentTarget).attr('col'));

    var newPosition = { top: $(e.currentTarget).offset().top, left: $(e.currentTarget).offset().left }
    fillContainerWithCurrentFigure(newPosition, DraggedFigure);
    CheckIndexForCurrentFigure(ChessFigureDetails.Id, ChessFigureDetails.itemId, ChessFigures, newRowIndex, newColumnIndex);

})

