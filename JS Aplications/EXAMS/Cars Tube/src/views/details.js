import { deleteCar, getCar } from "../api/data.js";
import { html } from "../util.js";

const detailsTemplate = (car) => html`
        <section id="listing-details">
            <h1>Details</h1>
            <div class="details-info">
                <img src="${car.imageUrl}">
                <hr>
                <ul class="listing-props">
                    <li><span>Brand:</span>${car.brand}</li>
                    <li><span>Model:</span>${car.model}</li>
                    <li><span>Year:</span>${car.year}</li>
                    <li><span>Price:</span>${car.price}$</li>
                </ul>

                <p class="description-para">${car.description}</p>

                ${sessionStorage.getItem(`userId`) == car._ownerId
                    ? html`
                    <div class="listings-buttons">
                         <a href="/edit/${car._id}" class="button-list">Edit</a>
                         <a id="delBtn" href="javascript:void(0)" class="button-list">Delete</a>
                   </div>`
                    : null}
                
            </div>
        </section>`;

export async function detailsPage(ctx){

    const id = ctx.params.id;
    const car = await getCar(id);

    console.log(car)
    ctx.render(detailsTemplate(car));

    document.getElementById(`delBtn`).addEventListener(`click`, async () => {
        
        const confirmation = confirm(`Are you shure you want to delete the car`);

        if (sessionStorage.getItem(`token`) && confirmation) {
            
            await deleteCar(id);
            ctx.page.redirect(`/catalog`);
        }
    })
}