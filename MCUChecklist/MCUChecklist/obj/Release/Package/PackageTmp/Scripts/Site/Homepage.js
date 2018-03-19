$(document).ready(function () {
    addTileBackgrounds();
    addHomepageClickHandlers();
});

function addHomepageClickHandlers() {
    $("#header .search-bar input").on('keyup', function () {
        var matcher = new RegExp($(this).val(), 'gi');
        $('.tile').show().not(function () {
            return matcher.test($(this).find('.top span').text())
        }).hide();
    });

    $(".username").bind("click tap", function () {
        $("#user-dropdown").toggleClass("show");
    });
}

function addTileBackgrounds() {
    $(".tile .background-image").each(function () {
        $(this).css("background-image", "url(" + $(this).data("background") + ")");
    });
}