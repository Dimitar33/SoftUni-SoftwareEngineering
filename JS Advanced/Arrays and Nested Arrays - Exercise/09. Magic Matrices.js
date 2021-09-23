function main(matrix) {

    let sum = matrix[0].reduce((a, b) => a + b);

    for (let i = 0; i < matrix.length; i++) {

        if (sum != matrix[i].reduce((a, b) => a + b)) {

            return false;
        }
    }

    for (let i = 0; i < matrix.length; i++) {

        let newSum = 0;

        for (let j = 0; j < matrix.length; j++) {

            newSum += matrix[j][i];
        }
        if (newSum != sum) {

            return false;
        }
    }
    return true;

}

main([[4],
[6, 7, 4],
[5, 5]]
);