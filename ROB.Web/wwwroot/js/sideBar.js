function sideBarLevel() {
    clearSideBar();
    setSidebarTitle("Level");
    setSidebarContent(getLevelContent());
    openNav();
}

function getLevelContent() {
    var currentLevel = $("#levelDisplay").text();
    var currentLevelInt = parseInt(currentLevel);
    var nextLevel = currentLevelInt + 1;
    nextLevel = String(nextLevel);
    return `<h3><span><i class="fas fa-minus-square" onclick="addValue('level',-1)"></i> <span id="levelDisplay">` + currentLevel + `</span> <i onclick="addValue('level',1)" class="fas fa-plus-square"></i></span></h3>
            <p>
                Your current level is ` + currentLevel + ` out of 10. This marks your character experience. In order to see how much more experience you need to level check out the slider below. After leveling up your character will gain more skills, talents, or techniques
            </p>
            <p>
                Experience is 500 out of 1500 until level ` + nextLevel + `.
                <div class="progress">
                  <div class="progress-bar bg-success" role="progressbar" style="width: 33%" aria-valuenow="500" aria-valuemin="0" aria-valuemax="1500"></div>
                </div>  
            </p>`
}

function sideBarLuck() {
    clearSideBar();
    setSidebarTitle("Luck");
    setSidebarContent(getLuckContent());
    openNav();
}

function getLuckContent() {
    var currentLuck = $("#luckDisplay").text();
    return `<p>
                Your current luck is ` + currentLuck + ` out of 5. 
            </p>
            <div class="alert alert-primary" role="alert">
              This is controlled by your DM and can only be modified by your DM after you have joined a campaign
            </div>
            <p>
                Luck is used to automatically make your roll the highest possible outcome. 
            </p>
            <p>
                Example: if you were rolling a 2d8 to attack a monster and rolled a 2 + 1 to equal 3, then you could spend a luck point to make that 3 a 16 (the highest you could have possibly rolled with a 2d8).
            </p>
            <div class="alert alert-warning" role="alert">
               Spend luck points wisely, you will only have a total of 5 unless the DM is gratious enough to give you more!
            </div>`
}

function sideBarWeaponsManager() {
    clearSideBar();
    setSidebarTitle("Weapons Manager");
    setSidebarContent(getWeaponsManagerContent());
    openNav();
}

function getWeaponsManagerContent() {
    var weaponsTableDataRow = ''
    var i = 0;
    AllWeapons.forEach(function (weapon) {
        weaponsTableDataRow += `<tr>
            <td>
                <button class="btn btn-primary" onclick="AddWeaponAsync(` + weapon.id + `)">Add</button>
            </td>
            <td onclick="showWeaonDetails(` + i + `)">
                ` + weapon.name + `
            </td>
            <td>
                ` + weapon.damageValue + `
            </td>
            <td>
                ` + getViewCost(weapon.cost) + `
            </td>
        </tr>
        `
        i++;
    });
    return `<table class="table">
    <thead>
        <tr>
            <th>Add</th>
            <th>Name</th>
            <th>DV</th>
            <th>Price</th>
        </tr>
    </thead>
    <tbody>        
        ` + weaponsTableDataRow + `
    </tbody>
</table>

<div id="csWeaponDetails">
</div>`
}

function showWeaonDetails(id) {
    details = $("#csWeaponDetails");
    details.empty();
    var html = `
        <div class="card text-dark">
        <div class="card-header">
            <h3>` + AllWeapons[id].name + `</h3>
        </div>
        <div class="card-body">
            <h5 class="card-title">Description: ` + AllWeapons[id].description + `</h5>
            <h5 class="card-title">Price: ` + getViewCost(AllWeapons[id].cost) + `</h5>
            <h5 class="card-title">DV: ` + AllWeapons[id].damageValue + `</h5>
        </div>
        <div class="card-footer">
            <p>last updated never</p>
        </div>
        </div>
    `
    details.append(html);
}

