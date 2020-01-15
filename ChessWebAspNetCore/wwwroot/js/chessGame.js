
var ChessFigures = [];
var ChessFigure = function (figureId, properties) {
    this.Id = parseInt(figureId);
    this.Properties = properties;
    ChessFigures.push(this);
    return this;
}

function FigureAbout() {
    this["Name"] = 'Receb';
   
}
function ClearAllDots() {
    $('.gameSquare').removeClass("filledWithOtherFigure").html("");
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
            $('.gameSquare[row="' + item.row + '"][col="' + item.col + '"]').addClass("filledWithOtherFigure");
        }
        else {
            $('.gameSquare[row="' + item.row + '"][col="' + item.col + '"]').append(greenChircleElementForIndexes);
        }
    }); 
}
$(document).ready(function () {
    var gameZoneWidth = $(".gameContainer").width();
    var squareWidthAndHeight = $(".gameSquare").width();
    $(".gameContainer").height(gameZoneWidth);
    var chessFiguresContainerWidth = $('.chessFiguresContainer').width();
    $('.chessFiguresContainer').height(chessFiguresContainerWidth);
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
       
        start: function (event, ui) {
            ClearAllDots();
            $(this).addClass('figureOnDrag');
            $(this).css(
                {
                    "transition": "box-shadow .3s linear ,width .3s ease,height .3s ease"
                });
            $(this).css({
                width: squareWidthAndHeight,
                height: squareWidthAndHeight

            })
        },
        stop: function (event, ui) {
            $(this).removeClass('figureOnDrag');
        },
    });
    $(".droppable").droppable({
        drop: function (event, ui) {

            var figureId = ui.draggable[0].attributes['figure-id'].value;
            $(ui.draggable[0]).on('dblclick', function (e) {
                var figureId = e.delegateTarget.attributes['figure-id'].value;
                var data = {
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
                        ShowPossibleIndexesForCurrentFigure(e.possibleIndexes)
                    },
                    failure: function (response) {
                        console.log(response);
                    },
                    error: function (response) {
                        console.log(response);
                    }

                })
            });
            if (IsFigureCoordinatesExist(figureId)) {
                var existedFigure = GetChessElementById(figureId);
                existedFigure.Properties.Row = event.target.attributes['row'].value;
                existedFigure.Properties.Col = event.target.attributes['col'].value;
                console.log(ChessFigures);
            }
            else {
                var newFigure = new ChessFigure(figureId, { Row: parseInt(event.target.attributes['row'].value), Col: parseInt(event.target.attributes['col'].value) });
            }

            
         
            fillContainerWithCurrentFigure(event.target, ui.draggable[0]);
             
        },
        accept: '.draggable' 
    });

});



function fillContainerWithCurrentFigure(container, figure) {
    var left = $(container).offset().left
    var top = $(container).offset().top
    $(figure).css(
        {
            "transition":"all .3s linear"


        });
    $(figure).offset({ top: top, left: left })

}
function IsFigureCoordinatesExist(figureId) {
    var result = false;
    ChessFigures.forEach(function (item, index) {
        if (item.Id == figureId) {
            result = true;
        }
    })
    return result;
}
function GetChessElementById(figureId) {
    var result = undefined;
    ChessFigures.forEach(function (item, index) {
        if (item.Id == figureId) {
            result = item;
        }
    })
    return result;
}
$(window).resize(function () {
    var gameZoneWidth = $(".gameContainer").width();
    $(".gameContainer").height(gameZoneWidth);


});