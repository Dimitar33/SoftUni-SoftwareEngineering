function main(arr){

    function sorting(a, b){
        return a - b;
    }

    arr.sort(sorting);

    let size = Math.floor(arr.length / 2);

    arr.splice(0, size)

    return arr;
}

main([3, 19, 14, 7, 2, 19, 6]);