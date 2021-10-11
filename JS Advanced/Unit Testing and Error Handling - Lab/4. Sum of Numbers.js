function main(arr){

    let sum = 0;

    for (const i of arr) {
        
        sum += Number(i);
    }

    return sum;
}