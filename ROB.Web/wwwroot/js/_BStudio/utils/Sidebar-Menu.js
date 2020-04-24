var originalSidebarWidth = $("#sidebar-wrapper").css("width");
var originalBodyHeight = $("body").css("height");
var selected_parentskills = "";
var selected_childskills = "";
var selected_techniques = "";
var selected_talents = "";
$(document).ready(function(){
    var parentSkill = [
        ["", [
            ["Artisan", "", "An Artisan, also sometimes called a Craftsman, is a skilled manual worker who makes items that may be functional or strictly decorative including but not limited to weapons, armor, clothing, jewelry, household items, and tools. They can also craft certain special items to be used later for magical purposes. Artisans practice a craft and may through experience and aptitude, reach the advanced levels of a master Artisan or master Craftsman."],
            ["Athletics", "", "The Athletics skill represents a character’s general level of physical fitness, which allows them to perform feats of Dexterity and Strength such as climbing, acrobatics, tightrope walking, gymnastic somersaults, leaps, and falls."],
            ["Awareness", "", "The Awareness skill allows a Player Character to use their natural senses to perceive something that would normally not be noticed, whether it is through sight, smell, taste, or hearing."],
            ["Knowledge", "", "This parent skill gives the PC a familiarity, awareness, or understanding of someone, something, or somewhere with facts, information, descriptions, or the skills to execute it."],
            ["Nature", "", "This parent skill gives the Player general knowledge about anything that deals with the land such as finding their way through a wilderness area, the ability to recognize natural dangers and hazards, whether from the land, plants, or creatures. The Player Character gains the ability to know and deals with natural creatures.  Plus, PC’s are able to navigate and travel the land as well as living off the land."],
            ["Social", "", "This is a charismatic skill that influences the thoughts and moods of others. This is achieved through the words and actions of the Player Character."],
            ["Subterfuge", "", "This skill involves being deceitful, cunning and stealthy. Player Characters with this parent skill can use trickery, guile and other dishonest means in an effort to achieve specific goals."],
            ["Melee Weapons", "", "This parent skill includes all types of hand-held melee weapons like swords, maces, spears, clubs, daggers, shields, pole-arms, ball-and-chain, etc. The Player Character, although not an expert, can wield any of these.  These are a few examples. Other types of melee weapons can be used contingent upon the GM’s approval."],
            ["Range Weapons", "", "This parent skill includes all manners of range weapon types like; short & longbows, light & heavy crossbows, thrown daggers & thrown axes, javelins & spears, etc. These are a few examples."]
        ]]
    ];
    var childSkill = [
        ["Artisan", [
            ["Artist", "", "This skill gives the PC the ability to produce works of fine art such as drawings, paintings, and sculptures."],
            ["Blacksmith", "", "The indicated skill allows the PC to create objects from wrought iron or steel by forging the metal using tools to hammer, bend, cut & form the material. Blacksmiths produce objects such as gates, grilles, railings, light fixtures, furniture, sculptures, tools, agricultural implements, decorative and religious items, cooking utensils, and weapons."],
            ["Bowyer", "", "With this skill the PC can create bow weaponry such as short bows, longbows, crossbows and greatbows."]
        ]],
        ["Athletics", [
            ["Acrobatics", "", "The indicated skill gives the PC the ability to perform extraordinary feats like somersaults, rolls, and twists. This ability allows the PC to avoid falling damage of up to 4 squares if a successful acrobatic feat roll is made."],
            ["Balance", "", "Such a skill gives the PC the ability to maintain their balance and coordination in moving through or over unstable or uneven surfaces."],
            ["Climbing", "", "The indicated skill gives the PC the ability to climb up, down, and across slopes, surfaces, walls, or other surfaces that have handholds. Climbing speed is twenty-five percent of their normal movement rate."]
        ]]
    ];
    var techniques = [
        ["Arcane", [
            ["Arcane Condition I", "(Prerequisite: Spell Focus | Plus an additional 20 points of Mana burn)", "This capability will allow a spell caster to place a ward, glyph, or rune in a set location that will trigger itself under predetermine conditions set by the spell caster. Once placed, the caster will cast a spell on it, and it will remain dormant until the conditions are met, touched, moved or the duration has expired. The duration is 24 hours plus one additional 24 hours period per level of the caster. Once it is triggered, it will release whatever spell that the caster placed on it."],
            ["Arcane Condition II", "(Prerequisite: Arcane Condition I | Plus an additional 20 points of Mana burn)", "The same as arcane condition I but the duration infinite until triggered."],
            ["Arcane Recipe", "(Prerequisite: Spell Focus)", "This technique will allow the spellcaster to create their own material components at half the cost. See \"Material Components\" on page 106 for more detailed information about material components."]
        ]],
        ["Clergy", [
            ["Enhanced Remove Affliction", "(Prerequisite: Remove Affliction)", "This technique gives the PC a +5 bonus when performing the remove affliction talent versus poisons and diseases."],
            ["Arcane Condition II", "(Prerequisite: Arcane Condition I | Plus an additional 20 points of Mana burn)", "The same as arcane condition I but the duration infinite until triggered."],
            ["Enhanced Holy Damage", "(Prerequisite: Bless Item)", "This capability adds an additional +2 DV modifier to the bless item talent."]
        ]]
    ];
    var talents = [
        ["The Beast Master", [
            ["Animal Empathy", "(Prerequisite: None)", "This talent can improve the attitude of the animal and may lead to the animal trusting the beast master. Benefit: Have the animal make a RES save versus the PC’s SOC.<br/>The PC will add an additional +1 per level to their SOC when attempting this.<br/>Note - The beast master will retain said talent for life. It’s an ability that can also be used to obtain an animal companion."],
            ["Call of the Wild I", "(Prerequisite: Animal Empathy)", "Around the time of adolescence (between the ages of 12 to 15), some beings feel an innate call from the wild and feel as if they are kindred spirits of the beasts that roam therein. Those who answer the hail find themselves developing a spiritual bond with a specific creature. Such bonds are for life, and the benefits are lost to both should either die. The newly formed pair also tend to live longer than normal, characters live to be quite old for their race, and the animal companions also live extended lives even as long as the their masters in some cases."],
            ["Call of the Wild II", "(Prerequisites: Animal Empathy | Call of the Wild)", "The bond the PC shares with their companion deepens; both gains increased strength, speed, and fortitude.<br/>Benefit: The duo (character and companion) gain a +2 to their strength, and Fortitude scores, and increase their sprinting/flying/swimming speed by 25%."]
        ]],
        ["The Blackguard", [
            ["Ascendance", "(Prerequisite: Stealth | Prowl | Fade)", "While in shade form the blackguard can start to climb surfaces spider-like. When using this capability, the blackguard will receive an additional +2 FV plus 1 per level to their climbing chance when trying to traverse an area surface."],
            ["Dark Sight", "(Prerequisite: Fade, Mergence or Slip)", "This talent will be included when a player chooses either the fade, mergence or slip talent. This talent gives the player the ability to see in total darkness for 5 squares plus two additional squares per experience level. See dark vision on pg.-207. If the player naturally has dark vision, then their natural vision will override this."],
            ["Death Strike", "(Prerequisite: Stealth | Prowl | Fade | Ascendance | Evade)", "This is a devastating attack with the potential to cripple or more so; kill your opponent with one single strike. This deadly attack is limited to melee combat only (never range combat). During melee combat, the PC will assume shade form, and upon a successful to-hit roll the PC may increase their overflow damage factor by .50 if 4 MHP per phased is used or 1.00 if 8 MHP per phase is used."]
        ]],
    ];
    $("#menu-toggle_1").click(function(){
        var documentWidth = $(document).width();
        if(documentWidth > 1400){
            $("#sidebar-wrapper").css({"width": "25%", "padding": "15px"});
        } else if(documentWidth > 1200){
            $("#sidebar-wrapper").css({"width": "50%", "padding": "15px"});
        } else if(documentWidth > 768){
            $("#sidebar-wrapper").css({"width": "70%", "padding": "15px"});
        } else {
            $("#sidebar-wrapper").css({"width": "90%", "padding": "15px"});
        }
        parentSkill.forEach(function(value1, index1){
            $("#data_container").append("<div id='parentSkill" + index1 + "'>
</div>");
            value1[1].forEach(function(value2, index2){
                $("#parentSkill" + index1).append("<div>
<input type='checkbox' class='profession_checkbox parentskills_checkbox' name='" + value2[0] + "' value='" + value2[0] + "'/>
<h2 class='profession_data_h2'>" + value2[0] + "</h2>
<p class='profession_data_p_sub'>" + value2[2] + "</p>
</div>"); 
            });
        });
        $("#sidebar-wrapper_title").text("Parent");
        $(".profession_data_p_sub").css("display", "none");
        $("body").append("<div id='sidebar-wrapper-open' style='width:100%;height:" + originalBodyHeight + ";z-index:1000;position:absolute;top:0;left:0;'>
</div>");
        $("#sidebar-wrapper").css("z-index", 2000);
        $("#sidebar-wrapper_title, #data_container").css("display", "block");
        $(".Separator-1").css("display", "flex");
        $(".sidebar-wrapper-innercontainer").append("<span id='close_sidebar'>Close&times;</span>
<div id='sidebar_icons'>
<i id='reset_icon' class='fa fa-undo'>
</i>
<i id='close_icon' class='fa fa-times'>
</i>
</div>");
        var selected_parentskills_Array = selected_parentskills.split(", ");
        selected_parentskills_Array.forEach(function(value){
            $(".parentskills_checkbox[value='" + value + "']").prop("checked", true);
        });
    });
    $("#menu-toggle_2").click(function(){
        var documentWidth = $(document).width();
        if(documentWidth > 1400){
            $("#sidebar-wrapper").css({"width": "25%", "padding": "15px"});
        } else if(documentWidth > 1200){
            $("#sidebar-wrapper").css({"width": "50%", "padding": "15px"});
        } else if(documentWidth > 768){
            $("#sidebar-wrapper").css({"width": "70%", "padding": "15px"});
        } else {
            $("#sidebar-wrapper").css({"width": "90%", "padding": "15px"});
        }
        childSkill.forEach(function(value1, index1){
            $("#data_container").append("<div id='childSkill" + index1 + "'>
<h1 class='profession_data_h1'>" + value1[0] + "</h1>
</div>");
            value1[1].forEach(function(value2, index2){
                $("#childSkill" + index1).append("<div>
<input type='checkbox' class='profession_checkbox childskills_checkbox' name='" + value2[0] + "' value='" + value2[0] + "'/>
<h2 class='profession_data_h2'>" + value2[0] + "</h2>
<p class='profession_data_p_sub'>" + value2[2] + "</p>
</div>"); 
            });
        });
        $("#sidebar-wrapper_title").text("Child-Skills");
        $(".profession_data_h2, .profession_checkbox, .profession_data_p_sub").css("display", "none");
        $("body").append("<div id='sidebar-wrapper-open' style='width:100%;height:" + originalBodyHeight + ";z-index:1000;position:absolute;top:0;left:0;'>
</div>");
        $("#sidebar-wrapper").css("z-index", 2000);
        $("#sidebar-wrapper_title, #data_container").css("display", "block");
        $(".Separator-1").css("display", "flex");
        $(".sidebar-wrapper-innercontainer").append("<span id='close_sidebar'>Close&times;</span>
<div id='sidebar_icons'>
<i id='reset_icon' class='fa fa-undo'>
</i>
<i id='close_icon' class='fa fa-times'>
</i>
</div>");
        var selected_childskills_Array = selected_childskills.split(", ");
        selected_childskills_Array.forEach(function(value){
            $(".childskills_checkbox[value='" + value + "']").prop("checked", true);
        });
    });
    $("#menu-toggle_3").click(function(){
        var documentWidth = $(document).width();
        if(documentWidth > 1400){
            $("#sidebar-wrapper").css({"width": "25%", "padding": "15px"});
        } else if(documentWidth > 1200){
            $("#sidebar-wrapper").css({"width": "50%", "padding": "15px"});
        } else if(documentWidth > 768){
            $("#sidebar-wrapper").css({"width": "70%", "padding": "15px"});
        } else {
            $("#sidebar-wrapper").css({"width": "90%", "padding": "15px"});
        }
        techniques.forEach(function(value1, index1){
            $("#data_container").append("<div id='techniques" + index1 + "'>
<h1 class='profession_data_h1'>" + value1[0] + "</h1>
</div>");
            value1[1].forEach(function(value2, index2){
                $("#techniques" + index1).append("<div>
<input type='checkbox' class='profession_checkbox techniques_checkbox' name='" + value2[0] + "' value='" + value2[0] + "'/>
<h2 class='profession_data_h2'>" + value2[0] + "</h2>
<p class='requisites_data_p_sub'>" + value2[1] + "</p>
<p class='profession_data_p_sub'>" + value2[2] + "</p>
</div>"); 
            });
        });
        $("#sidebar-wrapper_title").text("Techniques");
        $(".profession_data_h2, .profession_checkbox, .requisites_data_p_sub, .profession_data_p_sub").css("display", "none");
        $("body").append("<div id='sidebar-wrapper-open' style='width:100%;height:" + originalBodyHeight + ";z-index:1000;position:absolute;top:0;left:0;'>
</div>");
        $("#sidebar-wrapper").css("z-index", 2000);
        $("#sidebar-wrapper_title, #data_container").css("display", "block");
        $(".Separator-1").css("display", "flex");
        $(".sidebar-wrapper-innercontainer").append("<span id='close_sidebar'>Close&times;</span>
<div id='sidebar_icons'>
<i id='reset_icon' class='fa fa-undo'>
</i>
<i id='close_icon' class='fa fa-times'>
</i>
</div>");
        var selected_techniques_Array = selected_techniques.split(", ");
        selected_techniques_Array.forEach(function(value){
            $(".techniques_checkbox[value='" + value + "']").prop("checked", true);
        });
    });
    $("#menu-toggle_4").click(function(){
        var documentWidth = $(document).width();
        if(documentWidth > 1400){
            $("#sidebar-wrapper").css({"width": "25%", "padding": "15px"});
        } else if(documentWidth > 1200){
            $("#sidebar-wrapper").css({"width": "50%", "padding": "15px"});
        } else if(documentWidth > 768){
            $("#sidebar-wrapper").css({"width": "70%", "padding": "15px"});
        } else {
            $("#sidebar-wrapper").css({"width": "90%", "padding": "15px"});
        }
        talents.forEach(function(value1, index1){
            $("#data_container").append("<div id='talents" + index1 + "'>
<h1 class='profession_data_h1'>" + value1[0] + "</h1>
</div>");
            value1[1].forEach(function(value2, index2){
                $("#talents" + index1).append("<div>
<input type='checkbox' class='profession_checkbox talents_checkbox' name='" + value2[0] + "' value='" + value2[0] + "'/>
<h2 class='profession_data_h2'>" + value2[0] + "</h2>
<p class='requisites_data_p_sub'>" + value2[1] + "</p>
<p class='profession_data_p_sub'>" + value2[2] + "</p>
</div>"); 
            });
        });
        $("#sidebar-wrapper_title").text("Talents");
        $(".profession_data_h2, .profession_checkbox, .requisites_data_p_sub, .profession_data_p_sub").css("display", "none");
        $("body").append("<div id='sidebar-wrapper-open' style='width:100%;height:" + originalBodyHeight + ";z-index:1000;position:absolute;top:0;left:0;'>
</div>");
        $("#sidebar-wrapper").css("z-index", 2000);
        $("#sidebar-wrapper_title, #data_container").css("display", "block");
        $(".Separator-1").css("display", "flex");
        $(".sidebar-wrapper-innercontainer").append("<span id='close_sidebar'>Close&times;</span>
<div id='sidebar_icons'>
<i id='reset_icon' class='fa fa-undo'>
</i>
<i id='close_icon' class='fa fa-times'>
</i>
</div>");
        var selected_talents_Array = selected_talents.split(", ");
        selected_talents_Array.forEach(function(value){
            $(".talents_checkbox[value='" + value + "']").prop("checked", true);
        });
    });
    $(document).on("click", "#sidebar-wrapper-open", function(){
        $(".Separator-1, #sidebar-wrapper_title").css("display", "none");
        $("#data_container").empty();
        $("#sidebar-wrapper").css({"width": 0, "padding": 0});
        $("#close_sidebar").remove();
        $("#sidebar_icons").remove();
        $("#sidebar-wrapper-open").remove();
    });
    $(document).on("click", ".profession_data_h1", function(){
        $(this).siblings("p.profession_data_p, p.requisites_data_p").slideToggle();
        $(this).siblings("div").children(".profession_checkbox, h2.profession_data_h2").slideToggle();
        $(this).siblings("div").children("p.profession_data_p_sub, p.requisites_data_p_sub").slideUp();
    });
    $(document).on("click", ".profession_data_h2", function(){
        $(this).siblings("p.profession_data_p_sub, p.requisites_data_p_sub").slideToggle();
    });
    $(document).on("click", "#close_sidebar, #close_icon", function(){
        $(".Separator-1, #sidebar-wrapper_title").css("display", "none");
        $("#data_container").empty();
        $("#sidebar-wrapper").css({"width": 0, "padding": 0});
        $("#close_sidebar").remove();
        $("#sidebar_icons").remove();
        $("#sidebar-wrapper-open").remove();
    });
    $(document).on("change", ".parentskills_checkbox", function(){
        selected_parentskills = "";
        $(".parentskills_checkbox:checked").each(function(){
            if(selected_parentskills != "") selected_parentskills += ", ";
            selected_parentskills += $(this).siblings(".profession_data_h2").text();
        });
        if(selected_parentskills == ""){
            $("#selected_parentskills_p").slideUp();
            $("#selected_parentskills_p").text(selected_parentskills);
        } else {
            $("#selected_parentskills_p").text(selected_parentskills);
            $("#selected_parentskills_p").slideDown();
        }
    });
    $(document).on("change", ".childskills_checkbox", function(){
        selected_childskills = "";
        $(".childskills_checkbox:checked").each(function(){
            if(selected_childskills != "") selected_childskills += ", ";
            selected_childskills += $(this).siblings(".profession_data_h2").text();
        });
       if(selected_childskills == ""){
            $("#selected_childskills_p").slideUp();
            $("#selected_childskills_p").text(selected_childskills);
        } else {
            $("#selected_childskills_p").text(selected_childskills);
            $("#selected_childskills_p").slideDown();
        }
    });
    $(document).on("change", ".techniques_checkbox", function(){
        selected_techniques = "";
        $(".techniques_checkbox:checked").each(function(){
            if(selected_techniques != "") selected_techniques += ", ";
            selected_techniques += $(this).siblings(".profession_data_h2").text();
        });
       if(selected_techniques == ""){
            $("#selected_techniques_p").slideUp();
            $("#selected_techniques_p").text(selected_techniques);
        } else {
            $("#selected_techniques_p").text(selected_techniques);
            $("#selected_techniques_p").slideDown();
        }
    });
    $(document).on("change", ".talents_checkbox", function(){
        selected_talents = "";
        $(".talents_checkbox:checked").each(function(){
            if(selected_talents != "") selected_talents += ", ";
            selected_talents += $(this).siblings(".profession_data_h2").text();
        });
        if(selected_talents == ""){
            $("#selected_talents_p").slideUp();
            $("#selected_talents_p").text(selected_talents);
        } else {
            $("#selected_talents_p").text(selected_talents);
            $("#selected_talents_p").slideDown();
        }
    });
    $(document).on("click", "#reset_icon", function(){
        switch($(this).parents("#sidebar-wrapper").find("#sidebar-wrapper_title").text()){
            case "Parent":
                selected_parentskills = "";
                $(".parentskills_checkbox").prop("checked", false);
                $("#selected_parentskills_p").slideUp();
                $("#selected_parentskills_p").text("");
            break;
            case "Child-Skills":
                selected_childskills = "";
                $(".childskills_checkbox").prop("checked", false);
                $("#selected_childskills_p").slideUp();
                $("#selected_childskills_p").text("");
            break;
            case "Techniques":
                selected_techniques = "";
                $(".techniques_checkbox").prop("checked", false);
                $("#selected_techniques_p").slideUp();
                $("#selected_techniques_p").text("");
            break;
            case "Talents":
                selected_talents = "";
                $(".talents_checkbox").prop("checked", false);
                $("#selected_talents_p").slideUp();
                $("#selected_talents_p").text("");
            break;
        }
    });
});