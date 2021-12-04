import { deleteAlbum, getDetails } from '../api/data.js';
import {html} from '../lib.js';

const detailsTemplate = (album, onDelete) => html`
        <section id="detailsPage">
            <div class="wrapper">
                <div class="albumCover">
                    <img src="${album.imgUrl}">
                </div>
                <div class="albumInfo">
                    <div class="albumText">

                        <h1>Name: ${album.name}</h1>
                        <h3>Artist: ${album.artist}</h3>
                        <h4>Genre: ${album.genre}</h4>
                        <h4>Price: $${album.price}</h4>
                        <h4>Date: ${album.releaseDate}</h4>
                        <p>Description: ${album.description}</p>
                    </div>

                    ${sessionStorage.getItem(`token`) && sessionStorage.getItem(`userId`) == album._ownerId
                        ? html`
                        <div class="actionBtn">
                             <a href="/edit/${album._id}" class="edit">Edit</a>
                             <a @click=${onDelete} href="javascript:void(0)" class="remove">Delete</a>
                         </div>`
                        : null}
                    
                </div>
            </div>
        </section>`;

export async function detailsPage(ctx){

    const albumId = ctx.params.id;
    const album = await getDetails(albumId);

    ctx.render(detailsTemplate(album, onDelete));

    async function onDelete(ev){
        ev.preventDefault();

        const confirmation = confirm(`Are you shure you want to delte that album`);

        if (confirmation && sessionStorage.getItem(`token`)) {
            
            await deleteAlbum(albumId);
            ctx.page.redirect(`/catalog`);
        }
    }
}