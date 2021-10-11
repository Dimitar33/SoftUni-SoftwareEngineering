const { expect } = require(`chai`);
const rgbToHexColor = require(`./RGBToHex`);

describe(`RBG to Hex`, () => {

    it(`red not an int`, () => {

        expect(rgbToHexColor('asd', 12, 32)).to.be.undefined;
    })

    it(`red less than 0`, () => {

        expect(rgbToHexColor(-2, 21, 34)).to.be.undefined;
    })

    it(`red more than 255`, () => {

        expect(rgbToHexColor(2567, 23, 43)).to.be.undefined;
    })

    it(`green not an int`, () => {

        expect(rgbToHexColor(12, `asd`, 32)).to.be.undefined;
    })

    it(`green less than 0`, () => {

        expect(rgbToHexColor(2, -21, 34)).to.be.undefined;
    })

    it(`green more than 255`, () => {

        expect(rgbToHexColor(25, 2333, 43)).to.be.undefined;
    })

    it(`blue not an int`, () => {

        expect(rgbToHexColor(12, 12, `asd`)).to.be.undefined;
    })

    it(`blue less than 0`, () => {

        expect(rgbToHexColor(2, 21, -34)).to.be.undefined;
    })

    it(`blue more than 255`, () => {

        expect(rgbToHexColor(25, 233, 256)).to.be.undefined;
    })
    
    it(`work correctrly`, () => {

        expect(rgbToHexColor(213, 21, 15)).to.equal('#D5150F')
    })

    it('returns white with valid input', () => {
        expect(rgbToHexColor(0, 0, 0)).to.equal('#000000');
    });

    it('returns colors in Hex with valid input', () => {
        expect(rgbToHexColor(255, 158, 170)).to.equal('#FF9EAA');
    });
})