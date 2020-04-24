


//reveals attributes class buttons
$(document).ready(function () {
    hideAttr()
    $("#btn-mighty").click(function () {
        $("#btn-mighty").hide();
        $("#btn-strong").show();
        $("#btn-robust").show();
    });

    $("#btn-dexterous").click(function () {
        $("#btn-dexterous").hide();
        $("#btn-agile").show();
        $("#btn-precision").show();
    });

    $("#btn-intellectual").click(function () {
        $("#btn-intellectual").hide();
        $("#btn-know").show();
        $("#btn-head").show();
    });

    $("#btn-influential").click(function () {
        $("#btn-influential").hide();
        $("#btn-charismatic").show();
        $("#btn-attractive").show();
    });

    });

    //reveals attributes class buttons
$(document).ready(function () {
    $("#btn-mighty").click(function () {
        $("#btn-mighty").css("color", "gray");
    });

    $("#btn-dexterous").click(function () {
        $("#btn-dexterous").css("color", "gray");
    });

    $("#btn-intellectual").click(function () {
        $("#btn-intellectual").css("color", "gray");
    });

    $("#btn-influential").click(function () {
        $("#btn-influential").css("color", "gray");
    });

});

// Hides attribute class buttons
function hideAttr(){ 
    $("#btn-strong").hide();
    $("#btn-robust").hide();
    $("#btn-agile").hide();
    $("#btn-precision").hide();
    $("#btn-know").hide();
    $("#btn-head").hide();
    $("#btn-charismatic").hide();
    $("#btn-attractive").hide();
}

    





