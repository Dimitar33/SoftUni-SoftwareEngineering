function main(arr){

    let result = [];

    for (let i = 0; i < arr.length; i+=2) {
        
        result.push(arr[i]);
    }
    console.log(result.join(" "));
}

main(['20', '30', '40', '50', '60']);