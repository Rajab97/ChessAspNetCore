// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
/* show file value after file select */

$('.inputFileContainer .placeHolderContainer').click(function (e) {
    e.preventDefault();
    $(this).siblings('input[type="file"]').change(function (e) {

        var filename = e.target.files[0].name;
        $(this).siblings(".placeHolderContainer").children(".filePlaceHoler").text(filename)
    })
    $(this).siblings("input").click();
})
