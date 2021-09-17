function main(month, year){

    let days = new Date(year, month, 0).getDate();

    console.log(days);
    
}

main(2, 2012);