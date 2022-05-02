
window.onload = function parseText() {

    let namesInput = Array.from(document.querySelectorAll("img"));
    let prices = Array.from(document.querySelectorAll('span[style="display: none"]'));
    let ratings = Array.from(document.querySelectorAll('body>div'));

    let names = namesInput.filter(x => x.alt != 'Sold Out');

    let products = [];

    for (let i = 0; i < prices.length; i++) {

        let rating = Number(ratings[i].getAttribute('rating'));
        let quotient = 0;

        if (rating > 5) {

            quotient = Math.ceil(rating / 5);

            rating /= quotient;
        }

        rating = String(rating);
        let price = prices[i].textContent.replace('$', '').replace(',', '');
        let productName = names[i].alt;

        products.push({ productName, price, rating});

    }
    
    console.log(JSON.stringify(products, null, '\t'));
}

