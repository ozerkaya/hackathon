function createGame() {

    $.ajax({
        type: 'POST',
        url: '/Game/CreateGame',
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            window.location.href = "/Home/Game?GameKey=" + result.gameKey + "&&GamerKey=" + result.gamer1Key;
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert("Sıralama işlemi yapılamadı!");
        }
    });
}

function connectGame() {

    let friendKey = document.getElementById("friendKey").value;

    $.ajax({
        type: 'POST',
        url: '/Game/CreateGame',
        contentType: 'application/json; charset=utf-8',
        success: function (result) {
            window.location.href = "/Home/Game2?GameKey=" + friendKey;
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert("Sıralama işlemi yapılamadı!");
        }
    });
}

function getQuestion() {

    let gameID = document.getElementById("GameKey").value;
    let gamerID = document.getElementById("Gamer1Key").value;

    $.ajax({
        type: 'POST',
        url: '/Questions/GetQuestions',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify({ gameID, gamerID }),
        success: function (result) {

            document.getElementById('soru').innerHTML = result.questionTR;
            document.getElementById('question1').innerHTML = result.choiseA;
            document.getElementById('question2').innerHTML = result.choiseB;
            document.getElementById('question3').innerHTML = result.choiseC;
            document.getElementById('question4').innerHTML = result.choiseD;

            if (result.gamer1Point != undefined) {
                document.getElementById('gamer1Point').innerHTML = result.gamer1Point;
            }
            if (result.gamer1Point != undefined) {
                document.getElementById('gamer2Point').innerHTML = result.gamer2Point;
            }

            document.getElementById("closeModal").click();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert("Sıralama işlemi yapılamadı!");
        }
    });
}

function setQuestion(answer) {

    let gameID = document.getElementById("GameKey").value;
    let gamerID = document.getElementById("Gamer1Key").value;
    let questionNumber = document.getElementById("Gamer1Question").value;

    $.ajax({
        type: 'POST',
        url: '/Questions/SetAnswer',
        contentType: 'application/json; charset=utf-8',
        data: JSON.stringify({ gameID, gamerID, questionNumber, answer }),
        success: function (result) {

            document.getElementById('soru').innerHTML = result.questionTR;
            document.getElementById('question1').innerHTML = result.choiseA;
            document.getElementById('question2').innerHTML = result.choiseB;
            document.getElementById('question3').innerHTML = result.choiseC;
            document.getElementById('question4').innerHTML = result.choiseD;
            document.getElementById('Gamer1Question').value = result.gamer1Question;

            if (result.gamer1Point != undefined) {
                document.getElementById('gamer1Point').innerHTML = result.gamer1Point;
            }
            if (result.gamer1Point != undefined) {
                document.getElementById('gamer2Point').innerHTML = result.gamer2Point;
            }

            document.getElementById("closeModal").click();

        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert("Sıralama işlemi yapılamadı!");
        }
    });
}