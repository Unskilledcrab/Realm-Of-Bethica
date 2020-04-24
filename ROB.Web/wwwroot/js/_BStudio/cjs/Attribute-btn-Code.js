$(document).ready(function(){
	var progressBarStep1 = false;
	var progressBarStep2 = false;
	var progressBarStep3 = false;
	var progressBarStep4 = false;
	var mightyLevel = "";
	var dexterousLevel = "";
	var intellectualLevel = "";
	var influentialLevel = "";
	$("#btn-mighty").click(function(){
		if(!progressBarStep1){
			progressBarStep1 = true;
			AnimateProgressBar(1, 260);
			AnimateProgressBar(11, 260);
			mightyLevel = 4;
		} else if(!progressBarStep2){
			progressBarStep2 = true;
			AnimateProgressBar(1, 195);
			AnimateProgressBar(11, 195);
			mightyLevel = 3;
		} else if(!progressBarStep3){
			progressBarStep3 = true;
			AnimateProgressBar(1, 130);
			AnimateProgressBar(11, 130);
			mightyLevel = 2;
		} else if(!progressBarStep4){
			progressBarStep4 = true;
			AnimateProgressBar(1, 65);
			AnimateProgressBar(11, 65);
			mightyLevel = 1;
		}
	});
	$("#btn-dexterous").click(function(){
		if(!progressBarStep1){
			progressBarStep1 = true;
			AnimateProgressBar(2, 260);
			AnimateProgressBar(22, 260);
			dexterousLevel = 4;
		} else if(!progressBarStep2){
			progressBarStep2 = true;
			AnimateProgressBar(2, 195);
			AnimateProgressBar(22, 195);
			dexterousLevel = 3;
		} else if(!progressBarStep3){
			progressBarStep3 = true;
			AnimateProgressBar(2, 130);
			AnimateProgressBar(22, 130);
			dexterousLevel = 2;
		} else if(!progressBarStep4){
			progressBarStep4 = true;
			AnimateProgressBar(2, 65);
			AnimateProgressBar(22, 65);
			dexterousLevel = 1;
		}
	});
	$("#btn-intellectual").click(function(){
		if(!progressBarStep1){
			progressBarStep1 = true;
			AnimateProgressBar(3, 260);
			AnimateProgressBar(33, 260);
			intellectualLevel = 4;
		} else if(!progressBarStep2){
			progressBarStep2 = true;
			AnimateProgressBar(3, 195);
			AnimateProgressBar(33, 195);
			intellectualLevel = 3;
		} else if(!progressBarStep3){
			progressBarStep3 = true;
			AnimateProgressBar(3, 130);
			AnimateProgressBar(33, 130);
			intellectualLevel = 2;
		} else if(!progressBarStep4){
			progressBarStep4 = true;
			AnimateProgressBar(3, 65);
			AnimateProgressBar(33, 65);
			intellectualLevel = 1;
		}
	});
	$("#btn-influential").click(function(){
		if(!progressBarStep1){
			progressBarStep1 = true;
			AnimateProgressBar(4, 260);
			AnimateProgressBar(44, 260);
			influentialLevel = 4;
		} else if(!progressBarStep2){
			progressBarStep2 = true;
			AnimateProgressBar(4, 195);
			AnimateProgressBar(44, 195);
			influentialLevel = 3;
		} else if(!progressBarStep3){
			progressBarStep3 = true;
			AnimateProgressBar(4, 130);
			AnimateProgressBar(44, 130);
			influentialLevel = 2;
		} else if(!progressBarStep4){
			progressBarStep4 = true;
			AnimateProgressBar(4, 65);
			AnimateProgressBar(44, 65);
			influentialLevel = 1;
		}
	});
	$("#btn-strong").click(function(){
		if(mightyLevel == 4){
			if($("#box11").css("width") == "260px"){
				AnimateProgressBar(1, 260);
				AnimateProgressBar(11, 195);
			}
		} else if(mightyLevel == 3){
			if($("#box11").css("width") == "195px"){
				AnimateProgressBar(1, 195);
				AnimateProgressBar(11, 130);
			}
		} else if(mightyLevel == 2){
			if($("#box11").css("width") == "130px"){
				AnimateProgressBar(1, 130);
				AnimateProgressBar(11, 65);
			}
		} else if(mightyLevel == 1){
			if($("#box11").css("width") == "65px"){
				AnimateProgressBar(1, 65);
				AnimateProgressBar(11, 33);
			}
		}
	});
	$("#btn-robust").click(function(){
		if(mightyLevel == 4){
			if($("#box1").css("width") == "260px"){
				AnimateProgressBar(11, 260);
				AnimateProgressBar(1, 195);
			}
		} else if(mightyLevel == 3){
			if($("#box1").css("width") == "195px"){
				AnimateProgressBar(11, 195);
				AnimateProgressBar(1, 130);
			}
		} else if(mightyLevel == 2){
			if($("#box1").css("width") == "130px"){
				AnimateProgressBar(11, 130);
				AnimateProgressBar(1, 65);
			}
		} else if(mightyLevel == 1){
			if($("#box1").css("width") == "65px"){
				AnimateProgressBar(11, 65);
				AnimateProgressBar(1, 33);
			}
		}
	});
	$("#btn-agile").click(function(){
		if(dexterousLevel == 4){
			if($("#box22").css("width") == "260px"){
				AnimateProgressBar(2, 260);
				AnimateProgressBar(22, 195);
			}
		} else if(dexterousLevel == 3){
			if($("#box22").css("width") == "195px"){
				AnimateProgressBar(2, 195);
				AnimateProgressBar(22, 130);
			}
		} else if(dexterousLevel == 2){
			if($("#box22").css("width") == "130px"){
				AnimateProgressBar(2, 130);
				AnimateProgressBar(22, 65);
			}
		} else if(dexterousLevel == 1){
			if($("#box22").css("width") == "65px"){
				AnimateProgressBar(2, 65);
				AnimateProgressBar(22, 33);
			}
		}
	});
	$("#btn-precision").click(function(){
		if(dexterousLevel == 4){
			if($("#box2").css("width") == "260px"){
				AnimateProgressBar(22, 260);
				AnimateProgressBar(2, 195);
			}
		} else if(dexterousLevel == 3){
			if($("#box2").css("width") == "195px"){
				AnimateProgressBar(22, 195);
				AnimateProgressBar(2, 130);
			}
		} else if(dexterousLevel == 2){
			if($("#box2").css("width") == "130px"){
				AnimateProgressBar(22, 130);
				AnimateProgressBar(2, 65);
			}
		} else if(dexterousLevel == 1){
			if($("#box2").css("width") == "65px"){
				AnimateProgressBar(22, 65);
				AnimateProgressBar(2, 33);
			}
		}
	});
	$("#btn-know").click(function(){
		if(intellectualLevel == 4){
			if($("#box33").css("width") == "260px"){
				AnimateProgressBar(3, 260);
				AnimateProgressBar(33, 195);
			}
		} else if(intellectualLevel == 3){
			if($("#box33").css("width") == "195px"){
				AnimateProgressBar(3, 195);
				AnimateProgressBar(33, 130);
			}
		} else if(intellectualLevel == 2){
			if($("#box33").css("width") == "130px"){
				AnimateProgressBar(3, 130);
				AnimateProgressBar(33, 65);
			}
		} else if(intellectualLevel == 1){
			if($("#box33").css("width") == "65px"){
				AnimateProgressBar(3, 65);
				AnimateProgressBar(33, 33);
			}
		}
	});
	$("#btn-head").click(function(){
		if(intellectualLevel == 4){
			if($("#box3").css("width") == "260px"){
				AnimateProgressBar(33, 260);
				AnimateProgressBar(3, 195);
			}
		} else if(intellectualLevel == 3){
			if($("#box3").css("width") == "195px"){
				AnimateProgressBar(33, 195);
				AnimateProgressBar(3, 130);
			}
		} else if(intellectualLevel == 2){
			if($("#box3").css("width") == "130px"){
				AnimateProgressBar(33, 130);
				AnimateProgressBar(3, 65);
			}
		} else if(intellectualLevel == 1){
			if($("#box3").css("width") == "65px"){
				AnimateProgressBar(33, 65);
				AnimateProgressBar(3, 33);
			}
		}
	});
	$("#btn-charismatic").click(function(){
		if(influentialLevel == 4){
			if($("#box44").css("width") == "260px"){
				AnimateProgressBar(4, 260);
				AnimateProgressBar(44, 195);
			}
		} else if(influentialLevel == 3){
			if($("#box44").css("width") == "195px"){
				AnimateProgressBar(4, 195);
				AnimateProgressBar(44, 130);
			}
		} else if(influentialLevel == 2){
			if($("#box44").css("width") == "130px"){
				AnimateProgressBar(4, 130);
				AnimateProgressBar(44, 65);
			}
		} else if(influentialLevel == 1){
			if($("#box44").css("width") == "65px"){
				AnimateProgressBar(4, 65);
				AnimateProgressBar(44, 33);
			}
		}
	});
	$("#btn-attractive").click(function(){
		if(influentialLevel == 4){
			if($("#box4").css("width") == "260px"){
				AnimateProgressBar(44, 260);
				AnimateProgressBar(4, 195);
			}
		} else if(influentialLevel == 3){
			if($("#box4").css("width") == "195px"){
				AnimateProgressBar(44, 195);
				AnimateProgressBar(4, 130);
			}
		} else if(influentialLevel == 2){
			if($("#box4").css("width") == "130px"){
				AnimateProgressBar(44, 130);
				AnimateProgressBar(4, 65);
			}
		} else if(influentialLevel == 1){
			if($("#box4").css("width") == "65px"){
				AnimateProgressBar(44, 65);
				AnimateProgressBar(4, 33);
			}
		}
	});
	$("#reset-button").click(function(){
		progressBarStep1 = false;
		progressBarStep2 = false;
		progressBarStep3 = false;
		progressBarStep4 = false;
		mightyLevel = "";
		dexterousLevel = "";
		intellectualLevel = "";
		influentialLevel = "";
		AnimateProgressBar(1, 0);
		AnimateProgressBar(11, 0);
		AnimateProgressBar(2, 0);
		AnimateProgressBar(22, 0);
		AnimateProgressBar(3, 0);
		AnimateProgressBar(33, 0);
		AnimateProgressBar(4, 0);
		AnimateProgressBar(44, 0);
		$("#btn-mighty").show();
		$("#btn-strong").hide();
		$("#btn-robust").hide();
		$("#btn-dexterous").show();
        $("#btn-agile").hide();
		$("#btn-precision").hide();
		$("#btn-intellectual").show();
        $("#btn-know").hide();
		$("#btn-head").hide();
		$("#btn-influential").show();
        $("#btn-charismatic").hide();
        $("#btn-attractive").hide();
	});
	function AnimateProgressBar(id, width) {
		$("#box" + id).animate({width: width + "px"}, 500);
	}
});

