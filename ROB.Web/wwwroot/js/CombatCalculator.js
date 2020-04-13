$(document).keydown(function (event) {
    if (event.which == "17")
        isCntlPressed = true;
});
$(document).keyup(function () {
    isCntlPressed = false;
});
var isCntlPressed = false;

$(document).ready(function () {
    $('.toast').toast({ delay: 2000 });
});

var characterCount = 1;
function createCharacterSheet() {
    characterCount++;
    $("#character-container").append(getNextBlankCharacter(characterCount));
}
function getNextBlankCharacter(characterId) {
    var character = $('[character-id]').last().clone();
    character.find('[character-name]').attr('character-name', characterId);
    character.find('[character-name]').attr('onclick', 'setPlayer(this,' + characterId + ')');
    character.find('[add-weapon-btn]').attr('onclick', 'addWeapon(' + characterId + ')');
    character.find('[delete-character-btn]').attr('onclick', 'deleteCharacter(' + characterId + ')');
    character.attr('character-id', characterId);
    var oldName = character.find('[character-name]').val();
    character.find('[character-name]').val(oldName + " " + characterId);
    //character.find('[weapon-id]').attr('weapon-id',1); // these are unique to the character so no need to reset
    //character.find('[rm]').val("");
    //character.find('[eva]').val("");
    //character.find('[ar]').val("");
    //character.find('[ar]').attr('ar',0);
    //character.find('[pdr]').val("");
    //character.find('[hp]').val("");
    //character.find('[temp-hp]').val("");
    //character.find('[wound]').val("");
    character.find('[w-col-btn]').attr('href', '#wcollapse-' + characterId);
    character.find('[w-col-show]').attr('id', 'wcollapse-' + characterId);
    character.find('[a-col-btn]').attr('href', '#acollapse-' + characterId);
    character.find('[a-col-show]').attr('id', 'acollapse-' + characterId);
    return character;
}

function combatLog(message) {
    $('.modal-body').append('<p>' + message + '</p>');
    console.log(message);
}

var CombatCalculator = function (attacker, target, roll) {

    this.BaseRoll = Number(roll)

    // Attacker Props
    this.ToHit = Number(attacker.ToHit)
    this.AttackerName = attacker.Name
    this.DamageValue = Number(attacker.DV)
    this.PenatrationDamageValue = Number(attacker.PDV)
    this.DamageType = attacker.DamageType
    this.IsSpellAttack = attacker.IsSpellAttack;
    this.IsPenatrationOptional = attacker.IsPenatrationOptional; // this is used for swords since they can be slashing or stabbing
    this.IsPenatrationUsed = attacker.IsPenatrationUsed;

    // Target Props
    this.TargetId = target.Id
    this.TargetName = target.Name
    this.HP = Number(target.HP)
    this.Wound = Number(target.Wound)
    this.TempHP = Number(target.TempHP)
    this.EVA = Number(target.EVA)
    this.ArmorRating = Number(target.ArmorRating)
    this.ArmorRatingBase = Number(target.ArmorRatingBase); // wants to calculate armor reduction by the base armor rating
    this.PenatrationDefenseRating = Number(target.PenatrationDefenseRating)

    // private props
    var Message = '';
    var DamageFactor = 0
    var IsIgnoreArmor = false
    var PenatrationOptionPenalty = 0.5;

    this.DidHit = function (baseRoll, toHit, evasion) {
        if ((baseRoll + toHit) > evasion) {
            if (!this.IsSpellAttack) {
                var overflow = (baseRoll + toHit) - evasion;
                if (overflow > 30) {
                    this.DamageFactor = 2;
                    combatLog("Killing Blow");
                }
                else if (overflow > 15) {
                    this.DamageFactor = 1.5;
                    combatLog("Critical Blow");
                }
                else if (overflow > 5) {
                    this.DamageFactor = 1;
                    combatLog("Solid Hit");
                }
                else {
                    this.DamageFactor = 0.5;
                    combatLog("Grazing Blow");
                }
                //combatLog("Damage factor is " + this.DamageFactor);
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
                combatLog("Penetration occured and is ignoring armor");
            }
            else {
                this.IsIgnoreArmor = false;
                //combatLog("Could not penetrate armor");
            }
        } else {
            this.IsIgnoreArmor = false;
            combatLog("the weapon does not have penetration");
        }
    }
    this.CalculateHit = function (DV, AR) {
        var Damage = Math.ceil((DV * this.DamageFactor));
        if (this.IsPenatrationOptional == true)
            if (this.IsPenatrationUsed == true) {
                Damage = Math.ceil(Damage * this.PenatrationOptionPenalty);
                combatLog("the attacks damage penalty is " + this.PenatrationOptionPenalty + " for using penatration technique");
            }
        //combatLog("attacking for " + Damage + " damage against armor of " + this.ArmorRating);
        if ((!this.IsIgnoreArmor) && this.ArmorRating > 0) {
            if (Damage >= (this.ArmorRatingBase * 0.5)) {
                this.CalculateArmorReduction(Damage, this.ArmorRatingBase);
            }
            if (Damage > this.ArmorRating) {
                Damage = Damage - this.ArmorRating;
                //combatLog("players armor took " + this.ArmorRating + " damage");
            } else {
                return combatLog("players armor took the damage");
            }
        }
        if (this.TempHP > 0) {
            var baseDamage = Damage;
            Damage -= this.TempHP
            if (Damage <= 0) {
                this.TempHP -= baseDamage;
                return combatLog("players temp hp took damage")
            } else {
                this.TempHP = 0;
            }
        }
        this.HP -= Damage;
        this.Wound += Damage;
        combatLog("player took " + Damage + " damage");
        if (this.HP < 1) {
            return combatLog("player has been killed");
        }
        return //combatLog("player has " + this.HP + " HP remaining");
    }
    this.CalculateArmorReduction = function (damage, armorRating) {
        if (damage < (armorRating * 2)) {
            this.ArmorRating--;
            combatLog("players armor was reduced by 1 and is " + this.ArmorRating);
            return
        }
        var diff = Math.floor(damage / armorRating);
        combatLog("players armor was reduced by " + diff + " and is " + this.ArmorRating);
        this.ArmorRating = this.ArmorRating - diff;
        if (this.ArmorRating < 0) this.ArmorRating = 0;
    }
    this.Roll = function () {
        if (this.HP < 0)
            return combatLog("Why would you attack a dead person... you ANIMAL!");
        if (this.DidHit(this.BaseRoll, this.ToHit, this.EVA)) {
            this.HasPenetration(this.PenatrationDamageValue, this.PenatrationDefenseRating);
            this.CalculateHit(this.DamageValue, this.ArmorRating);
        } else { combatLog("you missed"); }
    }
}

