class Restaurant {
  
    constructor(budgetMoney) {

        this.budgetMoney = Number(budgetMoney);
        this.menu = {};
        this.stockProducts = {};
        this.history = [];
    }

    loadProducts(products) {

        for (const i of products) {

            let [name, quantity, price] = i.split(` `);
            price = Number(price);

            let note = `There was not enough money to load ${quantity} ${name}`;

            if (this.budgetMoney >= price) {

                if (!this.stockProducts[name]) {

                    this.stockProducts[name] = 0;
                }
                this.stockProducts[name] += Number(quantity);
                this.budgetMoney -= price;
                note = `Successfully loaded ${quantity} ${name}`
            }
            this.history.push(note);
        }

        return this.history.join(`\n`);
    }

    addToMenu(meal, neededProducts, price) {

        let message = `The ${meal} is already in the our menu, try something different.`;

        if (!this.menu[meal]) {

            this.menu[meal] = { products: {}, price: price };

            for (const i of neededProducts) {
                let [name, count] = i.split(` `);

                this.menu[meal]['products'][name] = Number(count);
            }

            let mealsCount = Object.keys(this.menu).length;
            if (mealsCount == 1) {

                message = `Great idea! Now with the ${meal} we have 1 meal in the menu, other ideas?`;
            }
            else {
                message = `Great idea! Now with the ${meal} we have ${mealsCount} meals in the menu, other ideas?`;
            }
        }

        return message;
    }

    showTheMenu() {

        if (Object.keys(this.menu).length == 0) {
            
            return `Our menu is not ready yet, please come later...`
        }
        let result = ``;

        for (const i in this.menu) {

            result += `${i} - $ ${this.menu[i]['price']}\n`
        }

        return result.trimEnd();
    }

    makeTheOrder(meal) {

        if (!this.menu[meal]) {

            return `There is not ${meal} yet in our menu, do you want to order something else?`;
        }

        let neededProducts = this.menu[meal].products;

        for (const key in neededProducts) {

            if (!this.stockProducts[key]) {
                
                return `For the time being, we cannot complete your order (${meal}), we are very sorry`;
            }
            
            if (this.stockProducts[key].quantity < neededProducts[key].count) {

                return `For the time being, we cannot complete your order (${meal}), we are very sorry`;
            }
        }

        for (const key in neededProducts) {

            this.stockProducts[key] -= neededProducts[key];

        }
        this.budgetMoney += this.menu[meal].price;
        
        return `Your order (${meal}) will be completed in the next 30 minutes and will cost you ${this.menu[meal].price}.`;
    }


}



let kitchen = new Restaurant(1000);
console.log(kitchen.loadProducts(['Banana 10 5', 'Banana 20 10', 'Strawberries 50 30', 'Yogurt 10 10', 'Yogurt 500 1500', 'Honey 5 50']));

console.log(kitchen.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99));
console.log(kitchen.addToMenu('Pizza', ['Flour 0.5', 'Oil 0.2', 'Yeast 0.5', 'Salt 0.1', 'Sugar 0.1', 'Tomato sauce 0.5', 'Pepperoni 1', 'Cheese 1.5'], 15.55));

console.log(kitchen.showTheMenu());

kitchen.loadProducts(['Yogurt 30 3', 'Honey 50 4', 'Strawberries 20 10', 'Banana 5 1']);
kitchen.addToMenu('frozenYogurt', ['Yogurt 1', 'Honey 1', 'Banana 1', 'Strawberries 10'], 9.99);
console.log(kitchen.makeTheOrder('frozenYogurt'));


