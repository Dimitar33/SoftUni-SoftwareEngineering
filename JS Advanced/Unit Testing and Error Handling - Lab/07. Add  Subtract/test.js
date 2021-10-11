const { expect } = require(`chai`);
const createCalculator = require('./AddSubtract')

describe(`calculator`, () => {

    let calc = '';
    beforeEach(function() {
         calc = createCalculator();
    });

    it(`has function add`, () => {
        
        expect(Object.keys(calc).includes(`add`)).to.be.true;
    })

    it(`has function subtract`, () => {

        expect(Object.keys(calc).includes(`subtract`)).to.be.true;
    })

    it(`has get`, () => {

        expect(Object.keys(calc).includes(`get`)).to.be.true;
    })

    it(`false on wrong function`, () => {

        expect(Object.keys(calc).includes(`someFunc`)).to.be.false;
    })

    it(`get start at 0`, () => {

        expect(calc.get()).to.equal(0);
    })

    it(`add work correct`, () => {

        calc.add(1);
        expect(calc.get()).to.equal(1);
    })

    it(`subtract work correct`, () => {

        calc.subtract(1);
        expect(calc.get()).to.equal(-1);
    })

    it(`add wrong input`, () => {

        calc.add(`asd`);
        expect(calc.get()).to.be.NaN;
    })

    it(`subtract wrong input`, () => {
        calc.subtract(`asd`);
        expect(calc.get()).to.be.NaN;

    })
})