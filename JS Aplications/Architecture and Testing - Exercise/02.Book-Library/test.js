const { expect } = require('chai');
const { chromium } = require('playwright-chromium');

describe('Test', async function () {
    this.timeout(5000);

    let page, browser;

    before(async () => browser = await chromium.launch());

    after(async () => await browser.close());

    beforeEach(async () => page = await browser.newPage());

    afterEach(async () => await page.close());

    it('loads and displays all books', async () => {

        await page.goto('http://localhost:5500');

        await page.click('text=Load All Books');

        expect('tbody').to.not.be.empty;

        // await page.waitForSelector('text=Harry Potter');

        // let rows = await page.$$eval('tr', (x) => x.map(r => r.textContent));

        // expect(rows[1]).to.contains('Harry Potter');
        // expect(rows[1]).to.contains('Rowling');
        // expect(rows[2]).to.contains('C# Fundamentals');
        // expect(rows[2]).to.contains('Nakov');
    });

    it('add book', async () => {

        await page.goto('http://localhost:5500');

        await page.fill('form#createForm >> input[name="title"]', `Test Title`);
        await page.fill('form#createForm >> input[name="author"]', `Test Author`);
        await page.click('form#createForm >> text=Submit');
    });

    it('edit book', async () => {

        await page.goto('http://localhost:5500');

        await page.click('#loadBooks');
        await page.click('.editBtn');

        await page.fill('#editForm >> input[name="title"]', 'Edit Title');
        await page.fill('#editForm >> input[name="author"]', 'Edit Author');
        await page.click('form#editForm >> text=Save');

    });

    it('delete book', async () => {

        await page.goto('http://localhost:5500');

        await page.click('#loadBooks');

        page.on('dialog', (ev) => {
            ev.accept();
        });
        
        await page.click('tbody tr:last-child .deleteBtn');
    })
})