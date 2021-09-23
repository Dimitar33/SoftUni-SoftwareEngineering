function main(arr) {

    let result = [];

    arr.sort(function (a, b) {
        if (a > b) {
            return 1;
        }
        return -1;
    });

    let len = Math.floor(arr.length / 2);

    for (let i = 0; i < len; i++) {
        
        result.push(arr[i]);
        result.push(arr[arr.length - 1 - i]);
    }

    if (arr.length % 2 != 0) {

        result.push(arr[len]);
    }

    return result;
}

main([1, 65, 3, 52, 48, 63, 31, -3, 18]);