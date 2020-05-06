$(document).ready(function () {
    //image animations for index page
    var shownImage = 1;
    setInterval(function () {
        $("#background_image_" + shownImage).css("opacity", "0");
        shownImage++;
        if (shownImage > 10) shownImage = 1;
        $("#background_image_" + shownImage).css("opacity", "1");
    }, 5000);
    //image animations for welcome page
    var arrayPositions = ["15% 30%", "0% 100%", "85% 30%", "100% 100%", "-2% 50%", "16% 80%", "100% 55%", "86% 77%"];
    var availableContainer = [true, true, true, true, true, true, true, true];
    var showImageThreshold = .90;
    setInterval(function () {
        arrayPositionsLength1 = arrayPositions.length;
        randomPosition1 = "";
        randomPositionIndex1 = "";
        if (availableContainer[0] && Math.random() > showImageThreshold) {
            randomPositionIndex1 = Math.floor(Math.random() * arrayPositionsLength1);
            randomPosition1 = arrayPositions[randomPositionIndex1];
            arrayPositions.splice(randomPositionIndex1, 1);
            $("#background_smallimage_1").css("background-position", randomPosition1);
            $("#background_smallimage_1").css("opacity", 1);
            availableContainer[0] = false;
            setTimeout(function () {
                $("#background_smallimage_1").css("opacity", 0);
                setTimeout(function () { availableContainer[0] = true; arrayPositions.push(randomPosition1); }, 2000);
            }, Math.ceil(Math.random() * 7000) + 3000);
        }
    }, 1000);
    setInterval(function () {
        arrayPositionsLength2 = arrayPositions.length;
        randomPosition2 = "";
        randomPositionIndex2 = "";
        if (availableContainer[1] && Math.random() > showImageThreshold) {
            randomPositionIndex2 = Math.floor(Math.random() * arrayPositionsLength2);
            randomPosition2 = arrayPositions[randomPositionIndex2];
            arrayPositions.splice(randomPositionIndex2, 1);
            $("#background_smallimage_2").css("background-position", randomPosition2);
            $("#background_smallimage_2").css("opacity", 1);
            availableContainer[1] = false;
            setTimeout(function () {
                $("#background_smallimage_2").css("opacity", 0);
                setTimeout(function () { availableContainer[1] = true; arrayPositions.push(randomPosition2); }, 2000);
            }, Math.ceil(Math.random() * 7000) + 3000);
        }
    }, 1000);
    setInterval(function () {
        arrayPositionsLength3 = arrayPositions.length;
        randomPosition3 = "";
        randomPositionIndex3 = "";
        if (availableContainer[2] && Math.random() > showImageThreshold) {
            randomPositionIndex3 = Math.floor(Math.random() * arrayPositionsLength3);
            randomPosition3 = arrayPositions[randomPositionIndex3];
            arrayPositions.splice(randomPositionIndex3, 1);
            $("#background_smallimage_3").css("background-position", randomPosition3);
            $("#background_smallimage_3").css("opacity", 1);
            availableContainer[2] = false;
            setTimeout(function () {
                $("#background_smallimage_3").css("opacity", 0);
                setTimeout(function () { availableContainer[2] = true; arrayPositions.push(randomPosition3); }, 2000);
            }, Math.ceil(Math.random() * 7000) + 3000);
        }
    }, 1000);
    setInterval(function () {
        arrayPositionsLength4 = arrayPositions.length;
        randomPosition4 = "";
        randomPositionIndex4 = "";
        if (availableContainer[3] && Math.random() > showImageThreshold) {
            randomPositionIndex4 = Math.floor(Math.random() * arrayPositionsLength4);
            randomPosition4 = arrayPositions[randomPositionIndex4];
            arrayPositions.splice(randomPositionIndex4, 1);
            $("#background_smallimage_4").css("background-position", randomPosition4);
            $("#background_smallimage_4").css("opacity", 1);
            availableContainer[3] = false;
            setTimeout(function () {
                $("#background_smallimage_4").css("opacity", 0);
                setTimeout(function () { availableContainer[3] = true; arrayPositions.push(randomPosition4); }, 2000);
            }, Math.ceil(Math.random() * 7000) + 3000);
        }
    }, 1000);
    setInterval(function () {
        arrayPositionsLength5 = arrayPositions.length;
        randomPosition5 = "";
        randomPositionIndex5 = "";
        if (availableContainer[4] && Math.random() > showImageThreshold) {
            randomPositionIndex5 = Math.floor(Math.random() * arrayPositionsLength5);
            randomPosition5 = arrayPositions[randomPositionIndex5];
            arrayPositions.splice(randomPositionIndex5, 1);
            $("#background_smallimage_5").css("background-position", randomPosition5);
            $("#background_smallimage_5").css("opacity", 1);
            availableContainer[4] = false;
            setTimeout(function () {
                $("#background_smallimage_5").css("opacity", 0);
                setTimeout(function () { availableContainer[4] = true; arrayPositions.push(randomPosition5); }, 2000);
            }, Math.ceil(Math.random() * 7000) + 3000);
        }
    }, 1000);
    setInterval(function () {
        arrayPositionsLength6 = arrayPositions.length;
        randomPosition6 = "";
        randomPositionIndex6 = "";
        if (availableContainer[5] && Math.random() > showImageThreshold) {
            randomPositionIndex6 = Math.floor(Math.random() * arrayPositionsLength6);
            randomPosition6 = arrayPositions[randomPositionIndex6];
            arrayPositions.splice(randomPositionIndex6, 1);
            $("#background_smallimage_6").css("background-position", randomPosition6);
            $("#background_smallimage_6").css("opacity", 1);
            setTimeout(function () {
                $("#background_smallimage_6").css("opacity", 0);
                setTimeout(function () { availableContainer[5] = true; arrayPositions.push(randomPosition6); }, 2000);
            }, Math.ceil(Math.random() * 7000) + 3000);
        }
    }, 1000);
    setInterval(function () {
        arrayPositionsLength7 = arrayPositions.length;
        randomPosition7 = "";
        randomPositionIndex7 = "";
        if (availableContainer[6] && Math.random() > showImageThreshold) {
            randomPositionIndex7 = Math.floor(Math.random() * arrayPositionsLength7);
            randomPosition7 = arrayPositions[randomPositionIndex7];
            arrayPositions.splice(randomPositionIndex7, 1);
            $("#background_smallimage_7").css("background-position", randomPosition7);
            $("#background_smallimage_7").css("opacity", 1);
            availableContainer[6] = false;
            setTimeout(function () {
                $("#background_smallimage_7").css("opacity", 0);
                setTimeout(function () { availableContainer[6] = true; arrayPositions.push(randomPosition7); }, 2000);
            }, Math.ceil(Math.random() * 7000) + 3000);
        }
    }, 1000);
    setInterval(function () {
        arrayPositionsLength8 = arrayPositions.length;
        randomPosition8 = "";
        randomPositionIndex8 = "";
        if (availableContainer[7] && Math.random() > showImageThreshold) {
            randomPositionIndex8 = Math.floor(Math.random() * arrayPositionsLength8);
            randomPosition8 = arrayPositions[randomPositionIndex8];
            arrayPositions.splice(randomPositionIndex8, 1);
            $("#background_smallimage_8").css("background-position", randomPosition8);
            $("#background_smallimage_8").css("opacity", 1);
            availableContainer[7] = false;
            setTimeout(function () {
                $("#background_smallimage_8").css("opacity", 0);
                setTimeout(function () { availableContainer[7] = true; arrayPositions.push(randomPosition8); }, 2000);
            }, Math.ceil(Math.random() * 7000) + 3000);
        }
    }, 1000);
    //countdown timer
    $("#countdown").countdown({
        date: "16 may 2020 08:00:00",
        format: "on"
    },

        function () {
            // callback function
        });
});

tippy('#gameDesc', {
    content: `<div class="container">
    <div class="rob-card">
        <div class="col-sm-6 col-md-4 rob-jumbotron2">
            <h3 class="text-left">Event Title<br /></h3>
            <p class="text-justify">The Great City is attacked by a mysterious serial killer who uses magic to bypass locks and defenses, brutally slaying his victims in the night. Attempts to resurrect the victims have failed, and when speak with dead has been cast the victims
                have only said “the tree” and “Orpheus.” The PCs must quickly take one of the corpses across the kingdom so that an expert necromancer may attempt to extract more information about the killer.<br /></p>
        </div>
    </div>
</div>`,
    placement: 'top',
    arrow: false,
    maxWidth: 500,
    allowHTML: true,
    animateFill: true,
    theme: "dark",
    duration: 100
});	