function showToast(message) {
    var t = $('.toast:not(.show)').first();
    t.find('.toast-body').empty().append('<p>' + message + '</p>');
    t.toast('show');
}

var CombatArena = function () {
    this.WeaponId = null;
    this.AttackerId = null;
    this.Attacker = null;
    this.Targets = [];
    this.CombatCalculators = [];
    this.RollCombat = function (weaponId) {
        $('.modal-body').empty();
        this.WeaponId = weaponId;
        this.Attacker = getAttacker(this.AttackerId, weaponId);
        var character = $('[character-id="' + this.AttackerId + '"]');
        var roll = character.find('[roll]').val();
        for (i = 0; i < this.Targets.length; i++) {
            this.CombatCalculators.push(new CombatCalculator(this.Attacker, getTarget(this.Targets[i]), roll));
        }
        this.RunCombatCalculations();
        this.CombatCalculators = [];
        $('#combatModal').modal('show');
    }
    this.RunCombatCalculations = function () {
        for (i = 0; i < this.CombatCalculators.length; i++) {
            combatLog(this.Attacker.Name + " is attacking " + this.CombatCalculators[i].TargetName);
            this.CombatCalculators[i].Roll();
            setTarget(this.CombatCalculators[i].TargetId, this.CombatCalculators[i].HP, this.CombatCalculators[i].TempHP, this.CombatCalculators[i].Wound, this.CombatCalculators[i].ArmorRating);
            combatLog("------------------");
        }
    }
    this.SetAttacker = function (id) {
        this.AttackerId = id;
        showToast("Attacker Added")
    }
    this.AddTarget = function (id) {
        var b = 0
        for (i = 0; i < this.Targets.length; i++) {
            if (this.Targets[i] == id)
                b++;
        }
        if (b == 0) {
            showToast("Target Added")
            this.Targets.push(id);
            var name = $('[character-id="' + id + '"]').find('[character-name]').val();
            var names = $('[character-id="' + this.AttackerId + '"]').find('[targeted]').val();
            names = names + name + ' ';
            $('[character-id="' + this.AttackerId + '"]').find('[targeted]').val(names);
        } else {
            showToast("Target is already targeted")
        }
    }
    this.Clear = function () {
        $('[targeted]').val("");
        this.AttackerId = null;
        this.WeaponId = null;
        this.Attacker = null;
        this.Targets = [];
        this.CombatCalculators = [];
    }
}

