const { expect } = require(`chai`);
const isOddOrEven = require(`./EvenOrOdd`);

describe(`even or odd ?`, () => {

    it(`wrong input`, () => {

        expect(isOddOrEven(12)).to.be.undefined;
    })

    it(`even work correct`, () => {

        expect(isOddOrEven(`asda`)).to.equal(`even`);
    })

    it(`odd work correct`, () => {

        expect(isOddOrEven(`asd`)).to.equal(`odd`);
    })
})