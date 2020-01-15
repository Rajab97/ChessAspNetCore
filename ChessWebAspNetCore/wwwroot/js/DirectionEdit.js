var counter = 1;
var trueIcon = '<td style="width:10%; text-align:center; font-size:large"><i style="color:green;" class="far fa-calendar-check"></i></td>';
var falseIcon = '<td style="width:10%; text-align:center; font-size:large"><i style="color:red" class="fas fa-calendar-times"></i></td>';
var addedDestinations = [];
$(".addDescription").click(function (e) {

    e.preventDefault();
    var destinationId = parseInt($(".availableDestinations").val(), 10);

    if (destinationId != undefined && destinationId != null && Number.isInteger(destinationId)) {
        //var descriptionName = $(".availableDestinations option:selected").text();
        var rowValue = $(".availableDestinations option:selected").attr("destination-Row");
        var columnValue = $(".availableDestinations option:selected").attr("destination-Column");
        var diagonalValue = $(".availableDestinations option:selected").attr("destination-Diagonal");
        var perpendicularValue = $(".availableDestinations option:selected").attr("destination-Perpendicular");

        $(".editDirection").append('<input type="hidden" name="Descriptions" class="Descriptions" value=' + destinationId + ' />');
        $(".availableDestinations option[value='" + destinationId + "']").remove();
        addedDestinations.push(destinationId);

        var tr = '<tr destinationId="' + destinationId + '" row="new' + counter + '"></tr>'
        var tdRow = ' <td style="width:25%;" class="centeredContainer"><span class="centeredElement">' + rowValue + '</span ></td >'
        var tdColumn = ' <td style="width:25%;" class="centeredContainer"><span class="centeredElement"> ' + columnValue + '</span ></td >';


        var tdDiagonal = (diagonalValue == 'true') ? trueIcon : falseIcon;
        var tdPerpendicular = (perpendicularValue == 'true') ? trueIcon : falseIcon;
        var tdDeleteButton = '<td class="centeredContainer" style="padding:25px 0px;"><a class="btn btn-danger deleteDescription centeredElement" data-description-id="' + destinationId +'"><i class="fas fa-trash-alt"></i></a></td>';
        $(".directionTable tbody").prepend(tr);
        $(".directionTable tbody").children("tr[row='new" + counter + "']").append(tdRow + tdColumn + tdDiagonal + tdPerpendicular + tdDeleteButton)
        counter++;
    }

})






$(".directionTable").on("click", ".deleteDescription", function (e) {

    e.preventDefault();
    var button = $(this);
    var deletedDescriptionId = parseInt(button.attr("data-description-id"), 10);
    var deletedDescriptionName = $(this).parent().siblings("th").children("span").text();
    if (deletedDescriptionId != undefined && deletedDescriptionId != null && Number.isInteger(deletedDescriptionId)) {
        if (confirm("Are you sure to delete this direction")) {


            if (addedDestinations.includes(deletedDescriptionId)) {
                $(".editDirection").children("input.Descriptions[value='" + deletedDescriptionId + "']").remove();
            }
            else {
                $(".editDirection").append('<input type="hidden" name="Descriptions" value=' + -deletedDescriptionId + ' />');
            }
            //$(".availableDirections").append('<option value="' + deletedDirectionId + '">' + deletedDirectionName + '</>');
            button.parents("td").parents("tr").remove();

        }
    }
})


