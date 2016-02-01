function GetGames(userName, resultCallBack) {
    var games = [];
    $.ajax({
        url: "http://localhost:8000/api/Games/"+userName

    }).done(function (result) {
        resultCallBack(result);
    });
    return games;
}
function GetFoods(userName, resultCallBack) {
    var foods = [];
    $.ajax({
        url: "http://localhost:8000/api/FoodOrders/" + userName

    }).done(function (result) {
        resultCallBack(result);
    });
    return foods;
}
function GetGamesByPlayerName(gameName, resultCallBack) {
    var players = [];
    $.ajax({
        url: "http://localhost:8000/api/GamesCustomController/" + gameName

    }).done(function (result) {
        resultCallBack(result);
    });
    return players;
}