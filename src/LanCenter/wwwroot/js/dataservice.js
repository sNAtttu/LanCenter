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