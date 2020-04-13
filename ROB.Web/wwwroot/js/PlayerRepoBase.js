var SheetRepoBase = function (sheetId, endpoint) {
    this.uri = window.location.origin + '/api/' + sheetId + '/' + endpoint;
    this.endpoint = endpoint;
    this.allData = [];
    this.data = null;
}

SheetRepoBase.prototype.getAllDataAsync = function () {
    var self = this;
    $.ajax({
        url: self.uri,
        type: "GET",
        success: function (data) {
            self.allData = data;
            console.log('successfully retrieved ' + self.endpoint);
            console.log(data);
        },
        error: function (request) {
            console.log('error occured retrieved ' + self.endpoint);
            console.log(request.responseText);
        }
    })
}

SheetRepoBase.prototype.getDataAsync = function (dataId) {
    var self = this;
    $.ajax({
        url: self.uri + '/' + dataId,
        type: "GET",
        success: function (data) {
            self.data = data;
            console.log('successfully retrieved ' + self.endpoint + ' ' + dataId);
            console.log(data);
        },
        error: function (request) {
            console.log('error occured retrieved ' + self.endpoint + ' ' + dataId);
            console.log(request.responseText);
        }
    })
}

SheetRepoBase.prototype.addDataAsync = function (data) {
    var self = this;
    $.ajax({
        url: self.uri,
        type: "POST",
        data: JSON.stringify(data),
        contentType: 'application/json;charset=UTF-8',        
        cache: false,
        success: function (data) {
            console.log('successfully added ' + self.endpoint + ' ' + data);
            console.log(data);
        },
        error: function (request) {
            console.log('error occured adding ' + self.endpoint + ' ' + data);
            console.log(request.responseText);
        }
    })
}

SheetRepoBase.prototype.updateDataAsync = function (data) {
    var self = this;
    $.ajax({
        url: self.uri,
        type: "PUT",
        data: JSON.stringify(data),
        contentType: 'application/json;charset=UTF-8',
        cache: false,
        success: function (data) {
            console.log('successfully added ' + self.endpoint + ' ' + data);
            console.log(data);
        },
        error: function (request) {
            console.log('error occured adding ' + self.endpoint + ' ' + data);
            console.log(request.responseText);
        }
    })
}

SheetRepoBase.prototype.deleteDataAsync = function (dataId) {
    var self = this;
    $.ajax({
        url: self.uri + '/' + dataId,
        type: 'DELETE',
        success: function (data) {
            console.log('successfully deleted ' + self.endpoint + ' ' + dataId);
            console.log(data);
        },
        error: function (request) {
            console.log('error occured deleting ' + self.endpoint + ' ' + dataId);
            console.log(request.responseText);
        }
    });
}