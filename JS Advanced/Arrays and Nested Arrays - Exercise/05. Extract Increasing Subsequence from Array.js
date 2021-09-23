function main(arr) {

    let result = [arr[0]];
    let lastElement = arr[0];

    // for (let i = 1; i < arr.length; i++) {

    //     if (lastElement <= arr[i]) {

    //         lastElement = arr[i];
    //         result.push(arr[i]);
    //     }

    // }

    // return result;

    result = arr.filter((x) => {

        if (x >= lastElement) {
            lastElement = x;
            return true
        }
        return false;
    } );

    console.log(result);
}

main([1, 
    3, 
    8, 
    4, 
    10, 
    12, 
    3, 
    2, 
    24]
    
    
    );