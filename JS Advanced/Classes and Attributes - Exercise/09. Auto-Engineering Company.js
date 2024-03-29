function main(arr) {
    
    let cars = {};

    for (const car of arr) {
        
        let [brand, model, count] = car.split(` | `);

        if (!cars[brand]) {
            
            cars[brand] = {};
        }

        if (!cars[brand][model]) {
            
            cars[brand][model] = 0;
        }

        cars[brand][model] += Number(count);
    }

        return Object.entries(cars).map(([a,b]) => `${a}\n${Object.entries(b).map(([c,d]) => `###${c} -> ${d}`).join(`\n`)}`).join(`\n`);
}

console.log(main(['Audi | Q7 | 1000',
'Audi | Q6 | 100',
'BMW | X5 | 1000',
'BMW | X6 | 100',
'Citroen | C4 | 123',
'Volga | GAZ-24 | 1000000',
'Lada | Niva | 1000000',
'Lada | Jigula | 1000000',
'Citroen | C4 | 22',
'Citroen | C5 | 10']
))