function main(matrix) {

    let result = Number.MIN_SAFE_INTEGER;
    let num = Number.MIN_SAFE_INTEGER;

    for (let i = 0; i < matrix.length; i++) {

        result = Math.max(...matrix[i]);

        if (result > num) {

            num = result
        }
    }

    console.log(num);
} 

main([[-20, -550, 10], [8, -33, -145]]);