//Attribute Class: OnClick width will change to listed valies below.

$(document).ready(BindFunctions);

function BindFunctions() {  
  $("#btn-strong").click(RunStrongClick);
  $("#btn-robust").click(RunRobustClick);
  $("#btn-agile").click(RunAgileClick);
  $("#btn-precision").click(RunPrecisionClick);
  $("#btn-know").click(RunKnowClick);
  $("#btn-head").click(RunHeadClick);
  $("#btn-charismatic").click(RunCharismaticClick);
  $("#btn-attractive").click(RunAttractiveClick);
}

function RunRobustClick() {  
  AnimateProgressBar("box1", "105");
  AnimateProgressBar("box11", "140");
}

function RunStrongClick() {
  AnimateProgressBar("box1", "140");
  AnimateProgressBar("box11", "105");
}

function RunAgileClick() {  
  AnimateProgressBar("box2", "105");
  AnimateProgressBar("box22", "70");
}

function RunPrecisionClick() {  
  AnimateProgressBar("box2", "70");
  AnimateProgressBar("box22", "105");
}

function RunKnowClick() {  
  AnimateProgressBar("box3", "70");
  AnimateProgressBar("box33", "35");
}

function RunHeadClick() {  
  AnimateProgressBar("box3", "35");
  AnimateProgressBar("box33", "70");
}

function RunCharismaticClick() {  
  AnimateProgressBar("box4", "35");
  AnimateProgressBar("box44", "17");
}

function RunAttractiveClick() {  
  AnimateProgressBar("box4", "17");
  AnimateProgressBar("box44", "35");
}

function AnimateProgressBar(id, width) {
  $("#" + id).animate({width: width + "px"}, 500);
}