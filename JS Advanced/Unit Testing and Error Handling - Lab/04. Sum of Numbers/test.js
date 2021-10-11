const { expect } = require('chai');
const sum = require('./Sum');

describe('Sum', () => {

    it('single number', () => {

        expect(sum([1])).to.equal(1);
    })

    it('multiple nums', () => {

        expect(sum([1, 1])).to.equal(2);
    })

    it('different nums', () => {

        expect(sum([1, 2, 3])).to.equal(6);
})
})
