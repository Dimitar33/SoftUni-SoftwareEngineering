function main(arr){

    let result = [];

    for (let i = 0; i < arr.length; i++) {
       
        if (arr[i] < 0) {

            result.unshift(arr[i]);
        }
        else{
            result.push(arr[i]);
        }
    }

    result.forEach(element => {
        
        console.log(element);
    });
}

main([3, -2, 0, -1])