tippy('#btn-mighty', {
	content: "Mighty is your characters physical strength and toughness!",
	placement: 'top',
	arrow: false,
	maxWidth: 500,
	animateFill: true,
	theme: "sample_theme1", 
	duration: 100
	
});	

tippy('#btn-strong', {
	content: "Choose strong if you value raw power over physical toughness!",
	placement: 'top',
	arrow: true,
	maxWidth: 500,
	animateFill: true,
	theme: "sample_theme2", 
	duration: 100
	
});	

tippy('#btn-robust', {
	content: "Choose robust if you value physical toughness over raw power!",
	placement: 'bottom',
	arrow: true,
	maxWidth: 500,
	animateFill: true,
	theme: "sample_theme2", 
	duration: 100
	
});	

tippy('#btn-dexterous', {
	content: "Dexterous is your character's physical agility, hand and eye coordination.!",
	placement: 'bottom',
	arrow: true,
	maxWidth: 500,
	animateFill: true,
	theme: "sample_theme1", 
	duration: 100
	
});	

tippy('#btn-agile', {
	content: "Choose agile if you value agility over accuracy!",
	placement: 'top',
	arrow: true,
	maxWidth: 500,
	animateFill: true,
	theme: "sample_theme2", 
	duration: 100
	
});	

tippy('#btn-precision', {
	content: "Choose precise if you value accuracy over agility!",
	placement: 'bottom',
	arrow: true,
	maxWidth: 500,
	animateFill: true,
	theme: "sample_theme2", 
	duration: 100
	
});	

