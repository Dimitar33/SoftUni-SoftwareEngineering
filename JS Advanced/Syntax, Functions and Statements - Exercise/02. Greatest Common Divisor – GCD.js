function main(num1 , num2){

    let smalestNum = 0;

    if (num1 > num2) {
        smalestNum = num2
    }
    else{
        smalestNum = num1
    }
    
    let divizor = 0;

    for (let i = smalestNum; i >= 1; i--) {

        if (num1 % i == 0 && num2 % i == 0) {

            divizor = i;

            break;
        }
    }

    console.log(divizor);
}

main(2154, 458);