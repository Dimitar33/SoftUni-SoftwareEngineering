function main(arg) {

    let funcCount = 0;
    let numCount = 0;
    let strCount = 0;

    if (typeof arg === `string`) {

        console.log(`${typeof arg}: ${arg}`);
        strCount++;
    }

    else if (typeof arg === `number`) {

        console.log(`${typeof arg}: ${arg}`);
        numCount++;
    }

    else if (typeof arg === `function`) {

        console.log(`${typeof arg}: ${arg}`);
        funcCount++;
    }

}

main(`false`);