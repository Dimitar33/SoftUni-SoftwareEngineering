function main(num){

    let str = num.toString();
    let isSame = true;
    let sum = 0;

    for (let j = 0; j < str.length; j++) {

        sum += Number(str[j]);
    }

    for (let i = 0; i < str.length; i++) {
        
        let firstNum = Number(str[0]); 

        if (firstNum != Number(str[i])) {
            
            isSame = false;
            break;
        }
    }

    console.log(isSame);
    console.log(sum);
}

main(1234);
