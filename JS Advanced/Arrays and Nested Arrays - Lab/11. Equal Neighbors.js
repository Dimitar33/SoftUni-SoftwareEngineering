function main(matrix){

    let count = 0;

    for (let i = 0; i < matrix.length ; i++) {
        
        for (let j = 0; j < matrix[i].length ; j++) {
           
            if (!(j + 1 >= matrix[i].length)) {
                
                if (matrix[i][j] == matrix[i][j + 1]) {
                    
                    count++;
                }
            }

            
            if (!(i + 1 >= matrix.length)) {

                if (matrix[i][j] == matrix[i + 1][j]) {
                
                    count ++;
                }
            }
        }
    }

    console.log(count);

}

// main([['3', '3', '4', '7', '0'],
//       ['4', '0', '5', '3', '4'],
//       ['2', '3', '5', '5', '2'],
//       ['9', '8', '7', '5', '4']]
// );

// main([['test', 'yes', 'yo', 'ho'],
// ['well', 'done', 'yo', '6'],
// ['not', 'done', 'yet', '5']]
// );

main([['2', '2', '5', '7', '4'],
      ['4', '0', '5', '3', '4'],
      ['2', '5', '5', '4', '2']]);
