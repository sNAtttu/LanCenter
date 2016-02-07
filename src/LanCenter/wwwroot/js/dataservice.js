function GetGames(userName, resultCallBack) {
    var games = [];
    $.ajax({
        url: "http://lancenter.azurewebsites.net/api/Games/" + userName

    }).done(function (result) {
        resultCallBack(result);
    });
    return games;
}
function GetFoods(userName, resultCallBack) {
    var foods = [];
    $.ajax({
        url: "http://lancenter.azurewebsites.net/api/FoodOrders/" + userName

    }).done(function (result) {
        resultCallBack(result);
    });
    return foods;
}
function GetGamesByPlayerName(gameName, resultCallBack) {
    var players = [];
    $.ajax({
        url: "http://lancenter.azurewebsites.net/api/GamesCustomController/" + gameName

    }).done(function (result) {
        resultCallBack(result);
    });
    return players;
}