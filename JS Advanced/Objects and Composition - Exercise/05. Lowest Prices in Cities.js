function main(arr){

    let result = [];

    for (const el of arr) {
        
        let [town, product, price] = el.split(' | ');
        price = Number(price);

        if (!result[product]) {
            
            result[product] = {};
        }
        
        result[product][town] = price;
    }

    for (const key in result) {
      
        let sorted = Object.entries(result[key]).sort((a,b) => a[1] - b[1]);
        console.log(`${key} -> ${sorted[0][1]} (${sorted[0][0]})`);
    }

}

main(['Sample Town | Sample Product | 1000',
'Sofia | Orange | 3',
'Sample Town | Orange | 2',
'Sample Town | Peach | 1',
'Sofia | Peach | 2',
'New York | Sample Product | 1000.1',
'New York | Burger | 10']
);