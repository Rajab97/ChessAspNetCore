var counter = 1;
var addedDirections = [];
$(".addDirection").click(function (e) {

    e.preventDefault();
    var directionId = parseInt($(".availableDirections").val(), 10);

    if (directionId != undefined && directionId != null && Number.isInteger(directionId)) {
        var directionName = $(".availableDirections option:selected").text();

        $(".editFigure").append('<input type="hidden" name="Directions" class="Directions" value=' + directionId + ' />');
        $(".availableDirections option[value='" + directionId + "']").remove();
        addedDirections.push(directionId);

        var tr = '<tr directionId="' + directionId + '" row="new' + counter + '"></tr>'
        var th = '<th scope="row" class="centeredContainer"><span class="centeredElement">' + directionName + '</span></th>'
        var td = ' <td class="centeredContainer" style="padding:25px 0px;">  <a class="btn btn-danger deleteDirection centeredElement" data-direction-id="' + directionId + '">  <i class="fas fa-trash-alt"></i>  </a>  </td>';

        $(".directionTable tbody").append(tr);
        $(".directionTable tbody").children("tr[row='new" + counter + "']").append(th + td)
        counter++;
    }

})

$(".directionTable").on("click", ".deleteDirection", function (e) {

    e.preventDefault();
    var button = $(this);
    var deletedDirectionId = parseInt(button.attr("data-direction-id"), 10);
    var deletedDirectionName = $(this).parent().siblings("th").children("span").text();
    if (deletedDirectionId != undefined && deletedDirectionId != null && Number.isInteger(deletedDirectionId)) {
        if (confirm("Are you sure to delete this direction")) {


            if (addedDirections.includes(deletedDirectionId)) {
                $(".editFigure").children("input.Directions[value='" + deletedDirectionId + "']").remove();
            }
            else {
                $(".editFigure").append('<input type="hidden" name="Directions" value=' + -deletedDirectionId + ' />');
            }
            $(".availableDirections").append('<option value="' + deletedDirectionId + '">'+ deletedDirectionName +'</>');
            button.parents("td").parents("tr").remove();

        }
    }
})


