const { expect } = require(`chai`);
const lookupChar = require(`./CharLookup`);

describe(`Char Lookup`, () => {

    it(`invalid index type`, () => {

        expect(lookupChar(`asd`, `2`)).to.be.undefined;
        expect(lookupChar(`asd`, 1.2)).to.be.undefined;
    })

    it(`invlaid index value`, () => {

        expect(lookupChar(`asd`, 4)).to.equal(`Incorrect index`)
        expect(lookupChar(`asd`, -4)).to.equal(`Incorrect index`)
    })

    it(`invalid string input`, () => {

        expect(lookupChar(123, 1)).to.be.undefined;
    })

    it(`work correct`, () => {

        expect(lookupChar(`asd`, 0)).to.equal(`a`)
        expect(lookupChar(`asd`, 1)).to.equal(`s`)
        expect(lookupChar(`asd`, 2)).to.equal(`d`)
    })
})