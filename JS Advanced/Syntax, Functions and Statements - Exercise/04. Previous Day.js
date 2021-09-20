function main(year, month, day){

    let dateString = `${year} ${month} ${day}`
    let date = new Date(dateString);
    date.setDate(day - 1)

    console.log(`${date.getFullYear()}-${date.getMonth() + 1}-${date.getDate()}`);
}

main(2016, 10, 1);