function main(arr) {

    arr.sort((a, b) => a.localeCompare(b));
    let marker = '';

    for (const item of arr) {

        if (marker != item[0].toUpperCase()) {

           console.log(marker = item[0].toUpperCase());
        }
        let [prod, price] = item.split(' : ');
        price = Number(price);

        console.log(`${prod}: ${price}`)
    }
}

main(['Appricot : 20.4',
    'Fridge : 1500',
    'TV : 1499',
    'Deodorant : 10',
    'Boiler : 300',
    'Apple : 1.25',
    'Anti-Bug Spray : 15',
    'T-Shirt : 10']
);