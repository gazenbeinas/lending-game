﻿$(document).ready(function () {

    loadFriends();

    function loadFriends() {
        $.ajax({
            type: "GET",
            url: "/api/game/",
            success: function (responseData) {
                var html = "";

                $.each(responseData, function (_, value) {

                    html += "<tr>";

                    html += '<td>' + value.id + '</td>';
                    html += '<td>' + value.name + '</td>';
                    html += '<td>' + (value.isBorrowed === true ? "Sim" : "Não") + '</td>';

                    html += '<td>';
                    html += '<a href="/game/Edit/' + value.id + '">Editar</a> | ';
                    html += '<a href="/game/Details/' + value.id + '">Detalhes</a> | ';
                    html += '<a href="/game/Delete/' + value.id + '">Deletar</a>';

                    html += "</td>";

                    html += "</tr>";
                });

                $("#tableGames").html(html);
            },
            error: function (e) {
                alert("Ocorreu um erro, verifique e tente novamente");
            }
        });
    }
});

function DeleteGame(gameId, gameTitle) {
    if (confirm('Deseja excluir o jogo ' + gameTitle + '?')) {
        window.location = '/Game/Delete/' + gameId;
    }
}