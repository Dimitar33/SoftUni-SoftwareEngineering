function main(arr, rotations){

    let temp ;

      
        for (let j = 0; j < rotations; j++) {
            
           temp = arr.pop();
           arr.unshift(temp);
        }

    console.log(arr.join(' '));
}

main(['Banana', 
'Orange', 
'Coconut', 
'Apple'], 
15
);