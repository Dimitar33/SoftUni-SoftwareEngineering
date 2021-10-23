const { expect, assert } = require(`chai`);
const library = require(`./library`);

describe(`library`, () => {

    describe(`calcPriceOfBook`, () => {

        it(`wrong input`, () => {

            expect(() => library.calcPriceOfBook(`asd`, `das`)).to.throw();
            expect(() => library.calcPriceOfBook(21, 21)).to.throw();
            expect(() => library.calcPriceOfBook(12, `das`)).to.throw();
        })

        it(`old book discount`, () => {

            assert.equal(library.calcPriceOfBook(`old Book`, 1221),
            `Price of old Book is 10.00`);
            assert.equal(library.calcPriceOfBook(`old Book`, 1980),
            `Price of old Book is 10.00`);
            
        })

        it(`no discount`, () => {

            assert.equal(library.calcPriceOfBook(`old Book`, 2221),
            `Price of old Book is 20.00`);
            assert.equal(library.calcPriceOfBook(`old Book`, 1981),
            `Price of old Book is 20.00`);
            
        })
    })

    describe(`findBook`, () => {

        it(`empty array`, () => {

            expect(() => library.findBook([], `ook`)).to.throw();
        })

        it(`book found`, () => {

            assert.equal(library.findBook([`myBook`, `Troy`], `myBook`),
            "We found the book you want.");
        })

        it(`book not found`, () => {

            assert.equal(library.findBook([`myBook`, `Troy`], `War`),
            "The book you are looking for is not here!");
        })
    })

    describe(`arrangeTheBooks`, () => {

        it(`wrong input`, () => {

            expect(() => library.arrangeTheBooks(`1`)).to.throw();
            expect(() => library.arrangeTheBooks(-1)).to.throw();
        })

        it(`no room on the shelves`, () => {

            assert.equal(library.arrangeTheBooks(41),
            "Insufficient space, more shelves need to be purchased.");
        })

        it(`enough room on the shelves`, () => {

            assert.equal(library.arrangeTheBooks(40),
            "Great job, the books are arranged.");
            assert.equal(library.arrangeTheBooks(20),
            "Great job, the books are arranged.");
        })
    })
})