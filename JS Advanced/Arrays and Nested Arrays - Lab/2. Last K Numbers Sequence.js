function main(len, k) {

    let arr = [1];


    for (let i = 0; i < len - 1; i++) {

        let num = 0;

        for (let j = 0; j < k; j++) {

            if ((arr.length - 1 - j) >= 0) {

                num += arr[arr.length - 1 - j];
            }
        }

        arr.push(num);
    }

    return arr
}

main(8, 2);