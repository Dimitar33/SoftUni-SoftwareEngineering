const { expect } = require(`chai`);
const mathEnforcer = require(`./MathEnforcer`);

describe(`Mathh Enforcer object`, () => {

    describe(`AddFive`, () => {

        it(`wronh input type`, () => {

            expect(mathEnforcer.addFive(`1`)).to.be.undefined;
            expect(mathEnforcer.addFive(`asd`)).to.be.undefined;
        })

        it(`work correct`, () => {

            expect(mathEnforcer.addFive(2)).to.equal(7);
            expect(mathEnforcer.addFive(-2)).to.equal(3);
            expect(mathEnforcer.addFive(1.99)).to.be.closeTo(7, 0.01);
            expect(mathEnforcer.addFive(2)).to.be.closeTo(7, 0.01);
        })
    })

    describe(`subtractTen`, () => {

        it(`wrong input type`, () => {

            expect(mathEnforcer.subtractTen(`asd`)).to.be.undefined;
            expect(mathEnforcer.subtractTen(`1`)).to.be.undefined;
        })

        it(`work correct`, () => {

            expect(mathEnforcer.subtractTen(11)).to.equal(1);
            expect(mathEnforcer.subtractTen(-1)).to.equal(-11);
            expect(mathEnforcer.subtractTen(10.99)).to.be.closeTo(1, 0.01);
            expect(mathEnforcer.subtractTen(11)).to.be.closeTo(1, 0.01);
        })
    })

    describe(`sum`, () => {

        it(`wrong input type`, () => {

            expect(mathEnforcer.sum(`asd`, 2)).to.be.undefined;
            expect(mathEnforcer.sum(2, `1`)).to.be.undefined;
            expect(mathEnforcer.sum(`2`, `1`)).to.be.undefined;
        })

        it(`work correct`, () => {

            expect(mathEnforcer.sum(11, 2)).to.equal(13);
            expect(mathEnforcer.sum(-11, 2)).to.equal(-9);
            expect(mathEnforcer.sum(11, -2)).to.equal(9);
            expect(mathEnforcer.sum(-11, -2)).to.equal(-13);
            expect(mathEnforcer.sum(10.99, 3)).to.be.closeTo(14, 0.01);
            expect(mathEnforcer.sum(11, 2.99)).to.be.closeTo(14, 0.01);
        })
    })

})