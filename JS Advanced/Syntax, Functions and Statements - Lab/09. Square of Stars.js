function main(size) {


    let result = '';

    for (let j = 0; j < size; j++) {


        result += String('* ');

    }
    for (let i = 0; i < size; i++) {

        console.log(result);
    }
}

main(4);