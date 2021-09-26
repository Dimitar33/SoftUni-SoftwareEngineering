function main(arr) {

    let nums = [];

    for (let i = 0; i < arr.length; i++) {

        if (Number(arr[i])) {

            nums.push(arr[i])
        }
        else {

            if (nums.length < 2) {

                console.log(`Error: not enough operands!`);
                return;
            }

            let x = nums.pop();
            let y = nums.pop();
            let result = Number;

            switch (arr[i]) {

                case `+`:  result = y + x; break;
                case `-`:  result = y - x; break;
                case `/`:  result = y / x; break;
                case `*`:  result = y * x; break;

                default:
                    break;
            }


            nums.push(result);
        }
    }

    if (nums.length == 1) {

        console.log(nums[0])
    }
    else {

        console.log(`Error: too many operands!`);
    }
}

main([5,
    3,
    4,
    '*',
    '-']

);