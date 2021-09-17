function main(a, b){

    let sum = 0;

    for (let j = Number(a); j <= Number(b); j++) {
        
        sum += Number(j);
    }

    console.log(sum)
}

main('-8', '20');