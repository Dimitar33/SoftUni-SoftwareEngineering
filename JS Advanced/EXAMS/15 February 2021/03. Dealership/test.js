const { expect, assert } = require(`chai`);
const dealership = require(`./dealership`);

describe(`dealership`, () => {

    describe(`newCarCost`, () => {

        it(`wrong input`, () => {

            expect(dealership.newCarCost('Audi A4 B8', `asd`,)).to.be.NaN;
        })

        it(`work correct`, () => {

            expect(dealership.newCarCost('Audi A4 B8', 20000,)).to.equal(5000);
            expect(dealership.newCarCost('Audi A6 4K', 40000,)).to.equal(20000);
            expect(dealership.newCarCost('Audi A8 D5', 33000,)).to.equal(8000);
            expect(dealership.newCarCost('Audi TT 8J', 20000,)).to.equal(6000);
        })

        it(`no discount`, () => {

            expect(dealership.newCarCost(`BMW`, 20000)).to.equal(20000);
        })
    })

    describe(`carEquipment`, () => {

        it(`work correct`, () => {

            expect(dealership.carEquipment([`a`, `b`, `s`], [1, 2])).to.eql([`b`, `s`]);
            expect(dealership.carEquipment([`a`, `b`, `s`], [1])).to.eql([`b`]);
        })
    })

    describe(`euroCategory`, () => {

        it(`category discount`, () => {

            assert.equal(dealership.euroCategory(4),
                'We have added 5% discount to the final price: 14250.');
            assert.equal(dealership.euroCategory(123),
                'We have added 5% discount to the final price: 14250.');
        })
        it(`no cat discount`, () => {

            assert.equal(dealership.euroCategory(2),
                `Your euro category is low, so there is no discount from the final price!`);
        })
    })
})