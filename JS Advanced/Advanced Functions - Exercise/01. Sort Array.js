function main(arr, arg){

    if (arg == `asc`) {
        
        arr.sort((a, b) => a - b);
    }
    else{

        arr.sort((a, b) => b - a);
    }

    return arr;
}

main([14, 7, 17, 6, 8], 'desc');
main([14, 7, 17, 6, 8], 'asc');