var CurrentCombatArena = new CombatArena();

function setPlayer(obj, id) {
    if (isCntlPressed) {
        CurrentCombatArena.AddTarget(id);
        $(obj).addClass('alert-danger');
    }
    else {
        CurrentCombatArena.Clear();
        $('[character-name]').removeClass('alert-danger').removeClass('alert-info');
        CurrentCombatArena.SetAttacker(id);
        $(obj).addClass('alert-info');
    }
}

function attack(id) {
    if (CurrentCombatArena.Targets.length > 0) {
        CurrentCombatArena.RollCombat(id);
    }
}

var Attacker = function (id, name, dv, pdv, toHit, damageType, isSpellAttack, isPenatrationOptional) {
    this.Id = id
    this.Name = name
    this.DV = dv
    this.PDV = pdv
    this.ToHit = toHit
    this.DamageType = damageType
    this.IsSpellAttack = isSpellAttack;
    this.IsPenatrationOptional = isPenatrationOptional; // this is used for swords since they can be slashing or 
}
function getAttacker(characterId, weaponId) {
    var character = $('[character-id="' + characterId + '"]');
    var charName = character.find('[character-name]').val();
    var weapon = character.find('[weapon-id ="' + weaponId + '"]');
    var name = weapon.find('[weapon-name]').val();
    var rm = weapon.find('[weapon-rm]').val();
    var thf = weapon.find('[weapon-thf]').val();
    var eva = weapon.find('[weapon-eva]').val();
    var dv = weapon.find('[dv]').val();
    var pvr = weapon.find('[pvr]').val();
    var damageType = weapon.find('[damage-type]').val();
    var reach = weapon.find('[reach]').val();

    var attacker = new Attacker(characterId, charName, dv, pvr, thf, damageType, false, false);
    return attacker;
}

var Target = function (id, name, hp, tempHP, wound, eva, ar, arBase, pdr) {
    this.Id = id
    this.Name = name
    this.HP = hp
    this.TempHP = tempHP
    this.Wound = wound
    this.EVA = eva
    this.ArmorRating = ar
    this.ArmorRatingBase = arBase; // wants to calculate armor reduction by the base armor rating
    this.PenatrationDefenseRating = pdr
}
function getTarget(characterId) {
    var character = $('[character-id="' + characterId + '"]');
    var name = character.find('[character-name]').val();
    var rm = character.find('[rm]').val();
    var eva = character.find('[eva]').val();
    var ar = character.find('[ar]').val();
    var arBase = character.find('[ar]').attr("ar");
    var pdr = character.find('[pdr]').val();
    var hp = character.find('[hp]').val();
    var tempHP = character.find('[temp-hp]').val();
    var wound = character.find('[wound]').val();

    var target = new Target(characterId, name, hp, tempHP, wound, eva, ar, arBase, pdr);
    return target;
}
function setTarget(characterId, hp, tempHP, wound, ar) {
    var character = $('[character-id="' + characterId + '"]');
    var ar = character.find('[ar]').val(ar);
    var hp = character.find('[hp]').val(hp);
    var tempHP = character.find('[temp-hp]').val(tempHP);
    var wound = character.find('[wound]').val(wound);
}

function addWeapon(characterId) {
    var character = $('[character-id="' + characterId + '"]');
    var weapons = character.find('[weapon-id]');
    var weaponCount = weapons.last().attr('weapon-id');
    weaponCount++;
    var weaponClone = weapons.first().clone().attr('weapon-id', weaponCount);
    weaponClone.find('[weapon-name]').attr('onclick', 'attack(' + weaponCount + ')')
    //weaponClone.find('[weapon-id]').attr('weapon-id',weaponCount);
    character.find('#weapon-container').append(weaponClone);
}
function deleteRow(e) {
    var weapons = $(e).closest("#weapon-container").find('[weapon-id]');
    if (weapons.length > 1)
        $(e).closest(".row").remove();
}
function deleteCharacter(id) {
    var characters = $("#character-container").find('[character-id]');
    if (characters.length > 1)
        $('[character-id=' + id + ']').remove();
}