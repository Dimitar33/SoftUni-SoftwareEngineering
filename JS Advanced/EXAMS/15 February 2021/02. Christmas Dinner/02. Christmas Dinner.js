class ChristmasDinner {

    constructor(budget) {

        if (budget < 0) {

            throw new Error(`The budget cannot be a negative number`);
        }

        this.budget = budget;
        this.dishes = [];
        this.products = [];
        this.guests = {};
    }

    shopping(product) {

        let name = product[0];
        let price = product[1];

        if (this.budget < price) {

            throw new Error(`Not enough money to buy this product`)
        }

        this.products.push(name);
        this.budget -= price;

        return `You have successfully bought ${name}!`;
    }

    recipes(recipe) {

        let prod = Object.keys(recipe[`productsList`]).map(function (key) {

            return recipe[`productsList`][key];
        });

        let isProd = true;

        prod.forEach(p => {

            if (!this.products.includes(p)) {

                isProd = false;

            }
        });

        if (isProd) {

            this.dishes.push(recipe);
            return `${recipe[`recipeName`]} has been successfully cooked!`;
        }

        throw new Error(`We do not have this product`);
    }

    inviteGuests(name, dish) {

        if (!this.dishes.map(x => x[`recipeName`]).includes(dish)) {

            throw new Error(`We do not have this dish`);
        }

        if (!this.guests[name]) {

            this.guests[name] = this.dishes.find(x => x[`recipeName`] == dish);
            return `You have successfully invited ${name}!`
        }

        throw new Error(`This guest has already been invited`);
    }

    showAttendance() {

        let result = ``;

        for (const name in this.guests) {

            result += `${name} will eat ${this.guests[name][`recipeName`]}, which consists of ${this.guests[name].productsList.join(`, `)}\n`;
        }

        return result.trim();
    }
}

let dinner = new ChristmasDinner(300);

dinner.shopping(['Salt', 1]);
dinner.shopping(['Beans', 3]);
dinner.shopping(['Cabbage', 4]);
dinner.shopping(['Rice', 2]);
dinner.shopping(['Savory', 1]);
dinner.shopping(['Peppers', 1]);
dinner.shopping(['Fruits', 40]);
dinner.shopping(['Honey', 10]);

dinner.recipes({
    recipeName: 'Oshav',
    productsList: ['Peppers', 'Honey']
});
dinner.recipes({
    recipeName: 'Folded cabbage leaves filled with rice',
    productsList: ['Cabbage', 'Salt', 'Savory']
});
dinner.recipes({
    recipeName: 'Peppers filled with beans',
    productsList: ['Beans', 'Peppers', 'Salt']
});

dinner.inviteGuests('Ivan', 'Oshav');
dinner.inviteGuests('Petar', 'Folded cabbage leaves filled with rice');
dinner.inviteGuests('Georgi', 'Peppers filled with beans');

console.log(dinner.showAttendance());
