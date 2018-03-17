$(document).ready(function () {
    showCookiesWarning();
});

function showCookiesWarning() {
    setTimeout(function () {
        $("#cookies-warning").addClass("show")
    }, 1000);

    $("#cookies-warning i").bind("click tap", function () {
        $("#cookies-warning").removeClass("show");
    });
}