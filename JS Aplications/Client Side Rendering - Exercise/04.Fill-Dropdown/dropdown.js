
import { html, render } from './node_modules/lit-html/lit-html.js';

const url = `http://localhost:3030/jsonstore/advanced/dropdown`;

const menu = document.getElementById(`menu`);
const optionElement = (option) => html`<option value="${option._id}">${option.text}</option>`;

const form = document.querySelector(`form`);

loadOptions();


form.addEventListener(`submit`, async (ev) => {
    ev.preventDefault();

    const input = document.getElementById(`itemText`).value;

    let asd = {

        text: input
    };

    if (input) {

        let res = await fetch(url, {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ _id: asd._id, text: asd.text })
        });

        if (!res.ok) {
            let err = await res.json();
            return alert(err.message);
        };

        loadOptions();
    }
})


function loadOptions() {

    fetch(url)
        .then(x => x.json())
        .then(x => {

            let obj = Object.values(x);
            render(html`${obj.map(optionElement)}`, menu);
        });
}