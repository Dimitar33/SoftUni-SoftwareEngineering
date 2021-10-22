const { expect, assert } = require(`chai`);
const pizzUni = require("./PizzaPlace");

describe(`piza place`, () => {

    describe(`makeAnOrder`, () => {

        it(`no pizza ordered`, () => {

            let obj = { orderedDrink: `the name of the drink` };

            expect(() => pizzUni.makeAnOrder(obj)).to.throw();
        })

        it(`order pizza and drink`, () => {

            let obj = { orderedPizza: `Quadro`, orderedDrink: `coke` };

            assert.equal(pizzUni.makeAnOrder(obj), `You just ordered Quadro and coke.`);
        })

        it(`order just pizza`, () => {

            let obj = { orderedPizza: `Quadro` };

            assert.equal(pizzUni.makeAnOrder(obj), `You just ordered Quadro`);
        })
    })

    describe(`getRemainingWork`, () => {

       it(`status redy`, () => {

        let obj = [{ pizzaName: `Quadro`, status: `ready` }];
        
        assert.equal(pizzUni.getRemainingWork(obj), 'All orders are complete!');
       })

       it(`status not redy`, () => {

        let obj = [{ pizzaName: `Quadro`, status: `ready` },{ pizzaName: `Siciliana`, status: `preparing` }];
        
        assert.equal(pizzUni.getRemainingWork(obj), `The following pizzas are still preparing: Siciliana.`);
       })

    })

    describe(`orderType`, () => {

        it(`with discount`, () => {

            expect(pizzUni.orderType(100, `Carry Out`)).to.equal(90);
        })

        it(`no discount`, () => {


            expect(pizzUni.orderType(100, `Delivery`)).to.equal(100);
        })
    })
})