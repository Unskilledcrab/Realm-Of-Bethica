$(document).ready(function () {
    resetButton();
});

function buttonClicked(buttonID) {
    buttonID2 = "#" + buttonID;
    simpleID = buttonID.replace("Button", "");
    $(buttonID2).toggleClass("btn-secondary");
    $(buttonID2).toggleClass("btn-primary");
    $(buttonID2).prop("disabled", true);

    if (statIncrement == 1) {
        document.getElementById(simpleID).value = 10;
        pairedValue = 8;
        statIncrement += 1;
    }
    else if (statIncrement == 2) {
        document.getElementById(simpleID).value = 8;
        pairedValue = 6;
        statIncrement += 1;
    }
    else if (statIncrement == 3) {
        document.getElementById(simpleID).value = 6;
        pairedValue = 4;
        statIncrement += 1;
    }
    else if (statIncrement == 4) {
        document.getElementById(simpleID).value = 4;
        pairedValue = 2;
        statIncrement += 1;
    }

    if (buttonID === "strongButton") {
        $('#robustButton').toggleClass("btn-secondary");
        $('#robustButton').toggleClass("btn-info");
        $('#robustButton').prop("disabled", true);
        document.getElementById("robust").value = pairedValue;
    }
    else if (buttonID === "robustButton") {
        $('#strongButton').toggleClass("btn-secondary");
        $('#strongButton').toggleClass("btn-info");
        $('#strongButton').prop("disabled", true);
        document.getElementById("strong").value = pairedValue;
    }
    else if (buttonID === "agileButton") {
        $('#precisionButton').toggleClass("btn-secondary");
        $('#precisionButton').toggleClass("btn-info");
        $('#precisionButton').prop("disabled", true);
        document.getElementById("precision").value = pairedValue;
    }
    else if (buttonID === "precisionButton") {
        $('#agileButton').toggleClass("btn-secondary");
        $('#agileButton').toggleClass("btn-info");
        $('#agileButton').prop("disabled", true);
        document.getElementById("agile").value = pairedValue;
    }
    else if (buttonID === "knowledgeableButton") {
        $('#headstrongButton').toggleClass("btn-secondary");
        $('#headstrongButton').toggleClass("btn-info");
        $('#headstrongButton').prop("disabled", true);
        document.getElementById("headstrong").value = pairedValue;
    }
    else if (buttonID === "headstrongButton") {
        $('#knowledgeableButton').toggleClass("btn-secondary");
        $('#knowledgeableButton').toggleClass("btn-info");
        $('#knowledgeableButton').prop("disabled", true);
        document.getElementById("knowledgeable").value = pairedValue;
    }
    else if (buttonID === "charismaticButton") {
        $('#attractiveButton').toggleClass("btn-secondary");
        $('#attractiveButton').toggleClass("btn-info");
        $('#attractiveButton').prop("disabled", true);
        document.getElementById("attractive").value = pairedValue;
    }
    else if (buttonID === "attractiveButton") {
        $('#charismaticButton').toggleClass("btn-secondary");
        $('#charismaticButton').toggleClass("btn-info");
        $('#charismaticButton').prop("disabled", true);
        document.getElementById("charismatic").value = pairedValue;
    }

    if (statIncrement === 5)
        $('#submitButton').prop("disabled", false);
}

function resetButton() {
    // Reactivate all of the buttons
    $('#strongButton').prop("disabled", false);
    $('#robustButton').prop("disabled", false);
    $('#agileButton').prop("disabled", false);
    $('#precisionButton').prop("disabled", false);
    $('#knowledgeableButton').prop("disabled", false);
    $('#headstrongButton').prop("disabled", false);
    $('#charismaticButton').prop("disabled", false);
    $('#attractiveButton').prop("disabled", false);

    // Reset the color for all of the buttons
    $('#strongButton').addClass("btn-secondary");
    $('#strongButton').removeClass("btn-primary");
    $('#strongButton').removeClass("btn-info");
    $('#robustButton').addClass("btn-secondary");
    $('#robustButton').removeClass("btn-primary");
    $('#robustButton').removeClass("btn-info");
    $('#agileButton').addClass("btn-secondary");
    $('#agileButton').removeClass("btn-primary");
    $('#agileButton').removeClass("btn-info");
    $('#precisionButton').addClass("btn-secondary");
    $('#precisionButton').removeClass("btn-primary");
    $('#precisionButton').removeClass("btn-info");
    $('#knowledgeableButton').addClass("btn-secondary");
    $('#knowledgeableButton').removeClass("btn-primary");
    $('#knowledgeableButton').removeClass("btn-info");
    $('#headstrongButton').addClass("btn-secondary");
    $('#headstrongButton').removeClass("btn-primary");
    $('#headstrongButton').removeClass("btn-info");
    $('#charismaticButton').addClass("btn-secondary");
    $('#charismaticButton').removeClass("btn-primary");
    $('#charismaticButton').removeClass("btn-info");
    $('#attractiveButton').addClass("btn-secondary");
    $('#attractiveButton').removeClass("btn-primary");
    $('#attractiveButton').removeClass("btn-info");

    statIncrement = 1;
    $('#submitButton').prop("disabled", true);
}