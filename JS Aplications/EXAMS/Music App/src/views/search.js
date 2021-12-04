import { searchAlbums } from '../api/data.js';
import { html } from '../lib.js';

const searchTemplate = (onSearch, albums) => html`
        <section id="searchPage">
            <h1>Search by Name</h1>

            <div class="search">
                <input id="search-input" type="text" name="search" placeholder="Enter desired albums's name">
                <button @click=${onSearch} class="button-list">Search</button>
            </div>

            <h2>Results:</h2>

            <!--Show after click Search button-->
            <div class="search-result">
              
              
                ${albums.length == 0
                    ? html`<p class="no-result">No result.</p>`
                    : html`${albums.map(albumTemplate)}`}

               
              
            </div>
        </section>`;

const albumTemplate = (album) => html`
        <div class="card-box">
            <img src="${album.imgUrl}">
            <div>
                <div class="text-center">
                    <p class="name">Name: ${album.name}</p>
                    <p class="artist">Artist: ${album.artist}</p>
                    <p class="genre">Genre: ${album.genre}</p>
                    <p class="price">Price: $${album.price}</p>
                    <p class="date">Release Date: ${album.releaseDate}</p>
                </div>
                ${sessionStorage.getItem(`token`)
        ? html`
                    <div class="btn-group">
                        <a href="/details/${album._id}" id="details">Details</a>
                   </div>`
        : null}
                
            </div>
        </div>`;

export function searchPage(ctx) {

    ctx.render(searchTemplate(onSearch, []));

    async function onSearch(ev) {
        ev.preventDefault();

        const searchTerm = document.getElementById(`search-input`).value;

        const albums = await searchAlbums(searchTerm);

        ctx.render(searchTemplate(onSearch, albums));
    }
}