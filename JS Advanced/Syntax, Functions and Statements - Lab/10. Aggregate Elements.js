function main(array){

    let sum = 0;
    let inverse = 0;
    let str = '';

    for (let i = 0; i < array.length; i++) {
        
        sum += array[i];
        inverse += 1 / array[i];
        str += array[i];
    }

    console.log(sum);
    console.log(inverse);
    console.log(str);
}

main([1, 2, 3]);