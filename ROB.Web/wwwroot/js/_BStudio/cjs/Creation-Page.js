$(document).ready(function(){
	var pos1;
	var pos2;
	var pos3;
	var smallScreen;
	setupPage();
	$("#btn-next").click(function(){
		nextCharacter();
	});
	$("#btn-previous").click(function(){
		prevCharacter();
	});
	$(window).resize(function(){
		setupPage();
	});
	function setupPage(){
		$("#archetype1_img, #archetype2_img, #archetype3_img").css({"transition": "all 0s ease 0s", "transform": "none", "display": "inline", "opacity": "1.0"});
		smallScreen = false;
		step = 1;
		$("#archetype1_img, #archetype3_img").css("transform", "scale(0.75,0.75)");
		setTimeout(function(){
			$("#archetype1_img, #archetype2_img, #archetype3_img").css("transition", "transform 1s");
		}, 50);
		populateCharacterData(2);
		if($(document).width() > 1197){
			pos1 = 274.015625;
			pos2 = 650.671875;
			pos3 = 1027.328125;
		} else if($(document).width() > 989){
			pos1 = 103.515625;
			pos2 = 420.171875;
			pos3 = 736.828125;
		} else if($(document).width() > 765){
			pos1 = 132.015625;
			pos2 = 368.671875
			pos3 = 605.328125;
		} else {
			smallScreen = true;
			$("#archetype1_img, #archetype2_img, #archetype3_img").css("transform", "none");
			$("#archetype1_img, #archetype3_img").css("display", "none");
		}
	}
	function nextCharacter(){
		if(step == 1){
			if(!smallScreen){
				$("#archetype1_img").css({"z-index": 3000, transform: "translateX(" + (pos2-pos1) + "px) scale(1.0,1.0)"});
				$("#archetype2_img").css({"z-index": 2000, transform: "translateX(" + (pos3-pos2) + "px) scale(0.75,0.75)"});
				$("#archetype3_img").css({"z-index": 1000, transform: "translateX(-" + (pos3-pos1) + "px) scale(0.75,0.75)"});
			} else {
				$("#archetype2_img").animate({"opacity": "0"},1000,function(){ $("#archetype2_img").css("display", "none"); $("#archetype1_img").css({"opacity": "0", "display": "block"}); $("#archetype1_img").animate({"opacity": "1.0"}, 1000)});
			}
			populateCharacterData(1);
			step = 2;
		} else if(step == 2){
			if(!smallScreen){
				$("#archetype1_img").css({"z-index": 2000, transform: "translateX(" + (pos3-pos1) + "px) scale(0.75,0.75)"});
				$("#archetype2_img").css({"z-index": 1000, transform: "translateX(-" + (pos2-pos1) + "px) scale(0.75,0.75)"});
				$("#archetype3_img").css({"z-index": 3000, transform: "translateX(-" + (pos2-pos1) + "px) scale(1.0,1.0)"});
			} else {
				$("#archetype1_img").animate({"opacity": "0"},1000,function(){ $("#archetype1_img").css("display", "none"); $("#archetype3_img").css({"opacity": "0", "display": "block"}); $("#archetype3_img").animate({"opacity": "1.0"}, 1000)});
			}
			populateCharacterData(3);
			step = 3;
		} else if(step == 3){
			if(!smallScreen){
				$("#archetype1_img").css({"z-index": 1000, transform: "translateX(" + 0 + "px) scale(0.75,0.75)"});
				$("#archetype2_img").css({"z-index": 3000, transform: "translateX(" + 0 + "px) scale(1.0,1.0)"});
				$("#archetype3_img").css({"z-index": 2000, transform: "translateX(-" + 0 + "px) scale(0.75,0.75)"});
			} else {	
				$("#archetype3_img").animate({"opacity": "0"},1000,function(){ $("#archetype3_img").css("display", "none"); $("#archetype2_img").css({"opacity": "0", "display": "block"}); $("#archetype2_img").animate({"opacity": "1.0"}, 1000)});
			}
			populateCharacterData(2);
			step = 1;
		}
	}
	function prevCharacter(){
		if(step == 1){
			if(!smallScreen){
				$("#archetype1_img").css({"z-index": 1000, transform: "translateX(" + (pos3-pos1) + "px) scale(0.75,0.75)"});
				$("#archetype2_img").css({"z-index": 2000, transform: "translateX(-" + (pos2-pos1) + "px) scale(0.75,0.75)"});
				$("#archetype3_img").css({"z-index": 3000, transform: "translateX(-" + (pos3-pos2) + "px) scale(1.0,1.0)"});
			} else {
				$("#archetype2_img").animate({"opacity": "0"},1000,function(){ $("#archetype2_img").css("display", "none"); $("#archetype3_img").css({"opacity": "0", "display": "block"}); $("#archetype3_img").animate({"opacity": "1.0"}, 1000)});
			}
			populateCharacterData(3);
			step = 3;
		} else if(step == 2){
			if(!smallScreen){
				$("#archetype1_img").css({"z-index": 2000, transform: "translateX(" + 0 + "px) scale(0.75,0.75)"});
				$("#archetype2_img").css({"z-index": 3000, transform: "translateX(" + 0 + "px) scale(1.0,1.0)"});
				$("#archetype3_img").css({"z-index": 1000, transform: "translateX(" + 0 + "px) scale(0.75,0.75)"});
			} else {
				$("#archetype1_img").animate({"opacity": "0"},1000,function(){ $("#archetype1_img").css("display", "none"); $("#archetype2_img").css({"opacity": "0", "display": "block"}); $("#archetype2_img").animate({"opacity": "1.0"}, 1000)});
			}
			populateCharacterData(2);
			step = 1;
		} else if(step == 3){
			if(!smallScreen){
				$("#archetype1_img").css({"z-index": 3000, transform: "translateX(" + (pos2-pos1) + "px) scale(1.0,1.0)"});
				$("#archetype2_img").css({"z-index": 1000, transform: "translateX(" + (pos3-pos2) + "px) scale(0.75,0.75)"});
				$("#archetype3_img").css({"z-index": 2000, transform: "translateX(-" + (pos3-pos1) + "px) scale(0.75,0.75)"});
			} else {
				$("#archetype3_img").animate({"opacity": "0"},1000,function(){ $("#archetype3_img").css("display", "none"); $("#archetype1_img").css({"opacity": "0", "display": "block"}); $("#archetype1_img").animate({"opacity": "1.0"}, 1000)});
			}
			populateCharacterData(1);
			step = 2;
		}
	}
	function populateCharacterData(characterNumber){
		$("#Charname").text($("#archetype" + characterNumber + "_img").attr("data-name"));
		$("#CharLevel").text($("#archetype" + characterNumber + "_img").attr("data-level"));
		$("#CharLevelNumber").text($("#archetype" + characterNumber + "_img").attr("data-levelnumber"));
		$("#CharRace").text($("#archetype" + characterNumber + "_img").attr("data-race"));
		$("#CharProf").text($("#archetype" + characterNumber + "_img").attr("data-profession"));
	}
});