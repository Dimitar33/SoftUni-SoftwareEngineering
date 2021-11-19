const { chromium } = require('playwright-chromium');
const { expect } = require('chai');

describe('messenger', function () {
    this.timeout(6000);

    let browser, page;

    before(async () => { browser = await chromium.launch({ headless: false, slowMo: 500 }) });
    after(async () => { await browser.close() });
    beforeEach(async () => { page = await browser.newPage() });
    afterEach(async () => { await page.close() });

    it('load messages', async () => {

        await page.goto('http://localhost:5500');

        await page.click('#refresh');
    })

    it(`send messages`, async () => {

        await page.goto('http://localhost:5500');

        await page.fill('#author', 'Test Author');
        await page.fill('#content', 'Test Content');
        await page.click('#submit');
    });

})