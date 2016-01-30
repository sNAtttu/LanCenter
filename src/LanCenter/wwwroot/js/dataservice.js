function GetGames(userName) {
    console.log(userName);
    var games = [];
    $.ajax({
        url: "http://localhost:8000/api/Games"

    }).done(function (result) {
        console.log(result);
    });
    return games;
}