function main(arr) {

    let bottles = {};
    let liters = {};
    
    for (const i of arr) {
        
        let [juice, quantity] = i.split(` => `);
        quantity = Number(quantity);

        if (!liters[juice]) {
            
            liters[juice] = 0;
        }

        liters[juice] += quantity;

      
        while (liters[juice] > 999) {
            
            if (!bottles[juice]) {
                
                bottles[juice] = 0;
            }

            bottles[juice] ++;
            liters[juice] -= 1000;
        }

    }

    return Object.entries(bottles).map(([a,b]) =>`${a} => ${b}`).join(`\n`);
}

console.log(main(['Orange => 2000',
'Peach => 1432',
'Banana => 450',
'Peach => 600',
'Strawberry => 549']))
