function main(arr){

    

    arr.sort(function sorting(a, b){

        if (a.toLowerCase() < b.toLowerCase()) {
            
            return -1;
        }
        return 1;
        
    });

    for (let i = 0; i < arr.length; i++) {
        
        console.log(`${i + 1}.${arr[i]}`)
    }
}

main(["John", "aBob", "AChristina", "Ema"]);