function main() {

    let ingridients = {

        carbohydrate: 0,
        flavour: 0,
        fat: 0,
        protein: 0
    };

    let recepies = {

        apple: { carbohydrate: 1, flavour: 2 },
        lemonade: { carbohydrate: 10, flavour: 20 },
        burger: { carbohydrate: 5, fat: 7, flavour: 3 },
        eggs: { protein: 5, fat: 1, flavour: 1 },
        turkey: { protein: 10, carbohydrate: 10, fat: 10, flavour: 10 }
    }

    let message = ``;

    let robot = {

        restock: (args) => {

            let ingrid = args[0];
            let quantity = Number(args[1]);

            ingridients[ingrid] += quantity;
            message = `Success`;
        },

        prepare: (args) => {

            let recepie = args[0];
            let quantity = Number(args[1]);

            let obj = Object.entries(recepies[recepie]);
            let isEnough = true;

            for (const i of obj) {

                let [ingridient, count] = i;

                if (ingridients[ingridient] < count * quantity) {

                    message = (`Error: not enough ${ingridient} in stock`);
                    isEnough = false;
                    break;
                }
            }

            if (isEnough) {
                
                obj.forEach(el => {
                    
                    let [ingridient, count] = el;

                    ingridients[ingridient] -= count * quantity;
                });

                message = `Success`;
            }
        },

        report: () => {

           message = `protein=${ingridients[`protein`]} carbohydrate=${ingridients[`carbohydrate`]} fat=${ingridients[`fat`]} flavour=${ingridients[`flavour`]}`;
        }

    }

    return function manage(str) {

        let [cmd, ...args] = str.split(` `);

        robot[cmd](args);

        return message;
    }

}


let manager = main();
console.log(manager("restock flavour 50")); // Success 
console.log(manager("prepare lemonade 4")); // Error: not enough carbohydrate in stock 
console.log(manager("report")); // Error: not enough carbohydrate in stock 
