function main(matrix){

    let left = 0;
    let right = 0;

    for (let i = 0; i < matrix.length; i++) {

            left += matrix[i][i];
            right += matrix[i][matrix.length - 1 - i];
    }

    console.log(left, right);
}

main([[3, 5, 17],
      [-1, 7, 14],
      [1, -8, 89]]
);