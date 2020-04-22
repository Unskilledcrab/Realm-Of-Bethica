$(document).ready(function(){
    var shownImage = 1;
    setInterval(function(){
        $("#background_image_" + shownImage).css("opacity", "0");
        shownImage++;
        if(shownImage > 10) shownImage = 1;
        $("#background_image_" + shownImage).css("opacity", "1");
    }, 5000);
});