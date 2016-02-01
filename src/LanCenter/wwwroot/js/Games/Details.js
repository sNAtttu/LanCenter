
$(document).ready(function () {
    activate();
});
var vm = {
    players: ko.observableArray(),
    refresh: function () { refreshArray(); }
};
function activate() {

    var gameName = $("#gameName").text();
    GetGamesByPlayerName(gameName, function (results) {
        results.forEach(function (player) {          
            vm.players.push(ko.observable(player));
        })
    });
    ko.applyBindings(vm);
}
function refreshArray() {
    var gameName = $("#gameName").text();
    vm.players = ko.observableArray();
    GetGamesByPlayerName(gameName, function (results) {
        results.forEach(function (player) {
            vm.players.push(ko.observable(player));
            console.log(vm.players()[0]());
        })
    });
}
