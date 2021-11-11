
import { showView , e} from './dom.js';
import { showCreate } from './create.js'
import { showDetails } from './details.js';

let catalog = document.querySelector(`.card-deck.d-flex.justify-content-center`);
let section = document.getElementById(`home-page`);
section.querySelector(`#createLink`).addEventListener(`click`, (ev) => {

    ev.preventDefault();
    showCreate();
});

catalog.addEventListener(`click`, (ev) => {
    ev.preventDefault();

    let target = ev.target;

    if (target.tagName == `BUTTON`) {
        target = target.parentElement;
    }
    if (target.tagName == `A`) {
        
        const id = target.dataset.id;
        showDetails(id);
    }
})

section.remove();

export function showHome() {

    showView(section);
    getMovies();
};

async function getMovies() {
    

    const res = await fetch(`http://localhost:3030/data/movies`);
    const data = await res.json();

    catalog.replaceChildren(...data.map(createMovieCard));
}

function createMovieCard(movie) {

    const element = e(`div`, { className: `card mb-4` });
    element.innerHTML = `
    <img class="card-img-top" src="${movie.img}"
    alt="Card image cap" width="400">
    <div class="card-body">
        <h4 class="card-title">${movie.title}</h4>
    </div>
    <div class="card-footer">
        <a href="#/details/6lOxMFSMkML09wux6sAF">
            <button type="button" class="btn btn-info">Details</button>
        </a>
    </div>`;

    return element;
}

window.getMovies = getMovies;