// changes the archetype images.

$(document).ready(function(){
  $("#btn-next").click(function(){
    $("#archetype1_img").attr("src", "Archetypes-Page/arcantist_male_w800.png");
      $("#archetype2_img").attr("src", "Archetypes-Page/priest_female_w800.png");
      $("#archetype3_img").attr("src", "Archetypes-Page/fighter_male_w800.png");
  });
});

$(document).ready(function(){
  $("#btn-previous").click(function(){
        $("#archetype3_img").attr("src", "shared/CharacterForm-200.png");
      $("#archetype2_img").attr("src", "shared/CharacterForm-200.png");
      $("#archetype1_img").attr("src", "shared/CharacterForm-350.png");
  });
});

