function main(arr){

    let result = [];
    let num = Math.min(...arr);
    result.push(num);

   let index = arr.indexOf(num);

    if (index > -1) {
        arr.splice(index, 1);
    }

    num = Math.min(...arr);
    result.push(num);

    console.log(result.join(' '));
}

main([30, 15, 50, 5]);