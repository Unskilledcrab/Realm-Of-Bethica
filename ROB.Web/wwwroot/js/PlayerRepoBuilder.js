var sheetId = $('#sheetId').attr("data-id");

var SheetRepo = function (endpoint) {
    SheetRepoBase.call(this, sheetId, endpoint);
};
SheetRepo.prototype = Object.create(SheetRepoBase.prototype);

var weapons = new SheetRepo('CharacterWeaponsManager');
var items = new SheetRepo('CharacterItemsManager');
var shields = new SheetRepo('CharacterShieldsManager');
var notes = new SheetRepo('CharacterNotesManager');
var details = new SheetRepo('CharacterDetailsManager');

/*
*** THIS IS WRONG DO NOT DO THIS WHEN ADDING SOMETHING TO A REPO ****

var testThing = function () {
    this.PublicNotes = 'notes';
    this.PrivateNotes = 'pnotes';
    this.Backstory = 'backstory';
}
*/

var testNotes =  {
    PublicNotes: 'notes',
    PrivateNotes: 'pnotes',
    Backstory: 'backstory'
}

var testDetails = {
    Background: 'notes',
    Gender: 'pnotes',
    EyeColor: 'backstory'
}