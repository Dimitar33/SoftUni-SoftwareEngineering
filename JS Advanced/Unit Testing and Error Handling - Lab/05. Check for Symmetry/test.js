const { expect } = require(`chai`);
const isSymmetric = require(`./CheckForSymmetry`);

describe(`is it symmetric`, () => {

    it(`incorrect input`, () => {

        expect(isSymmetric(2)).to.equal(false);
    })

    it(`is symmetric`, () => {

        expect(isSymmetric([1,2,1])).to.equal(true);
    })

    it(`it is not symmetric`, () => {

        expect(isSymmetric([1,2,2])).to.be.false;
    })

    it(`str input error`, () => {

        expect(isSymmetric('something')).to.be.false;
    })

    it(`it is symmetric`, () => {

        expect(isSymmetric(['asd', `asd`])).to.be.true;
    })
})