
var RowColumnPairs = [];
$(document).ready(function () {
    var addIndexCounter = 1;

    //Add Indexes to Form And Table
    $('.AddIndexToFigure').click(function (e) {
        e.preventDefault();
        var RowIndex = $('#RowIndex').val();
        var ColumnIndex = $('#ColumnIndex').val();

        if ((RowIndex < 0 || RowIndex > 8) || (ColumnIndex < 0 || ColumnIndex > 8)) {
            alert("Index is not valid.");
            return;
        }
        var tableRow = '<tr rowId="' + addIndexCounter + '" rowIndex="' + RowIndex + '" columnIndex = "' + ColumnIndex + '"></tr>';
        var tableTdRow = '<td style="text-align:center;" class="centeredContainer"><span class="centeredElement">' + RowIndex + '</span></td>';
        var tableTdColumn = '<td style="text-align:center;" class="centeredContainer"><span class="centeredElement">' + ColumnIndex + '</span></td>';
        var tableTdButton = '<td class="centeredContainer" style="padding:25px 0px;"><a href="#" inputId="' + addIndexCounter+'"  class="RemoveIndex centeredElement btn btn-danger" >Remove</a></td>';
        var AddedIndexTable = $('.AddedIndexesTable');
        AddedIndexTable.children('tbody').append(tableRow);
        AddedIndexTable.children('tbody').children('tr[rowId="' + addIndexCounter + '"]').append(tableTdRow).append(tableTdColumn).append(tableTdButton);
        var AddedFormInput = '<input rowId = "' + addIndexCounter + '" class="Indexes" name="Indexes" type="hidden" value="' + RowIndex + "-" + ColumnIndex + '"/>'

        var searchInputElement = $('.FigureForm .Indexes[value="' + RowIndex + "-" + ColumnIndex + '"]');
        console.log(searchInputElement);
        if (searchInputElement.length != 0) {
            $(searchInputElement).remove();
        }
        else {
            $(".FigureForm").append(AddedFormInput);
            RowColumnPairs.push(RowIndex + "-" + ColumnIndex)
        }
        
        
        addIndexCounter++;
    })
  
 

})

$(".AddedIndexesTable").on("click", ".RemoveIndex", function (e) {
    e.preventDefault();
    var Id = $(this).parent('td').parent('tr').attr('rowId');
    var RowIndex = $(this).parent('td').parent('tr').attr('rowIndex');
    var ColumnIndex = $(this).parent('td').parent('tr').attr('columnIndex');

    var indexOfElement = RowColumnPairs.indexOf(RowIndex + "-" + ColumnIndex)
    if (indexOfElement > -1) {
        var inputId = parseInt($(this).attr("inputId"), 10);
        if (inputId != undefined && inputId != null) {
            $('.FigureForm .Indexes[rowId="' + inputId + '"]').remove();
        }
        RowColumnPairs.splice(indexOfElement, 1);
        $('.AddedIndexesTable tbody tr[rowId="' + Id + '"]').remove();
    }
    else {
        var AddedFormInput = '<input class="Indexes" name="Indexes" type="hidden" value="' + RowIndex + "-" + ColumnIndex + '"/>';
        $(".FigureForm").append(AddedFormInput);
        $('.AddedIndexesTable tbody tr[rowId="' + Id + '"]').remove();
    }
    

})
