$(document).ready(function () {
    activate();
});
var vm = {
    yourGameString: "Pelisi: ",
    playerGames: ko.observableArray(),
    playerFoods: ko.observableArray()
};
function activate() {

    var username = $("#userName").text();
    GetGames(username, function(results) {
        results.forEach(function (game) {
            vm.playerGames.push(game);
        })
    });
    GetFoods(username, function (results) {
        results.forEach(function (food) {
            vm.playerFoods.push(food);
        })
    })
    ko.applyBindings(vm);
}
