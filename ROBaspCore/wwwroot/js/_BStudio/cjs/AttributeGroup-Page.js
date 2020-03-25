
// Attribute Group: Each button will set the progress bar to a width of 420px.

$(document).ready(BindFunctions);

function BindFunctions() {  
  $("#btn-mighty").click(RunMightClick);
  $("#btn-dexterous").click(RunDexterousClick);
  $("#btn-intellectual").click(RunIntellectualClick);
  $("#btn-influential").click(RunInfluentialClick);

}

function RunMightClick() {  
  AnimateProgressBar("box1", "140");
  AnimateProgressBar("box11", "140");
}

function RunDexterousClick() {  
  AnimateProgressBar("box2", "105");
  AnimateProgressBar("box22", "105");
}

function RunIntellectualClick() {  
  AnimateProgressBar("box3", "70");
  AnimateProgressBar("box33", "70");
}

function RunInfluentialClick() {  
  AnimateProgressBar("box4", "35");
  AnimateProgressBar("box44", "35");
}

function AnimateProgressBar(id, width) {
  $("#" + id).animate({width: width + "px"}, 500);
}