tippy('#btn-intellectual', {
	content: "Intellectual is your characters mental reasoning and psychic fortitude!",
	placement: 'top',
	arrow: true,
	maxWidth: 500,
	animateFill: true,
	theme: "sample_theme1", 
	duration: 100
	
});	

tippy('#btn-know', {
	content: "Choose knowledge if you value intellectual prowness over mental fortitude!",
	placement: 'top',
	arrow: true,
	maxWidth: 500,
	animateFill: true,
	theme: "sample_theme2", 
	duration: 100
	
});	

tippy('#btn-head', {
	content: "Choose headstrong if you value a strong psyche over knowledge!",
	placement: 'bottom',
	arrow: true,
	maxWidth: 500,
	animateFill: true,
	theme: "sample_theme2", 
	duration: 100
	
});	

tippy('#btn-influential', {
	content: "Influential is your characters social prowness and physical influence!",
	placement: 'bottom',
	arrow: true,
	maxWidth: 500,
	animateFill: true,
	theme: "sample_theme1", 
	duration: 100
	
});	

tippy('#btn-charismatic', {
	content: "Choose charismatic if you value social skills over phycical influence!",
	placement: 'top',
	arrow: true,
	maxWidth: 500,
	animateFill: true,
	theme: "sample_theme2", 
	duration: 100
	
});	

tippy('#btn-attractive', {
	content: "Choose attractiven if you value physical influence over social interaction!",
	placement: 'bottom',
	arrow: true,
	maxWidth: 500,
	animateFill: true,
	theme: "sample_theme2", 
	duration: 100
	
});	