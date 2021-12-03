import { html } from '../../node_modules/lit-html/lit-html.js';
import { bookLikes, deleteBook, details, like } from '../api/data.js';

let count = 0;

const detailsTemplate = (isOwner, isLogedin, book, likes, onDelete, onLike) => html`
        <section id="details-page" class="details">
            <div class="book-information">
                <h3>${book.title}</h3>
                <p class="type">Type: ${book.type}</p>
                <p class="img"><img src="${book.imageUrl}"></p>
                <div class="actions">

                ${detailsNav(isOwner, isLogedin, book, onDelete, onLike)}

                    <div class="likes">
                        <img class="hearts" src="/images/heart.png">
                        <span id="total-likes">Likes: ${likes}</span>
                    </div>
                  
                </div>
            </div>
            <div class="book-description">
                <h3>Description:</h3>
                <p>${book.description}</p>
            </div>
        </section>`;

function detailsNav(isOwner, isLogedin, book, onDelete, onLike) {

    if (isOwner) {
        return html`
        <a class="button" href="/edit/${book._id}">Edit</a>
        <a @click=${onDelete} class="button" href="javascript:void(0)">Delete</a>`;
    }
    if (isLogedin && !isOwner) {

        return html`
        <a @click=${onLike} class="button" href="#">Like</a>`;
    }
}

export async function detailsPage(ctx) {

    const bookId = ctx.params.id;
    const likes = await bookLikes(bookId);
    const book = await details(bookId);
    const isOwner = sessionStorage.getItem(`userId`) == book._ownerId;
    const isLogedin = sessionStorage.getItem(`token`);

    ctx.render(detailsTemplate(isOwner, isLogedin, book, likes, onDelete, onLike));

    async function onDelete(ev) {
        ev.preventDefault();

        const confirmation = confirm(`Are you shure you want to delete the book`);

        if (confirmation && sessionStorage.getItem(`token`)) {

            await deleteBook(bookId);

            ctx.page.redirect(`/`);
        }
    }

    async function onLike(ev) {
        ev.preventDefault();

        await like({bookId});

        ctx.page.redirect(`/details/${bookId}`)
    }

}