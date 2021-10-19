const { expect } = require(`chai`);
const testNumbers = require(`./testNumbers`);

describe(`Test NUmbers`, () => {

    describe(`sumNumbers`, () => {

        it(`whong input type`, () => {

            expect(testNumbers.sumNumbers(`a`, 1)).to.be.undefined;
            expect(testNumbers.sumNumbers(2, `1`)).to.be.undefined;
        })

        it(`work correct`, () => {

            expect(testNumbers.sumNumbers(1,2)).to.equal(`3.00`);
            expect(testNumbers.sumNumbers(-1,2)).to.equal(`1.00`);
            expect(testNumbers.sumNumbers(1,-2)).to.equal(`-1.00`);
            expect(testNumbers.sumNumbers(-1,-2)).to.equal(`-3.00`);
            expect(testNumbers.sumNumbers(1.1212,2)).to.equal(`3.12`);
            expect(testNumbers.sumNumbers(-1.1212,2)).to.equal(`0.88`);
            expect(testNumbers.sumNumbers(1,2.1212)).to.equal('3.12');
        })
    })

    describe(`numberChecker`, () => {

        it(`wrong input type`, () => {

            expect(() => testNumbers.numberChecker(`a`)).to.throw();
        })

        it(`odd num`, () => {

            expect(testNumbers.numberChecker(1)).to.equal(`The number is odd!`)
        })

        it(`even num`, () =>{

            expect(testNumbers.numberChecker(2)).to.equal(`The number is even!`)
        })
    })

    describe(`averageSum`, () => {

        it(`work correct`, () => {

            expect(testNumbers.averageSumArray([1,2,3])).to.equal(2);

        })
    })
})