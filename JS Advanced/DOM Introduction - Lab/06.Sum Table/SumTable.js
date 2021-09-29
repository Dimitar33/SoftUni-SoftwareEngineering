function sumTable() {

    let prices = document.querySelectorAll(`table tr`);
    let sum = 0;

    for (let i = 1; i < prices.length - 1; i++) {
        
        sum += Number(prices[i].lastElementChild.textContent);
    }
    console.log(sum);
    prices[prices.length -1].lastElementChild.textContent = sum;
}