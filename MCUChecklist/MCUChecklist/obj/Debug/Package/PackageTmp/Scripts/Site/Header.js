$(document).ready(function () {
    addHeaderClickHandlers();
});

function addHeaderClickHandlers() {
    $("#header .search-button").bind("click tap", function () {
        $("#header .header-middle.search").addClass("show");
        $("#header .search-bar input").focus();
    });

    $("#header .search .close").bind("click tap", function () {
        $("#header .header-middle.search").removeClass("show");
        $("#header .search-bar input").val("").keyup();
    });
}