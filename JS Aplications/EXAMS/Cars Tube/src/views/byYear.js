import { getAllCars, getByYear } from "../api/data.js";
import { html } from "../util.js";

const searchTemplate = (search, cars) => html`
        <section id="search-cars">
            <h1>Filter by year</h1>

            <div class="container">
                <input id="search-input" type="text" name="search" placeholder="Enter desired production year">
                <button @click=${search} class="button-list">Search</button>
            </div>

            <h2>Results:</h2>
            <div class="listings">
        ${console.log(cars.length)}
                ${cars.length == 0
        ? html`<p class="no-cars"> No results.</p>`
        : html`${cars.map(carTemplate)}`}
                
            </div>
        </section>`;

const carTemplate = (car) => html`
                <div class="listing">
                    <div class="preview">
                        <img src="${car.imageUrl}">
                    </div>
                    <h2>${car.brand} ${car.model}</h2>
                    <div class="info">
                        <div class="data-info">
                            <h3>Year: ${car.year}</h3>
                            <h3>Price: ${car.price} $</h3>
                        </div>
                        <div class="data-buttons">
                            <a href="/details/${car._id}" class="button-carDetails">Details</a>
                        </div>
                    </div>
                </div>`;

export function searchPage(ctx) {

    ctx.render(searchTemplate(search, []));

    async function search() {

        const searchYear = document.getElementById(`search-input`).value;
        const cars = await getByYear(searchYear);

        ctx.render(searchTemplate(search, cars));
    }

}