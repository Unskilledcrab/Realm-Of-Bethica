// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    sideBarTitle = $("#sidebarTitle");
    sideBarContent = $("#sidebarContent");
});

function confirmDelete(uniqueId, isDeleteClicked) {
    var deleteSpan = 'deleteSpan_' + uniqueId;
    var confirmDeleteSpan = 'confirmDeleteSpan_' + uniqueId;

    if (isDeleteClicked) {
        $('#' + deleteSpan).hide();
        $('#' + confirmDeleteSpan).show();
    } else {
        $('#' + deleteSpan).show();
        $('#' + confirmDeleteSpan).hide();
    }
}

function clearSideBar() {
    sideBarTitle.empty();
    sideBarContent.empty();
}

function setSidebarTitle(title) {
    sideBarTitle.append(`<h2>` + title + `</h2>`);
}

function setSidebarContent(html) {
    sideBarContent.append(html);
}

/* Set the width of the sidebar to 250px and the left margin of the page content to 250px */
function openNav() {
    document.getElementById("mySidebar").style.width = "250px";
    $('#sidebar').addClass('active');
    $('.overlay').addClass('active');
    //document.getElementById("main").style.marginLeft = "250px";
}

/* Set the width of the sidebar to 0 and the left margin of the page content to 0 */
function closeNav() {
    document.getElementById("mySidebar").style.width = "0";
    $('#sidebar').removeClass('active');
    $('.overlay').removeClass('active');
    //document.getElementById("main").style.marginLeft = "0";
}

// look at TechniqueModels/Create bottom table to see how the filtering should be set up to use this method
function filterGroups(groupId) {
    var validSelectors = $(".groupId");

    for (var i = 0; i < validSelectors.length; i++) {
        var item = validSelectors[i];
        item.classList.contains("class_" + groupId) ? item.style.display = "block" : item.style.display = "none";
    }
}

function getViewCost(copperCost) {
    var cost = 0
    var suffix = ''
    if (copperCost < 100) {
        cost = copperCost;
        suffix = " cu";
    }
    else if (copperCost < 1000) {
        cost = copperCost / 100;
        suffix = " sp";
    }
    else if (copperCost < 10000) {
        cost = copperCost / 1000;
        suffix = " gold";
    }
    else {
        cost = copperCost / 10000;
        suffix = " plat";
    }
    return cost + suffix;
}

var CombatCalculator = function () {
    this.DamageValue = 10
    this.HP = 20
    this.EVA = 25
    this.ToHit = 10
    this.BaseRoll = 1
    this.DamageFactor = 0
    this.ArmorRating = 6
    this.ArmorRatingBase = 6; // wants to calculate armor reduction by the base armor rating
    this.PenatrationDefenseRating = 15
    this.PenatrationDamageValue = 5
    this.IsIgnoreArmor = false
    this.IsSpellAttack = false;
    this.IsPenatrationOptional = false; // this is used for swords since they can be slashing or stabbing
    this.IsPenatrationUsed = false;
    this.PenatrationOptionPenalty = 0.5;
    this.Setup = function (TH, DV, PDV, PDR, EVA, HP, AR, isSpellAttack) {
        this.ToHit = TH;
        this.DamageValue = DV;
        this.PenatrationDamageValue = PDV;
        this.PenatrationDefenseRating = PDR;
        this.EVA = EVA;
        this.HP = HP;
        this.ArmorRating = AR;
        this.IsSpellAttack = isSpellAttack
    }
    this.DidHit = function (baseRoll, toHit, evasion) {
        if ((baseRoll + toHit) > evasion) {
            if (!this.IsSpellAttack) {
                var overflow = (baseRoll + toHit) - evasion;
                if (overflow > 30)
                    this.DamageFactor = 2;
                else if (overflow > 15)
                    this.DamageFactor = 1.5;
                else if (overflow > 5)
                    this.DamageFactor = 1;
                else
                    this.DamageFactor = 0.5;
                console.log("Damage factor is " + this.DamageFactor);
            }
            return true;
        } else { return false; }
    }
    this.HasPenetration = function (PV, PDR) {
        if (this.IsPenatrationOptional == true)
            if (this.IsPenatrationUsed == false)
                return;
        if (PV > 0) {
            if (PV > PDR) {
                this.IsIgnoreArmor = true;
                console.log("Penetration occured and is ignoring armor");
            }
            else {
                this.IsIgnoreArmor = false;
                console.log("Could not penetrate armor");
            }
        } else {
            this.IsIgnoreArmor = false;
            console.log("the weapon does not have penetration");
        }
    }
    this.CalculateHit = function (DV, AR) {
        var Damage = (DV * this.DamageFactor);
        if (this.IsPenatrationOptional == true)
            if (this.IsPenatrationUsed == true) {
                Damage = Math.ceil(Damage * this.PenatrationOptionPenalty);
                console.log("the attacks damage penalty is " + this.PenatrationOptionPenalty + " for using penatration technique");
            }
        console.log("attacking for " + Damage + " damage against armor of " + this.ArmorRating);
        if ((!this.IsIgnoreArmor) && this.ArmorRating > 0) {
            if (Damage >= (this.ArmorRatingBase * 0.5)) {
                this.CalculateArmorReduction(Damage, this.ArmorRatingBase);
            }
            if (Damage > this.ArmorRating) {
                Damage = Damage - this.ArmorRating;
                console.log("players armor took " + this.ArmorRating + " damage");
            } else {
                return console.log("players armor took the damage");
            }
        }
        this.HP = this.HP - Damage;
        console.log("player took " + Damage + " damage");
        if (this.HP < 1) {
            return console.log("player has been killed");
        }
        return console.log("player has " + this.HP + " HP remaining");
    }
    this.CalculateArmorReduction = function (damage, armorRating) {
        if (damage < (armorRating * 2)) {
            this.ArmorRating--;
            console.log("players armor was reduced by 1 and is " + this.ArmorRating);
            return
        }
        var diff = Math.floor(damage / armorRating);
        console.log("players armor was reduced by " + diff + " and is " + this.ArmorRating);
        this.ArmorRating = this.ArmorRating - diff;
        if (this.ArmorRating < 0) this.ArmorRating = 0;
    }
    this.Roll = function (baseRoll) {
        if (this.HP < 0)
            return console.log("Why would you attack a dead person... you ANIMAL!");
        if (this.DidHit(baseRoll, this.ToHit, this.EVA)) {
            this.HasPenetration(this.PenatrationDamageValue, this.PenatrationDefenseRating);
            this.CalculateHit(this.DamageValue, this.ArmorRating);
        } else { console.log("you missed"); }
    }
}

var test = new CombatCalculator();


$(document).ready(function () {
    $("[date-local-convert]").each(function () {
        $(this)
        let UTCDate = $(this).text() + " UTC";
        let localDate = new Date(UTCDate);
        $(this).text(localDate.toString());
    });

    let iterator = 0;
    $("[date-UTC-convert]").each(function () {
        let id = "date-UTC-covert-" + iterator;
        let UTCid = "date-converted-" + iterator;
        $(this).attr("id", id);
        $(this).change(function () {
            let localDate = new Date($(this).val());
            $('#' + UTCid).val(localDate.toUTCString());
        });
        $('#' + id).datetimepicker();
        $(this).clone().attr("id", UTCid).attr("type", "hidden").insertAfter(this);
        $(this).attr("name", "n/a");
        iterator++;
    });    
});