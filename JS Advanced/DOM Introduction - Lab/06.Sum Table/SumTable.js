function sumTable() {

    let prices = document.querySelectorAll(`td`);
    let sum = 0;

    for (let i = 1; i < prices.length - 1; i+=2) {
        
        sum += prices[i].value;
    }
    console.log(sum);
    prices[prices.length -1].value = sum;
}