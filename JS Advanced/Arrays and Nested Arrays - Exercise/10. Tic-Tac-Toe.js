function main(arr) {

    let field = [];
    let xTurn = true;
    let gameOver = false;
    let xWins = false;
    let oWins = false;
    let winer = '';

    for (let i = 0; i < 3; i++) {

        field[i] = [];

        for (let j = 0; j < 3; j++) {

            field[i][j] = 'false';

        }
    }

    for (let i = 0; i < arr.length; i++) {

        let string = arr[i].split(' ');
        let x = Number(string[0]);
        let y = Number(string[1]);

        if (field[x][y] == 'false') {

            if (xTurn) {

                field[x][y] = 'X';
                xTurn = false;
            }
            else {

                field[x][y] = 'O';
                xTurn = true;
            }

            xWins = win(field, 'X');
            oWins = win(field, 'O');

            if (xWins) {

                winer = 'X';
                console.log(`Player X wins!`);
                break;
            }

            if (oWins) {

                winer = 'O';
                console.log(`Player O wins!`);
                break;
            }

            if (boardFull(field)) {

                console.log('The game ended! Nobody wins :(');
                break;
            }

        }
        else {

            console.log('This place is already taken. Please choose another!');
        }

    }

    function win(field, player) {

        if (field[0][0] == player && field[0][1] == player && field[0][2] == player) {

            return true;
        }

        else if (field[1][0] == player && field[1][1] == player && field[1][2] == player) {

            return true;
        }
        else if (field[2][0] == player && field[2][1] == player && field[2][2] == player) {

            return true;
        }

        else if (field[0][0] == player && field[1][0] == player && field[2][0] == player) {

            return true;
        }

        else if (field[1][0] == player && field[1][1] == player && field[1][2] == player) {

            return true;
        }

        else if (field[2][0] == player && field[2][1] == player && field[2][2] == player) {

            return true;
        }

        else if (field[0][0] == player && field[1][1] == player && field[2][2] == player) {

            return true;
        }

        else if (field[2][0] == player && field[1][1] == player && field[0][2] == player) {

            return true;
        }

        return false;
    }

    function boardFull(field) {

        for (let i = 0; i < field.length; i++) {

            for (let j = 0; j < field.length; j++) {

                if (field[i][j] == 'false') {

                    return false;
                }

            }

        }
        return true;
    }


    field.forEach(x => {

        console.log(x.join('\t'));
    });


}

main(["0 1",
"0 0",
"0 2",
"2 0",
"1 0",
"1 2",
"1 1",
"2 1",
"2 2",
"0 0"]


)