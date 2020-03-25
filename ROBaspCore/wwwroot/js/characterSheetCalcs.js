$(document).ready(function () {
    recalculateAll();
});

function recalculateAll() {
    // gather variables to use
    strength = parseInt($("#strength").val());
    fortitude = parseInt($("#fortitude").val());
    dexterity = parseInt($("#dexterity").val());
    accuracy = parseInt($("#accuracy").val());
    intellect = parseInt($("#intellect").val());
    resolve = parseInt($("#resolve").val());
    influence = parseInt($("#influence").val());
    demeanor = parseInt($("#demeanor").val());

    setValues("strength", strength);
    setValues("fortitude", fortitude);
    setValues("dexterity", dexterity);
    setValues("accuracy", accuracy);
    setValues("intellect", intellect);
    setValues("resolve", resolve);
    setValues("influence", influence);
    setValues("demeanor", demeanor);

    level = parseInt($("#level").val());

    // set all variables
    setDeadlift();
    setBenchPress();
    setCarryingCapacity();
    setStrengthDamage();
    setStrengthSave();
    setFortitudeSave();
    setResolveSave();
    setEvasion();
    setDodge();
    setReaction();
    setMana();
    setDivinePower();
    setAllVital();
    setAllParentSkills();
    setVision();
    setListen();
    setSmell();
}

function setAllVital() {
    setBasePoints();
    setOP_DTH();
    setMHP();
    setHPB();
    setHP();
}

function setAllParentSkills() {
    setAtrisan();
    setAthletics();
    setAwareness();
    setKnowledge();
    setNature();
    setSocial();
    setSubterfuge();
    setMelee();
    setRange();
}

function setValues(id, functionCall) {
    var functionReturn = parseInt(functionCall, 10);
    var modifier = getModiferValue(id);
    var newValue = functionReturn + modifier;
    $("#" + id).val(newValue);
    $("#" + id + "Display").text(newValue);
}

function addValue(id, valueToAdd) {
    var oldValue = parseInt($("#" + id).val(), 10);
    var newValue = oldValue + valueToAdd;
    setValues(id, newValue);
}

function getDisplayValue(id) {
    return parseInt($("#" + id + "Display").text(), 10);
}

function getModiferValue(id) {
    var modifier = parseInt($("#" + id + "Modifier").val(), 10);
    if (isNaN(modifier)) {
        modifier = 0;
    }
    return modifier;
}

function setListen() {
    setValues("listen", getDisplayValue("awareness"));
}

function setVision() {
    setValues("vision", getDisplayValue("awareness"));
}

function setSmell() {
    setValues("smell", getDisplayValue("awareness"));
}

function setAtrisan() {
    var parentSkillId = "artisan"
    setValues(parentSkillId, getParentSkill(dexterity, intellect, parentSkillId));
}

function setAthletics() {
    var parentSkillId = "athletics"
    setValues(parentSkillId, getParentSkill(strength, dexterity, parentSkillId));
}

function setAwareness() {
    var parentSkillId = "awareness"
    setValues(parentSkillId, getParentSkill(intellect, resolve, parentSkillId));
}

function setKnowledge() {
    var parentSkillId = "knowledge"
    setValues(parentSkillId, getParentSkill(intellect, resolve, parentSkillId));
}

function setNature() {
    var parentSkillId = "nature"
    setValues(parentSkillId, getParentSkill(intellect, resolve, parentSkillId));
}

function setSocial() {
    var parentSkillId = "social"
    setValues(parentSkillId, getParentSkill(influence, demeanor, parentSkillId));
}

function setSubterfuge() {
    var parentSkillId = "subterfuge"
    setValues(parentSkillId, getParentSkill(dexterity, intellect, parentSkillId));
}

function setMelee() {
    var parentSkillId = "melee"
    setValues(parentSkillId, getParentSkill(strength, dexterity, parentSkillId));
}

function setRange() {
    var parentSkillId = "range"
    setValues(parentSkillId, getParentSkill(accuracy, intellect, parentSkillId));
}


function getDeadlift() {
    return Math.ceil(strength * 30);
}

function setDeadlift() {
    setValues("deadlift", getDeadlift());
}

function getBenchPress() {
    return Math.ceil(strength * 20);
}

function setBenchPress() {
    setValues("benchpress", getBenchPress());
}

function getCarryingCapacity() {
    return Math.ceil(strength * 10);
}

function setCarryingCapacity() {
    setValues("carryingcapacity", getCarryingCapacity());
}

function getStrengthDamage() {
    return Math.ceil(strength / 2);
}

function setStrengthDamage() {
    setValues("strengthdamage", getStrengthDamage());
}

function getStrengthSave() {
    return Math.ceil(strength + level);
}

function setStrengthSave() {
    setValues("strengthsave", getStrengthSave());
}

function getFortitudeSave() {
    return Math.ceil(fortitude + level);
}

function setFortitudeSave() {
    setValues("fortitudesave", getFortitudeSave());
}

function getResolveSave() {
    return Math.ceil(resolve + level);
}

function setResolveSave() {
    setValues("resolvesave", getResolveSave());
}

function getEvasion() {
    return Math.ceil(dexterity + 10 + level);
}

function setEvasion() {
    setValues("evasion", getEvasion());
}

function getDodge() {
    return Math.ceil(getEvasion() + 10);
}

function setDodge() {
    setValues("dodge", getDodge());
}

function getReaction() {
    return Math.ceil(dexterity + (intellect / 2));
}

function setReaction() {
    setValues("reaction", getReaction());
}

function getMana() {
    return Math.ceil(resolve + ((resolve / 2) * level));
}

function setMana() {
    setValues("mana", getMana());
}

function getDivinePower() {
    return Math.ceil((influence / 2) + level);
}

function setDivinePower() {
    setValues("divinepower", getDivinePower());
}

function getBasePoints() {
    return Math.ceil(fortitude * 2);
}

function setBasePoints() {
    setValues("bp", getBasePoints());
    setValues("cp", getBasePoints());
    setValues("fp", getBasePoints());
}

function getOP_DTH() {
    return Math.ceil(fortitude);
}

function setOP_DTH() {
    setValues("op", getOP_DTH());
    setValues("dth", getOP_DTH());
}

function getMHP() {
    return Math.ceil(resolve * 4);
}

function setMHP() {
    setValues("mhp", getMHP());
}

function getHPB() {
    return Math.ceil((1 + (1 * (fortitude / 5))));
}

function setHPB() {
    setValues("hpb", getHPB());
}

function getHP() {
    return Math.ceil(((strength + fortitude) + getHPB(fortitude)));
}

function setHP() {
    setValues("hp", getHP());
}

function getParentSkill(attribute1, attribute2, parentId) {
    var proficient = 0;
    if ($("#" + parentId + "Proficient").prop("checked") == true) {
        proficient = 2;
    }
    return Math.ceil(((attribute1 + attribute2) / 2) + proficient);
}

/*
 * Might use this to set each stat as a variable and then just return that variable in each GET method...
 *
function getAllStats(strength, fortitude, resolve, dexterity, intellect, influence, level) {

}
*/